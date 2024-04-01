using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace job_search_be.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class employers_refresh_token : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employers_Refresh_Token",
                columns: table => new
                {
                    EmployersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Refresh_TokenExpires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpiration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employers_Refresh_Token", x => x.EmployersId);
                    table.ForeignKey(
                        name: "FK_Employers_Refresh_Token_Employers_EmployersId",
                        column: x => x.EmployersId,
                        principalTable: "Employers",
                        principalColumn: "EmployersId");
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employers_Refresh_Token");
        }
    }
}
