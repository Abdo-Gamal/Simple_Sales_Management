using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sales_management.Migrations
{
    public partial class inti29 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "invoicesModelView");

            migrationBuilder.CreateTable(
                name: "DisplayInvoicsModelView",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    totale = table.Column<double>(type: "float", nullable: true),
                    customerName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisplayInvoicsModelView", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCarRepoModelView",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prices = table.Column<double>(type: "float", nullable: false),
                    quantity = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCarRepoModelView", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DisplayInvoicsModelView");

            migrationBuilder.DropTable(
                name: "ProductCarRepoModelView");

            migrationBuilder.CreateTable(
                name: "invoicesModelView",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    customerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invoicesModelView", x => x.Id);
                });
        }
    }
}
