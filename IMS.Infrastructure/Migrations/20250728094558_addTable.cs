using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace IMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WarehouseReceivedProducts",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    warehouse_stock_id = table.Column<int>(type: "integer", nullable: false),
                    product_id = table.Column<int>(type: "integer", nullable: false),
                    good_product = table.Column<int>(type: "integer", nullable: false),
                    damaged_product = table.Column<int>(type: "integer", nullable: false),
                    missing_product = table.Column<int>(type: "integer", nullable: false),
                    isDelete = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehouseReceivedProducts", x => x.id);
                    table.ForeignKey(
                        name: "FK_WarehouseReceivedProducts_Products_product_id",
                        column: x => x.product_id,
                        principalTable: "Products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WarehouseReceivedProducts_WarehouseStocks_warehouse_stock_id",
                        column: x => x.warehouse_stock_id,
                        principalTable: "WarehouseStocks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseReceivedProducts_product_id",
                table: "WarehouseReceivedProducts",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseReceivedProducts_warehouse_stock_id",
                table: "WarehouseReceivedProducts",
                column: "warehouse_stock_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WarehouseReceivedProducts");
        }
    }
}
