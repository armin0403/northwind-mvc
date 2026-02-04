using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NorthwindMVC.Infrastucture.Migrations
{
    /// <inheritdoc />
    public partial class renamingSupplierModel2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Suppliers_SupplyerId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_SupplyerId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_SupplierId",
                table: "Products",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Suppliers_SupplierId",
                table: "Products",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Suppliers_SupplierId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_SupplierId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SupplyerId",
                table: "Products",
                column: "SupplyerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Suppliers_SupplyerId",
                table: "Products",
                column: "SupplyerId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
