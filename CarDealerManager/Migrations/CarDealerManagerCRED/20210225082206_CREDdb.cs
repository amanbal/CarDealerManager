using System;
using System.IO;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarDealerManager.Migrations.CarDealerManagerCRED
{
    public partial class CREDdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Phone = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Phone = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarBrandName = table.Column<string>(nullable: false),
                    CarModel = table.Column<string>(nullable: false),
                    CarYear = table.Column<string>(maxLength: 4, nullable: false),
                    Fuel = table.Column<int>(nullable: false),
                    Transmission = table.Column<int>(nullable: false),
                    Color = table.Column<string>(nullable: false),
                    InStock = table.Column<int>(nullable: false),
                    SupplierFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Car_Supplier_SupplierFK",
                        column: x => x.SupplierFK,
                        principalTable: "Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfPurchase = table.Column<DateTime>(nullable: false),
                    WarrantyDuration = table.Column<int>(nullable: false),
                    CarFK = table.Column<int>(nullable: false),
                    CustomerFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Store_Car_CarFK",
                        column: x => x.CarFK,
                        principalTable: "Car",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Store_Customer_CustomerFK",
                        column: x => x.CustomerFK,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_SupplierFK",
                table: "Car",
                column: "SupplierFK");

            migrationBuilder.CreateIndex(
                name: "IX_Store_CarFK",
                table: "Store",
                column: "CarFK");

            migrationBuilder.CreateIndex(
                name: "IX_Store_CustomerFK",
                table: "Store",
                column: "CustomerFK");
            var sqlFile = Path.Combine(".\\DatabaseScript", @"Data.sql");
            migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Supplier");
        }
    }
}
