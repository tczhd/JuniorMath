using Microsoft.EntityFrameworkCore.Migrations;

namespace JuniorMath.Infrastructure.Data.Migrations
{
    public partial class ChangeQuestionIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Questions_ExamId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_Name",
                table: "Questions");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_ExamId_Name",
                table: "Questions",
                columns: new[] { "ExamId", "Name" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Questions_ExamId_Name",
                table: "Questions");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_ExamId",
                table: "Questions",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_Name",
                table: "Questions",
                column: "Name",
                unique: true);
        }
    }
}
