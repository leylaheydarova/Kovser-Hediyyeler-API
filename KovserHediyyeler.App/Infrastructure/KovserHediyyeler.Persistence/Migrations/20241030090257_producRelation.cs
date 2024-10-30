using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KovserHediyyeler.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class producRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ColorCodeProductProperties_ProductProperties_ProductPropertyID",
                table: "ColorCodeProductProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductComments_WebUser_CustomerID",
                table: "ProductComments");

            migrationBuilder.AddForeignKey(
                name: "FK_ColorCodeProductProperties_ProductProperties_ProductPropertyID",
                table: "ColorCodeProductProperties",
                column: "ProductPropertyID",
                principalTable: "ProductProperties",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductComments_WebUser_CustomerID",
                table: "ProductComments",
                column: "CustomerID",
                principalTable: "WebUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ColorCodeProductProperties_ProductProperties_ProductPropertyID",
                table: "ColorCodeProductProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductComments_WebUser_CustomerID",
                table: "ProductComments");

            migrationBuilder.AddForeignKey(
                name: "FK_ColorCodeProductProperties_ProductProperties_ProductPropertyID",
                table: "ColorCodeProductProperties",
                column: "ProductPropertyID",
                principalTable: "ProductProperties",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductComments_WebUser_CustomerID",
                table: "ProductComments",
                column: "CustomerID",
                principalTable: "WebUser",
                principalColumn: "Id");
        }
    }
}
