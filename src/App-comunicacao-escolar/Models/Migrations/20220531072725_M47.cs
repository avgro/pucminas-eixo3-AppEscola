using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_comunicacao_escolar.Migrations
{
    public partial class M47 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventosDaAgenda_Usuarios_idUsuarioQueCadastrouEvento",
                table: "EventosDaAgenda");

            migrationBuilder.RenameColumn(
                name: "idUsuarioQueCadastrouEvento",
                table: "EventosDaAgenda",
                newName: "IdUsuarioQueCadastrouEvento");

            migrationBuilder.RenameIndex(
                name: "IX_EventosDaAgenda_idUsuarioQueCadastrouEvento",
                table: "EventosDaAgenda",
                newName: "IX_EventosDaAgenda_IdUsuarioQueCadastrouEvento");

            migrationBuilder.AddForeignKey(
                name: "FK_EventosDaAgenda_Usuarios_IdUsuarioQueCadastrouEvento",
                table: "EventosDaAgenda",
                column: "IdUsuarioQueCadastrouEvento",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventosDaAgenda_Usuarios_IdUsuarioQueCadastrouEvento",
                table: "EventosDaAgenda");

            migrationBuilder.RenameColumn(
                name: "IdUsuarioQueCadastrouEvento",
                table: "EventosDaAgenda",
                newName: "idUsuarioQueCadastrouEvento");

            migrationBuilder.RenameIndex(
                name: "IX_EventosDaAgenda_IdUsuarioQueCadastrouEvento",
                table: "EventosDaAgenda",
                newName: "IX_EventosDaAgenda_idUsuarioQueCadastrouEvento");

            migrationBuilder.AddForeignKey(
                name: "FK_EventosDaAgenda_Usuarios_idUsuarioQueCadastrouEvento",
                table: "EventosDaAgenda",
                column: "idUsuarioQueCadastrouEvento",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
