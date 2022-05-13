using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_comunicacao_escolar.Migrations
{
    public partial class M28 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MensagemMensagemArquivosAnexados_Mensagem_MensagemDosAnexosId",
                table: "MensagemMensagemArquivosAnexados");

            migrationBuilder.AddForeignKey(
                name: "FK_MensagemMensagemArquivosAnexados_Mensagem_MensagemDosAnexosId",
                table: "MensagemMensagemArquivosAnexados",
                column: "MensagemDosAnexosId",
                principalTable: "Mensagem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MensagemMensagemArquivosAnexados_Mensagem_MensagemDosAnexosId",
                table: "MensagemMensagemArquivosAnexados");

            migrationBuilder.AddForeignKey(
                name: "FK_MensagemMensagemArquivosAnexados_Mensagem_MensagemDosAnexosId",
                table: "MensagemMensagemArquivosAnexados",
                column: "MensagemDosAnexosId",
                principalTable: "Mensagem",
                principalColumn: "Id");
        }
    }
}
