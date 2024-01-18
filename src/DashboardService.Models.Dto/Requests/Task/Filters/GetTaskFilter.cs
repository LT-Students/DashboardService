using Microsoft.AspNetCore.Mvc;

namespace LT.DigitalOffice.DashboardService.Models.Dto.Requests.Task.Filters;

public record GetTaskFilter
{
  [FromQuery(Name = "includetasktype")]
  public bool IncludeTaskType { get; set; } = true;
  
  [FromQuery(Name = "includepriority")]
  public bool IncludePriority { get; set; } = true;
  
  [FromQuery(Name = "includecomments")]
  public bool IncludeComments { get; set; } = true;
  
  [FromQuery(Name = "includelogs")]
  public bool IncludeLogs { get; set; }
}