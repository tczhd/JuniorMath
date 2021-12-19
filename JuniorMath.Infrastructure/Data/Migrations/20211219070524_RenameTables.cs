using Microsoft.EntityFrameworkCore.Migrations;

namespace JuniorMath.Infrastructure.Data.Migrations
{
    public partial class RenameTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExaminationPapers_SiteUser_CreatedBy",
                table: "ExaminationPapers");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_ExaminationPapers_ExamId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentExaminationPaperQuestionAnswers_Questions_QuestionId",
                table: "StudentExaminationPaperQuestionAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentExaminationPaperQuestionAnswers_SiteUser_SiteUserId",
                table: "StudentExaminationPaperQuestionAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentExaminationPaperQuestionAnswers_StudentExaminationPapers_StudentExamId",
                table: "StudentExaminationPaperQuestionAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentExaminationPapers_ExaminationPapers_EaxmId",
                table: "StudentExaminationPapers");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentExaminationPapers_SiteUser_SiteUserId",
                table: "StudentExaminationPapers");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentExaminationPapers_SiteUser_SubmittedBy",
                table: "StudentExaminationPapers");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentExamQuestionAnswerDetail_StudentExaminationPaperQuestionAnswers_StudentExamQuestionAnswerId",
                table: "StudentExamQuestionAnswerDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentExaminationPapers",
                table: "StudentExaminationPapers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentExaminationPaperQuestionAnswers",
                table: "StudentExaminationPaperQuestionAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExaminationPapers",
                table: "ExaminationPapers");

            migrationBuilder.RenameTable(
                name: "StudentExaminationPapers",
                newName: "StudentExam");

            migrationBuilder.RenameTable(
                name: "StudentExaminationPaperQuestionAnswers",
                newName: "StudentExamQuestionAnswers");

            migrationBuilder.RenameTable(
                name: "ExaminationPapers",
                newName: "Exam");

            migrationBuilder.RenameIndex(
                name: "IX_StudentExaminationPapers_SubmittedBy",
                table: "StudentExam",
                newName: "IX_StudentExam_SubmittedBy");

            migrationBuilder.RenameIndex(
                name: "IX_StudentExaminationPapers_SiteUserId",
                table: "StudentExam",
                newName: "IX_StudentExam_SiteUserId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentExaminationPapers_EaxmId",
                table: "StudentExam",
                newName: "IX_StudentExam_EaxmId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentExaminationPaperQuestionAnswers_StudentExamId",
                table: "StudentExamQuestionAnswers",
                newName: "IX_StudentExamQuestionAnswers_StudentExamId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentExaminationPaperQuestionAnswers_SiteUserId",
                table: "StudentExamQuestionAnswers",
                newName: "IX_StudentExamQuestionAnswers_SiteUserId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentExaminationPaperQuestionAnswers_QuestionId",
                table: "StudentExamQuestionAnswers",
                newName: "IX_StudentExamQuestionAnswers_QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_ExaminationPapers_CreatedBy",
                table: "Exam",
                newName: "IX_Exam_CreatedBy");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentExam",
                table: "StudentExam",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentExamQuestionAnswers",
                table: "StudentExamQuestionAnswers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exam",
                table: "Exam",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exam_SiteUser_CreatedBy",
                table: "Exam",
                column: "CreatedBy",
                principalTable: "SiteUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Exam_ExamId",
                table: "Questions",
                column: "ExamId",
                principalTable: "Exam",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExam_Exam_EaxmId",
                table: "StudentExam",
                column: "EaxmId",
                principalTable: "Exam",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExam_SiteUser_SiteUserId",
                table: "StudentExam",
                column: "SiteUserId",
                principalTable: "SiteUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExam_SiteUser_SubmittedBy",
                table: "StudentExam",
                column: "SubmittedBy",
                principalTable: "SiteUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExamQuestionAnswerDetail_StudentExamQuestionAnswers_StudentExamQuestionAnswerId",
                table: "StudentExamQuestionAnswerDetail",
                column: "StudentExamQuestionAnswerId",
                principalTable: "StudentExamQuestionAnswers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExamQuestionAnswers_Questions_QuestionId",
                table: "StudentExamQuestionAnswers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExamQuestionAnswers_SiteUser_SiteUserId",
                table: "StudentExamQuestionAnswers",
                column: "SiteUserId",
                principalTable: "SiteUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExamQuestionAnswers_StudentExam_StudentExamId",
                table: "StudentExamQuestionAnswers",
                column: "StudentExamId",
                principalTable: "StudentExam",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exam_SiteUser_CreatedBy",
                table: "Exam");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Exam_ExamId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentExam_Exam_EaxmId",
                table: "StudentExam");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentExam_SiteUser_SiteUserId",
                table: "StudentExam");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentExam_SiteUser_SubmittedBy",
                table: "StudentExam");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentExamQuestionAnswerDetail_StudentExamQuestionAnswers_StudentExamQuestionAnswerId",
                table: "StudentExamQuestionAnswerDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentExamQuestionAnswers_Questions_QuestionId",
                table: "StudentExamQuestionAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentExamQuestionAnswers_SiteUser_SiteUserId",
                table: "StudentExamQuestionAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentExamQuestionAnswers_StudentExam_StudentExamId",
                table: "StudentExamQuestionAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentExamQuestionAnswers",
                table: "StudentExamQuestionAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentExam",
                table: "StudentExam");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exam",
                table: "Exam");

            migrationBuilder.RenameTable(
                name: "StudentExamQuestionAnswers",
                newName: "StudentExaminationPaperQuestionAnswers");

            migrationBuilder.RenameTable(
                name: "StudentExam",
                newName: "StudentExaminationPapers");

            migrationBuilder.RenameTable(
                name: "Exam",
                newName: "ExaminationPapers");

            migrationBuilder.RenameIndex(
                name: "IX_StudentExamQuestionAnswers_StudentExamId",
                table: "StudentExaminationPaperQuestionAnswers",
                newName: "IX_StudentExaminationPaperQuestionAnswers_StudentExamId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentExamQuestionAnswers_SiteUserId",
                table: "StudentExaminationPaperQuestionAnswers",
                newName: "IX_StudentExaminationPaperQuestionAnswers_SiteUserId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentExamQuestionAnswers_QuestionId",
                table: "StudentExaminationPaperQuestionAnswers",
                newName: "IX_StudentExaminationPaperQuestionAnswers_QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentExam_SubmittedBy",
                table: "StudentExaminationPapers",
                newName: "IX_StudentExaminationPapers_SubmittedBy");

            migrationBuilder.RenameIndex(
                name: "IX_StudentExam_SiteUserId",
                table: "StudentExaminationPapers",
                newName: "IX_StudentExaminationPapers_SiteUserId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentExam_EaxmId",
                table: "StudentExaminationPapers",
                newName: "IX_StudentExaminationPapers_EaxmId");

            migrationBuilder.RenameIndex(
                name: "IX_Exam_CreatedBy",
                table: "ExaminationPapers",
                newName: "IX_ExaminationPapers_CreatedBy");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentExaminationPaperQuestionAnswers",
                table: "StudentExaminationPaperQuestionAnswers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentExaminationPapers",
                table: "StudentExaminationPapers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExaminationPapers",
                table: "ExaminationPapers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExaminationPapers_SiteUser_CreatedBy",
                table: "ExaminationPapers",
                column: "CreatedBy",
                principalTable: "SiteUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_ExaminationPapers_ExamId",
                table: "Questions",
                column: "ExamId",
                principalTable: "ExaminationPapers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExaminationPaperQuestionAnswers_Questions_QuestionId",
                table: "StudentExaminationPaperQuestionAnswers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExaminationPaperQuestionAnswers_SiteUser_SiteUserId",
                table: "StudentExaminationPaperQuestionAnswers",
                column: "SiteUserId",
                principalTable: "SiteUser",
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
                name: "FK_StudentExaminationPapers_SiteUser_SiteUserId",
                table: "StudentExaminationPapers",
                column: "SiteUserId",
                principalTable: "SiteUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExaminationPapers_SiteUser_SubmittedBy",
                table: "StudentExaminationPapers",
                column: "SubmittedBy",
                principalTable: "SiteUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExamQuestionAnswerDetail_StudentExaminationPaperQuestionAnswers_StudentExamQuestionAnswerId",
                table: "StudentExamQuestionAnswerDetail",
                column: "StudentExamQuestionAnswerId",
                principalTable: "StudentExaminationPaperQuestionAnswers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
