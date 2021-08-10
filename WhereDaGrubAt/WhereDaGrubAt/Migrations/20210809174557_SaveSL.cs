using Microsoft.EntityFrameworkCore.Migrations;

namespace WhereDaGrubAt.Migrations
{
    public partial class SaveSL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ListTitle",
                table: "ShoppingList",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ListTitle",
                table: "ShoppingList");
        }
    }
}
