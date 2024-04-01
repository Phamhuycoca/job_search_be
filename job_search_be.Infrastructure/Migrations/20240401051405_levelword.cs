using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace job_search_be.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class levelword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LevelworkId",
                table: "Jobs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Levelworks",
                columns: table => new
                {
                    LevelworkId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LevelworkName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    deletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Levelworks", x => x.LevelworkId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_LevelworkId",
                table: "Jobs",
                column: "LevelworkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Levelworks_LevelworkId",
                table: "Jobs",
                column: "LevelworkId",
                principalTable: "Levelworks",
                principalColumn: "LevelworkId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Levelworks_LevelworkId",
                table: "Jobs");

            migrationBuilder.DropTable(
                name: "Levelworks");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_LevelworkId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "LevelworkId",
                table: "Jobs");
        }
    }
}
