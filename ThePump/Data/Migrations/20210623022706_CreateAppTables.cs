using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ThePump.Data.Migrations
{
    public partial class CreateAppTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimePeriod",
                table: "Goal");

            migrationBuilder.AddColumn<DateTime>(
                name: "FinishingDate",
                table: "Goal",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartingDate",
                table: "Goal",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "AddData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentBodyWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RequiredBodyWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TypeOfExercise = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddData_Goal_GoalId",
                        column: x => x.GoalId,
                        principalTable: "Goal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddData_GoalId",
                table: "AddData",
                column: "GoalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddData");

            migrationBuilder.DropColumn(
                name: "FinishingDate",
                table: "Goal");

            migrationBuilder.DropColumn(
                name: "StartingDate",
                table: "Goal");

            migrationBuilder.AddColumn<int>(
                name: "TimePeriod",
                table: "Goal",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
