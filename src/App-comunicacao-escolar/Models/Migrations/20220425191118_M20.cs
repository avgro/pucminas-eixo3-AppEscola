using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_comunicacao_escolar.Migrations
{
    public partial class M20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HorariosDasDisciplinas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HorarioInicio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HorarioFim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaDaSemana = table.Column<int>(type: "int", nullable: false),
                    DisciplinaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorariosDasDisciplinas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HorariosDasDisciplinas_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HorariosDasDisciplinas_DisciplinaId",
                table: "HorariosDasDisciplinas",
                column: "DisciplinaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HorariosDasDisciplinas");
        }
    }
}
