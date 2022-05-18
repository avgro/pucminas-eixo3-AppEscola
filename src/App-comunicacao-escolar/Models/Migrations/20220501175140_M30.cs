using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_comunicacao_escolar.Migrations
{
    public partial class M30 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SobreNome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CodigoDoAluno = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DataDeNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NomeAlunoComCodigoEntreParenteses = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TurmaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alunos_Turmas_TurmaId",
                        column: x => x.TurmaId,
                        principalTable: "Turmas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AlunoResponsavel",
                columns: table => new
                {
                    AlunosId = table.Column<int>(type: "int", nullable: false),
                    ResponsaveisResponsavelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoResponsavel", x => new { x.AlunosId, x.ResponsaveisResponsavelId });
                    table.ForeignKey(
                        name: "FK_AlunoResponsavel_Alunos_AlunosId",
                        column: x => x.AlunosId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoResponsavel_Responsaveis_ResponsaveisResponsavelId",
                        column: x => x.ResponsaveisResponsavelId,
                        principalTable: "Responsaveis",
                        principalColumn: "ResponsavelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunoResponsavel_ResponsaveisResponsavelId",
                table: "AlunoResponsavel",
                column: "ResponsaveisResponsavelId");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_TurmaId",
                table: "Alunos",
                column: "TurmaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunoResponsavel");

            migrationBuilder.DropTable(
                name: "Alunos");
        }
    }
}
