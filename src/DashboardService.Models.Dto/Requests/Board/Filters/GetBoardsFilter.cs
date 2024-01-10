using LT.DigitalOffice.Kernel.Requests;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LT.DigitalOffice.DashboardService.Models.Dto.Requests.Board.Filters;

public record GetBoardsFilter : BaseFindFilter
{
  [FromQuery(Name = "projectId")]
  public Guid? ProjectId { get; set; }

  [FromQuery(Name = "isAscendingSort")]
  public bool? IsAscendingSort { get; set; }

  [FromQuery(Name = "isActive")]
  public bool? IsActive { get; set; }

  [FromQuery(Name = "nameIncludeSubstring")]
  public string NameIncludeSubstring { get; set; }
}
