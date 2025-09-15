using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOTE.Solutions.DAL.Migrations
{
    /// <inheritdoc />
    public partial class update_address_sead_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 1, "EGY", "EGYPT" });

            migrationBuilder.InsertData(
                table: "Governorates",
                columns: new[] { "Id", "Code", "CountryId", "Name" },
                values: new object[] { 1, "Giza", 1, "Giza" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Code", "GovernorateId", "Name" },
                values: new object[] { 1, "Imbaba", 1, "Imbaba" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Governorates",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
