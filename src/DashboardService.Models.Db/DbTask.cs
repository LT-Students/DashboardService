using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace LT.DigitalOffice.DashboardService.Models.Db;

public class DbTask
{
  public const string TableName = "Tasks";

  public Guid Id { get; set; }
  public Guid GroupId { get; set; }
  public Guid? TaskTypeId { get; set; }
  public Guid? PriorityId { get; set; }
  public string Name { get; set; }
  public string Content { get; set; }
  public DateTime CreatedAtUtc { get; set; }
  public Guid CreatedBy { get; set; }
  public DateTime? DeadlineAtUtc { get; set; }
  
  public DbGroup Group { get; set; }
  public DbTaskType TaskType { get; set; }
  public DbPriority Priority { get; set; }
  public ICollection<DbComment> Comments { get; set; } = new List<DbComment>();
  public ICollection<DbChangeLog> Logs { get; set; } = new List<DbChangeLog>();
}

public class DbTaskConfiguration : IEntityTypeConfiguration<DbTask>
{
  public void Configure(EntityTypeBuilder<DbTask> builder)
  {
    builder
      .ToTable(DbTask.TableName);

    builder
      .HasKey(d => d.Id);

    builder
      .HasOne(t => t.Group)
      .WithMany(g => g.Tasks);

    builder
      .HasOne(t => t.TaskType)
      .WithMany(tt => tt.Tasks);

    builder
      .HasOne(t => t.Priority)
      .WithMany(p => p.Tasks);

    builder
      .Property(t => t.Name)
      .HasMaxLength(50)
      .IsRequired();
    
    builder
      .Property(t => t.Content)
      .IsRequired();

    builder
      .Property(t => t.CreatedAtUtc)
      .IsRequired();

    builder
      .Property(t => t.CreatedBy)
      .IsRequired();

    builder
      .HasMany(t => t.Comments)
      .WithOne(c => c.Task);

    builder
      .HasMany(t => t.Logs)
      .WithOne(l => l.Task);
  }
}