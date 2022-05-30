using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_comunicacao_escolar.Migrations
{
    public partial class M42 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AutorizacoesEventos_Alunos_AlunoId",
                table: "AutorizacoesEventos");

            migrationBuilder.DropForeignKey(
                name: "FK_AutorizacoesEventos_EventosDaAgenda_EventoId",
                table: "AutorizacoesEventos");

            migrationBuilder.AddForeignKey(
                name: "FK_AutorizacoesEventos_Alunos_AlunoId",
                table: "AutorizacoesEventos",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AutorizacoesEventos_EventosDaAgenda_EventoId",
                table: "AutorizacoesEventos",
                column: "EventoId",
                principalTable: "EventosDaAgenda",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AutorizacoesEventos_Alunos_AlunoId",
                table: "AutorizacoesEventos");

            migrationBuilder.DropForeignKey(
                name: "FK_AutorizacoesEventos_EventosDaAgenda_EventoId",
                table: "AutorizacoesEventos");

            migrationBuilder.AddForeignKey(
                name: "FK_AutorizacoesEventos_Alunos_AlunoId",
                table: "AutorizacoesEventos",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AutorizacoesEventos_EventosDaAgenda_EventoId",
                table: "AutorizacoesEventos",
                column: "EventoId",
                principalTable: "EventosDaAgenda",
                principalColumn: "Id");
        }
    }
}
