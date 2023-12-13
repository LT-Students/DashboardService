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

public class DbCommentConfiguration : IEntityTypeConfiguration<DbComment>
{
  public void Configure(EntityTypeBuilder<DbComment> builder)
  {
    builder
      .ToTable(DbComment.ToTable);

    builder
      .HasKey(p => p.Id);

    builder
      .Property(p => p.Task)
      .IsRequired();

    builder
      .Property(p => p.CreatedBy)
      .IsRequired();

    builder
      .Property(p => p.Content)
      .HasMaxLength(50)
      .IsRequired();

    builder
      .Property(p => p.CreatedAtUtc)
      .IsRequired();

    builder
      .Property(p => p.CreatedAtUtc)
      .IsRequired();

    builder
      .WithMany(t => t.Task)
      .HasOne(p => p.Comment);
  }
}