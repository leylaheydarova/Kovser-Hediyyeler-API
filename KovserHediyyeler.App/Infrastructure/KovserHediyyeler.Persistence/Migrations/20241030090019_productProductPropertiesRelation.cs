using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KovserHediyyeler.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class productProductPropertiesRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductComments_Products_ProductID",
                table: "ProductComments");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductProperties_Products_ProductID",
                table: "ProductProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_WishListItems_Products_ProductID",
                table: "WishListItems");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductComments_Products_ProductID",
                table: "ProductComments",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProperties_Products_ProductID",
                table: "ProductProperties",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WishListItems_Products_ProductID",
                table: "WishListItems",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductComments_Products_ProductID",
                table: "ProductComments");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductProperties_Products_ProductID",
                table: "ProductProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_WishListItems_Products_ProductID",
                table: "WishListItems");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductComments_Products_ProductID",
                table: "ProductComments",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProperties_Products_ProductID",
                table: "ProductProperties",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WishListItems_Products_ProductID",
                table: "WishListItems",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID");
        }
    }
}
