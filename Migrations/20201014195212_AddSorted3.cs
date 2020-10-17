using Microsoft.EntityFrameworkCore.Migrations;

namespace Doska.Migrations
{
    public partial class AddSorted3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SortedSubtitle",
                table: "Catalogs");
        }

        //protected override void Down(MigrationBuilder migrationBuilder)
        //{
        //    migrationBuilder.AddColumn<int>(
        //        name: "SortedSubtitle",
        //        table: "Catalogs",
        //        type: "int",
        //        nullable: false,
        //        defaultValue: 0);
        //}
    }
}
