using Microsoft.AspNetCore.Mvc;

namespace LT.DigitalOffice.DashboardService.Models.Dto.Requests.ChangeLog.Filter;

public record GetChangeLogFilter
{
  [FromQuery(Name = "includetask")]
  public bool IncludeTask { get; set; } = false;
}
