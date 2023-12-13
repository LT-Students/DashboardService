using System;
using System.Collections.Generic;

namespace LT.DigitalOffice.DashboardService.Models.Db;

public class DbGroup
{
  public const string ToTable = "Groups";

  public Guid Id { get; set; }
  public Guid BoardId { get; set; }
  public Guid CreatedBy { get; set; }
  public Guid ModifiedBy { get; set; }
  public string Name { get; set; }
  public bool IsActive { get; set; }
  public DateTime CreatedAtUtc { get; set; }
  public DateTime ModifiedAtUtc { get; set; }

  public DbBoard Board { get; set; }
  public ICollection<DbTask> Tasks { get; set; }
}

public class DbGroupConfiguration : IEntityTypeConfiguration<DbGroup>
{
  public void Configure(EntityTypeBuilder<DbGroup> builder)
  {
    builder
      .ToTable(DbGroup.ToTable);

    builder
      .HasKey(p => p.Id);

    builder
      .HasOne(t => t.Board)
      .WithMany(p => p.Group);

    builder
      .Property(p => p.CreatedBy)
      .IsRequired();

    builder
      .Property(p => p.ModifierBy)
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
      .Property(p => p.CreatedAtUtc)
      .IsRequired();

    builder
      .WithMany(t => t.Task)
      .HasOne(p => p.Group);
  }
}

