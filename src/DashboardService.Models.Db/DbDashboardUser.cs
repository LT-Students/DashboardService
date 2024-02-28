using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace LT.DigitalOffice.DashboardService.Models.Db;

public class DbDashboardUser
{
  public const string TableName = "DashboardUsers";
  
  // TODO: addIsActive
  // TODO: узнать, нужно ли при создании борда сразу в реквесте прокидывать dashboardUser`ов
  // TODO: использовать ли _globalCache ?
  // TODO: нужно ли разделение на Director и Employee а также Manager и Employee ?
  public Guid Id { get; set; }
  public Guid UserId { get; set; }
  public Guid DashboardId { get; set; }
  public int Assignment { get; set; }
  
  public DbBoard Board { get; set; }
}

public class DbDashboardUserConfiguration : IEntityTypeConfiguration<DbDashboardUser>
{
  public void Configure(EntityTypeBuilder<DbDashboardUser> builder)
  {
    builder
      .ToTable(DbBoard.TableName);

    builder
      .HasKey(du => du.Id);

    builder
      .Property(du => du.UserId)
      .IsRequired();

    builder
      .Property(du => du.DashboardId)
      .IsRequired();
    
    builder
      .Property(du => du.Assignment)
      .IsRequired();

    builder
      .HasOne(du => du.Board)
      .WithMany(b => b.Users);
  }
}
