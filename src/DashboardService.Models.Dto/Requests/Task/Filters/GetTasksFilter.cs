using LT.DigitalOffice.Kernel.Requests;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LT.DigitalOffice.DashboardService.Models.Dto.Requests.Task.Filters;

public record GetTasksFilter : BaseFindFilter
{
  [FromQuery]
  public Guid? GroupId { get; set; }
  
  [FromQuery(Name = "isAscendingSort")]
  public bool? IsAscendingSort { get; set; }

  [FromQuery(Name = "nameIncludeSubstring")]
  public string NameIncludeSubstring { get; set; }
}