using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace job_search_be.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class jobs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    JobId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestJob = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BenefitsJob = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressJob = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkingTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkexperienceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormofworkId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalaryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    createdBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    deletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.JobId);
                    table.ForeignKey(
                        name: "FK_Jobs_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId");
                    table.ForeignKey(
                        name: "FK_Jobs_Employers_EmployersId",
                        column: x => x.EmployersId,
                        principalTable: "Employers",
                        principalColumn: "EmployersId");
                    table.ForeignKey(
                        name: "FK_Jobs_Formofworks_FormofworkId",
                        column: x => x.FormofworkId,
                        principalTable: "Formofworks",
                        principalColumn: "FormofworkId");
                    table.ForeignKey(
                        name: "FK_Jobs_Salaries_SalaryId",
                        column: x => x.SalaryId,
                        principalTable: "Salaries",
                        principalColumn: "SalaryId");
                    table.ForeignKey(
                        name: "FK_Jobs_Workexperiences_WorkexperienceId",
                        column: x => x.WorkexperienceId,
                        principalTable: "Workexperiences",
                        principalColumn: "WorkexperienceId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CityId",
                table: "Jobs",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_EmployersId",
                table: "Jobs",
                column: "EmployersId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_FormofworkId",
                table: "Jobs",
                column: "FormofworkId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_SalaryId",
                table: "Jobs",
                column: "SalaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_WorkexperienceId",
                table: "Jobs",
                column: "WorkexperienceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jobs");
        }
    }
}
