using LT.DigitalOffice.Kernel.Requests;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LT.DigitalOffice.DashboardService.Models.Dto.Requests.ChangeLog.Filter;

public record GetChangeLogsFilter : BaseFindFilter
{
  [FromQuery]
  public Guid? TaskId { get; set; }

  [FromQuery]
  public DateTime? LastDateTime { get; set; }

  [FromQuery(Name = "isAscendingSort")]
  public bool? IsAscendingSort { get; set; }

  [FromQuery(Name = "nameIncludeSubstring")]
  public string NameIncludeSubstring { get; set; }
}
