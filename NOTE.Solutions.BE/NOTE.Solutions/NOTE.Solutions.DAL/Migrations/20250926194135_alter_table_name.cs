
#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace NOTE.Solutions.DAL.Migrations
{
    /// <inheritdoc />
    public partial class alter_table_name : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_AspNetUsers_ApplicationUserId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_AspNetUsers_CreatedById",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_AspNetUsers_UpdatedById",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Branches_BranchId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Manager_AspNetUsers_ApplicationUserId",
                table: "Manager");

            migrationBuilder.DropForeignKey(
                name: "FK_Manager_Companies_CompanyId",
                table: "Manager");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Manager",
                table: "Manager");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.RenameTable(
                name: "Manager",
                newName: "Managers");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "Employees");

            migrationBuilder.RenameIndex(
                name: "IX_Manager_CompanyId",
                table: "Managers",
                newName: "IX_Managers_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Manager_ApplicationUserId",
                table: "Managers",
                newName: "IX_Managers_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_UpdatedById",
                table: "Employees",
                newName: "IX_Employees_UpdatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_CreatedById",
                table: "Employees",
                newName: "IX_Employees_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_BranchId",
                table: "Employees",
                newName: "IX_Employees_BranchId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_ApplicationUserId",
                table: "Employees",
                newName: "IX_Employees_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Managers",
                table: "Managers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_AspNetUsers_ApplicationUserId",
                table: "Employees",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_AspNetUsers_CreatedById",
                table: "Employees",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_AspNetUsers_UpdatedById",
                table: "Employees",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Branches_BranchId",
                table: "Employees",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Managers_AspNetUsers_ApplicationUserId",
                table: "Managers",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Managers_Companies_CompanyId",
                table: "Managers",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_AspNetUsers_ApplicationUserId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_AspNetUsers_CreatedById",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_AspNetUsers_UpdatedById",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Branches_BranchId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Managers_AspNetUsers_ApplicationUserId",
                table: "Managers");

            migrationBuilder.DropForeignKey(
                name: "FK_Managers_Companies_CompanyId",
                table: "Managers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Managers",
                table: "Managers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "Managers",
                newName: "Manager");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Employee");

            migrationBuilder.RenameIndex(
                name: "IX_Managers_CompanyId",
                table: "Manager",
                newName: "IX_Manager_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Managers_ApplicationUserId",
                table: "Manager",
                newName: "IX_Manager_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_UpdatedById",
                table: "Employee",
                newName: "IX_Employee_UpdatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_CreatedById",
                table: "Employee",
                newName: "IX_Employee_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_BranchId",
                table: "Employee",
                newName: "IX_Employee_BranchId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_ApplicationUserId",
                table: "Employee",
                newName: "IX_Employee_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Manager",
                table: "Manager",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_AspNetUsers_ApplicationUserId",
                table: "Employee",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_AspNetUsers_CreatedById",
                table: "Employee",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_AspNetUsers_UpdatedById",
                table: "Employee",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Branches_BranchId",
                table: "Employee",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Manager_AspNetUsers_ApplicationUserId",
                table: "Manager",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Manager_Companies_CompanyId",
                table: "Manager",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
