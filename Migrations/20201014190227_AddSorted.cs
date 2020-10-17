using Microsoft.EntityFrameworkCore.Migrations;

namespace Doska.Migrations
{
    public partial class AddSorted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SortedSubtitle",
                table: "Catalogs",
                nullable: false,
                defaultValue: 0);

            //migrationBuilder.CreateTable(
            //    name: "vCatalog",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(nullable: false),
            //        NameTitle = table.Column<string>(nullable: true),
            //        NameSubtitle = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "vCatalog");

            migrationBuilder.DropColumn(
                name: "SortedSubtitle",
                table: "Catalogs");
        }
    }
}
