using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KovserHediyyeler.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddressWebUserRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressWebUsers");

            migrationBuilder.CreateTable(
                name: "AddressWebUser",
                columns: table => new
                {
                    AddressesID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WebUsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressWebUser", x => new { x.AddressesID, x.WebUsersId });
                    table.ForeignKey(
                        name: "FK_AddressWebUser_Addresses_AddressesID",
                        column: x => x.AddressesID,
                        principalTable: "Addresses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AddressWebUser_WebUser_WebUsersId",
                        column: x => x.WebUsersId,
                        principalTable: "WebUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddressWebUser_WebUsersId",
                table: "AddressWebUser",
                column: "WebUsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressWebUser");

            migrationBuilder.CreateTable(
                name: "AddressWebUsers",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WebUserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                        name: "FK_AddressWebUsers_WebUser_WebUserID",
                        column: x => x.WebUserID,
                        principalTable: "WebUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddressWebUsers_AddressID",
                table: "AddressWebUsers",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_AddressWebUsers_WebUserID",
                table: "AddressWebUsers",
                column: "WebUserID");
        }
    }
}
