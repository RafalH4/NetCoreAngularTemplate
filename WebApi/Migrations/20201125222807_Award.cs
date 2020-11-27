using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class Award : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BusinessId",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VeteranCardNumber",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Awards",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AwardDescription = table.Column<string>(nullable: true),
                    UrlPhoto = table.Column<string>(nullable: true),
                    VeteranId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Awards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Awards_Users_VeteranId",
                        column: x => x.VeteranId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Businesses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BusinessName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    PhotoUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Businesses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OrganizationName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    PhotoUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusinessesRatings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    VeteranId = table.Column<Guid>(nullable: true),
                    BusinessId = table.Column<Guid>(nullable: true),
                    Rate = table.Column<int>(nullable: false),
                    Opinion = table.Column<string>(nullable: true),
                    UrlPhoto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessesRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessesRatings_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessesRatings_Users_VeteranId",
                        column: x => x.VeteranId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PromotionName = table.Column<string>(nullable: true),
                    PromotionDescription = table.Column<string>(nullable: true),
                    Discount = table.Column<int>(nullable: false),
                    BusinessId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Promotions_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VeteranOrganizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    VeteranId = table.Column<Guid>(nullable: true),
                    OrganizationId = table.Column<Guid>(nullable: true),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VeteranOrganizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VeteranOrganizations_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VeteranOrganizations_Users_VeteranId",
                        column: x => x.VeteranId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_BusinessId",
                table: "Users",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Awards_VeteranId",
                table: "Awards",
                column: "VeteranId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessesRatings_BusinessId",
                table: "BusinessesRatings",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessesRatings_VeteranId",
                table: "BusinessesRatings",
                column: "VeteranId");

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_BusinessId",
                table: "Promotions",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_VeteranOrganizations_OrganizationId",
                table: "VeteranOrganizations",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_VeteranOrganizations_VeteranId",
                table: "VeteranOrganizations",
                column: "VeteranId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Businesses_BusinessId",
                table: "Users",
                column: "BusinessId",
                principalTable: "Businesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Businesses_BusinessId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Awards");

            migrationBuilder.DropTable(
                name: "BusinessesRatings");

            migrationBuilder.DropTable(
                name: "Promotions");

            migrationBuilder.DropTable(
                name: "VeteranOrganizations");

            migrationBuilder.DropTable(
                name: "Businesses");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropIndex(
                name: "IX_Users_BusinessId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BusinessId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "VeteranCardNumber",
                table: "Users");
        }
    }
}
