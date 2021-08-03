using Microsoft.EntityFrameworkCore.Migrations;

namespace WhereDaGrubAt.Migrations
{
    public partial class UDRecipe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "NotUserDefined",
                table: "Recipe",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NotUserDefined",
                table: "Recipe");
        }
    }
}
