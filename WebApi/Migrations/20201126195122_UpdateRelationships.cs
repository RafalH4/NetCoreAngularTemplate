using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class UpdateRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Awards_Users_VeteranId",
                table: "Awards");

            migrationBuilder.DropForeignKey(
                name: "FK_EnterpreneurSales_Users_EnterpreneurId",
                table: "EnterpreneurSales");

            migrationBuilder.DropForeignKey(
                name: "FK_VeteranSales_Businesses_BusinessId",
                table: "VeteranSales");

            migrationBuilder.DropIndex(
                name: "IX_VeteranSales_BusinessId",
                table: "VeteranSales");

            migrationBuilder.DropIndex(
                name: "IX_EnterpreneurSales_EnterpreneurId",
                table: "EnterpreneurSales");

            migrationBuilder.DropIndex(
                name: "IX_Awards_VeteranId",
                table: "Awards");

            migrationBuilder.DropColumn(
                name: "BusinessId",
                table: "VeteranSales");

            migrationBuilder.DropColumn(
                name: "EnterpreneurId",
                table: "EnterpreneurSales");

            migrationBuilder.DropColumn(
                name: "VeteranId",
                table: "Awards");

            migrationBuilder.AddColumn<float>(
                name: "Lattitude",
                table: "VeteranSales",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Longitude",
                table: "VeteranSales",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "AwatarUrl",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Lattitude",
                table: "Businesses",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Longitude",
                table: "Businesses",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "VeteranAwards",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AwardId = table.Column<Guid>(nullable: true),
                    VeteranId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VeteranAwards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VeteranAwards_Awards_AwardId",
                        column: x => x.AwardId,
                        principalTable: "Awards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VeteranAwards_Users_VeteranId",
                        column: x => x.VeteranId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VeteranAwards_AwardId",
                table: "VeteranAwards",
                column: "AwardId");

            migrationBuilder.CreateIndex(
                name: "IX_VeteranAwards_VeteranId",
                table: "VeteranAwards",
                column: "VeteranId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VeteranAwards");

            migrationBuilder.DropColumn(
                name: "Lattitude",
                table: "VeteranSales");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "VeteranSales");

            migrationBuilder.DropColumn(
                name: "AwatarUrl",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Lattitude",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Businesses");

            migrationBuilder.AddColumn<Guid>(
                name: "BusinessId",
                table: "VeteranSales",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EnterpreneurId",
                table: "EnterpreneurSales",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "VeteranId",
                table: "Awards",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VeteranSales_BusinessId",
                table: "VeteranSales",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_EnterpreneurSales_EnterpreneurId",
                table: "EnterpreneurSales",
                column: "EnterpreneurId");

            migrationBuilder.CreateIndex(
                name: "IX_Awards_VeteranId",
                table: "Awards",
                column: "VeteranId");

            migrationBuilder.AddForeignKey(
                name: "FK_Awards_Users_VeteranId",
                table: "Awards",
                column: "VeteranId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EnterpreneurSales_Users_EnterpreneurId",
                table: "EnterpreneurSales",
                column: "EnterpreneurId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VeteranSales_Businesses_BusinessId",
                table: "VeteranSales",
                column: "BusinessId",
                principalTable: "Businesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
