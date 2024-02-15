using System;
using System.ComponentModel.DataAnnotations;

namespace LT.DigitalOffice.DashboardService.Models.Dto.Requests.Task;

public record CreateTaskRequest
{
  /// <summary>
  /// Unique group identifier.
  /// </summary>
  public Guid GroupId { get; set; }
  
  /// <summary>
  /// Unique task type identifier.
  /// </summary>
  public Guid? TaskTypeId { get; set; }
  
  /// <summary>
  /// Unique priority identifier.
  /// </summary>
  public Guid? PriorityId { get; set; }
  
  /// <summary>
  /// Task name.
  /// </summary>
  [Required]
  public string Name { get; set; }
  
  /// <summary>
  /// Task content.
  /// </summary>
  [Required]
  public string Content { get; set; }
  
  /// <summary>
  /// Task deadline.
  /// </summary>
  public DateTime? DeadlineAtUtc { get; set; }
}