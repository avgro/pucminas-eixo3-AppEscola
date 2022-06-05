using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_comunicacao_escolar.Migrations
{
    public partial class M55 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComentariosPostagensLinhaDoTempo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Conteudo = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AutorId = table.Column<int>(type: "int", nullable: true),
                    LinhaDoTempoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComentariosPostagensLinhaDoTempo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComentariosPostagensLinhaDoTempo_PostagensLinhaDoTempo_LinhaDoTempoId",
                        column: x => x.LinhaDoTempoId,
                        principalTable: "PostagensLinhaDoTempo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComentariosPostagensLinhaDoTempo_Usuarios_AutorId",
                        column: x => x.AutorId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComentariosPostagensLinhaDoTempo_AutorId",
                table: "ComentariosPostagensLinhaDoTempo",
                column: "AutorId");

            migrationBuilder.CreateIndex(
                name: "IX_ComentariosPostagensLinhaDoTempo_LinhaDoTempoId",
                table: "ComentariosPostagensLinhaDoTempo",
                column: "LinhaDoTempoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComentariosPostagensLinhaDoTempo");
        }
    }
}
