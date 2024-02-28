using LT.DigitalOffice.DashboardService.Models.Db;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace LT.DigitalOffice.DashboardService.Data.Provider.MsSql.Ef.Migrations;

[DbContext(typeof(DashboardServiceDbContext))]
[Migration("20242702200700_InitialCreate")]
public class DashboardUser : Migration 
{
  protected override void Up(MigrationBuilder migrationBuilder)
  {
    CreateDbDashboardUserTable(migrationBuilder);
  }

  protected override void Down(MigrationBuilder migrationBuilder)
  {
    migrationBuilder.DropTable(DbDashboardUser.TableName);
  }
  
  private void CreateDbDashboardUserTable(MigrationBuilder migrationBuilder)
  {
    {
      migrationBuilder.CreateTable(
        name: DbDashboardUser.TableName,
        columns: table => new
        {
          Id = table.Column<Guid>(nullable: false),
          UserId = table.Column<Guid>(nullable: false),
          DashboardId = table.Column<Guid>(nullable: false),
          Assignment = table.Column<int>(nullable: false),
        },
        constraints: table =>
        {
          table.PrimaryKey($"PK_{DbDashboardUser.TableName}", x => x.Id);
        });
    }
  }
  
  
}