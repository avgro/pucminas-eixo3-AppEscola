using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_comunicacao_escolar.Migrations
{
    public partial class M29 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosQueArquivaramConversa_Conversas_ConversaId",
                table: "UsuariosQueArquivaramConversa");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosQueArquivaramConversa_Conversas_ConversaId",
                table: "UsuariosQueArquivaramConversa",
                column: "ConversaId",
                principalTable: "Conversas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosQueArquivaramConversa_Conversas_ConversaId",
                table: "UsuariosQueArquivaramConversa");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosQueArquivaramConversa_Conversas_ConversaId",
                table: "UsuariosQueArquivaramConversa",
                column: "ConversaId",
                principalTable: "Conversas",
                principalColumn: "Id");
        }
    }
}
