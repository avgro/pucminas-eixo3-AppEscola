using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_comunicacao_escolar.Migrations
{
    public partial class M06 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsuariosQueArquivaramConversa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    ConversaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosQueArquivaramConversa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuariosQueArquivaramConversa_Conversas_ConversaId",
                        column: x => x.ConversaId,
                        principalTable: "Conversas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosQueArquivaramConversa_ConversaId",
                table: "UsuariosQueArquivaramConversa",
                column: "ConversaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuariosQueArquivaramConversa");
        }
    }
}
