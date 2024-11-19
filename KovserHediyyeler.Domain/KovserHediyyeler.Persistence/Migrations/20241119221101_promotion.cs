using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KovserHediyyeler.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class promotion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductShop_Products_ProductsID",
                table: "ProductShop");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductShop_Shops_ShopsID",
                table: "ProductShop");

            migrationBuilder.RenameColumn(
                name: "ShopsID",
                table: "ProductShop",
                newName: "ShopID");

            migrationBuilder.RenameColumn(
                name: "ProductsID",
                table: "ProductShop",
                newName: "ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_ProductShop_ShopsID",
                table: "ProductShop",
                newName: "IX_ProductShop_ShopID");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Colors",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "HexCode",
                table: "Colors",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: true),
                    DiscountedPrice = table.Column<double>(type: "float", nullable: true),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colors_HexCode",
                table: "Colors",
                column: "HexCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Colors_Name",
                table: "Colors",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductShop_Products_ProductID",
                table: "ProductShop",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductShop_Shops_ShopID",
                table: "ProductShop",
                column: "ShopID",
                principalTable: "Shops",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductShop_Products_ProductID",
                table: "ProductShop");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductShop_Shops_ShopID",
                table: "ProductShop");

            migrationBuilder.DropTable(
                name: "Promotions");

            migrationBuilder.DropIndex(
                name: "IX_Colors_HexCode",
                table: "Colors");

            migrationBuilder.DropIndex(
                name: "IX_Colors_Name",
                table: "Colors");

            migrationBuilder.DropColumn(
                name: "District",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "ShopID",
                table: "ProductShop",
                newName: "ShopsID");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "ProductShop",
                newName: "ProductsID");

            migrationBuilder.RenameIndex(
                name: "IX_ProductShop_ShopID",
                table: "ProductShop",
                newName: "IX_ProductShop_ShopsID");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Colors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "HexCode",
                table: "Colors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductShop_Products_ProductsID",
                table: "ProductShop",
                column: "ProductsID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductShop_Shops_ShopsID",
                table: "ProductShop",
                column: "ShopsID",
                principalTable: "Shops",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
