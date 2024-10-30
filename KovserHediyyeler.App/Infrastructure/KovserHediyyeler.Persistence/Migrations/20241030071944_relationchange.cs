using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KovserHediyyeler.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class relationchange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WebUser_Baskets_BasketID",
                table: "WebUser");

            migrationBuilder.DropForeignKey(
                name: "FK_WebUser_WishLists_WishListID",
                table: "WebUser");

            migrationBuilder.DropIndex(
                name: "IX_WebUser_BasketID",
                table: "WebUser");

            migrationBuilder.DropIndex(
                name: "IX_WebUser_WishListID",
                table: "WebUser");

            migrationBuilder.DropColumn(
                name: "BasketID",
                table: "WebUser");

            migrationBuilder.DropColumn(
                name: "WishListID",
                table: "WebUser");

            migrationBuilder.AddColumn<string>(
                name: "CustomerID",
                table: "WishLists",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomerID",
                table: "Baskets",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_WishLists_CustomerID",
                table: "WishLists",
                column: "CustomerID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_CustomerID",
                table: "Baskets",
                column: "CustomerID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_WebUser_CustomerID",
                table: "Baskets",
                column: "CustomerID",
                principalTable: "WebUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WishLists_WebUser_CustomerID",
                table: "WishLists",
                column: "CustomerID",
                principalTable: "WebUser",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_WebUser_CustomerID",
                table: "Baskets");

            migrationBuilder.DropForeignKey(
                name: "FK_WishLists_WebUser_CustomerID",
                table: "WishLists");

            migrationBuilder.DropIndex(
                name: "IX_WishLists_CustomerID",
                table: "WishLists");

            migrationBuilder.DropIndex(
                name: "IX_Baskets_CustomerID",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "WishLists");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "Baskets");

            migrationBuilder.AddColumn<Guid>(
                name: "BasketID",
                table: "WebUser",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "WishListID",
                table: "WebUser",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WebUser_BasketID",
                table: "WebUser",
                column: "BasketID",
                unique: true,
                filter: "[BasketID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_WebUser_WishListID",
                table: "WebUser",
                column: "WishListID");

            migrationBuilder.AddForeignKey(
                name: "FK_WebUser_Baskets_BasketID",
                table: "WebUser",
                column: "BasketID",
                principalTable: "Baskets",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WebUser_WishLists_WishListID",
                table: "WebUser",
                column: "WishListID",
                principalTable: "WishLists",
                principalColumn: "ID");
        }
    }
}
