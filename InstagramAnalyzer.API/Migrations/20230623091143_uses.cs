using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InstagramAnalyzer.API.Migrations
{
    /// <inheritdoc />
    public partial class uses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LoginModel",
                table: "LoginModel");

            migrationBuilder.RenameTable(
                name: "LoginModel",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "LoginModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoginModel",
                table: "LoginModel",
                column: "Id");
        }
    }
}
