using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JuniorMath.Infrastructure.Data.Migrations
{
    public partial class InitTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddressType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressType = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressType", x => x.Id);
                });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUsers",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(nullable: false),
            //        UserName = table.Column<string>(nullable: true),
            //        NormalizedUserName = table.Column<string>(nullable: true),
            //        Email = table.Column<string>(nullable: true),
            //        NormalizedEmail = table.Column<string>(nullable: true),
            //        EmailConfirmed = table.Column<bool>(nullable: false),
            //        PasswordHash = table.Column<string>(nullable: true),
            //        SecurityStamp = table.Column<string>(nullable: true),
            //        ConcurrencyStamp = table.Column<string>(nullable: true),
            //        PhoneNumber = table.Column<string>(nullable: true),
            //        PhoneNumberConfirmed = table.Column<bool>(nullable: false),
            //        TwoFactorEnabled = table.Column<bool>(nullable: false),
            //        LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
            //        LockoutEnabled = table.Column<bool>(nullable: false),
            //        AccessFailedCount = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUsers", x => x.Id);
            //    });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Iso2 = table.Column<string>(unicode: false, maxLength: 5, nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SiteUserLevel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteUserLevel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SiteUser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 250, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", fixedLength: true, maxLength: 450, nullable: false),
                    SiteUserLevelId = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(fixedLength: true, maxLength: 10, nullable: false),
                    Note = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SiteUser_SiteUserLevel",
                        column: x => x.SiteUserLevelId,
                        principalTable: "SiteUserLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SiteUser_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressTypeId = table.Column<int>(nullable: false),
                    Address1 = table.Column<string>(maxLength: 150, nullable: false),
                    Address2 = table.Column<string>(maxLength: 50, nullable: true),
                    City = table.Column<string>(maxLength: 150, nullable: false),
                    RegionId = table.Column<int>(nullable: true),
                    Region = table.Column<string>(maxLength: 50, nullable: true),
                    CountryId = table.Column<int>(nullable: false),
                    AttentionTo = table.Column<string>(maxLength: 150, nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    CreatedDateUTC = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedDateUTC = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_AddressType",
                        column: x => x.AddressTypeId,
                        principalTable: "AddressType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Address_Country",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Address_SiteUser_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "SiteUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Address_Region",
                        column: x => x.RegionId,
                        principalTable: "Region",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Address_SiteUser_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "SiteUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_AddressTypeId",
                table: "Address",
                column: "AddressTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_CountryId",
                table: "Address",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_CreatedBy",
                table: "Address",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Address_RegionId",
                table: "Address",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_UpdatedBy",
                table: "Address",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SiteUser_SiteUserLevelId",
                table: "SiteUser",
                column: "SiteUserLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_SiteUser_UserId",
                table: "SiteUser",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "AddressType");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "SiteUser");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropTable(
                name: "SiteUserLevel");

            //migrationBuilder.DropTable(
            //    name: "AspNetUsers");
        }
    }
}
