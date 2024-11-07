using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KovserHediyyeler.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeNamingBasket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeID",
                table: "Addresses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EmployeID",
                table: "Addresses",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
