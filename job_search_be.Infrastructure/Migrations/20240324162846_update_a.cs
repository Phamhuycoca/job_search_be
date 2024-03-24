using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace job_search_be.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class update_a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "createdAt",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "createdBy",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deletedAt",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "deletedBy",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updatedAt",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "updatedBy",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "createdAt",
                table: "RefreshTokens",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "createdBy",
                table: "RefreshTokens",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deletedAt",
                table: "RefreshTokens",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "deletedBy",
                table: "RefreshTokens",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updatedAt",
                table: "RefreshTokens",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "updatedBy",
                table: "RefreshTokens",
                type: "uniqueidentifier",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "createdAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "createdBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "deletedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "deletedBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "updatedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "updatedBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "createdAt",
                table: "RefreshTokens");

            migrationBuilder.DropColumn(
                name: "createdBy",
                table: "RefreshTokens");

            migrationBuilder.DropColumn(
                name: "deletedAt",
                table: "RefreshTokens");

            migrationBuilder.DropColumn(
                name: "deletedBy",
                table: "RefreshTokens");

            migrationBuilder.DropColumn(
                name: "updatedAt",
                table: "RefreshTokens");

            migrationBuilder.DropColumn(
                name: "updatedBy",
                table: "RefreshTokens");
        }
    }
}
