using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace LT.DigitalOffice.DashboardService.Models.Db;

public class DbTaskType
{
  public const string TableName = "TaskTypes";
  
  public Guid Id { get; set; }
  public string Name { get; set; }
  
  public ICollection<DbTask> Tasks { get; set; }
}

public class DbTaskTypeConfiguration : IEntityTypeConfiguration<DbTaskType>
{
  public void Configure(EntityTypeBuilder<DbTaskType> builder)
  {
    builder
      .ToTable(DbTaskType.TableName);

    builder
      .HasKey(d => d.Id);

    builder
      .Property(d => d.Name)
      .HasMaxLength(50)
      .IsRequired();

    builder
      .HasMany(tt => tt.Tasks)
      .WithOne(t => t.TaskType);
  }
}