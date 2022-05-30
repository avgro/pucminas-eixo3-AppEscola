using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_comunicacao_escolar.Migrations
{
    public partial class M41 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AutorizacoesEventos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlunoId = table.Column<int>(type: "int", nullable: true),
                    EventoId = table.Column<int>(type: "int", nullable: true),
                    Autorizado = table.Column<bool>(type: "bit", nullable: true),
                    AssinadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutorizacoesEventos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AutorizacoesEventos_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AutorizacoesEventos_EventosDaAgenda_EventoId",
                        column: x => x.EventoId,
                        principalTable: "EventosDaAgenda",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutorizacoesEventos_AlunoId",
                table: "AutorizacoesEventos",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_AutorizacoesEventos_EventoId",
                table: "AutorizacoesEventos",
                column: "EventoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutorizacoesEventos");
        }
    }
}
