using Microsoft.AspNetCore.Mvc;
using System;

namespace LT.DigitalOffice.DashboardService.Models.Dto.Requests.ChangeLog.Filter;

public class GetChangeLogFilter
{
  [FromQuery(Name = "includetask")]
  public bool IncludeTask { get; set; } = true;
}
