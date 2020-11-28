using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class updateVeteran2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "VeteranId",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_VeteranId",
                table: "Users",
                column: "VeteranId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_VeteranId",
                table: "Users",
                column: "VeteranId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_VeteranId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_VeteranId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "VeteranId",
                table: "Users");
        }
    }
}
