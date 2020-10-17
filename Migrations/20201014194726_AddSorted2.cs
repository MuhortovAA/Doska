using Microsoft.EntityFrameworkCore.Migrations;

namespace Doska.Migrations
{
    public partial class AddSorted2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<int>(
            //    name: "SortedSubtitle",
            //    table: "vCatalog",
            //    nullable: false,
            //    defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SortedSubtitle",
                table: "Subtitles",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SortedSubtitle",
                table: "vCatalog");

            migrationBuilder.DropColumn(
                name: "SortedSubtitle",
                table: "Subtitles");
        }
    }
}
