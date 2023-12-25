using Microsoft.AspNetCore.Mvc;

namespace LT.DigitalOffice.DashboardService.Models.Dto.Requests.Board.Filters;

public record GetBoardFilter
{
  [FromQuery(Name = "includegroup")]
  public bool IncludeGroup { get; set; } = true;
}
