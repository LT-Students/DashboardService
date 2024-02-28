using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace LT.DigitalOffice.DashboardService.Models.Db;

public class DbBoard
{
  public const string TableName = "Boards";

  public Guid Id { get; set; }
  public Guid ProjectId { get; set; }
  public string Name { get; set; }
  public bool IsActive { get; set; }
  public Guid CreatedBy { get; set; }
  public DateTime CreatedAtUtc { set; get; }
  public Guid? ModifiedBy { get; set; }
  public DateTime? ModifiedAtUtc { get; set; }

  public ICollection<DbGroup> Groups { get; set; } = new List<DbGroup>();
  public ICollection<DbDashboardUser> Users { get; set; } = new List<DbDashboardUser>();
}

public class DbBoardConfiguration : IEntityTypeConfiguration<DbBoard>
{
  public void Configure(EntityTypeBuilder<DbBoard> builder)
  {
    builder
      .ToTable(DbBoard.TableName);

    builder
      .HasKey(b => b.Id);

    builder
      .Property(b => b.Name)
      .HasMaxLength(50)
      .IsRequired();

    builder
      .Property(b => b.CreatedBy)
      .IsRequired();

    builder
      .Property(b => b.ProjectId)
      .IsRequired();

    builder
      .Property(b => b.CreatedAtUtc)
      .IsRequired();

    builder
      .Property(b => b.IsActive)
      .IsRequired();

    builder
      .HasMany(b => b.Groups)
      .WithOne(g => g.Board);
    
    builder
      .HasMany(b => b.Users)
      .WithOne(du => du.Board);
  }
}
