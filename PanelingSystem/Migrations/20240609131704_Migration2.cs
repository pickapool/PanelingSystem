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
                name: "FK_Panels_Accounts_PanelUserId",
                table: "Panels");

            migrationBuilder.DropIndex(
                name: "IX_Panels_PanelUserId",
                table: "Panels");

            migrationBuilder.DropColumn(
                name: "PanelUserId",
                table: "Panels");

            migrationBuilder.CreateIndex(
                name: "IX_Panels_UserId",
                table: "Panels",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Panels_Accounts_UserId",
                table: "Panels",
                column: "UserId",
                principalTable: "Accounts",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Panels_Accounts_UserId",
                table: "Panels");

            migrationBuilder.DropIndex(
                name: "IX_Panels_UserId",
                table: "Panels");

            migrationBuilder.AddColumn<int>(
                name: "PanelUserId",
                table: "Panels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Panels_PanelUserId",
                table: "Panels",
                column: "PanelUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Panels_Accounts_PanelUserId",
                table: "Panels",
                column: "PanelUserId",
                principalTable: "Accounts",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
