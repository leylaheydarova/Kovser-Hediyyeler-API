using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KovserHediyyeler.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class deletediscountcolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_Discounts_DiscountID",
                table: "Baskets");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Discounts_DiscountID",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Discounts_DiscountID",
                table: "Products");

            migrationBuilder.DropTable(
                name: "CategoryDiscount");

            migrationBuilder.DropTable(
                name: "DepartmentDiscount");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropIndex(
                name: "IX_Products_DiscountID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_DiscountID",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_Baskets_DiscountID",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "Icon",
                table: "SocialMedias");

            migrationBuilder.DropColumn(
                name: "DiscountID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DiscountID",
                table: "OrderDetails");

            migrationBuilder.AddColumn<double>(
                name: "DiscountedPrice",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountedPrice",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "SocialMedias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "DiscountID",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DiscountID",
                table: "OrderDetails",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Persentage = table.Column<double>(type: "float", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CategoryDiscount",
                columns: table => new
                {
                    CategoriesID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiscountsID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryDiscount", x => new { x.CategoriesID, x.DiscountsID });
                    table.ForeignKey(
                        name: "FK_CategoryDiscount_Categories_CategoriesID",
                        column: x => x.CategoriesID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryDiscount_Discounts_DiscountsID",
                        column: x => x.DiscountsID,
                        principalTable: "Discounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentDiscount",
                columns: table => new
                {
                    DepartmentsID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiscountsID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentDiscount", x => new { x.DepartmentsID, x.DiscountsID });
                    table.ForeignKey(
                        name: "FK_DepartmentDiscount_Departments_DepartmentsID",
                        column: x => x.DepartmentsID,
                        principalTable: "Departments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentDiscount_Discounts_DiscountsID",
                        column: x => x.DiscountsID,
                        principalTable: "Discounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_DiscountID",
                table: "Products",
                column: "DiscountID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_DiscountID",
                table: "OrderDetails",
                column: "DiscountID");

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_DiscountID",
                table: "Baskets",
                column: "DiscountID");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryDiscount_DiscountsID",
                table: "CategoryDiscount",
                column: "DiscountsID");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentDiscount_DiscountsID",
                table: "DepartmentDiscount",
                column: "DiscountsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_Discounts_DiscountID",
                table: "Baskets",
                column: "DiscountID",
                principalTable: "Discounts",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Discounts_DiscountID",
                table: "OrderDetails",
                column: "DiscountID",
                principalTable: "Discounts",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Discounts_DiscountID",
                table: "Products",
                column: "DiscountID",
                principalTable: "Discounts",
                principalColumn: "ID");
        }
    }
}
