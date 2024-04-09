using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace job_search_be.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class recruimet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recruitment",
                columns: table => new
                {
                    RecruitmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Job_SeekerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecruitmentDateTime = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recruitment", x => x.RecruitmentId);
                    table.ForeignKey(
                        name: "FK_Recruitment_Job_Seekers_Job_SeekerId",
                        column: x => x.Job_SeekerId,
                        principalTable: "Job_Seekers",
                        principalColumn: "Job_SeekerId");
                    table.ForeignKey(
                        name: "FK_Recruitment_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "JobId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recruitment_Job_SeekerId",
                table: "Recruitment",
                column: "Job_SeekerId");

            migrationBuilder.CreateIndex(
                name: "IX_Recruitment_JobId",
                table: "Recruitment",
                column: "JobId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recruitment");
        }
    }
}
