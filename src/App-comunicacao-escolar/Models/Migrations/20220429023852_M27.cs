using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_comunicacao_escolar.Migrations
{
    public partial class M27 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NumeroDeNovasMensagensNaConversa_Conversas_ConversaId",
                table: "NumeroDeNovasMensagensNaConversa");

            migrationBuilder.AddForeignKey(
                name: "FK_NumeroDeNovasMensagensNaConversa_Conversas_ConversaId",
                table: "NumeroDeNovasMensagensNaConversa",
                column: "ConversaId",
                principalTable: "Conversas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NumeroDeNovasMensagensNaConversa_Conversas_ConversaId",
                table: "NumeroDeNovasMensagensNaConversa");

            migrationBuilder.AddForeignKey(
                name: "FK_NumeroDeNovasMensagensNaConversa_Conversas_ConversaId",
                table: "NumeroDeNovasMensagensNaConversa",
                column: "ConversaId",
                principalTable: "Conversas",
                principalColumn: "Id");
        }
    }
}
