using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sales_management.Migrations
{
    public partial class iti27 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "invoices");

            migrationBuilder.DropColumn(
                name: "barcode",
                table: "invoices");

            migrationBuilder.DropColumn(
                name: "discount_price",
                table: "invoices");

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    price = table.Column<double>(type: "float", nullable: false),
                    quantity = table.Column<double>(type: "float", nullable: false),
                    invoiceId = table.Column<int>(type: "int", nullable: false),
                    productsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Car_invoices_invoiceId",
                        column: x => x.invoiceId,
                        principalTable: "invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Car_products_productsId",
                        column: x => x.productsId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_invoiceId",
                table: "Car",
                column: "invoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_productsId",
                table: "Car",
                column: "productsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "barcode",
                table: "invoices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "discount_price",
                table: "invoices",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
