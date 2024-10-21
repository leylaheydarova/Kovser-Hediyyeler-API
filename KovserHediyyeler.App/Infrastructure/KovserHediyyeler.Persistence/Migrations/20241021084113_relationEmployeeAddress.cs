using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KovserHediyyeler.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class relationEmployeeAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Employees_EmployeeID",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_EmployeeID",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "EmployeeID",
                table: "Addresses");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_EmployeID",
                table: "Addresses",
                column: "EmployeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Employees_EmployeID",
                table: "Addresses",
                column: "EmployeID",
                principalTable: "Employees",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Employees_EmployeID",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_EmployeID",
                table: "Addresses");

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeID",
                table: "Addresses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_EmployeeID",
                table: "Addresses",
                column: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Employees_EmployeeID",
                table: "Addresses",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "ID");
        }
    }
}
