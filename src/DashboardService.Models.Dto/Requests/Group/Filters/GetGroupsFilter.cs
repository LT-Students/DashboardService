using LT.DigitalOffice.Kernel.Requests;
using Microsoft.AspNetCore.Mvc;

namespace LT.DigitalOffice.DashboardService.Models.Dto.Requests.Group.Filters;

public record GetGroupsFilter : BaseFindFilter
{
  [FromQuery(Name = "isAscendingSort")]
  public bool? IsAscendingSort { get; set; }

  [FromQuery(Name = "isActive")]
  public bool? IsActive { get; set; }

  [FromQuery(Name = "nameIncludeSubstring")]
  public string NameIncludeSubstring { get; set; }
}
