using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_comunicacao_escolar.Migrations
{
    public partial class M37 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AgendaId",
                table: "EventosDaAgenda",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventosDaAgenda_AgendaId",
                table: "EventosDaAgenda",
                column: "AgendaId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventosDaAgenda_Agendas_AgendaId",
                table: "EventosDaAgenda",
                column: "AgendaId",
                principalTable: "Agendas",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventosDaAgenda_Agendas_AgendaId",
                table: "EventosDaAgenda");

            migrationBuilder.DropIndex(
                name: "IX_EventosDaAgenda_AgendaId",
                table: "EventosDaAgenda");

            migrationBuilder.DropColumn(
                name: "AgendaId",
                table: "EventosDaAgenda");
        }
    }
}
