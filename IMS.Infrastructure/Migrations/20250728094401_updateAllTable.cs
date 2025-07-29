using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateAllTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchageOrders_Warehouses_warehouse_id",
                table: "PurchageOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseStocks_Products_product_id",
                table: "WarehouseStocks");

            migrationBuilder.DropIndex(
                name: "IX_WarehouseStocks_product_id",
                table: "WarehouseStocks");

            migrationBuilder.DropIndex(
                name: "IX_PurchageOrders_warehouse_id",
                table: "PurchageOrders");

            migrationBuilder.DropColumn(
                name: "product_id",
                table: "WarehouseStocks");

            migrationBuilder.DropColumn(
                name: "quantity",
                table: "WarehouseStocks");

            migrationBuilder.DropColumn(
                name: "warehouse_id",
                table: "PurchageOrders");

            migrationBuilder.AddColumn<DateTime>(
                name: "createdAt",
                table: "WarehouseStocks",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "createdAt",
                table: "WarehouseStocks");

            migrationBuilder.AddColumn<int>(
                name: "product_id",
                table: "WarehouseStocks",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "quantity",
                table: "WarehouseStocks",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "warehouse_id",
                table: "PurchageOrders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseStocks_product_id",
                table: "WarehouseStocks",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_PurchageOrders_warehouse_id",
                table: "PurchageOrders",
                column: "warehouse_id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchageOrders_Warehouses_warehouse_id",
                table: "PurchageOrders",
                column: "warehouse_id",
                principalTable: "Warehouses",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseStocks_Products_product_id",
                table: "WarehouseStocks",
                column: "product_id",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
