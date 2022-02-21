using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TS.DataAccess.Migrations
{
    public partial class AddTableOtelAndTur : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TurBilgileri",
                columns: table => new
                {
                    TurId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TurAltKategori = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaslangicTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BitisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fiyat = table.Column<double>(type: "float", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GidilecekYerler = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TurBasligi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FiyataDahilHizmetler = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FiyataDahilOlmayanHizmetler = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TurProgrami = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TurKalkisNoktalari = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Durum = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurBilgileri", x => x.TurId);
                });

            migrationBuilder.CreateTable(
                name: "OtelBilgileri",
                columns: table => new
                {
                    OtelBilgiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CiftKisilikOda = table.Column<double>(type: "float", nullable: false),
                    IlaveYatak = table.Column<double>(type: "float", nullable: false),
                    TekKisilikOda = table.Column<double>(type: "float", nullable: false),
                    Cocuk_3_6_Yas = table.Column<double>(type: "float", nullable: false),
                    Cocuk_7_12_Yas = table.Column<double>(type: "float", nullable: false),
                    Aciklama = table.Column<double>(type: "float", nullable: false),
                    TurId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtelBilgileri", x => x.OtelBilgiId);
                    table.ForeignKey(
                        name: "FK_OtelBilgileri_TurBilgileri_TurId",
                        column: x => x.TurId,
                        principalTable: "TurBilgileri",
                        principalColumn: "TurId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OtelBilgileri_TurId",
                table: "OtelBilgileri",
                column: "TurId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OtelBilgileri");

            migrationBuilder.DropTable(
                name: "TurBilgileri");
        }
    }
}
