using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internet_Programlama_Final_Work.Migrations
{
    /// <inheritdoc />
    public partial class bes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LabGorevliPhoto",
                table: "LabGorevliler");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LabGorevliPhoto",
                table: "LabGorevliler",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
