using System;
using System.Collections.Generic;

namespace LT.DigitalOffice.DashboardService.Models.Db;

public class DbTask
{
  public const string ToTable = "Tasks";
  
  public Guid Id { get; set; }
  public Guid GroupId { get; set; }
  public Guid? ParentTaskId { get; set; }
  public Guid? TaskTypeId { get; set; }
  public Guid? PriorityId { get; set; }

  public string Name { get; set; }
  public string Content { get; set; }
  
  public DateTime CreatedAtUtc { get; set; }
  public DateTime? DeadLineAtUtc { get; set; }
  
  public DbGroup Group { get; set; }
  public DbTask? ParentTask { get; set; }
  public DbTaskType? TaskType { get; set; }
  public DbPriority? Priority { get; set; }

  public List<DbComment> Comments { get; set; } = new();
  public List<DbChangeLog> Logs { get; set; } = new();
}