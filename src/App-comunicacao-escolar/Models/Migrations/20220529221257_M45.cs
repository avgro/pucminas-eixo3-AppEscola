using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_comunicacao_escolar.Migrations
{
    public partial class M45 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_EventosDaAgenda_idUsuarioQueCadastrouEvento",
                table: "EventosDaAgenda",
                column: "idUsuarioQueCadastrouEvento");

            migrationBuilder.AddForeignKey(
                name: "FK_EventosDaAgenda_Usuarios_idUsuarioQueCadastrouEvento",
                table: "EventosDaAgenda",
                column: "idUsuarioQueCadastrouEvento",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventosDaAgenda_Usuarios_idUsuarioQueCadastrouEvento",
                table: "EventosDaAgenda");

            migrationBuilder.DropIndex(
                name: "IX_EventosDaAgenda_idUsuarioQueCadastrouEvento",
                table: "EventosDaAgenda");
        }
    }
}
