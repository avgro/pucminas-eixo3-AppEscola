using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_comunicacao_escolar.Migrations
{
    public partial class M05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MensagemMensagemArquivosAnexados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeOriginalDoArquivo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeUnicoDoArquivo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MensagemDosAnexosId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MensagemMensagemArquivosAnexados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MensagemMensagemArquivosAnexados_Mensagem_MensagemDosAnexosId",
                        column: x => x.MensagemDosAnexosId,
                        principalTable: "Mensagem",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MensagemMensagemArquivosAnexados_MensagemDosAnexosId",
                table: "MensagemMensagemArquivosAnexados",
                column: "MensagemDosAnexosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MensagemMensagemArquivosAnexados");
        }
    }
}
