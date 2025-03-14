using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PanelingSystem.Migrations
{
    /// <inheritdoc />
    public partial class Migration19 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PanelGrades_Accounts_UserAccountUserId",
                table: "PanelGrades");

            migrationBuilder.DropIndex(
                name: "IX_PanelGrades_UserAccountUserId",
                table: "PanelGrades");

            migrationBuilder.DropColumn(
                name: "UserAccountUserId",
                table: "PanelGrades");

            migrationBuilder.AddColumn<int>(
                name: "DefenseType",
                table: "PanelGrades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PanelGrades_UserId",
                table: "PanelGrades",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PanelGrades_Accounts_UserId",
                table: "PanelGrades",
                column: "UserId",
                principalTable: "Accounts",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PanelGrades_Accounts_UserId",
                table: "PanelGrades");

            migrationBuilder.DropIndex(
                name: "IX_PanelGrades_UserId",
                table: "PanelGrades");

            migrationBuilder.DropColumn(
                name: "DefenseType",
                table: "PanelGrades");

            migrationBuilder.AddColumn<int>(
                name: "UserAccountUserId",
                table: "PanelGrades",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PanelGrades_UserAccountUserId",
                table: "PanelGrades",
                column: "UserAccountUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PanelGrades_Accounts_UserAccountUserId",
                table: "PanelGrades",
                column: "UserAccountUserId",
                principalTable: "Accounts",
                principalColumn: "UserId");
        }
    }
}
