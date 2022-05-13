using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_comunicacao_escolar.Migrations
{
    public partial class M19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "listaDestinatariosNome",
                table: "Mensagem",
                newName: "ListaDestinatariosNome");

            migrationBuilder.RenameColumn(
                name: "listaDestinatarios",
                table: "Mensagem",
                newName: "ListaDestinatarios");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ListaDestinatariosNome",
                table: "Mensagem",
                newName: "listaDestinatariosNome");

            migrationBuilder.RenameColumn(
                name: "ListaDestinatarios",
                table: "Mensagem",
                newName: "listaDestinatarios");
        }
    }
}
