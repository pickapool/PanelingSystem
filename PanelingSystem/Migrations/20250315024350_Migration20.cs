using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PanelingSystem.Migrations
{
    /// <inheritdoc />
    public partial class Migration20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "DefenseVerdicts",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_DefenseVerdicts_GroupId",
                table: "DefenseVerdicts",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_DefenseVerdicts_Groups_GroupId",
                table: "DefenseVerdicts",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "GroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DefenseVerdicts_Groups_GroupId",
                table: "DefenseVerdicts");

            migrationBuilder.DropIndex(
                name: "IX_DefenseVerdicts_GroupId",
                table: "DefenseVerdicts");

            migrationBuilder.AlterColumn<long>(
                name: "GroupId",
                table: "DefenseVerdicts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
