using System;

namespace LT.DigitalOffice.DashboardService.Models.Dto.Requests.Task;

public record EditTaskRequest
{
  /// <summary>
  /// New task type identifier.
  /// </summary>
  public Guid? TaskTypeId { get; set; }
  
  /// <summary>
  /// New priority identifier.
  /// </summary>
  public Guid? PriorityId { get; set; }
  
  /// <summary>
  /// New task name.
  /// </summary>
  public string Name { get; set; }
  
  /// <summary>
  /// New task content.
  /// </summary>
  public string Content { get; set; }
  
  /// <summary>
  /// New task deadline.
  /// </summary>
  public DateTime? DeadlineAtUtc { get; set; }
}