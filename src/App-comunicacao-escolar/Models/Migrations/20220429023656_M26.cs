using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_comunicacao_escolar.Migrations
{
    public partial class M26 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mensagem_Conversas_ConversaId",
                table: "Mensagem");

            migrationBuilder.AddForeignKey(
                name: "FK_Mensagem_Conversas_ConversaId",
                table: "Mensagem",
                column: "ConversaId",
                principalTable: "Conversas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mensagem_Conversas_ConversaId",
                table: "Mensagem");

            migrationBuilder.AddForeignKey(
                name: "FK_Mensagem_Conversas_ConversaId",
                table: "Mensagem",
                column: "ConversaId",
                principalTable: "Conversas",
                principalColumn: "Id");
        }
    }
}
