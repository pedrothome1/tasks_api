using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tasks.Api.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssignmentGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignmentGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Project = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Estimate = table.Column<int>(nullable: false),
                    GroupId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assignments_AssignmentGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "AssignmentGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssignmentUnits",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AssignmentId = table.Column<Guid>(nullable: true),
                    StartedAt = table.Column<DateTimeOffset>(nullable: false),
                    EndedAt = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignmentUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssignmentUnits_Assignments_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_GroupId",
                table: "Assignments",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentUnits_AssignmentId",
                table: "AssignmentUnits",
                column: "AssignmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignmentUnits");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "AssignmentGroups");
        }
    }
}
