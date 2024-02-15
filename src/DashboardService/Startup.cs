using AspNetCoreRateLimit;
using DigitalOffice.Kernel.Configurations;
using DigitalOffice.Kernel.OpenApi.SchemaFilters;
using HealthChecks.UI.Client;
using LT.DigitalOffice.DashboardService.Broker;
using LT.DigitalOffice.DashboardService.Data.Provider.MsSql.Ef;
using LT.DigitalOffice.DashboardService.Models.Dto.Responses;
using LT.DigitalOffice.Kernel.BrokerSupport.Configurations;
using LT.DigitalOffice.Kernel.BrokerSupport.Extensions;
using LT.DigitalOffice.Kernel.BrokerSupport.Middlewares.Token;
using LT.DigitalOffice.Kernel.Configurations;
using LT.DigitalOffice.Kernel.EFSupport.Extensions;
using LT.DigitalOffice.Kernel.EFSupport.Helpers;
using LT.DigitalOffice.Kernel.Extensions;
using LT.DigitalOffice.Kernel.Middlewares.ApiInformation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Json.Serialization;

namespace LT.DigitalOffice.DashboardService;

public class Startup : BaseApiInfo
{
  public const string CorsPolicyName = "LtDoCorsPolicy";

  private readonly RabbitMqConfig _rabbitMqConfig;
  private readonly BaseServiceInfoConfig _serviceInfoConfig;
  private readonly SwaggerConfiguration _swaggerConfiguration;

  public IConfiguration Configuration { get; }

  public Startup(IConfiguration configuration)
  {
    Configuration = configuration;

    _rabbitMqConfig = Configuration
      .GetSection(BaseRabbitMqConfig.SectionName)
      .Get<RabbitMqConfig>();

    _serviceInfoConfig = Configuration
      .GetSection(BaseServiceInfoConfig.SectionName)
      .Get<BaseServiceInfoConfig>();
    
    _swaggerConfiguration = Configuration
      .GetSection(SwaggerConfiguration.SectionName)
      .Get<SwaggerConfiguration>() ?? new();

    Version = "1.0";
    Description = "DashboardService is an API intended to work with dashboards";
    StartTime = DateTime.UtcNow;
    ApiName = $"LT Digital Office - {_serviceInfoConfig.Name}";
  }
  
  public void ConfigureServices(IServiceCollection services)
  {
    services.AddCors(options =>
    {
      options.AddPolicy(
        CorsPolicyName,
        builder =>
        {
          builder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
    });

    services.Configure<TokenConfiguration>(Configuration.GetSection("CheckTokenMiddleware"));
    services.Configure<BaseRabbitMqConfig>(Configuration.GetSection(BaseRabbitMqConfig.SectionName));
    services.Configure<BaseServiceInfoConfig>(Configuration.GetSection(BaseServiceInfoConfig.SectionName));

    services.AddHttpContextAccessor();
    services
      .AddControllers()
      .AddJsonOptions(options =>
      {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
      })
      .AddNewtonsoftJson(options =>
      {
        options.SerializerSettings.DateParseHandling = DateParseHandling.None;
      });

    string connStr = ConnectionStringHandler.Get(Configuration);
    
    services.AddDbContext<DashboardServiceDbContext>(options =>
    {
      options.UseSqlServer(connStr);
    });

    services.AddBusinessObjects();

    services.ConfigureMassTransit(_rabbitMqConfig);
    
    services.AddSwaggerGen(options =>
    {
      options.SwaggerDoc($"{Version}", new OpenApiInfo
      {
        Version = Version,
        Title = _serviceInfoConfig.Name,
        Description = Description
      });

      string controllersXmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
      string modelsXmlFileName = $"{Assembly.GetAssembly(typeof(TaskResponse)).GetName().Name}.xml";

      options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, controllersXmlFileName));
      options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, modelsXmlFileName));

      options.EnableAnnotations();

      options.SchemaFilter<JsonPatchDocumentSchemaFilter>();
    });

    services.AddMemoryCache();

    services.Configure<IpRateLimitOptions>(options =>
      Configuration.GetSection("IpRateLimitingSettings").Bind(options));

    services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

    services.AddInMemoryRateLimiting();

    services
      .AddHealthChecks()
      .AddSqlServer(connStr)
      .AddRabbitMqCheck();
  }

  public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
  {
    app.UpdateDatabase<DashboardServiceDbContext>();

    app.UseForwardedHeaders();

    app.UseExceptionsHandler(loggerFactory);

    app.UseApiInformation();

    app.UseRouting();
    
    string backendUrl = $"{Environment.GetEnvironmentVariable("BaseDomain")}{_swaggerConfiguration.ServicePath}";
    app.UseSwagger(options =>
    {
      options.PreSerializeFilters.Add((swagger, httpReq) =>
      {
        swagger.Servers = new List<OpenApiServer> { new OpenApiServer { Url = backendUrl } };
      });
    })
    .UseSwaggerUI(options =>
    {
      options.SwaggerEndpoint($"{_swaggerConfiguration.ServicePath}/swagger/{Version}/swagger.json", $"{Version}");
    });

    app.UseMiddleware<TokenMiddleware>();

    app.UseCors(CorsPolicyName);

    app.UseIpRateLimiting();

    app.UseEndpoints(endpoints =>
    {
      endpoints.MapControllers().RequireCors(CorsPolicyName);

      endpoints.MapHealthChecks($"/hc", new HealthCheckOptions
      {
        ResultStatusCodes = new Dictionary<HealthStatus, int>
        {
          { HealthStatus.Unhealthy, 200 },
          { HealthStatus.Healthy, 200 },
          { HealthStatus.Degraded, 200 },
        },
        Predicate = check => check.Name != "masstransit-bus",
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
      });
    });
  }
}
