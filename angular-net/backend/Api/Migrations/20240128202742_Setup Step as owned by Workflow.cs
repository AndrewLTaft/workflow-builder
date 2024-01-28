using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class SetupStepasownedbyWorkflow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Step_StepId",
                table: "Parts");

            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Workflows_WorkflowId",
                table: "Parts");

            migrationBuilder.DropForeignKey(
                name: "FK_Step_Workflows_WorkflowId",
                table: "Step");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Step",
                table: "Step");

            migrationBuilder.DropIndex(
                name: "IX_Step_WorkflowId",
                table: "Step");

            migrationBuilder.DropIndex(
                name: "IX_Parts_StepId",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_Parts_WorkflowId",
                table: "Parts");

            migrationBuilder.AlterColumn<int>(
                name: "WorkflowId",
                table: "Step",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Step",
                table: "Step",
                columns: new[] { "WorkflowId", "Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_Step_Workflows_WorkflowId",
                table: "Step",
                column: "WorkflowId",
                principalTable: "Workflows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Step_Workflows_WorkflowId",
                table: "Step");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Step",
                table: "Step");

            migrationBuilder.AlterColumn<int>(
                name: "WorkflowId",
                table: "Step",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Step",
                table: "Step",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Step_WorkflowId",
                table: "Step",
                column: "WorkflowId");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_StepId",
                table: "Parts",
                column: "StepId");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_WorkflowId",
                table: "Parts",
                column: "WorkflowId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_Step_StepId",
                table: "Parts",
                column: "StepId",
                principalTable: "Step",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_Workflows_WorkflowId",
                table: "Parts",
                column: "WorkflowId",
                principalTable: "Workflows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Step_Workflows_WorkflowId",
                table: "Step",
                column: "WorkflowId",
                principalTable: "Workflows",
                principalColumn: "Id");
        }
    }
}
