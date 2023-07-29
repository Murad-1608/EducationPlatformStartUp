using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SimpleChanges1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Courses",
                newName: "TeacherId");

            migrationBuilder.AddColumn<int>(
                name: "TeacherId1",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TeacherId1",
                table: "Courses",
                column: "TeacherId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Teachers_TeacherId1",
                table: "Courses",
                column: "TeacherId1",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Teachers_TeacherId1",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_TeacherId1",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "TeacherId1",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "Courses",
                newName: "UserId");
        }
    }
}
