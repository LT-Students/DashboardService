using LT.DigitalOffice.DashboardService.Models.Db;
using System;
using System.Collections.Generic;

namespace LT.DigitalOffice.DashboardService.Models.Dto.Responses;

public record TaskResponse
{
  public Guid Id { get; set; }
  public Guid? TaskTypeId { get; set; }
  public Guid? PriorityId { get; set; }
  public string Name { get; set; }
  public string Content { get; set; }
  public DateTime CreatedAtUtc { get; set; }
  public DateTime DeadlineAtUtc { get; set; }
  
  // TODO Convert to DTO after all infrastructure PR`s will be merged
  public DbGroup Group { get; set; }
  public DbTaskType TaskType { get; set; }
  public DbPriority Priority { get; set; }
  public ICollection<DbComment> Comments { get; set; }
  public ICollection<DbChangeLog> Logs { get; set; }
}