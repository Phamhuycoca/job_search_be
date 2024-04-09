using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace job_search_be.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ups : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "createdAt",
                table: "Recruitment",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "createdBy",
                table: "Recruitment",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deletedAt",
                table: "Recruitment",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "deletedBy",
                table: "Recruitment",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updatedAt",
                table: "Recruitment",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "updatedBy",
                table: "Recruitment",
                type: "uniqueidentifier",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "createdAt",
                table: "Recruitment");

            migrationBuilder.DropColumn(
                name: "createdBy",
                table: "Recruitment");

            migrationBuilder.DropColumn(
                name: "deletedAt",
                table: "Recruitment");

            migrationBuilder.DropColumn(
                name: "deletedBy",
                table: "Recruitment");

            migrationBuilder.DropColumn(
                name: "updatedAt",
                table: "Recruitment");

            migrationBuilder.DropColumn(
                name: "updatedBy",
                table: "Recruitment");
        }
    }
}
