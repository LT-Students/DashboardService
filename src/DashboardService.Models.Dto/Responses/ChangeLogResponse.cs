using System;

namespace LT.DigitalOffice.DashboardService.Models.Dto.Responses;

public class ChangeLogResponse
{
  public Guid Id { get; set; }
  public Guid CreatedBy { get; set; }
  public string EntityName { get; set; }
  public string PropertyName { get; set; }
  public string PropertyOldValue { get; set; }
  public string PropertyNewValue { get; set; }
  public DateTime CreatedAtUtc { get; set; }

  // public TaskInfo Task { get; set; }
}
