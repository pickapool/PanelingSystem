using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PanelingSystem.Migrations
{
    /// <inheritdoc />
    public partial class Migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Panels_Schedules_GroupId",
                table: "Panels");

            migrationBuilder.DropIndex(
                name: "IX_Panels_GroupId",
                table: "Panels");

            migrationBuilder.AddColumn<int>(
                name: "ScheduleModelScheduleId",
                table: "Panels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Panels_ScheduleModelScheduleId",
                table: "Panels",
                column: "ScheduleModelScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Panels_Schedules_ScheduleModelScheduleId",
                table: "Panels",
                column: "ScheduleModelScheduleId",
                principalTable: "Schedules",
                principalColumn: "ScheduleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Panels_Schedules_ScheduleModelScheduleId",
                table: "Panels");

            migrationBuilder.DropIndex(
                name: "IX_Panels_ScheduleModelScheduleId",
                table: "Panels");

            migrationBuilder.DropColumn(
                name: "ScheduleModelScheduleId",
                table: "Panels");

            migrationBuilder.CreateIndex(
                name: "IX_Panels_GroupId",
                table: "Panels",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Panels_Schedules_GroupId",
                table: "Panels",
                column: "GroupId",
                principalTable: "Schedules",
                principalColumn: "ScheduleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
