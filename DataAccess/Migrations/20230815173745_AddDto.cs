using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddDto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MiniDetail",
                table: "Courses",
                newName: "MiniDetails");

            migrationBuilder.AddColumn<decimal>(
                name: "BonusPrice",
                table: "Courses",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BonusPrice",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "MiniDetails",
                table: "Courses",
                newName: "MiniDetail");
        }
    }
}
