using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class AddEnterpreneur_to_enterpreneurSale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EnterpreneurId",
                table: "EnterpreneurSales",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EnterpreneurSales_EnterpreneurId",
                table: "EnterpreneurSales",
                column: "EnterpreneurId");

            migrationBuilder.AddForeignKey(
                name: "FK_EnterpreneurSales_Users_EnterpreneurId",
                table: "EnterpreneurSales",
                column: "EnterpreneurId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnterpreneurSales_Users_EnterpreneurId",
                table: "EnterpreneurSales");

            migrationBuilder.DropIndex(
                name: "IX_EnterpreneurSales_EnterpreneurId",
                table: "EnterpreneurSales");

            migrationBuilder.DropColumn(
                name: "EnterpreneurId",
                table: "EnterpreneurSales");
        }
    }
}
