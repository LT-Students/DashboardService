using System;

namespace LT.DigitalOffice.DashboardService.Models.Dto.Models;

public record GroupInfo
{
  public Guid Id { get; set; }
  public Guid BoardId { get; set; }
  public string Name { get; set; }
  public bool IsActive { get; set; }
  public Guid CreatedBy { get; set; }
  public DateTime CreatedAtUtc { get; set; }
  public Guid? ModifiedBy { get; set; }
  public DateTime? ModifiedAtUtc { get; set; }
}