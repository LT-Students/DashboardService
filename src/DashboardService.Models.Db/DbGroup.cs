using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace LT.DigitalOffice.DashboardService.Models.Db;

public class DbGroup
{
  public const string TableName = "Groups";

  public Guid Id { get; set; }
  public Guid BoardId { get; set; }
  public string Name { get; set; }
  public bool IsActive { get; set; }
  public Guid CreatedBy { get; set; }
  public DateTime CreatedAtUtc { get; set; }
  public Guid? ModifiedBy { get; set; }
  public DateTime? ModifiedAtUtc { get; set; }

  public DbBoard Board { get; set; }
  public ICollection<DbTask> Tasks { get; set; }
}

public class DbGroupConfiguration : IEntityTypeConfiguration<DbGroup>
{
  public void Configure(EntityTypeBuilder<DbGroup> builder)
  {
    builder
      .ToTable(DbGroup.TableName);

    builder
      .HasKey(p => p.Id);

    builder
      .HasOne(t => t.Board)
      .WithMany(p => p.Groups);

    builder
      .Property(p => p.CreatedBy)
      .IsRequired();

    builder
      .Property(p => p.Name)
      .HasMaxLength(50)
      .IsRequired();

    builder
      .Property(p => p.IsActive)
      .IsRequired();

    builder
      .Property(p => p.CreatedAtUtc)
      .IsRequired();

    builder
      .HasMany(t => t.Tasks)
      .WithOne(p => p.Group);
  }
}

