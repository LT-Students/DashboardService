using LT.DigitalOffice.Kernel.Requests;
using Microsoft.AspNetCore.Mvc;

namespace LT.DigitalOffice.DashboardService.Models.Dto.Requests.Board.Filters;

public record GetBoardsFilter : BaseFindFilter
{
  [FromQuery(Name = "isAscendingSort")]
  public bool? IsAscendingSort { get; set; }

  [FromQuery(Name = "nameIncludeSubstring")]
  public string NameIncludeSubstring { get; set; }
}
