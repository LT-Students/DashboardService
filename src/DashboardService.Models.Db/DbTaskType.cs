using System;
using System.Collections.Generic;

namespace LT.DigitalOffice.DashboardService.Models.Db;

public class DbTaskType
{
  public const string ToTable = "TaskTypes";
  
  public Guid Id { get; set; }
  public string Name { get; set; }
  
  public List<DbTask> Tasks { get; set; } = new();
}