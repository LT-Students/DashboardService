using System;
using System.Collections.Generic;

namespace LT.DigitalOffice.DashboardService.Models.Db;

public class DbGroup
{
  public const string ToTable = "Groups";
  
  public Guid Id { get; set; }
  public Guid BoardId { get; set; }
  public Guid CreatedBy { get; set; }
  public Guid ModifiedBy { get; set; }
  public string Name { get; set; }
  public bool IsActive { get; set; }
  public DateTime CreatedAtUtc { get; set; }
  public DateTime ModifiedAtUtc { get; set; }
  
  public DbBoard Board { get; set; }
  public List<DbTask> Tasks { get; set; } = new();
}