using System;
using System.Collections.Generic;

namespace LT.DigitalOffice.DashboardService.Models.Db;

public class DbBoard
{
  public const string ToTable = "Boards";
  
  public Guid Id { get; set; }
  public Guid ProjectId { get; set; }
  public Guid CreatedBy { get; set; }
  public Guid ModifierBy { get; set; }
  public string Name { get; set; }
  public DateTime CreatedAtUtc { get; set; }
  public DateTime ModifiedAtUtc { get; set; }

  public List<DbGroup> Groups { get; set; } = new();
}