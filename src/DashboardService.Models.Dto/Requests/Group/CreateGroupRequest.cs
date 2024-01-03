using System;

namespace LT.DigitalOffice.DashboardService.Models.Dto.Requests.Group;

public record CreateGroupRequest
{
  public Guid BoardId { get; set; }
  public string Name { get; set; }
  public bool IsActive { get; set; } = true;
}