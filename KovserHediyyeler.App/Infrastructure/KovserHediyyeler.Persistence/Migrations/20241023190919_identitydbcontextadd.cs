using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KovserHediyyeler.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class identitydbcontextadd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressWebUsers_WebUsers_WebUserID",
                table: "AddressWebUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerBankCards_WebUsers_CustomerID",
                table: "CustomerBankCards");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_WebUsers_CustomerID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductComments_WebUsers_CustomerID",
                table: "ProductComments");

            migrationBuilder.DropForeignKey(
                name: "FK_WebUsers_Baskets_BasketID",
                table: "WebUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_WebUsers_WishLists_WishListID",
                table: "WebUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WebUsers",
                table: "WebUsers");

            migrationBuilder.RenameTable(
                name: "WebUsers",
                newName: "WebUser");

            migrationBuilder.RenameIndex(
                name: "IX_WebUsers_WishListID",
                table: "WebUser",
                newName: "IX_WebUser_WishListID");

            migrationBuilder.RenameIndex(
                name: "IX_WebUsers_BasketID",
                table: "WebUser",
                newName: "IX_WebUser_BasketID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WebUser",
                table: "WebUser",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AddressWebUsers_WebUser_WebUserID",
                table: "AddressWebUsers",
                column: "WebUserID",
                principalTable: "WebUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerBankCards_WebUser_CustomerID",
                table: "CustomerBankCards",
                column: "CustomerID",
                principalTable: "WebUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_WebUser_CustomerID",
                table: "Orders",
                column: "CustomerID",
                principalTable: "WebUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductComments_WebUser_CustomerID",
                table: "ProductComments",
                column: "CustomerID",
                principalTable: "WebUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WebUser_Baskets_BasketID",
                table: "WebUser",
                column: "BasketID",
                principalTable: "Baskets",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WebUser_WishLists_WishListID",
                table: "WebUser",
                column: "WishListID",
                principalTable: "WishLists",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressWebUsers_WebUser_WebUserID",
                table: "AddressWebUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerBankCards_WebUser_CustomerID",
                table: "CustomerBankCards");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_WebUser_CustomerID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductComments_WebUser_CustomerID",
                table: "ProductComments");

            migrationBuilder.DropForeignKey(
                name: "FK_WebUser_Baskets_BasketID",
                table: "WebUser");

            migrationBuilder.DropForeignKey(
                name: "FK_WebUser_WishLists_WishListID",
                table: "WebUser");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WebUser",
                table: "WebUser");

            migrationBuilder.RenameTable(
                name: "WebUser",
                newName: "WebUsers");

            migrationBuilder.RenameIndex(
                name: "IX_WebUser_WishListID",
                table: "WebUsers",
                newName: "IX_WebUsers_WishListID");

            migrationBuilder.RenameIndex(
                name: "IX_WebUser_BasketID",
                table: "WebUsers",
                newName: "IX_WebUsers_BasketID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WebUsers",
                table: "WebUsers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AddressWebUsers_WebUsers_WebUserID",
                table: "AddressWebUsers",
                column: "WebUserID",
                principalTable: "WebUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerBankCards_WebUsers_CustomerID",
                table: "CustomerBankCards",
                column: "CustomerID",
                principalTable: "WebUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_WebUsers_CustomerID",
                table: "Orders",
                column: "CustomerID",
                principalTable: "WebUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductComments_WebUsers_CustomerID",
                table: "ProductComments",
                column: "CustomerID",
                principalTable: "WebUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WebUsers_Baskets_BasketID",
                table: "WebUsers",
                column: "BasketID",
                principalTable: "Baskets",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WebUsers_WishLists_WishListID",
                table: "WebUsers",
                column: "WishListID",
                principalTable: "WishLists",
                principalColumn: "ID");
        }
    }
}
