using System;

namespace LT.DigitalOffice.DashboardService.Models.Dto.Models;

public record TaskInfo
{
  public Guid Id { get; set; }
  public Guid? TaskTypeId { get; set; }
  public Guid? PriorityId { get; set; }
  public string Name { get; set; }
  public string Content { get; set; }
  public DateTime CreatedAtUtc { get; set; }
  public DateTime? DeadlineAtUtc { get; set; }
}