using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace LT.DigitalOffice.DashboardService.Models.Db;

public class DbChangeLog
{
  public const string TableName = "ChangeLogs";

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

public class DbChangeLogConfiguration : IEntityTypeConfiguration<DbChangeLog>
{
  public void Configure(EntityTypeBuilder<DbChangeLog> builder)
  {
    builder.ToTable(DbChangeLog.TableName);

    builder
      .HasKey(t => t.Id);

    builder
      .Property(t => t.TaskId)
      .IsRequired();

    builder
      .Property(p => p.EntityName)
      .HasMaxLength(50)
      .IsRequired();

    builder
      .Property(p => p.PropertyName)
      .HasMaxLength(50)
      .IsRequired();

    builder
      .Property(p => p.PropertyOldValue)
      .HasMaxLength(50)
      .IsRequired();

    builder
      .Property(p => p.PropertyNewValue)
      .HasMaxLength(50)
      .IsRequired();

    builder
      .Property(p => p.CreatedAtUtc)
      .IsRequired();

    builder
      .Property(p => p.CreatedBy)
      .IsRequired();

    builder
      .HasOne(t => t.Task)
      .WithMany(g => g.Logs);
  }
}
