using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using System;
using System.Collections.Generic;

namespace LT.DigitalOffice.DashboardService.Models.Dto.Responses;

public class BoardResponse
{
  public Guid Id { get; set; }

  public Guid ProjectId { get; set; }

  public string Name { get; set; }

  public bool IsActive { get; set; }

  public List<GroupInfo> Groups {get; set;}
}
