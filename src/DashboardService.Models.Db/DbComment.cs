using System;

namespace LT.DigitalOffice.DashboardService.Models.Db;

public class DbComment
{
  public const string ToTable = "Comments";
  
  public Guid Id { get; set; }
  public Guid TaskId { get; set; }
  public Guid CreatedBy { get; set; }
  public string Content { get; set; }
  public DateTime CreatedAtUtc { get; set; }

  public DbTask Task { get; set; }
}