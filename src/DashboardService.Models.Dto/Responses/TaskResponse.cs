using LT.DigitalOffice.DashboardService.Models.Db;
using LT.DigitalOffice.DashboardService.Models.Dto.Models;
using System;
using System.Collections.Generic;

namespace LT.DigitalOffice.DashboardService.Models.Dto.Responses;

public record TaskResponse
{
  public Guid Id { get; set; }
  public Guid GroupId { get; set; }
  public Guid? TaskTypeId { get; set; }
  public Guid? PriorityId { get; set; }
  public string Name { get; set; }
  public string Content { get; set; }
  public DateTime CreatedAtUtc { get; set; }
  public DateTime? DeadlineAtUtc { get; set; }
  
  public GroupInfo Group { get; set; }
  public TaskTypeInfo TaskType { get; set; }
  public PriorityInfo Priority { get; set; }
  public List<CommentInfo> Comments { get; set; }
  public List<ChangeLogInfo> Logs { get; set; }
}