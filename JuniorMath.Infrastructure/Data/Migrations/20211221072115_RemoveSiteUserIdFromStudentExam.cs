using Microsoft.EntityFrameworkCore.Migrations;

namespace JuniorMath.Infrastructure.Data.Migrations
{
    public partial class RemoveSiteUserIdFromStudentExam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentExam_SiteUser_SiteUserId",
                table: "StudentExam");

            migrationBuilder.DropIndex(
                name: "IX_StudentExam_SiteUserId",
                table: "StudentExam");

            migrationBuilder.DropColumn(
                name: "SiteUserId",
                table: "StudentExam");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SiteUserId",
                table: "StudentExam",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentExam_SiteUserId",
                table: "StudentExam",
                column: "SiteUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExam_SiteUser_SiteUserId",
                table: "StudentExam",
                column: "SiteUserId",
                principalTable: "SiteUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
