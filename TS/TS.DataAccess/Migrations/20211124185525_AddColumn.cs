using Microsoft.EntityFrameworkCore.Migrations;

namespace TS.DataAccess.Migrations
{
    public partial class AddColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ulasim",
                table: "TurBilgileri",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FiyatTanimi",
                table: "OtelBilgileri",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ulasim",
                table: "TurBilgileri");

            migrationBuilder.DropColumn(
                name: "FiyatTanimi",
                table: "OtelBilgileri");
        }
    }
}
