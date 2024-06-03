using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internet_Programlama_Final_Work.Migrations
{
    /// <inheritdoc />
    public partial class yedi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hastalar_LabGorevliler_SorumluLabGorevliId",
                table: "Hastalar");

            migrationBuilder.DropForeignKey(
                name: "FK_Sonuclar_LabGorevliler_LabGorevliId",
                table: "Sonuclar");

            migrationBuilder.DropTable(
                name: "LabGorevliler");

            migrationBuilder.RenameColumn(
                name: "LabGorevliId",
                table: "Sonuclar",
                newName: "HemsireId");

            migrationBuilder.RenameIndex(
                name: "IX_Sonuclar_LabGorevliId",
                table: "Sonuclar",
                newName: "IX_Sonuclar_HemsireId");

            migrationBuilder.RenameColumn(
                name: "SorumluLabGorevliId",
                table: "Hastalar",
                newName: "SorumluHemsireId");

            migrationBuilder.RenameIndex(
                name: "IX_Hastalar_SorumluLabGorevliId",
                table: "Hastalar",
                newName: "IX_Hastalar_SorumluHemsireId");

            migrationBuilder.CreateTable(
                name: "Hemsireler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdSoyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bölüm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    İşeBaşlamaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hemsireler", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Hastalar_Hemsireler_SorumluHemsireId",
                table: "Hastalar",
                column: "SorumluHemsireId",
                principalTable: "Hemsireler",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sonuclar_Hemsireler_HemsireId",
                table: "Sonuclar",
                column: "HemsireId",
                principalTable: "Hemsireler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hastalar_Hemsireler_SorumluHemsireId",
                table: "Hastalar");

            migrationBuilder.DropForeignKey(
                name: "FK_Sonuclar_Hemsireler_HemsireId",
                table: "Sonuclar");

            migrationBuilder.DropTable(
                name: "Hemsireler");

            migrationBuilder.RenameColumn(
                name: "HemsireId",
                table: "Sonuclar",
                newName: "LabGorevliId");

            migrationBuilder.RenameIndex(
                name: "IX_Sonuclar_HemsireId",
                table: "Sonuclar",
                newName: "IX_Sonuclar_LabGorevliId");

            migrationBuilder.RenameColumn(
                name: "SorumluHemsireId",
                table: "Hastalar",
                newName: "SorumluLabGorevliId");

            migrationBuilder.RenameIndex(
                name: "IX_Hastalar_SorumluHemsireId",
                table: "Hastalar",
                newName: "IX_Hastalar_SorumluLabGorevliId");

            migrationBuilder.CreateTable(
                name: "LabGorevliler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdSoyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numara = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UzmanlikAlani = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabGorevliler", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Hastalar_LabGorevliler_SorumluLabGorevliId",
                table: "Hastalar",
                column: "SorumluLabGorevliId",
                principalTable: "LabGorevliler",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sonuclar_LabGorevliler_LabGorevliId",
                table: "Sonuclar",
                column: "LabGorevliId",
                principalTable: "LabGorevliler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
