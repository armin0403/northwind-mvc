using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NorthwindMVC.Infrastucture.Migrations
{
    /// <inheritdoc />
    public partial class renamingSupplierModel1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Supplyers_SupplyerId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Supplyers",
                table: "Supplyers");

            migrationBuilder.RenameTable(
                name: "Supplyers",
                newName: "Suppliers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Suppliers",
                table: "Suppliers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Suppliers_SupplyerId",
                table: "Products",
                column: "SupplyerId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Suppliers_SupplyerId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Suppliers",
                table: "Suppliers");

            migrationBuilder.RenameTable(
                name: "Suppliers",
                newName: "Supplyers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Supplyers",
                table: "Supplyers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Supplyers_SupplyerId",
                table: "Products",
                column: "SupplyerId",
                principalTable: "Supplyers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
