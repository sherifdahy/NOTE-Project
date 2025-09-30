using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NOTE.Solutions.DAL.Migrations
{
    /// <inheritdoc />
    public partial class add_seeding_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "IsDefault", "IsDeleted", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "727F7C04-0A04-4012-9AA0-5BDF83C53788", false, false, "Admin", "ADMIN" },
                    { 2, "10208DE5-8AD0-41E3-BFED-CFD49C46BEDF", true, false, "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BranchId", "CompanyId", "ConcurrencyStamp", "Email", "EmailConfirmed", "IdentifierNumber", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, null, null, "A999212D-E3FE-410C-BEA5-888AD868482C", "admin@note-solutions.com", true, "", false, null, "", "ADMIN@NOTE-SOLUTIONS.COM", "ADMIN@NOTE-SOLUTIONS.COM", "AQAAAAIAAYagAAAAEH/h4I8oY8R+S+iAqlENxpa0K2kPTlTFr+E/srwjHRQrNCYAB5n8+RUUieW7vCJDCw==", null, false, "3F52186E-A158-4F4A-8822-ABEE912135EB", false, "admin@note-solutions.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
