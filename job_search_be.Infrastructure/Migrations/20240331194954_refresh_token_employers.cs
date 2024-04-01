using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace job_search_be.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class refresh_token_employers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "createdAt",
                table: "Employers_Refresh_Token",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "createdBy",
                table: "Employers_Refresh_Token",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deletedAt",
                table: "Employers_Refresh_Token",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "deletedBy",
                table: "Employers_Refresh_Token",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updatedAt",
                table: "Employers_Refresh_Token",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "updatedBy",
                table: "Employers_Refresh_Token",
                type: "uniqueidentifier",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "createdAt",
                table: "Employers_Refresh_Token");

            migrationBuilder.DropColumn(
                name: "createdBy",
                table: "Employers_Refresh_Token");

            migrationBuilder.DropColumn(
                name: "deletedAt",
                table: "Employers_Refresh_Token");

            migrationBuilder.DropColumn(
                name: "deletedBy",
                table: "Employers_Refresh_Token");

            migrationBuilder.DropColumn(
                name: "updatedAt",
                table: "Employers_Refresh_Token");

            migrationBuilder.DropColumn(
                name: "updatedBy",
                table: "Employers_Refresh_Token");
        }
    }
}
