using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace job_search_be.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class favoufite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Favourite",
                columns: table => new
                {
                    FavouriteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Job_SeekerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsFavourite = table.Column<bool>(type: "bit", nullable: false),
                    JobId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    createdBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    deletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favourite", x => x.FavouriteId);
                    table.ForeignKey(
                        name: "FK_Favourite_Job_Seekers_Job_SeekerId",
                        column: x => x.Job_SeekerId,
                        principalTable: "Job_Seekers",
                        principalColumn: "Job_SeekerId");
                    table.ForeignKey(
                        name: "FK_Favourite_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "JobId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Favourite_Job_SeekerId",
                table: "Favourite",
                column: "Job_SeekerId");

            migrationBuilder.CreateIndex(
                name: "IX_Favourite_JobId",
                table: "Favourite",
                column: "JobId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favourite");
        }
    }
}
