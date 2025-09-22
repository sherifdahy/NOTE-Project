using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOTE.Solutions.DAL.Migrations
{
    /// <inheritdoc />
    public partial class update_some_entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_POSs_ClientId_ClientSecret",
                table: "POSs");

            migrationBuilder.DropIndex(
                name: "IX_POSs_POSSerial_BranchId",
                table: "POSs");

            migrationBuilder.DropIndex(
                name: "IX_Documents_UUID",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "BuyerName",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "BuyerSSN",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "BuyerType",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "DocumentNumber",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "UUID",
                table: "Documents");

            migrationBuilder.CreateTable(
                name: "DocumentBuyer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SSN = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Type = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentBuyer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentBuyer_ApplicationUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DocumentBuyer_ApplicationUsers_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DocumentHeader",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DocumentNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UUID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentHeader", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentHeader_ApplicationUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DocumentHeader_ApplicationUsers_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_POSs_POSSerial_BranchId",
                table: "POSs",
                columns: new[] { "POSSerial", "BranchId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DocumentBuyer_CreatedById",
                table: "DocumentBuyer",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentBuyer_UpdatedById",
                table: "DocumentBuyer",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentHeader_CreatedById",
                table: "DocumentHeader",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentHeader_UpdatedById",
                table: "DocumentHeader",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentHeader_UUID",
                table: "DocumentHeader",
                column: "UUID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentBuyer");

            migrationBuilder.DropTable(
                name: "DocumentHeader");

            migrationBuilder.DropIndex(
                name: "IX_POSs_POSSerial_BranchId",
                table: "POSs");

            migrationBuilder.AddColumn<string>(
                name: "BuyerName",
                table: "Documents",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BuyerSSN",
                table: "Documents",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte>(
                name: "BuyerType",
                table: "Documents",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "Documents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DocumentNumber",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UUID",
                table: "Documents",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_POSs_ClientId_ClientSecret",
                table: "POSs",
                columns: new[] { "ClientId", "ClientSecret" });

            migrationBuilder.CreateIndex(
                name: "IX_POSs_POSSerial_BranchId",
                table: "POSs",
                columns: new[] { "POSSerial", "BranchId" });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_UUID",
                table: "Documents",
                column: "UUID",
                unique: true);
        }
    }
}
