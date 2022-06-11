using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_comunicacao_escolar.Migrations
{
    public partial class M63 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventosDaAgenda_Agendas_AgendaId",
                table: "EventosDaAgenda");

            migrationBuilder.AddForeignKey(
                name: "FK_EventosDaAgenda_Agendas_AgendaId",
                table: "EventosDaAgenda",
                column: "AgendaId",
                principalTable: "Agendas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventosDaAgenda_Agendas_AgendaId",
                table: "EventosDaAgenda");

            migrationBuilder.AddForeignKey(
                name: "FK_EventosDaAgenda_Agendas_AgendaId",
                table: "EventosDaAgenda",
                column: "AgendaId",
                principalTable: "Agendas",
                principalColumn: "Id");
        }
    }
}
