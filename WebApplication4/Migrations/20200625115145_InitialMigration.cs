using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication4.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "confectioneries",
                columns: table => new
                {
                    idConfectionery = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    PricePerite = table.Column<float>(nullable: false),
                    Type = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_confectioneries", x => x.idConfectionery);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    idClient = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Surname = table.Column<string>(maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.idClient);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    idEmployee = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Surname = table.Column<string>(maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.idEmployee);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    idOrder = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateAccepted = table.Column<DateTime>(nullable: false),
                    DateFinished = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(maxLength: 255, nullable: true),
                    idClient = table.Column<int>(nullable: false),
                    idEmployee = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.idOrder);
                    table.ForeignKey(
                        name: "FK_orders_customers_idClient",
                        column: x => x.idClient,
                        principalTable: "customers",
                        principalColumn: "idClient",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orders_Employees_idEmployee",
                        column: x => x.idEmployee,
                        principalTable: "Employees",
                        principalColumn: "idEmployee",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "confectionery_Orders",
                columns: table => new
                {
                    idConfectionery = table.Column<int>(nullable: false),
                    idOrder = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_confectionery_Orders", x => new { x.idOrder, x.idConfectionery });
                    table.ForeignKey(
                        name: "FK_confectionery_Orders_confectioneries_idConfectionery",
                        column: x => x.idConfectionery,
                        principalTable: "confectioneries",
                        principalColumn: "idConfectionery",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_confectionery_Orders_orders_idOrder",
                        column: x => x.idOrder,
                        principalTable: "orders",
                        principalColumn: "idOrder",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_confectionery_Orders_idConfectionery",
                table: "confectionery_Orders",
                column: "idConfectionery");

            migrationBuilder.CreateIndex(
                name: "IX_orders_idClient",
                table: "orders",
                column: "idClient");

            migrationBuilder.CreateIndex(
                name: "IX_orders_idEmployee",
                table: "orders",
                column: "idEmployee");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "confectionery_Orders");

            migrationBuilder.DropTable(
                name: "confectioneries");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
