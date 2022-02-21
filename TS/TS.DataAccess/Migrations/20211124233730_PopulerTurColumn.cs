using Microsoft.EntityFrameworkCore.Migrations;

namespace TS.DataAccess.Migrations
{
    public partial class PopulerTurColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PopulerDurum",
                table: "TurBilgileri",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PopulerDurum",
                table: "TurBilgileri");
        }
    }
}
