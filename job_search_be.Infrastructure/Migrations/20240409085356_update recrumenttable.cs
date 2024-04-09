using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace job_search_be.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updaterecrumenttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsStatus",
                table: "Recruitment",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsStatus",
                table: "Recruitment");
        }
    }
}
