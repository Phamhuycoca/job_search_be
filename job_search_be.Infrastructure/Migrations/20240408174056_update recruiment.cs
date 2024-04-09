using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace job_search_be.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updaterecruiment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EmployersId",
                table: "Recruitment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Recruitment_EmployersId",
                table: "Recruitment",
                column: "EmployersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recruitment_Employers_EmployersId",
                table: "Recruitment",
                column: "EmployersId",
                principalTable: "Employers",
                principalColumn: "EmployersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recruitment_Employers_EmployersId",
                table: "Recruitment");

            migrationBuilder.DropIndex(
                name: "IX_Recruitment_EmployersId",
                table: "Recruitment");

            migrationBuilder.DropColumn(
                name: "EmployersId",
                table: "Recruitment");
        }
    }
}
