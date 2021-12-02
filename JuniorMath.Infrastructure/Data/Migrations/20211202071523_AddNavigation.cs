using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JuniorMath.Infrastructure.Data.Migrations
{
    public partial class AddNavigation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExaminationPapers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExaminationPapers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExaminationPapers_SiteUser_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "SiteUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuestionImageSetting",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    ImageName = table.Column<string>(maxLength: 100, nullable: false),
                    ImageType = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionImageSetting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    QuestionType = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ImageOrders = table.Column<string>(maxLength: 1000, nullable: false),
                    CorrectAnswers = table.Column<string>(maxLength: 1000, nullable: false),
                    Marks = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    CreatedByNavigationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_SiteUser_CreatedByNavigationId",
                        column: x => x.CreatedByNavigationId,
                        principalTable: "SiteUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentExaminationPapers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SiteUserId = table.Column<int>(nullable: false),
                    PaperId = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    TotalMarks = table.Column<int>(nullable: true),
                    Submitted = table.Column<bool>(nullable: false),
                    SubmittedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentExaminationPapers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentExaminationPapers_SiteUser_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "SiteUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentExaminationPapers_ExaminationPapers_PaperId",
                        column: x => x.PaperId,
                        principalTable: "ExaminationPapers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentExaminationPapers_SiteUser_SiteUserId",
                        column: x => x.SiteUserId,
                        principalTable: "SiteUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExaminationPaperQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PaperId = table.Column<int>(nullable: false),
                    QuestionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExaminationPaperQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExaminationPaperQuestions_ExaminationPapers_PaperId",
                        column: x => x.PaperId,
                        principalTable: "ExaminationPapers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExaminationPaperQuestions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentExaminationPaperQuestionAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentExaminationPaperId = table.Column<int>(nullable: false),
                    QuestionId = table.Column<int>(nullable: false),
                    Answers = table.Column<string>(nullable: true),
                    Marks = table.Column<int>(nullable: true),
                    SiteUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentExaminationPaperQuestionAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentExaminationPaperQuestionAnswers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentExaminationPaperQuestionAnswers_SiteUser_SiteUserId",
                        column: x => x.SiteUserId,
                        principalTable: "SiteUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentExaminationPaperQuestionAnswers_StudentExaminationPapers_StudentExaminationPaperId",
                        column: x => x.StudentExaminationPaperId,
                        principalTable: "StudentExaminationPapers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExaminationPaperQuestions_PaperId",
                table: "ExaminationPaperQuestions",
                column: "PaperId");

            migrationBuilder.CreateIndex(
                name: "IX_ExaminationPaperQuestions_QuestionId",
                table: "ExaminationPaperQuestions",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_ExaminationPapers_CreatedBy",
                table: "ExaminationPapers",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionImageSetting_ImageName",
                table: "QuestionImageSetting",
                column: "ImageName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_CreatedByNavigationId",
                table: "Questions",
                column: "CreatedByNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_Name",
                table: "Questions",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentExaminationPaperQuestionAnswers_QuestionId",
                table: "StudentExaminationPaperQuestionAnswers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentExaminationPaperQuestionAnswers_SiteUserId",
                table: "StudentExaminationPaperQuestionAnswers",
                column: "SiteUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentExaminationPaperQuestionAnswers_StudentExaminationPaperId",
                table: "StudentExaminationPaperQuestionAnswers",
                column: "StudentExaminationPaperId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentExaminationPapers_CreatedBy",
                table: "StudentExaminationPapers",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_StudentExaminationPapers_PaperId",
                table: "StudentExaminationPapers",
                column: "PaperId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentExaminationPapers_SiteUserId",
                table: "StudentExaminationPapers",
                column: "SiteUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExaminationPaperQuestions");

            migrationBuilder.DropTable(
                name: "QuestionImageSetting");

            migrationBuilder.DropTable(
                name: "StudentExaminationPaperQuestionAnswers");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "StudentExaminationPapers");

            migrationBuilder.DropTable(
                name: "ExaminationPapers");
        }
    }
}
