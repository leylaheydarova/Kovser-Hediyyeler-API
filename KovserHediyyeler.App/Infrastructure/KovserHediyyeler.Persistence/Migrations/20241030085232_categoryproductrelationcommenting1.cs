using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KovserHediyyeler.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class categoryproductrelationcommenting1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductShops_Products_ProductID",
                table: "ProductShops");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductShops_Shops_ShopID",
                table: "ProductShops");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductShops_Products_ProductID",
                table: "ProductShops",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductShops_Shops_ShopID",
                table: "ProductShops",
                column: "ShopID",
                principalTable: "Shops",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductShops_Products_ProductID",
                table: "ProductShops");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductShops_Shops_ShopID",
                table: "ProductShops");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductShops_Products_ProductID",
                table: "ProductShops",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductShops_Shops_ShopID",
                table: "ProductShops",
                column: "ShopID",
                principalTable: "Shops",
                principalColumn: "ID");
        }
    }
}
