using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOTE.Solutions.DAL.Migrations
{
    /// <inheritdoc />
    public partial class asdasda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BuyerId",
                table: "Documents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HeaderId",
                table: "Documents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Documents_BuyerId",
                table: "Documents",
                column: "BuyerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documents_HeaderId",
                table: "Documents",
                column: "HeaderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_DocumentBuyer_BuyerId",
                table: "Documents",
                column: "BuyerId",
                principalTable: "DocumentBuyer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_DocumentHeader_HeaderId",
                table: "Documents",
                column: "HeaderId",
                principalTable: "DocumentHeader",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_DocumentBuyer_BuyerId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_DocumentHeader_HeaderId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_BuyerId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_HeaderId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "BuyerId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "HeaderId",
                table: "Documents");
        }
    }
}
