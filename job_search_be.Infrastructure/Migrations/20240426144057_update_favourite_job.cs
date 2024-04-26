using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace job_search_be.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class update_favourite_job : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "createdAt",
                table: "Favoufite_Job",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "createdBy",
                table: "Favoufite_Job",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deletedAt",
                table: "Favoufite_Job",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "deletedBy",
                table: "Favoufite_Job",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updatedAt",
                table: "Favoufite_Job",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "updatedBy",
                table: "Favoufite_Job",
                type: "uniqueidentifier",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "createdAt",
                table: "Favoufite_Job");

            migrationBuilder.DropColumn(
                name: "createdBy",
                table: "Favoufite_Job");

            migrationBuilder.DropColumn(
                name: "deletedAt",
                table: "Favoufite_Job");

            migrationBuilder.DropColumn(
                name: "deletedBy",
                table: "Favoufite_Job");

            migrationBuilder.DropColumn(
                name: "updatedAt",
                table: "Favoufite_Job");

            migrationBuilder.DropColumn(
                name: "updatedBy",
                table: "Favoufite_Job");
        }
    }
}
