using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_comunicacao_escolar.Migrations
{
    public partial class M58 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComentariosPostagensLinhaDoTempo_PostagensLinhaDoTempo_PostagemLinhaDoTempoId",
                table: "ComentariosPostagensLinhaDoTempo");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAtualizacao",
                table: "PostagensLinhaDoTempo",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ComentariosPostagensLinhaDoTempo_PostagensLinhaDoTempo_PostagemLinhaDoTempoId",
                table: "ComentariosPostagensLinhaDoTempo",
                column: "PostagemLinhaDoTempoId",
                principalTable: "PostagensLinhaDoTempo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComentariosPostagensLinhaDoTempo_PostagensLinhaDoTempo_PostagemLinhaDoTempoId",
                table: "ComentariosPostagensLinhaDoTempo");

            migrationBuilder.DropColumn(
                name: "DataAtualizacao",
                table: "PostagensLinhaDoTempo");

            migrationBuilder.AddForeignKey(
                name: "FK_ComentariosPostagensLinhaDoTempo_PostagensLinhaDoTempo_PostagemLinhaDoTempoId",
                table: "ComentariosPostagensLinhaDoTempo",
                column: "PostagemLinhaDoTempoId",
                principalTable: "PostagensLinhaDoTempo",
                principalColumn: "Id");
        }
    }
}
