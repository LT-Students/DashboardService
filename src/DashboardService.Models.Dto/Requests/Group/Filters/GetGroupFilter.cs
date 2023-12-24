using LT.DigitalOffice.Kernel.Requests;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LT.DigitalOffice.DashboardService.Models.Dto.Requests.Group.Filters;
public record GetGroupFilter : BaseFindFilter
{
  [FromQuery(Name = "includeboard")]
  public bool IncludeBoard { get; set; } = true;

  [FromQuery(Name = "includelogs")]
  public bool IncludeLogs { get; set; }
}
