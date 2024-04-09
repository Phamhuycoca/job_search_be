using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace job_search_be.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class uokkk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Recruitment",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Recruitment");
        }
    }
}
