using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace LT.DigitalOffice.DashboardService.Models.Db;

public class DbBoard
{
  public const string ToTable = "Boards";

  public Guid Id { get; set; }
  public Guid ProjectId { get; set; }
  public Guid CreatedBy { get; set; }
  public Guid ModifierBy { get; set; }
  public string Name { get; set; }
  public bool IsActive { get; set; }
  public DateTime CreatedAtUtc { get; set; }
  public DateTime ModifiedAtUtc { get; set; }

  public ICollection<DbGroup> Groups { get; set; }
}

public class DbBoardConfiguration : IEntityTypeConfiguration<DbBoard>
{
  public void Configure(EntityTypeBuilder<DbBoard> builder)
  {
    builder
      .ToTable(DbBoard.ToTable);

    builder
      .HasKey(p => p.Id);

    builder
      .Property(p => p.Name)
      .HasMaxLength(50)
      .IsRequired();

    builder
      .Property(p => p.CreatedBy)
      .IsRequired();

    builder
      .Property(p => p.ProjectId)
      .IsRequired();

    builder
      .Property(p => p.CreatedAtUtc)
      .IsRequired();

    builder
      .Property(p => p.ModifierBy)
      .IsRequired();

    builder
      .Property(p => p.IsActive)
      .IsRequired();

    builder
      .HasMany(p => p.Groups)
      .WithOne(t => t.Board);
  }
}
