using LT.DigitalOffice.DashboardService.Models.Db;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace LT.DigitalOffice.DashboardService.Data.Provider.MsSql.Ef.Migrations;

[DbContext(typeof(DashboardServiceDbContext))]
[Migration("20220729014055_InitialCreate")]
public class InitialCreate : Migration
{
  protected override void Up(MigrationBuilder migrationBuilder)
  {
    CreateTaskTypeTable(migrationBuilder);
    CreatePriorityTable(migrationBuilder);
    CreateTaskTable(migrationBuilder);
  }

  protected override void Down(MigrationBuilder migrationBuilder)
  {
    migrationBuilder.DropTable(DbTask.ToTable);
    migrationBuilder.DropTable(DbPriority.ToTable);
    migrationBuilder.DropTable(DbTaskType.ToTable);
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
        table.ForeignKey(
          name: $"FK_{DbTask.ToTable}_{DbGroup.ToTable}_GroupId",
          column: x=>x.GroupId,
          principalTable:$"{DbGroup.ToTable}",
          principalColumn:$"{nameof(DbGroup.Id)}",
          onDelete: ReferentialAction.Cascade
        );
        table.ForeignKey(
          name: $"FK_{DbTask.ToTable}_{DbTaskType.ToTable}_TaskTypeId",
          column: x=>x.TaskTypeId,
          principalTable:$"{DbTaskType.ToTable}",
          principalColumn:$"{nameof(DbTaskType.Id)}",
          onDelete: ReferentialAction.SetNull
        );
        table.ForeignKey(
          name: $"FK_{DbTask.ToTable}_{DbPriority.ToTable}_PriorityId",
          column: x=>x.PriorityId,
          principalTable:$"{DbPriority.ToTable}",
          principalColumn:$"{nameof(DbPriority.Id)}",
          onDelete: ReferentialAction.SetNull
        );
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
        table.ForeignKey(
          name: $"FK_{DbGroup.ToTable}_{DbBoard.ToTable}_BoardId",
          column: x => x.DbBoardId,
          principalTable: $"{DbBoard.ToTable}",
          principalColumn: $"{nameof(DbBoard.Id)}",
          onDelete: ReferentialAction.Cascade
        );
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
        table.ForeignKey(
          name: $"FK_{DbComment.ToTable}_{DbTask.ToTable}_TaskId",
          column: x => x.DbTaskId,
          principalTable: $"{DbTask.ToTable}",
          principalColumn: $"{nameof(DbTask.Id)}",
          onDelete: ReferentialAction.Cascade
        );
      }
    );
  }

}