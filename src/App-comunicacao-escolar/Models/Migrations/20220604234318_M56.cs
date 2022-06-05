using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_comunicacao_escolar.Migrations
{
    public partial class M56 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComentariosPostagensLinhaDoTempo_PostagensLinhaDoTempo_LinhaDoTempoId",
                table: "ComentariosPostagensLinhaDoTempo");

            migrationBuilder.RenameColumn(
                name: "LinhaDoTempoId",
                table: "ComentariosPostagensLinhaDoTempo",
                newName: "PostagemLinhaDoTempoId");

            migrationBuilder.RenameIndex(
                name: "IX_ComentariosPostagensLinhaDoTempo_LinhaDoTempoId",
                table: "ComentariosPostagensLinhaDoTempo",
                newName: "IX_ComentariosPostagensLinhaDoTempo_PostagemLinhaDoTempoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ComentariosPostagensLinhaDoTempo_PostagensLinhaDoTempo_PostagemLinhaDoTempoId",
                table: "ComentariosPostagensLinhaDoTempo",
                column: "PostagemLinhaDoTempoId",
                principalTable: "PostagensLinhaDoTempo",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComentariosPostagensLinhaDoTempo_PostagensLinhaDoTempo_PostagemLinhaDoTempoId",
                table: "ComentariosPostagensLinhaDoTempo");

            migrationBuilder.RenameColumn(
                name: "PostagemLinhaDoTempoId",
                table: "ComentariosPostagensLinhaDoTempo",
                newName: "LinhaDoTempoId");

            migrationBuilder.RenameIndex(
                name: "IX_ComentariosPostagensLinhaDoTempo_PostagemLinhaDoTempoId",
                table: "ComentariosPostagensLinhaDoTempo",
                newName: "IX_ComentariosPostagensLinhaDoTempo_LinhaDoTempoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ComentariosPostagensLinhaDoTempo_PostagensLinhaDoTempo_LinhaDoTempoId",
                table: "ComentariosPostagensLinhaDoTempo",
                column: "LinhaDoTempoId",
                principalTable: "PostagensLinhaDoTempo",
                principalColumn: "Id");
        }
    }
}
