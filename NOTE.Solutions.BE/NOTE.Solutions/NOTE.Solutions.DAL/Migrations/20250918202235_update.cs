using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOTE.Solutions.DAL.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_POS_ApplicationUsers_CreatedById",
                table: "POS");

            migrationBuilder.DropForeignKey(
                name: "FK_POS_ApplicationUsers_UpdatedById",
                table: "POS");

            migrationBuilder.DropForeignKey(
                name: "FK_POS_Branches_BranchId",
                table: "POS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_POS",
                table: "POS");

            migrationBuilder.RenameTable(
                name: "POS",
                newName: "POSs");

            migrationBuilder.RenameIndex(
                name: "IX_POS_UpdatedById",
                table: "POSs",
                newName: "IX_POSs_UpdatedById");

            migrationBuilder.RenameIndex(
                name: "IX_POS_POSSerial_BranchId",
                table: "POSs",
                newName: "IX_POSs_POSSerial_BranchId");

            migrationBuilder.RenameIndex(
                name: "IX_POS_CreatedById",
                table: "POSs",
                newName: "IX_POSs_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_POS_ClientId_ClientSecret",
                table: "POSs",
                newName: "IX_POSs_ClientId_ClientSecret");

            migrationBuilder.RenameIndex(
                name: "IX_POS_BranchId",
                table: "POSs",
                newName: "IX_POSs_BranchId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_POSs",
                table: "POSs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_POSs_ApplicationUsers_CreatedById",
                table: "POSs",
                column: "CreatedById",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_POSs_ApplicationUsers_UpdatedById",
                table: "POSs",
                column: "UpdatedById",
                principalTable: "ApplicationUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_POSs_Branches_BranchId",
                table: "POSs",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_POSs_ApplicationUsers_CreatedById",
                table: "POSs");

            migrationBuilder.DropForeignKey(
                name: "FK_POSs_ApplicationUsers_UpdatedById",
                table: "POSs");

            migrationBuilder.DropForeignKey(
                name: "FK_POSs_Branches_BranchId",
                table: "POSs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_POSs",
                table: "POSs");

            migrationBuilder.RenameTable(
                name: "POSs",
                newName: "POS");

            migrationBuilder.RenameIndex(
                name: "IX_POSs_UpdatedById",
                table: "POS",
                newName: "IX_POS_UpdatedById");

            migrationBuilder.RenameIndex(
                name: "IX_POSs_POSSerial_BranchId",
                table: "POS",
                newName: "IX_POS_POSSerial_BranchId");

            migrationBuilder.RenameIndex(
                name: "IX_POSs_CreatedById",
                table: "POS",
                newName: "IX_POS_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_POSs_ClientId_ClientSecret",
                table: "POS",
                newName: "IX_POS_ClientId_ClientSecret");

            migrationBuilder.RenameIndex(
                name: "IX_POSs_BranchId",
                table: "POS",
                newName: "IX_POS_BranchId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_POS",
                table: "POS",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_POS_ApplicationUsers_CreatedById",
                table: "POS",
                column: "CreatedById",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_POS_ApplicationUsers_UpdatedById",
                table: "POS",
                column: "UpdatedById",
                principalTable: "ApplicationUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_POS_Branches_BranchId",
                table: "POS",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
