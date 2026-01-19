using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOTE.Solutions.DAL.Migrations
{
    /// <inheritdoc />
    public partial class asd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Contexts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "System Admin");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Contexts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "SystemAdmin");
        }
    }
}
