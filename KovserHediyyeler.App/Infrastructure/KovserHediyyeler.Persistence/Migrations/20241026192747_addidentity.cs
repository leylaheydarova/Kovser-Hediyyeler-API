using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KovserHediyyeler.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addidentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "IdentityUserToken<string>",
                newName: "UserTokens");

            migrationBuilder.RenameTable(
                name: "IdentityUserRole<string>",
                newName: "UserRoles");

            migrationBuilder.RenameTable(
                name: "IdentityUserLogin<string>",
                newName: "UserLogins");

            migrationBuilder.AddColumn<string>(
                name: "CustomerID",
                table: "ProductComments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomerID",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomerID",
                table: "CustomerBankCards",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WebUserID",
                table: "AddressWebUsers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "IdentityUserClaim<Guid>",
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
                    table.PrimaryKey("PK_IdentityUserClaim<Guid>", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserLogin<Guid>",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserLogin<Guid>", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserRole<Guid>",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserRole<Guid>", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserToken<Guid>",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserToken<Guid>", x => new { x.UserId, x.LoginProvider, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "WebUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BasketID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WishListID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WebUser_Baskets_BasketID",
                        column: x => x.BasketID,
                        principalTable: "Baskets",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_WebUser_WishLists_WishListID",
                        column: x => x.WishListID,
                        principalTable: "WishLists",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductComments_CustomerID",
                table: "ProductComments",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerID",
                table: "Orders",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerBankCards_CustomerID",
                table: "CustomerBankCards",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_AddressWebUsers_WebUserID",
                table: "AddressWebUsers",
                column: "WebUserID");

            migrationBuilder.CreateIndex(
                name: "IX_WebUser_BasketID",
                table: "WebUser",
                column: "BasketID");

            migrationBuilder.CreateIndex(
                name: "IX_WebUser_WishListID",
                table: "WebUser",
                column: "WishListID");

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

            migrationBuilder.DropTable(
                name: "IdentityUserClaim<Guid>");

            migrationBuilder.DropTable(
                name: "IdentityUserLogin<Guid>");

            migrationBuilder.DropTable(
                name: "IdentityUserRole<Guid>");

            migrationBuilder.DropTable(
                name: "IdentityUserToken<Guid>");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "WebUser");

            migrationBuilder.DropIndex(
                name: "IX_ProductComments_CustomerID",
                table: "ProductComments");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_CustomerBankCards_CustomerID",
                table: "CustomerBankCards");

            migrationBuilder.DropIndex(
                name: "IX_AddressWebUsers_WebUserID",
                table: "AddressWebUsers");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "ProductComments");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "CustomerBankCards");

            migrationBuilder.DropColumn(
                name: "WebUserID",
                table: "AddressWebUsers");

            migrationBuilder.RenameTable(
                name: "UserTokens",
                newName: "IdentityUserToken<string>");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                newName: "IdentityUserRole<string>");

            migrationBuilder.RenameTable(
                name: "UserLogins",
                newName: "IdentityUserLogin<string>");
        }
    }
}
