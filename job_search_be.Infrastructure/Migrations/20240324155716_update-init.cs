using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace job_search_be.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateinit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Permissions_PermissionId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_PermissionId",
                table: "Roles");

            migrationBuilder.AlterColumn<string>(
                name: "PermissionId",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PermissionId",
                table: "Roles",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_PermissionId",
                table: "Roles",
                column: "PermissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Permissions_PermissionId",
                table: "Roles",
                column: "PermissionId",
                principalTable: "Permissions",
                principalColumn: "PermissionId");
        }
    }
}
