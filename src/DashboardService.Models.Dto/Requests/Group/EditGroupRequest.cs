using System;

namespace LT.DigitalOffice.DashboardService.Models.Dto.Requests.Group;

public record EditGroupRequest
{
  /// <summary>
  /// Unique board identifier.
  /// </summary>
  public Guid BoardId { get; set; }
  
  /// <summary>
  /// New group name.
  /// </summary>
  public string Name { get; set; }
  
  /// <summary>
  /// New group activity.
  /// </summary>
  public bool IsActive { get; set; }
}