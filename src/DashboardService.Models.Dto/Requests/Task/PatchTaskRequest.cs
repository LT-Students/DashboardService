using System;

namespace LT.DigitalOffice.DashboardService.Models.Dto.Requests.Task;

public record PatchTaskRequest
{
  public Guid? TaskTypeId { get; set; }
  public Guid? PriorityId { get; set; }
  public string Name { get; set; }
  public string Content { get; set; }
  public DateTime DeadlineAtUtc { get; set; }
}