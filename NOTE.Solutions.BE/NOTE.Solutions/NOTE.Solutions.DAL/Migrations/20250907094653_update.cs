using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NOTE.Solutions.DAL.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationRoles_ApplicationUsers_CreatedById",
                table: "ApplicationRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationRoles_ApplicationUsers_UpdatedById",
                table: "ApplicationRoles");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationRoles_CreatedById",
                table: "ApplicationRoles");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationRoles_UpdatedById",
                table: "ApplicationRoles");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ApplicationRoles");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "ApplicationRoles");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "ApplicationRoles");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "ApplicationRoles");

            migrationBuilder.InsertData(
                table: "ApplicationRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ApplicationRoles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "ApplicationRoles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "ApplicationRoles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedById",
                table: "ApplicationRoles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationRoles_CreatedById",
                table: "ApplicationRoles",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationRoles_UpdatedById",
                table: "ApplicationRoles",
                column: "UpdatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationRoles_ApplicationUsers_CreatedById",
                table: "ApplicationRoles",
                column: "CreatedById",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationRoles_ApplicationUsers_UpdatedById",
                table: "ApplicationRoles",
                column: "UpdatedById",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
