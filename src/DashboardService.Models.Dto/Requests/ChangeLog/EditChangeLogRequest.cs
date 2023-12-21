using System;

namespace LT.DigitalOffice.DashboardService.Models.Dto.Requests.ChangeLog;

public class EditChangeLogRequest
{
  public Guid? TaskId { get; set; }
  public string EntityName { get; set; }
  public string PropertyName { get; set; }
  public string PropertyOldValue { get; set; }
  public string PropertyNewValue { get; set; }
}