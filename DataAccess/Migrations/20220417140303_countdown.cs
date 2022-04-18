using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class countdown : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countdowns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    months = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    days = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    year = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hours = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    minutes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    seconds = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    dealDescr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countdowns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Countdowns_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Countdowns_ProductId",
                table: "Countdowns",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countdowns");
        }
    }
}
