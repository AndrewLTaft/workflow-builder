using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class ConvertStepIdtoGuid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Step",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<bool>(
                name: "Completed",
                table: "Parts",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "StepId",
                table: "Parts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parts_StepId",
                table: "Parts",
                column: "StepId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_Step_StepId",
                table: "Parts",
                column: "StepId",
                principalTable: "Step",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Step_StepId",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_Parts_StepId",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "Completed",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "StepId",
                table: "Parts");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Step",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);
        }
    }
}
