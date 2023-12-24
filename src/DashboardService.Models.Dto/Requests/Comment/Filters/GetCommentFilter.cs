using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LT.DigitalOffice.DashboardService.Models.Dto.Requests.Comment.Filters;
public class GetCommentFilter
{
  [FromQuery(Name = "includetask")]
  public bool IncludeTask { get; set; } = true;

  [FromQuery(Name = "includelogs")]
  public bool IncludeLogs { get; set; }
}
