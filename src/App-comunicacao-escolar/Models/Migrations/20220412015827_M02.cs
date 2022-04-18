using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_comunicacao_escolar.Migrations
{
    public partial class M02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conversas_NumeroDeNovasMensagensNaConversa_NumeroDeNovasMensagensNaConversaId",
                table: "Conversas");

            migrationBuilder.DropIndex(
                name: "IX_Conversas_NumeroDeNovasMensagensNaConversaId",
                table: "Conversas");

            migrationBuilder.DropColumn(
                name: "NumeroDeNovasMensagensNaConversaId",
                table: "Conversas");

            migrationBuilder.AddColumn<int>(
                name: "ConversaId",
                table: "NumeroDeNovasMensagensNaConversa",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NumeroDeNovasMensagensNaConversa_ConversaId",
                table: "NumeroDeNovasMensagensNaConversa",
                column: "ConversaId");

            migrationBuilder.AddForeignKey(
                name: "FK_NumeroDeNovasMensagensNaConversa_Conversas_ConversaId",
                table: "NumeroDeNovasMensagensNaConversa",
                column: "ConversaId",
                principalTable: "Conversas",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NumeroDeNovasMensagensNaConversa_Conversas_ConversaId",
                table: "NumeroDeNovasMensagensNaConversa");

            migrationBuilder.DropIndex(
                name: "IX_NumeroDeNovasMensagensNaConversa_ConversaId",
                table: "NumeroDeNovasMensagensNaConversa");

            migrationBuilder.DropColumn(
                name: "ConversaId",
                table: "NumeroDeNovasMensagensNaConversa");

            migrationBuilder.AddColumn<int>(
                name: "NumeroDeNovasMensagensNaConversaId",
                table: "Conversas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Conversas_NumeroDeNovasMensagensNaConversaId",
                table: "Conversas",
                column: "NumeroDeNovasMensagensNaConversaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Conversas_NumeroDeNovasMensagensNaConversa_NumeroDeNovasMensagensNaConversaId",
                table: "Conversas",
                column: "NumeroDeNovasMensagensNaConversaId",
                principalTable: "NumeroDeNovasMensagensNaConversa",
                principalColumn: "Id");
        }
    }
}
