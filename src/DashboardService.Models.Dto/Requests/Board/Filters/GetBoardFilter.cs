using Microsoft.AspNetCore.Mvc;

namespace LT.DigitalOffice.DashboardService.Models.Dto.Requests.Board.Filters;

public record GetBoardFilter
{
  [FromQuery(Name = "includegroups")]
  public bool IncludeGroups { get; set; } = true;
}
