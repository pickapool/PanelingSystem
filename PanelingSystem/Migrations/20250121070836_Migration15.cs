using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PanelingSystem.Migrations
{
    /// <inheritdoc />
    public partial class Migration15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "FinalGrade",
                table: "Members",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PreOralGrade",
                table: "Members",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TitleGrade",
                table: "Members",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinalGrade",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "PreOralGrade",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "TitleGrade",
                table: "Members");
        }
    }
}
