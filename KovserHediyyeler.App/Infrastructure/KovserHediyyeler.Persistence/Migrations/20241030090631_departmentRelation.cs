using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KovserHediyyeler.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class departmentRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryDepartments_Departments_DepartmentID",
                table: "CategoryDepartments");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentPositions_Departments_DepartmentID",
                table: "DepartmentPositions");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentPromotions_Departments_DepartmentID",
                table: "DepartmentPromotions");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentID",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Departments_DepartmentID",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_SocialMedias_Departments_DepartmentID",
                table: "SocialMedias");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryDepartments_Departments_DepartmentID",
                table: "CategoryDepartments",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentPositions_Departments_DepartmentID",
                table: "DepartmentPositions",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentPromotions_Departments_DepartmentID",
                table: "DepartmentPromotions",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentID",
                table: "Employees",
                column: "DepartmentID",
                principalTable: "Departments",
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
                name: "FK_SocialMedias_Departments_DepartmentID",
                table: "SocialMedias",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryDepartments_Departments_DepartmentID",
                table: "CategoryDepartments");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentPositions_Departments_DepartmentID",
                table: "DepartmentPositions");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentPromotions_Departments_DepartmentID",
                table: "DepartmentPromotions");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentID",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Departments_DepartmentID",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_SocialMedias_Departments_DepartmentID",
                table: "SocialMedias");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryDepartments_Departments_DepartmentID",
                table: "CategoryDepartments",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentPositions_Departments_DepartmentID",
                table: "DepartmentPositions",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentPromotions_Departments_DepartmentID",
                table: "DepartmentPromotions",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentID",
                table: "Employees",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Departments_DepartmentID",
                table: "Products",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_SocialMedias_Departments_DepartmentID",
                table: "SocialMedias",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "ID");
        }
    }
}
