using System;

namespace LT.DigitalOffice.DashboardService.Models.Db;

public class DbChangeLog
{
  public const string ToTable = "ChangeLogs";
  
  public Guid Id { get; set; }
  public Guid TaskId { get; set; }
  public Guid CreatedBy { get; set; }
  public string EntityName { get; set; }
  public string PropertyName { get; set; }
  public string PropertyOldValue { get; set; }
  public string PropertyNewValue { get; set; }
  public DateTime CreatedAtUtc { get; set; }
  
  public DbTask Task { get; set; }
}