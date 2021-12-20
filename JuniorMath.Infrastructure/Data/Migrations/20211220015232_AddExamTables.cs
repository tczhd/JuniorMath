using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JuniorMath.Infrastructure.Data.Migrations
{
    public partial class AddExamTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exam",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exam_SiteUser_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "SiteUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuestionImageSetting",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ExamId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    QuestionType = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    CorrectAnswers = table.Column<string>(maxLength: 1000, nullable: false),
                    Marks = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_SiteUser_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "SiteUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Questions_Exam_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentExam",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EaxmId = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    TotalMarks = table.Column<int>(nullable: true),
                    Submitted = table.Column<bool>(nullable: false),
                    SubmittedDate = table.Column<DateTime>(nullable: false),
                    SubmittedBy = table.Column<int>(nullable: false),
                    SiteUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentExam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentExam_Exam_EaxmId",
                        column: x => x.EaxmId,
                        principalTable: "Exam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentExam_SiteUser_SiteUserId",
                        column: x => x.SiteUserId,
                        principalTable: "SiteUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentExam_SiteUser_SubmittedBy",
                        column: x => x.SubmittedBy,
                        principalTable: "SiteUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuestionDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QuestionId = table.Column<int>(nullable: false),
                    QuestionImageSettingId = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    GroupName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionDetail_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuestionDetail_QuestionImageSetting_QuestionImageSettingId",
                        column: x => x.QuestionImageSettingId,
                        principalTable: "QuestionImageSetting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentExamQuestionAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentExamId = table.Column<int>(nullable: false),
                    QuestionId = table.Column<int>(nullable: false),
                    Answers = table.Column<string>(nullable: true),
                    Marks = table.Column<int>(nullable: true),
                    SiteUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentExamQuestionAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentExamQuestionAnswers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentExamQuestionAnswers_SiteUser_SiteUserId",
                        column: x => x.SiteUserId,
                        principalTable: "SiteUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentExamQuestionAnswers_StudentExam_StudentExamId",
                        column: x => x.StudentExamId,
                        principalTable: "StudentExam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentExamQuestionAnswerDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentExamQuestionAnswerId = table.Column<int>(nullable: false),
                    QuestionDetailId = table.Column<int>(nullable: false),
                    AnswerCounts = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentExamQuestionAnswerDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentExamQuestionAnswerDetail_QuestionDetail_QuestionDetailId",
                        column: x => x.QuestionDetailId,
                        principalTable: "QuestionDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentExamQuestionAnswerDetail_StudentExamQuestionAnswers_StudentExamQuestionAnswerId",
                        column: x => x.StudentExamQuestionAnswerId,
                        principalTable: "StudentExamQuestionAnswers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exam_CreatedBy",
                table: "Exam",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionDetail_QuestionId",
                table: "QuestionDetail",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionDetail_QuestionImageSettingId",
                table: "QuestionDetail",
                column: "QuestionImageSettingId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionImageSetting_ImageName",
                table: "QuestionImageSetting",
                column: "ImageName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_CreatedBy",
                table: "Questions",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_ExamId",
                table: "Questions",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_Name",
                table: "Questions",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentExam_EaxmId",
                table: "StudentExam",
                column: "EaxmId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentExam_SiteUserId",
                table: "StudentExam",
                column: "SiteUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentExam_SubmittedBy",
                table: "StudentExam",
                column: "SubmittedBy");

            migrationBuilder.CreateIndex(
                name: "IX_StudentExamQuestionAnswerDetail_QuestionDetailId",
                table: "StudentExamQuestionAnswerDetail",
                column: "QuestionDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentExamQuestionAnswerDetail_StudentExamQuestionAnswerId",
                table: "StudentExamQuestionAnswerDetail",
                column: "StudentExamQuestionAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentExamQuestionAnswers_QuestionId",
                table: "StudentExamQuestionAnswers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentExamQuestionAnswers_SiteUserId",
                table: "StudentExamQuestionAnswers",
                column: "SiteUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentExamQuestionAnswers_StudentExamId",
                table: "StudentExamQuestionAnswers",
                column: "StudentExamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentExamQuestionAnswerDetail");

            migrationBuilder.DropTable(
                name: "QuestionDetail");

            migrationBuilder.DropTable(
                name: "StudentExamQuestionAnswers");

            migrationBuilder.DropTable(
                name: "QuestionImageSetting");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "StudentExam");

            migrationBuilder.DropTable(
                name: "Exam");
        }
    }
}
