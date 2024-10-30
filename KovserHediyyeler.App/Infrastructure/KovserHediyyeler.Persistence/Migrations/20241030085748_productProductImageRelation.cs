using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KovserHediyyeler.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class productProductImageRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Products_ProductID",
                table: "Files");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Products_ProductID",
                table: "Files",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Products_ProductID",
                table: "Files");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Products_ProductID",
                table: "Files",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID");
        }
    }
}
