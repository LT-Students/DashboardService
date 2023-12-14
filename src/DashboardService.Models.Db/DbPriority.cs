using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace LT.DigitalOffice.DashboardService.Models.Db;

public class DbPriority
{
  public const string TableName = "Priorities";

  public Guid Id { get; set; }
  public string Name { get; set; }

  public ICollection<DbTask> Tasks { get; set; } = new List<DbTask>();
}

public class DbPriorityConfiguration : IEntityTypeConfiguration<DbPriority>
{
  public void Configure(EntityTypeBuilder<DbPriority> builder)
  {
    builder
      .ToTable(DbPriority.TableName);

    builder
      .HasKey(p => p.Id);

    builder
      .Property(p => p.Name)
      .HasMaxLength(50)
      .IsRequired();

    builder
      .HasMany(p => p.Tasks)
      .WithOne(t => t.Priority);
  }
}