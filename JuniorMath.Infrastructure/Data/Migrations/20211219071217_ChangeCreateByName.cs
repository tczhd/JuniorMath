using Microsoft.EntityFrameworkCore.Migrations;

namespace JuniorMath.Infrastructure.Data.Migrations
{
    public partial class ChangeCreateByName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_SiteUser_CreatedByNavigationId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_CreatedByNavigationId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "CreatedByNavigationId",
                table: "Questions");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_CreatedBy",
                table: "Questions",
                column: "CreatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_SiteUser_CreatedBy",
                table: "Questions",
                column: "CreatedBy",
                principalTable: "SiteUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_SiteUser_CreatedBy",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_CreatedBy",
                table: "Questions");

            migrationBuilder.AddColumn<int>(
                name: "CreatedByNavigationId",
                table: "Questions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_CreatedByNavigationId",
                table: "Questions",
                column: "CreatedByNavigationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_SiteUser_CreatedByNavigationId",
                table: "Questions",
                column: "CreatedByNavigationId",
                principalTable: "SiteUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
