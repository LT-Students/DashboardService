using Microsoft.AspNetCore.Mvc;

namespace LT.DigitalOffice.DashboardService.Models.Dto.Requests.Task.Filters;

public record GetTaskFilter
{
  // TODO: Wait for groups implementation
  //[FromQuery(Name = "includegroup")]
  //public bool IncludeGroup { get; set; } = true;

  [FromQuery(Name = "includetasktype")]
  public bool IncludeTaskType { get; set; } = true;
  
  [FromQuery(Name = "includepriority")]
  public bool IncludePriority { get; set; } = true;
  
  [FromQuery(Name = "includecomments")]
  public bool IncludeComments { get; set; } = true;
  
  [FromQuery(Name = "includelogs")]
  public bool IncludeLogs { get; set; }
}