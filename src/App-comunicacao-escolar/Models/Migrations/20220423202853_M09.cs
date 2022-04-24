using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_comunicacao_escolar.Migrations
{
    public partial class M09 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TelefoneFixo",
                table: "Usuarios",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TelefoneMovel",
                table: "Usuarios",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TelefoneFixo",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "TelefoneMovel",
                table: "Usuarios");
        }
    }
}
