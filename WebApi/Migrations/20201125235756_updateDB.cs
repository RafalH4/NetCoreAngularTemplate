using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class updateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Promotions");

            migrationBuilder.CreateTable(
                name: "EnterpreneurSales",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SaleName = table.Column<string>(nullable: true),
                    SaleDescription = table.Column<string>(nullable: true),
                    Discount = table.Column<int>(nullable: false),
                    isActivated = table.Column<bool>(nullable: false),
                    DateFrom = table.Column<DateTime>(nullable: false),
                    DateTo = table.Column<DateTime>(nullable: false),
                    BusinessId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnterpreneurSales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnterpreneurSales_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VeteranSales",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SaleName = table.Column<string>(nullable: true),
                    SaleDescription = table.Column<string>(nullable: true),
                    Discount = table.Column<int>(nullable: false),
                    isActivated = table.Column<bool>(nullable: false),
                    DateFrom = table.Column<DateTime>(nullable: false),
                    DateTo = table.Column<DateTime>(nullable: false),
                    VeteranId = table.Column<Guid>(nullable: true),
                    BusinessId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VeteranSales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VeteranSales_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VeteranSales_Users_VeteranId",
                        column: x => x.VeteranId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EnterpreneurSales_BusinessId",
                table: "EnterpreneurSales",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_VeteranSales_BusinessId",
                table: "VeteranSales",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_VeteranSales_VeteranId",
                table: "VeteranSales",
                column: "VeteranId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnterpreneurSales");

            migrationBuilder.DropTable(
                name: "VeteranSales");

            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    PromotionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PromotionName = table.Column<string>(type: "nvarchar(max)", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_BusinessId",
                table: "Promotions",
                column: "BusinessId");
        }
    }
}
