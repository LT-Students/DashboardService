using System;

namespace LT.DigitalOffice.DashboardService.Models.Dto.Requests.Group;

public record CreateGroupRequest
{
  /// <summary>
  /// Unique board identifier.
  /// </summary>
  public Guid BoardId { get; set; }
  
  /// <summary>
  /// Group name.
  /// </summary>
  public string Name { get; set; }
  
  /// <summary>
  /// Group activity.
  /// </summary>
  public bool IsActive { get; set; } = true;
}