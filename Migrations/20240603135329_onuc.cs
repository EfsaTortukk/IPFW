using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internet_Programlama_Final_Work.Migrations
{
    /// <inheritdoc />
    public partial class onuc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logincs",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PassWord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoggedStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logincs", x => x.Email);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logincs");
        }
    }
}
