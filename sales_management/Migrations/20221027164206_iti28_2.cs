using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sales_management.Migrations
{
    public partial class iti28_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Total",
                table: "invoices",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<bool>(
                name: "iscofirm",
                table: "invoices",
                type: "bit",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "invoicesModelView");

            migrationBuilder.DropColumn(
                name: "iscofirm",
                table: "invoices");

            migrationBuilder.AlterColumn<double>(
                name: "Total",
                table: "invoices",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);
        }
    }
}
