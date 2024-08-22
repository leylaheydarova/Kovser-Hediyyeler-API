using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KovserHediyyeler.Data.Migrations
{
    /// <inheritdoc />
    public partial class departmentadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Createdat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updatedat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deletedat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Instagram = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TikTok = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Facebook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YouTube = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
