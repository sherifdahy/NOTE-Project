using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOTE.Solutions.DAL.Migrations
{
    /// <inheritdoc />
    public partial class update_ssn_in_application_user : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdentifierNumber",
                table: "Manager",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdentifierNumber",
                table: "Employee",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdentifierNumber",
                table: "Manager");

            migrationBuilder.DropColumn(
                name: "IdentifierNumber",
                table: "Employee");
        }
    }
}
