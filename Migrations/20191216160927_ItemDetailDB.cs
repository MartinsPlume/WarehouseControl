using Microsoft.EntityFrameworkCore.Migrations;

namespace WarehouseControl.Migrations
{
    public partial class ItemDetailDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ItemDescription",
                table: "ItemDetails",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemDescription",
                table: "ItemDetails");
        }
    }
}
