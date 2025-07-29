using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "WarehouseStocks",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "SellerOrders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "SellerOrderItems",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "PurchaseOrdersItem",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "PurchageOrders",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "WarehouseStocks");

            migrationBuilder.DropColumn(
                name: "name",
                table: "SellerOrders");

            migrationBuilder.DropColumn(
                name: "name",
                table: "SellerOrderItems");

            migrationBuilder.DropColumn(
                name: "name",
                table: "PurchaseOrdersItem");

            migrationBuilder.DropColumn(
                name: "name",
                table: "PurchageOrders");
        }
    }
}
