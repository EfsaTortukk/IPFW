using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internet_Programlama_Final_Work.Migrations
{
    /// <inheritdoc />
    public partial class bir : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doktorlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdSoyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UzmanlikAlani = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoktorPhoto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numara = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doktorlar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LabAdresler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KoridorNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KatNo = table.Column<int>(type: "int", nullable: false),
                    TelefonNo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabAdresler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LabGorevliler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdSoyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UzmanlikAlani = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LabGorevliPhoto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numara = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabGorevliler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestTurler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LabAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AcTok = table.Column<bool>(type: "bit", nullable: false),
                    SonucSuresi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestTurler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hastalar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdSoyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Yas = table.Column<int>(type: "int", nullable: false),
                    SorumluDoktorId = table.Column<int>(type: "int", nullable: true),
                    SorumluLabGorevliId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hastalar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hastalar_Doktorlar_SorumluDoktorId",
                        column: x => x.SorumluDoktorId,
                        principalTable: "Doktorlar",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Hastalar_LabGorevliler_SorumluLabGorevliId",
                        column: x => x.SorumluLabGorevliId,
                        principalTable: "LabGorevliler",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sonuclar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FotografDosyasi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HastaId = table.Column<int>(type: "int", nullable: false),
                    DoktorId = table.Column<int>(type: "int", nullable: false),
                    LabGorevliId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sonuclar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sonuclar_Doktorlar_DoktorId",
                        column: x => x.DoktorId,
                        principalTable: "Doktorlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sonuclar_Hastalar_HastaId",
                        column: x => x.HastaId,
                        principalTable: "Hastalar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sonuclar_LabGorevliler_LabGorevliId",
                        column: x => x.LabGorevliId,
                        principalTable: "LabGorevliler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hastalar_SorumluDoktorId",
                table: "Hastalar",
                column: "SorumluDoktorId");

            migrationBuilder.CreateIndex(
                name: "IX_Hastalar_SorumluLabGorevliId",
                table: "Hastalar",
                column: "SorumluLabGorevliId");

            migrationBuilder.CreateIndex(
                name: "IX_Sonuclar_DoktorId",
                table: "Sonuclar",
                column: "DoktorId");

            migrationBuilder.CreateIndex(
                name: "IX_Sonuclar_HastaId",
                table: "Sonuclar",
                column: "HastaId");

            migrationBuilder.CreateIndex(
                name: "IX_Sonuclar_LabGorevliId",
                table: "Sonuclar",
                column: "LabGorevliId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LabAdresler");

            migrationBuilder.DropTable(
                name: "Sonuclar");

            migrationBuilder.DropTable(
                name: "TestTurler");

            migrationBuilder.DropTable(
                name: "Hastalar");

            migrationBuilder.DropTable(
                name: "Doktorlar");

            migrationBuilder.DropTable(
                name: "LabGorevliler");
        }
    }
}
