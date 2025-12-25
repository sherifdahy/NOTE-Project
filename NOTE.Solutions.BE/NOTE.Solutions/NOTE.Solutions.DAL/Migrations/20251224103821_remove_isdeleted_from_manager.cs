using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOTE.Solutions.DAL.Migrations
{
    /// <inheritdoc />
    public partial class remove_isdeleted_from_manager : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Managers");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ActiveCodes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ActiveCodes");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Managers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
