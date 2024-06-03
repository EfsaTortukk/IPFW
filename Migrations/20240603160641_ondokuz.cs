using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internet_Programlama_Final_Work.Migrations
{
    /// <inheritdoc />
    public partial class ondokuz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Logincs",
                table: "Logincs");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Logincs");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Logincs",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Logincs",
                table: "Logincs",
                column: "Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Logincs",
                table: "Logincs");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Logincs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Logincs",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Logincs",
                table: "Logincs",
                column: "Id");
        }
    }
}
