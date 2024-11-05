using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KovserHediyyeler.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class relationadding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductShops_Shops_ShopID",
                table: "ProductShops");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductShops_Shops_ShopID",
                table: "ProductShops",
                column: "ShopID",
                principalTable: "Shops",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductShops_Shops_ShopID",
                table: "ProductShops");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductShops_Shops_ShopID",
                table: "ProductShops",
                column: "ShopID",
                principalTable: "Shops",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
