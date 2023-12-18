using System.ComponentModel.DataAnnotations;
using System;

namespace LT.DigitalOffice.DashboardService.Models.Dto.Requests.ChangeLog;

public class CreateChangeLogRequest
{
  public Guid TaskId { get; set; }

  [Required]
  public string EntityName { get; set; }

  [Required]
  public string PropertyName { get; set; }

  [Required]
  public string PropertyNewValue { get; set; }
}
