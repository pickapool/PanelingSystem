using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PanelingSystem.Migrations
{
    /// <inheritdoc />
    public partial class Migration17 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PanelGrades",
                columns: table => new
                {
                    PanelGradeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grade = table.Column<double>(type: "float", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    UserAccountUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PanelGrades", x => x.PanelGradeId);
                    table.ForeignKey(
                        name: "FK_PanelGrades_Accounts_UserAccountUserId",
                        column: x => x.UserAccountUserId,
                        principalTable: "Accounts",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PanelGrades_UserAccountUserId",
                table: "PanelGrades",
                column: "UserAccountUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PanelGrades");
        }
    }
}
