using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JuniorMath.Infrastructure.Data.Migrations
{
    public partial class AddQuestionDetailtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentExaminationPaperQuestionAnswers_StudentExaminationPapers_StudentExaminationPaperId",
                table: "StudentExaminationPaperQuestionAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentExaminationPapers_SiteUser_CreatedBy",
                table: "StudentExaminationPapers");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentExaminationPapers_ExaminationPapers_PaperId",
                table: "StudentExaminationPapers");

            migrationBuilder.DropTable(
                name: "ExaminationPaperQuestions");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "StudentExaminationPapers");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "StudentExaminationPapers");

            migrationBuilder.DropColumn(
                name: "ImageOrders",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "PaperId",
                table: "StudentExaminationPapers",
                newName: "SubmittedBy");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "StudentExaminationPapers",
                newName: "EaxmId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentExaminationPapers_PaperId",
                table: "StudentExaminationPapers",
                newName: "IX_StudentExaminationPapers_SubmittedBy");

            migrationBuilder.RenameIndex(
                name: "IX_StudentExaminationPapers_CreatedBy",
                table: "StudentExaminationPapers",
                newName: "IX_StudentExaminationPapers_EaxmId");

            migrationBuilder.RenameColumn(
                name: "StudentExaminationPaperId",
                table: "StudentExaminationPaperQuestionAnswers",
                newName: "StudentExamId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentExaminationPaperQuestionAnswers_StudentExaminationPaperId",
                table: "StudentExaminationPaperQuestionAnswers",
                newName: "IX_StudentExaminationPaperQuestionAnswers_StudentExamId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SubmittedDate",
                table: "StudentExaminationPapers",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SiteUserId",
                table: "StudentExaminationPapers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ExamId",
                table: "Questions",
                nullable: false,
                defaultValue: 0);

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
                        name: "FK_StudentExamQuestionAnswerDetail_StudentExaminationPaperQuestionAnswers_StudentExamQuestionAnswerId",
                        column: x => x.StudentExamQuestionAnswerId,
                        principalTable: "StudentExaminationPaperQuestionAnswers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_ExamId",
                table: "Questions",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionDetail_QuestionId",
                table: "QuestionDetail",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionDetail_QuestionImageSettingId",
                table: "QuestionDetail",
                column: "QuestionImageSettingId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentExamQuestionAnswerDetail_QuestionDetailId",
                table: "StudentExamQuestionAnswerDetail",
                column: "QuestionDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentExamQuestionAnswerDetail_StudentExamQuestionAnswerId",
                table: "StudentExamQuestionAnswerDetail",
                column: "StudentExamQuestionAnswerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_ExaminationPapers_ExamId",
                table: "Questions",
                column: "ExamId",
                principalTable: "ExaminationPapers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExaminationPaperQuestionAnswers_StudentExaminationPapers_StudentExamId",
                table: "StudentExaminationPaperQuestionAnswers",
                column: "StudentExamId",
                principalTable: "StudentExaminationPapers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExaminationPapers_ExaminationPapers_EaxmId",
                table: "StudentExaminationPapers",
                column: "EaxmId",
                principalTable: "ExaminationPapers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExaminationPapers_SiteUser_SubmittedBy",
                table: "StudentExaminationPapers",
                column: "SubmittedBy",
                principalTable: "SiteUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_ExaminationPapers_ExamId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentExaminationPaperQuestionAnswers_StudentExaminationPapers_StudentExamId",
                table: "StudentExaminationPaperQuestionAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentExaminationPapers_ExaminationPapers_EaxmId",
                table: "StudentExaminationPapers");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentExaminationPapers_SiteUser_SubmittedBy",
                table: "StudentExaminationPapers");

            migrationBuilder.DropTable(
                name: "StudentExamQuestionAnswerDetail");

            migrationBuilder.DropTable(
                name: "QuestionDetail");

            migrationBuilder.DropIndex(
                name: "IX_Questions_ExamId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "ExamId",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "SubmittedBy",
                table: "StudentExaminationPapers",
                newName: "PaperId");

            migrationBuilder.RenameColumn(
                name: "EaxmId",
                table: "StudentExaminationPapers",
                newName: "CreatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_StudentExaminationPapers_SubmittedBy",
                table: "StudentExaminationPapers",
                newName: "IX_StudentExaminationPapers_PaperId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentExaminationPapers_EaxmId",
                table: "StudentExaminationPapers",
                newName: "IX_StudentExaminationPapers_CreatedBy");

            migrationBuilder.RenameColumn(
                name: "StudentExamId",
                table: "StudentExaminationPaperQuestionAnswers",
                newName: "StudentExaminationPaperId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentExaminationPaperQuestionAnswers_StudentExamId",
                table: "StudentExaminationPaperQuestionAnswers",
                newName: "IX_StudentExaminationPaperQuestionAnswers_StudentExaminationPaperId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SubmittedDate",
                table: "StudentExaminationPapers",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<int>(
                name: "SiteUserId",
                table: "StudentExaminationPapers",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "StudentExaminationPapers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "StudentExaminationPapers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ImageOrders",
                table: "Questions",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.CreateIndex(
                name: "IX_ExaminationPaperQuestions_PaperId",
                table: "ExaminationPaperQuestions",
                column: "PaperId");

            migrationBuilder.CreateIndex(
                name: "IX_ExaminationPaperQuestions_QuestionId",
                table: "ExaminationPaperQuestions",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExaminationPaperQuestionAnswers_StudentExaminationPapers_StudentExaminationPaperId",
                table: "StudentExaminationPaperQuestionAnswers",
                column: "StudentExaminationPaperId",
                principalTable: "StudentExaminationPapers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExaminationPapers_SiteUser_CreatedBy",
                table: "StudentExaminationPapers",
                column: "CreatedBy",
                principalTable: "SiteUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExaminationPapers_ExaminationPapers_PaperId",
                table: "StudentExaminationPapers",
                column: "PaperId",
                principalTable: "ExaminationPapers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
