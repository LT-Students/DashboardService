using LT.DigitalOffice.DashboardService.Models.Db;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace LT.DigitalOffice.DashboardService.Data.Provider.MsSql.Ef.Migrations;

[DbContext(typeof(DashboardServiceDbContext))]
[Migration("20231211221100_InitialCreate")]
public class InitialCreate : Migration
{
  protected override void Up(MigrationBuilder migrationBuilder)
  {
    CreateTaskTypeTable(migrationBuilder);
    CreatePriorityTable(migrationBuilder);
    CreateTaskTable(migrationBuilder);
    CreateGroupTable(migrationBuilder);
    CreateCommentTable(migrationBuilder);
    CreateBoardTable(migrationBuilder);
    CreateChangeLogTable(migrationBuilder);
  }

  protected override void Down(MigrationBuilder migrationBuilder)
  {
    migrationBuilder.DropTable(DbTask.ToTable);
    migrationBuilder.DropTable(DbPriority.ToTable);
    migrationBuilder.DropTable(DbTaskType.ToTable);
    migrationBuilder.DropTable(DbGroup.ToTable);
    migrationBuilder.DropTable(DbComment.ToTable);
    migrationBuilder.DropTable(DbBoard.ToTable);
    migrationBuilder.DropTable(DbChangeLog.ToTable);
  }

  private void CreateTaskTypeTable(MigrationBuilder migrationBuilder)
  {
    migrationBuilder.CreateTable(
      name: DbTaskType.ToTable,
      columns: table => new
      {
        Id = table.Column<Guid>(nullable: false),
        Name = table.Column<string>(nullable: false, type: "nvarchar(50)", maxLength:50),
      },
      constraints: table =>
      {
        table.PrimaryKey($"PK_{DbTaskType.ToTable}", x => x.Id);
      }
    );
  }

  private void CreatePriorityTable(MigrationBuilder migrationBuilder)
  {
    migrationBuilder.CreateTable(
      name: DbPriority.ToTable,
      columns: table => new
      {
        Id = table.Column<Guid>(nullable: false),
        Name = table.Column<string>(nullable: false, type: "nvarchar(50)", maxLength:50),
      },
      constraints: table =>
      {
        table.PrimaryKey($"PK_{DbPriority.ToTable}", x => x.Id);
      }
    );
  }

  private void CreateTaskTable(MigrationBuilder migrationBuilder)
  {
    migrationBuilder.CreateTable(
      name: DbTask.ToTable,
      columns: table => new
      {
        Id = table.Column<Guid>(nullable: false),
        GroupId = table.Column<Guid>(nullable: false),
        TaskTypeId = table.Column<Guid>(nullable: true),
        PriorityId = table.Column<Guid>(nullable: true),
        Name = table.Column<string>(nullable: false, type: "nvarchar(50)", maxLength:50),
        Content = table.Column<string>(nullable: false, type: "nvarchar(max)"),
        CreatedAtUtc = table.Column<DateTime>(nullable: false),
        DeadlineAtUtc = table.Column<DateTime>(nullable: true),
      },
      constraints: table =>
      {
        table.PrimaryKey($"PK_{DbTask.ToTable}", x => x.Id);
      }
    );
  }

  private void CreateGroupTable(MigrationBuilder migrationBuilder)
  {
    migrationBuilder.CreateTable(
      name: DbGroup.ToTable,
      columns: table => new
      {
        Id = table.Column<Guid>(nullable: false),
        BoardId = table.Column<Guid>(nullable: false),
        CreatedBy = table.Column<Guid>(nullable: false),
        ModifiedBy = table.Column<Guid>(nullable: false),
        Name = table.Column<string>(nullable: false, type: "nvarchar(50)", maxLength: 50),
        IsActive = table.Column<bool>(nullable: false),
        CreatedAtUtc = table.Column<DateTime>(nullable: false),
        ModifiedAtUtc = table.Column<DateTime>(nullable: false),
      },
      constraints: table =>
      {
        table.PrimaryKey($"PK_{DbGroup.ToTable}", x => x.Id);
      }
    );
  }

  private void CreateCommentTable(MigrationBuilder migrationBuilder)
  {
    migrationBuilder.CreateTable(
      name: DbComment.ToTable,
      columns: table => new
      {
        Id = table.Column<Guid>(nullable: false),
        TaskId = table.Column<Guid>(nullable: false),
        CreatedBy = table.Column<Guid>(nullable: false),
        Content = table.Column<string>(nullable: false, type: "nvarchar(max)"),
        CreatedAtUtc = table.Column<DateTime>(nullable: false),
      },
      constraints: table =>
      {
        table.PrimaryKey($"PK_{DbComment.ToTable}", x => x.Id);
      }
    );
  }

  private void CreateBoardTable(MigrationBuilder migrationBuilder)
  {
    migrationBuilder.CreateTable(
      name: DbBoard.ToTable,
      columns: table => new
      {
        Id = table.Column<Guid>(nullable: false),
        ProjectId = table.Column<Guid>(nullable: false),
        Name = table.Column<string>(nullable: false, type: "nvarchar(50)", maxLength: 50),
        CreatedBy = table.Column<Guid>(nullable: false),
        ModifiedBy = table.Column<Guid>(nullable: false),
        IsActive = table.Column<bool>(nullable: false),
        CreatedAtUtc = table.Column<DateTime>(nullable: false),
        ModifiedAtUtc = table.Column<DateTime>(nullable: false),
      },
      constraints: table =>
      {
        table.PrimaryKey($"PK_{DbBoard.ToTable}", x => x.Id);
      }
    );
  }

  private void CreateChangeLogTable(MigrationBuilder migrationBuilder)
  {
    migrationBuilder.CreateTable(
      name: DbChangeLog.ToTable,
      columns: table => new
      {
        Id = table.Column<Guid>(nullable: false),
        TaskId = table.Column<Guid>(nullable: false),
        EntityName = table.Column<string>(nullable: false, type: "nvarchar(50)", maxLength: 50),
        PropertyName = table.Column<string>(nullable: false, type: "nvarchar(50)", maxLength: 50),
        PropertyOldValue = table.Column<string>(nullable: false, type: "nvarchar(50)", maxLength: 50),
        PropertyNewValue = table.Column<string>(nullable: false, type: "nvarchar(50)", maxLength: 50),
        CreatedBy = table.Column<Guid>(nullable: false),
                CreatedAtUtc = table.Column<DateTime>(nullable: false),
      },
      constraints: table =>
      {
        table.PrimaryKey($"PK_{DbChangeLog.ToTable}", x => x.Id);
      }
    );

  }
}