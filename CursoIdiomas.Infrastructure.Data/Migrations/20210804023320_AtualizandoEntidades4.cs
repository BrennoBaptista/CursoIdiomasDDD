using Microsoft.EntityFrameworkCore.Migrations;

namespace CursoIdiomas.Infrastructure.Data.Migrations
{
    public partial class AtualizandoEntidades4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Turmas_IdTurma",
                table: "Alunos");

            migrationBuilder.RenameColumn(
                name: "IdTurma",
                table: "Alunos",
                newName: "TurmaId");

            migrationBuilder.RenameIndex(
                name: "IX_Alunos_IdTurma",
                table: "Alunos",
                newName: "IX_Alunos_TurmaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Turmas_TurmaId",
                table: "Alunos",
                column: "TurmaId",
                principalTable: "Turmas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Turmas_TurmaId",
                table: "Alunos");

            migrationBuilder.RenameColumn(
                name: "TurmaId",
                table: "Alunos",
                newName: "IdTurma");

            migrationBuilder.RenameIndex(
                name: "IX_Alunos_TurmaId",
                table: "Alunos",
                newName: "IX_Alunos_IdTurma");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Turmas_IdTurma",
                table: "Alunos",
                column: "IdTurma",
                principalTable: "Turmas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
