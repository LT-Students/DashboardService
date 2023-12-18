using LT.DigitalOffice.Kernel.Requests;
using Microsoft.AspNetCore.Mvc;

namespace LT.DigitalOffice.DashboardService.Models.Dto.Requests.Priority.Filters;

public record GetPrioritiesFilter : BaseFindFilter
{
  [FromQuery(Name = "isAscendingSort")]
  public bool? IsAscendingSort { get; set; }

  [FromQuery(Name = "nameIncludeSubstring")]
  public string NameIncludeSubstring { get; set; }
}