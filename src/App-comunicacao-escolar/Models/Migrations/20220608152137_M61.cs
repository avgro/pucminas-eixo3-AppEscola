using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_comunicacao_escolar.Migrations
{
    public partial class M61 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComentariosPostagensLinhaDoTempo_Usuarios_AutorId",
                table: "ComentariosPostagensLinhaDoTempo");

            migrationBuilder.DropForeignKey(
                name: "FK_PostagensLinhaDoTempo_Usuarios_AutorId",
                table: "PostagensLinhaDoTempo");

            migrationBuilder.AddForeignKey(
                name: "FK_ComentariosPostagensLinhaDoTempo_Usuarios_AutorId",
                table: "ComentariosPostagensLinhaDoTempo",
                column: "AutorId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_PostagensLinhaDoTempo_Usuarios_AutorId",
                table: "PostagensLinhaDoTempo",
                column: "AutorId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComentariosPostagensLinhaDoTempo_Usuarios_AutorId",
                table: "ComentariosPostagensLinhaDoTempo");

            migrationBuilder.DropForeignKey(
                name: "FK_PostagensLinhaDoTempo_Usuarios_AutorId",
                table: "PostagensLinhaDoTempo");

            migrationBuilder.AddForeignKey(
                name: "FK_ComentariosPostagensLinhaDoTempo_Usuarios_AutorId",
                table: "ComentariosPostagensLinhaDoTempo",
                column: "AutorId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostagensLinhaDoTempo_Usuarios_AutorId",
                table: "PostagensLinhaDoTempo",
                column: "AutorId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }
    }
}
