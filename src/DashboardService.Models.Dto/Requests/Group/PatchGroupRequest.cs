﻿using System;

namespace LT.DigitalOffice.DashboardService.Models.Dto.Requests.Group;

public record PatchGroupRequest
{
  public Guid BoardId { get; set; }
  public string GroupName { get; set; }
  public bool GroupIsActive { get; set; }
  public Guid? GroupModifiedBy { get; set; }
}