using Microsoft.EntityFrameworkCore.Migrations;

namespace Doska.Migrations
{
    public partial class AddSorted4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "SortedSubtitle",
            //    table: "vCatalog");

            migrationBuilder.DropColumn(
                name: "SortedSubtitle",
                table: "Subtitles");

            //migrationBuilder.AlterColumn<int>(
            //    name: "id",
            //    table: "vCatalog",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "idTitle",
                table: "Subtitles",
                nullable: false,
                defaultValue: 0);

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_vCatalog",
            //    table: "vCatalog",
            //    column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_vCatalog",
                table: "vCatalog");

            migrationBuilder.DropColumn(
                name: "idTitle",
                table: "Subtitles");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "vCatalog",
                type: "int",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "SortedSubtitle",
                table: "vCatalog",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SortedSubtitle",
                table: "Subtitles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
