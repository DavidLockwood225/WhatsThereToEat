using Microsoft.EntityFrameworkCore.Migrations;

namespace WhereDaGrubAt.Migrations
{
    public partial class UDItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "NotUserDefined",
                table: "Item",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NotUserDefined",
                table: "Item");
        }
    }
}
