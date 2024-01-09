using LT.DigitalOffice.Kernel.Requests;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LT.DigitalOffice.DashboardService.Models.Dto.Requests.ChangeLog.Filter;

public record GetChangeLogsFilter : BaseFindFilter
{
  [FromQuery]
  public Guid? TaskId { get; set; }

  [FromQuery(Name = "isAscendingSortByCreatedAtUtc")]
  public bool? IsAscendingSortByCreatedAtUtc { get; set; } = false;

  [FromQuery(Name = "isAscendingSortByEntityName")]
  public bool? IsAscendingSortByEntityName { get; set; }

  [FromQuery(Name = "entityNameIncludeSubstring")]
  public string EntityNameIncludeSubstring { get; set; }

  [FromQuery(Name = "propertyNameIncludeSubstring")]
  public string PropertyNameIncludeSubstring { get; set; }
}
