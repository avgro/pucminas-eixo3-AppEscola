using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_comunicacao_escolar.Migrations
{
    public partial class M01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumeroDeNovasMensagensNaConversaId",
                table: "Conversas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "NumeroDeNovasMensagensNaConversa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    PossuiMensagensNaoLidas = table.Column<bool>(type: "bit", nullable: false),
                    NumeroDeMensagensNaoLidas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumeroDeNovasMensagensNaConversa", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conversas_NumeroDeNovasMensagensNaConversa_NumeroDeNovasMensagensNaConversaId",
                table: "Conversas");

            migrationBuilder.DropTable(
                name: "NumeroDeNovasMensagensNaConversa");

            migrationBuilder.DropIndex(
                name: "IX_Conversas_NumeroDeNovasMensagensNaConversaId",
                table: "Conversas");

            migrationBuilder.DropColumn(
                name: "NumeroDeNovasMensagensNaConversaId",
                table: "Conversas");
        }
    }
}
