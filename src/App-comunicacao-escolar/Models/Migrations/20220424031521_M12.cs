using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_comunicacao_escolar.Migrations
{
    public partial class M12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professores_Usuarios_UsuarioId",
                table: "Professores");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Professores_UsuarioId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_UsuarioId",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Professores",
                table: "Professores");

            migrationBuilder.DropIndex(
                name: "IX_Professores_UsuarioId",
                table: "Professores");

            migrationBuilder.DropColumn(
                name: "ProfessorId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Professores");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Professores",
                newName: "ProfessorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Professores",
                table: "Professores",
                column: "ProfessorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Professores_Usuarios_ProfessorId",
                table: "Professores",
                column: "ProfessorId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professores_Usuarios_ProfessorId",
                table: "Professores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Professores",
                table: "Professores");

            migrationBuilder.RenameColumn(
                name: "ProfessorId",
                table: "Professores",
                newName: "UsuarioId");

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

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Professores",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Professores",
                table: "Professores",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_UsuarioId",
                table: "Usuarios",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Professores_UsuarioId",
                table: "Professores",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Professores_Usuarios_UsuarioId",
                table: "Professores",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Professores_UsuarioId",
                table: "Usuarios",
                column: "UsuarioId",
                principalTable: "Professores",
                principalColumn: "Id");
        }
    }
}
