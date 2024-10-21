using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KovserHediyyeler.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class crosstables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_Baskets_BasketID",
                table: "BasketItems");

            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_Products_ProductID",
                table: "BasketItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_WebUsers_CustomerID",
                table: "Baskets");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerBankCards_Banks_BankID",
                table: "CustomerBankCards");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerBankCards_WebUsers_CustomerID",
                table: "CustomerBankCards");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentID",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Positions_PositionID",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_Orders_ID",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_Products_ProductID",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Orders_OrderID",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Products_ProductID",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderPayments_Orders_ID",
                table: "OrderPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Shippings_ShippingID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Shops_ShopID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_WebUsers_CustomerID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductComments_Products_ProductID",
                table: "ProductComments");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductComments_WebUsers_CustomerID",
                table: "ProductComments");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryID",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Departments_DepartmentID",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Promotions_PromotionID",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Promotions_Categories_CategoryID",
                table: "Promotions");

            migrationBuilder.DropForeignKey(
                name: "FK_Promotions_Departments_DepartmentID",
                table: "Promotions");

            migrationBuilder.DropForeignKey(
                name: "FK_SocialMedias_Departments_DepartmentID",
                table: "SocialMedias");

            migrationBuilder.DropForeignKey(
                name: "FK_WebUsers_WishLists_WishListID",
                table: "WebUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_WishListItems_Products_ProductID",
                table: "WishListItems");

            migrationBuilder.DropForeignKey(
                name: "FK_WishListItems_WishLists_WishListID",
                table: "WishListItems");

            migrationBuilder.DropTable(
                name: "AddressWebUser");

            migrationBuilder.DropTable(
                name: "CategoryDepartment");

            migrationBuilder.DropTable(
                name: "ColorCodeProductProperty");

            migrationBuilder.DropTable(
                name: "DepartmentPosition");

            migrationBuilder.DropTable(
                name: "ProductProductProperty");

            migrationBuilder.DropTable(
                name: "ProductShop");

            migrationBuilder.DropIndex(
                name: "IX_Promotions_CategoryID",
                table: "Promotions");

            migrationBuilder.DropIndex(
                name: "IX_Promotions_DepartmentID",
                table: "Promotions");

            migrationBuilder.DropIndex(
                name: "IX_Baskets_CustomerID",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "DepartmentID",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "OrderID",
                table: "OrderPayments");

            migrationBuilder.DropColumn(
                name: "OrderID",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "DiscountID",
                table: "Baskets");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "WebUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "WebUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "WebUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductID",
                table: "ProductProperties",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "AddressWebUsers",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WebUserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressWebUsers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AddressWebUsers_Addresses_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Addresses",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_AddressWebUsers_WebUsers_WebUserID",
                        column: x => x.WebUserID,
                        principalTable: "WebUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CategoryDepartments",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartmentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryDepartments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CategoryDepartments_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_CategoryDepartments_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "CategoryPromotions",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PromotionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryPromotions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CategoryPromotions_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_CategoryPromotions_Promotions_PromotionID",
                        column: x => x.PromotionID,
                        principalTable: "Promotions",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ColorCodeProductProperties",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ColorCodeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductPropertyID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorCodeProductProperties", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ColorCodeProductProperties_Colors_ColorCodeID",
                        column: x => x.ColorCodeID,
                        principalTable: "Colors",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ColorCodeProductProperties_ProductProperties_ProductPropertyID",
                        column: x => x.ProductPropertyID,
                        principalTable: "ProductProperties",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "DepartmentPositions",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartmentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PositionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentPositions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DepartmentPositions_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_DepartmentPositions_Positions_PositionID",
                        column: x => x.PositionID,
                        principalTable: "Positions",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "DepartmentPromotions",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartmentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PromotionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentPromotions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DepartmentPromotions_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_DepartmentPromotions_Promotions_PromotionID",
                        column: x => x.PromotionID,
                        principalTable: "Promotions",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ProductShops",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShopID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductShops", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductShops_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ProductShops_Shops_ShopID",
                        column: x => x.ShopID,
                        principalTable: "Shops",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_WebUsers_BasketID",
                table: "WebUsers",
                column: "BasketID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProperties_ProductID",
                table: "ProductProperties",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_InvoiceFileId",
                table: "Orders",
                column: "InvoiceFileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderPaymentID",
                table: "Orders",
                column: "OrderPaymentID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AddressWebUsers_AddressID",
                table: "AddressWebUsers",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_AddressWebUsers_WebUserID",
                table: "AddressWebUsers",
                column: "WebUserID");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryDepartments_CategoryID",
                table: "CategoryDepartments",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryDepartments_DepartmentID",
                table: "CategoryDepartments",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryPromotions_CategoryID",
                table: "CategoryPromotions",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryPromotions_PromotionID",
                table: "CategoryPromotions",
                column: "PromotionID");

            migrationBuilder.CreateIndex(
                name: "IX_ColorCodeProductProperties_ColorCodeID",
                table: "ColorCodeProductProperties",
                column: "ColorCodeID");

            migrationBuilder.CreateIndex(
                name: "IX_ColorCodeProductProperties_ProductPropertyID",
                table: "ColorCodeProductProperties",
                column: "ProductPropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentPositions_DepartmentID",
                table: "DepartmentPositions",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentPositions_PositionID",
                table: "DepartmentPositions",
                column: "PositionID");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentPromotions_DepartmentID",
                table: "DepartmentPromotions",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentPromotions_PromotionID",
                table: "DepartmentPromotions",
                column: "PromotionID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductShops_ProductID",
                table: "ProductShops",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductShops_ShopID",
                table: "ProductShops",
                column: "ShopID");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_Baskets_BasketID",
                table: "BasketItems",
                column: "BasketID",
                principalTable: "Baskets",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_Products_ProductID",
                table: "BasketItems",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerBankCards_Banks_BankID",
                table: "CustomerBankCards",
                column: "BankID",
                principalTable: "Banks",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerBankCards_WebUsers_CustomerID",
                table: "CustomerBankCards",
                column: "CustomerID",
                principalTable: "WebUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentID",
                table: "Employees",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Positions_PositionID",
                table: "Employees",
                column: "PositionID",
                principalTable: "Positions",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Products_ProductID",
                table: "Files",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Orders_OrderID",
                table: "OrderDetails",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Products_ProductID",
                table: "OrderDetails",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Files_InvoiceFileId",
                table: "Orders",
                column: "InvoiceFileId",
                principalTable: "Files",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderPayments_OrderPaymentID",
                table: "Orders",
                column: "OrderPaymentID",
                principalTable: "OrderPayments",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Shippings_ShippingID",
                table: "Orders",
                column: "ShippingID",
                principalTable: "Shippings",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Shops_ShopID",
                table: "Orders",
                column: "ShopID",
                principalTable: "Shops",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_WebUsers_CustomerID",
                table: "Orders",
                column: "CustomerID",
                principalTable: "WebUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductComments_Products_ProductID",
                table: "ProductComments",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductComments_WebUsers_CustomerID",
                table: "ProductComments",
                column: "CustomerID",
                principalTable: "WebUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProperties_Products_ProductID",
                table: "ProductProperties",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryID",
                table: "Products",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Departments_DepartmentID",
                table: "Products",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Promotions_PromotionID",
                table: "Products",
                column: "PromotionID",
                principalTable: "Promotions",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_SocialMedias_Departments_DepartmentID",
                table: "SocialMedias",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WebUsers_Baskets_BasketID",
                table: "WebUsers",
                column: "BasketID",
                principalTable: "Baskets",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WebUsers_WishLists_WishListID",
                table: "WebUsers",
                column: "WishListID",
                principalTable: "WishLists",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WishListItems_Products_ProductID",
                table: "WishListItems",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WishListItems_WishLists_WishListID",
                table: "WishListItems",
                column: "WishListID",
                principalTable: "WishLists",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_Baskets_BasketID",
                table: "BasketItems");

            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_Products_ProductID",
                table: "BasketItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerBankCards_Banks_BankID",
                table: "CustomerBankCards");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerBankCards_WebUsers_CustomerID",
                table: "CustomerBankCards");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentID",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Positions_PositionID",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_Products_ProductID",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Orders_OrderID",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Products_ProductID",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Files_InvoiceFileId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderPayments_OrderPaymentID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Shippings_ShippingID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Shops_ShopID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_WebUsers_CustomerID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductComments_Products_ProductID",
                table: "ProductComments");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductComments_WebUsers_CustomerID",
                table: "ProductComments");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductProperties_Products_ProductID",
                table: "ProductProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryID",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Departments_DepartmentID",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Promotions_PromotionID",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_SocialMedias_Departments_DepartmentID",
                table: "SocialMedias");

            migrationBuilder.DropForeignKey(
                name: "FK_WebUsers_Baskets_BasketID",
                table: "WebUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_WebUsers_WishLists_WishListID",
                table: "WebUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_WishListItems_Products_ProductID",
                table: "WishListItems");

            migrationBuilder.DropForeignKey(
                name: "FK_WishListItems_WishLists_WishListID",
                table: "WishListItems");

            migrationBuilder.DropTable(
                name: "AddressWebUsers");

            migrationBuilder.DropTable(
                name: "CategoryDepartments");

            migrationBuilder.DropTable(
                name: "CategoryPromotions");

            migrationBuilder.DropTable(
                name: "ColorCodeProductProperties");

            migrationBuilder.DropTable(
                name: "DepartmentPositions");

            migrationBuilder.DropTable(
                name: "DepartmentPromotions");

            migrationBuilder.DropTable(
                name: "ProductShops");

            migrationBuilder.DropIndex(
                name: "IX_WebUsers_BasketID",
                table: "WebUsers");

            migrationBuilder.DropIndex(
                name: "IX_ProductProperties_ProductID",
                table: "ProductProperties");

            migrationBuilder.DropIndex(
                name: "IX_Orders_InvoiceFileId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderPaymentID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "WebUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "WebUsers");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "WebUsers");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "ProductProperties");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryID",
                table: "Promotions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentID",
                table: "Promotions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrderID",
                table: "OrderPayments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "OrderID",
                table: "Files",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerID",
                table: "Baskets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DiscountID",
                table: "Baskets",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AddressWebUser",
                columns: table => new
                {
                    AddressID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WebUsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressWebUser", x => new { x.AddressID, x.WebUsersId });
                    table.ForeignKey(
                        name: "FK_AddressWebUser_Addresses_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Addresses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AddressWebUser_WebUsers_WebUsersId",
                        column: x => x.WebUsersId,
                        principalTable: "WebUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryDepartment",
                columns: table => new
                {
                    CategoriesID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartmentsID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryDepartment", x => new { x.CategoriesID, x.DepartmentsID });
                    table.ForeignKey(
                        name: "FK_CategoryDepartment_Categories_CategoriesID",
                        column: x => x.CategoriesID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryDepartment_Departments_DepartmentsID",
                        column: x => x.DepartmentsID,
                        principalTable: "Departments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ColorCodeProductProperty",
                columns: table => new
                {
                    ColorsID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PropertiesID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorCodeProductProperty", x => new { x.ColorsID, x.PropertiesID });
                    table.ForeignKey(
                        name: "FK_ColorCodeProductProperty_Colors_ColorsID",
                        column: x => x.ColorsID,
                        principalTable: "Colors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ColorCodeProductProperty_ProductProperties_PropertiesID",
                        column: x => x.PropertiesID,
                        principalTable: "ProductProperties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentPosition",
                columns: table => new
                {
                    DepartmentsID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PositionsID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentPosition", x => new { x.DepartmentsID, x.PositionsID });
                    table.ForeignKey(
                        name: "FK_DepartmentPosition_Departments_DepartmentsID",
                        column: x => x.DepartmentsID,
                        principalTable: "Departments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentPosition_Positions_PositionsID",
                        column: x => x.PositionsID,
                        principalTable: "Positions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductProductProperty",
                columns: table => new
                {
                    ProductsID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PropertiesID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProductProperty", x => new { x.ProductsID, x.PropertiesID });
                    table.ForeignKey(
                        name: "FK_ProductProductProperty_ProductProperties_PropertiesID",
                        column: x => x.PropertiesID,
                        principalTable: "ProductProperties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductProductProperty_Products_ProductsID",
                        column: x => x.ProductsID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductShop",
                columns: table => new
                {
                    ProductsID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShopsID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductShop", x => new { x.ProductsID, x.ShopsID });
                    table.ForeignKey(
                        name: "FK_ProductShop_Products_ProductsID",
                        column: x => x.ProductsID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductShop_Shops_ShopsID",
                        column: x => x.ShopsID,
                        principalTable: "Shops",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_CategoryID",
                table: "Promotions",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_DepartmentID",
                table: "Promotions",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_CustomerID",
                table: "Baskets",
                column: "CustomerID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AddressWebUser_WebUsersId",
                table: "AddressWebUser",
                column: "WebUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryDepartment_DepartmentsID",
                table: "CategoryDepartment",
                column: "DepartmentsID");

            migrationBuilder.CreateIndex(
                name: "IX_ColorCodeProductProperty_PropertiesID",
                table: "ColorCodeProductProperty",
                column: "PropertiesID");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentPosition_PositionsID",
                table: "DepartmentPosition",
                column: "PositionsID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProductProperty_PropertiesID",
                table: "ProductProductProperty",
                column: "PropertiesID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductShop_ShopsID",
                table: "ProductShop",
                column: "ShopsID");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_Baskets_BasketID",
                table: "BasketItems",
                column: "BasketID",
                principalTable: "Baskets",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_Products_ProductID",
                table: "BasketItems",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_WebUsers_CustomerID",
                table: "Baskets",
                column: "CustomerID",
                principalTable: "WebUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerBankCards_Banks_BankID",
                table: "CustomerBankCards",
                column: "BankID",
                principalTable: "Banks",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerBankCards_WebUsers_CustomerID",
                table: "CustomerBankCards",
                column: "CustomerID",
                principalTable: "WebUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentID",
                table: "Employees",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Positions_PositionID",
                table: "Employees",
                column: "PositionID",
                principalTable: "Positions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Orders_ID",
                table: "Files",
                column: "ID",
                principalTable: "Orders",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Products_ProductID",
                table: "Files",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Orders_OrderID",
                table: "OrderDetails",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Products_ProductID",
                table: "OrderDetails",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPayments_Orders_ID",
                table: "OrderPayments",
                column: "ID",
                principalTable: "Orders",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Shippings_ShippingID",
                table: "Orders",
                column: "ShippingID",
                principalTable: "Shippings",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Shops_ShopID",
                table: "Orders",
                column: "ShopID",
                principalTable: "Shops",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_WebUsers_CustomerID",
                table: "Orders",
                column: "CustomerID",
                principalTable: "WebUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductComments_Products_ProductID",
                table: "ProductComments",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductComments_WebUsers_CustomerID",
                table: "ProductComments",
                column: "CustomerID",
                principalTable: "WebUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryID",
                table: "Products",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Departments_DepartmentID",
                table: "Products",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Promotions_PromotionID",
                table: "Products",
                column: "PromotionID",
                principalTable: "Promotions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Promotions_Categories_CategoryID",
                table: "Promotions",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Promotions_Departments_DepartmentID",
                table: "Promotions",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_SocialMedias_Departments_DepartmentID",
                table: "SocialMedias",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WebUsers_WishLists_WishListID",
                table: "WebUsers",
                column: "WishListID",
                principalTable: "WishLists",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WishListItems_Products_ProductID",
                table: "WishListItems",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WishListItems_WishLists_WishListID",
                table: "WishListItems",
                column: "WishListID",
                principalTable: "WishLists",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
