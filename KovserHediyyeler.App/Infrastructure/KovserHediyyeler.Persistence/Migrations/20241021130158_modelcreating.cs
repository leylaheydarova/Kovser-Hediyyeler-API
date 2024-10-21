using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KovserHediyyeler.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class modelcreating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WebUsers_Baskets_BasketID",
                table: "WebUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_WebUsers_Baskets_BasketID",
                table: "WebUsers",
                column: "BasketID",
                principalTable: "Baskets",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WebUsers_Baskets_BasketID",
                table: "WebUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_WebUsers_Baskets_BasketID",
                table: "WebUsers",
                column: "BasketID",
                principalTable: "Baskets",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
