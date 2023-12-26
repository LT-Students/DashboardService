using System;
using System.ComponentModel.DataAnnotations;

namespace LT.DigitalOffice.DashboardService.Models.Dto.Requests.Task;

public record CreateTaskRequest
{
  public Guid GroupId { get; set; }
  public Guid? TaskTypeId { get; set; }
  public Guid? PriorityId { get; set; }
  [Required]
  public string Name { get; set; }
  [Required]
  public string Content { get; set; }
  public DateTime? DeadlineAtUtc { get; set; }
}