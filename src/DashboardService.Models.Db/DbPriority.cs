using System;
using System.Collections.Generic;

namespace LT.DigitalOffice.DashboardService.Models.Db;

public class DbPriority
{
  public const string ToTable = "Priorities";
  
  public Guid Id { get; set; }
  public string Name { get; set; }

  public List<DbTask> Tasks { get; set; } = new();
}