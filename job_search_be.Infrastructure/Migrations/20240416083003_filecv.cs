using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace job_search_be.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class filecv : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FileCv",
                columns: table => new
                {
                    FileCvId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HostPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileCvPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Job_SeekerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    createdBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    deletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileCv", x => x.FileCvId);
                    table.ForeignKey(
                        name: "FK_FileCv_Job_Seekers_Job_SeekerId",
                        column: x => x.Job_SeekerId,
                        principalTable: "Job_Seekers",
                        principalColumn: "Job_SeekerId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FileCv_Job_SeekerId",
                table: "FileCv",
                column: "Job_SeekerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileCv");
        }
    }
}
