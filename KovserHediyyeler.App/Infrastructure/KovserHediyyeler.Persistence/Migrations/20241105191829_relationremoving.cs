using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KovserHediyyeler.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class relationremoving : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Baskets_BasketID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_BasketID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BasketID",
                table: "Orders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BasketID",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BasketID",
                table: "Orders",
                column: "BasketID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Baskets_BasketID",
                table: "Orders",
                column: "BasketID",
                principalTable: "Baskets",
                principalColumn: "ID");
        }
    }
}
