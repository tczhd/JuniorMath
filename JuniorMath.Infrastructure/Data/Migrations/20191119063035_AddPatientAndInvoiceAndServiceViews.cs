using Microsoft.EntityFrameworkCore.Migrations;
using System.IO;

namespace JuniorMath.Infrastructure.Data.Migrations
{
    public partial class AddPatientAndInvoiceAndServiceViews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, @"JuniorMath.Infrastructure\Data\DatabaseElements\Views\View_PatientSearchSource.sql");
            migrationBuilder.Sql(File.ReadAllText(sql));

            var sql1 = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, @"JuniorMath.Infrastructure\Data\DatabaseElements\Views\View_ItemSearchSource.sql");
            migrationBuilder.Sql(File.ReadAllText(sql1));

            var sql2 = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, @"JuniorMath.Infrastructure\Data\DatabaseElements\Views\View_InvoiceSearchSource.sql");
            migrationBuilder.Sql(File.ReadAllText(sql2));

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sql = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, @"JuniorMath.Infrastructure\Data\DatabaseElements\Views\HistoryViews\View_PatientSearchSource.sql");
            migrationBuilder.Sql(File.ReadAllText(sql));

            var sql1 = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, @"JuniorMath.Infrastructure\Data\DatabaseElements\Views\HistoryViews\View_ItemSearchSource.sql");
            migrationBuilder.Sql(File.ReadAllText(sql1));

            var sql2 = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, @"JuniorMath.Infrastructure\Data\DatabaseElements\Views\HistoryViews\View_InvoiceSearchSource.sql");
            migrationBuilder.Sql(File.ReadAllText(sql2)); ;

        }
    }
}
