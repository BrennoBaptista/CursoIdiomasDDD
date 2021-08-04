using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CursoIdiomas.Infrastructure.Data.Migrations
{
    public partial class AtualizandoEntidades3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Turmas_TurmaId",
                table: "Alunos");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_TurmaId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "ChaveTurma",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "TurmaId",
                table: "Alunos");

            migrationBuilder.AddColumn<Guid>(
                name: "IdTurma",
                table: "Alunos",
                type: "uniqueidentifier",
                nullable: true,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_IdTurma",
                table: "Alunos",
                column: "IdTurma");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Turmas_IdTurma",
                table: "Alunos",
                column: "IdTurma",
                principalTable: "Turmas",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Turmas_IdTurma",
                table: "Alunos");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_IdTurma",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "IdTurma",
                table: "Alunos");

            migrationBuilder.AddColumn<string>(
                name: "ChaveTurma",
                table: "Alunos",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TurmaId",
                table: "Alunos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_TurmaId",
                table: "Alunos",
                column: "TurmaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Turmas_TurmaId",
                table: "Alunos",
                column: "TurmaId",
                principalTable: "Turmas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
