using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_comunicacao_escolar.Migrations
{
    public partial class M11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfessorId",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Formacao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Perfil = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Professores_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_UsuarioId",
                table: "Usuarios",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Professores_UsuarioId",
                table: "Professores",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Professores_UsuarioId",
                table: "Usuarios",
                column: "UsuarioId",
                principalTable: "Professores",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Professores_UsuarioId",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "Professores");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_UsuarioId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "ProfessorId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Usuarios");
        }
    }
}
