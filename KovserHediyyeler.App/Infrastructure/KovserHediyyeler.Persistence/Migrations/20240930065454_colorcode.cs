using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KovserHediyyeler.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class colorcode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColorProductProperty");

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

            migrationBuilder.CreateIndex(
                name: "IX_ColorCodeProductProperty_PropertiesID",
                table: "ColorCodeProductProperty",
                column: "PropertiesID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColorCodeProductProperty");

            migrationBuilder.CreateTable(
                name: "ColorProductProperty",
                columns: table => new
                {
                    ColorsID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PropertiesID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorProductProperty", x => new { x.ColorsID, x.PropertiesID });
                    table.ForeignKey(
                        name: "FK_ColorProductProperty_Colors_ColorsID",
                        column: x => x.ColorsID,
                        principalTable: "Colors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ColorProductProperty_ProductProperties_PropertiesID",
                        column: x => x.PropertiesID,
                        principalTable: "ProductProperties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ColorProductProperty_PropertiesID",
                table: "ColorProductProperty",
                column: "PropertiesID");
        }
    }
}
