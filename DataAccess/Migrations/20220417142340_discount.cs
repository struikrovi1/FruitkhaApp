using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class discount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countdowns_Products_ProductId",
                table: "Countdowns");

            migrationBuilder.DropIndex(
                name: "IX_Countdowns_ProductId",
                table: "Countdowns");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Countdowns");

            migrationBuilder.AddColumn<bool>(
                name: "isDiscount",
                table: "Products",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDiscount",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Countdowns",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Countdowns_ProductId",
                table: "Countdowns",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Countdowns_Products_ProductId",
                table: "Countdowns",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
