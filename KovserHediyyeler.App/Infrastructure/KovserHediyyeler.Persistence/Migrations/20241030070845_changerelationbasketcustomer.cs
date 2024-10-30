using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KovserHediyyeler.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class changerelationbasketcustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WebUser_BasketID",
                table: "WebUser");

            migrationBuilder.CreateIndex(
                name: "IX_WebUser_BasketID",
                table: "WebUser",
                column: "BasketID",
                unique: true,
                filter: "[BasketID] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WebUser_BasketID",
                table: "WebUser");

            migrationBuilder.CreateIndex(
                name: "IX_WebUser_BasketID",
                table: "WebUser",
                column: "BasketID");
        }
    }
}
