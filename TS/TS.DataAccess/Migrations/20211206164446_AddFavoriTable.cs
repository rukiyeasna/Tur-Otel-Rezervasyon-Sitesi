using Microsoft.EntityFrameworkCore.Migrations;

namespace TS.DataAccess.Migrations
{
    public partial class AddFavoriTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Favori",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TurId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favori", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favori_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favori_TurBilgileri_TurId",
                        column: x => x.TurId,
                        principalTable: "TurBilgileri",
                        principalColumn: "TurId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Favori_AppUserId",
                table: "Favori",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Favori_TurId",
                table: "Favori",
                column: "TurId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favori");
        }
    }
}
