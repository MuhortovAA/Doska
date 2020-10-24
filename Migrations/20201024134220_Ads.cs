using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Doska.Migrations
{
    public partial class Ads : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.CreateTable(
                name: "Adses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCatalog = table.Column<int>(nullable: false),
                    IdCustomer = table.Column<int>(nullable: false),
                    AdsText = table.Column<string>(nullable: true),
                    AdsCreate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adses", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adses");

            migrationBuilder.DropColumn(
                name: "TitleId",
                table: "vCatalog");
        }
    }
}
