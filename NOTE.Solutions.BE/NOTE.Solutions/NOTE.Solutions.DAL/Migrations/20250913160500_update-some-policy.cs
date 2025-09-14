using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOTE.Solutions.DAL.Migrations
{
    /// <inheritdoc />
    public partial class updatesomepolicy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActiveCodes_ApplicationUsers_CreatedById",
                table: "ActiveCodes");

            migrationBuilder.DropForeignKey(
                name: "FK_ActiveCodes_ApplicationUsers_UpdatedById",
                table: "ActiveCodes");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_ApplicationUsers_CreatedById",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_ApplicationUsers_UpdatedById",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_ApplicationUsers_CreatedById",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_ApplicationUsers_UpdatedById",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Governorates_ApplicationUsers_CreatedById",
                table: "Governorates");

            migrationBuilder.DropForeignKey(
                name: "FK_Governorates_ApplicationUsers_UpdatedById",
                table: "Governorates");

            migrationBuilder.DropIndex(
                name: "IX_Governorates_CreatedById",
                table: "Governorates");

            migrationBuilder.DropIndex(
                name: "IX_Governorates_UpdatedById",
                table: "Governorates");

            migrationBuilder.DropIndex(
                name: "IX_Countries_CreatedById",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Countries_UpdatedById",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Cities_CreatedById",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Cities_UpdatedById",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_ActiveCodes_CreatedById",
                table: "ActiveCodes");

            migrationBuilder.DropIndex(
                name: "IX_ActiveCodes_UpdatedById",
                table: "ActiveCodes");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Governorates");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Governorates");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Governorates");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Governorates");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ActiveCodes");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "ActiveCodes");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "ActiveCodes");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "ActiveCodes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Governorates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Governorates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Governorates",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedById",
                table: "Governorates",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Countries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Countries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Countries",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedById",
                table: "Countries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Cities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Cities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Cities",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedById",
                table: "Cities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ActiveCodes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "ActiveCodes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "ActiveCodes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedById",
                table: "ActiveCodes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Governorates_CreatedById",
                table: "Governorates",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Governorates_UpdatedById",
                table: "Governorates",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CreatedById",
                table: "Countries",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_UpdatedById",
                table: "Countries",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CreatedById",
                table: "Cities",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_UpdatedById",
                table: "Cities",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ActiveCodes_CreatedById",
                table: "ActiveCodes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ActiveCodes_UpdatedById",
                table: "ActiveCodes",
                column: "UpdatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_ActiveCodes_ApplicationUsers_CreatedById",
                table: "ActiveCodes",
                column: "CreatedById",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActiveCodes_ApplicationUsers_UpdatedById",
                table: "ActiveCodes",
                column: "UpdatedById",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_ApplicationUsers_CreatedById",
                table: "Cities",
                column: "CreatedById",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_ApplicationUsers_UpdatedById",
                table: "Cities",
                column: "UpdatedById",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_ApplicationUsers_CreatedById",
                table: "Countries",
                column: "CreatedById",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_ApplicationUsers_UpdatedById",
                table: "Countries",
                column: "UpdatedById",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Governorates_ApplicationUsers_CreatedById",
                table: "Governorates",
                column: "CreatedById",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Governorates_ApplicationUsers_UpdatedById",
                table: "Governorates",
                column: "UpdatedById",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
