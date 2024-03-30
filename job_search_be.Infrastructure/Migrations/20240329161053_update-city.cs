using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace job_search_be.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatecity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Employers_EmployersId",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Cities_EmployersId",
                table: "Cities");

            migrationBuilder.RenameColumn(
                name: "EmployersId",
                table: "Cities",
                newName: "updatedBy");

            migrationBuilder.AddColumn<Guid>(
                name: "CityId",
                table: "Employers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "createdAt",
                table: "Cities",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "createdBy",
                table: "Cities",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deletedAt",
                table: "Cities",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "deletedBy",
                table: "Cities",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updatedAt",
                table: "Cities",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employers_CityId",
                table: "Employers",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employers_Cities_CityId",
                table: "Employers",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "CityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employers_Cities_CityId",
                table: "Employers");

            migrationBuilder.DropIndex(
                name: "IX_Employers_CityId",
                table: "Employers");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Employers");

            migrationBuilder.DropColumn(
                name: "createdAt",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "createdBy",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "deletedAt",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "deletedBy",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "updatedAt",
                table: "Cities");

            migrationBuilder.RenameColumn(
                name: "updatedBy",
                table: "Cities",
                newName: "EmployersId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_EmployersId",
                table: "Cities",
                column: "EmployersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Employers_EmployersId",
                table: "Cities",
                column: "EmployersId",
                principalTable: "Employers",
                principalColumn: "EmployersId");
        }
    }
}
