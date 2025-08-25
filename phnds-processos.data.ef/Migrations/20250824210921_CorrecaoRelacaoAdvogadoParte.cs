using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace phnds_processos.data.ef.Migrations
{
    /// <inheritdoc />
    public partial class CorrecaoRelacaoAdvogadoParte : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advogados_Partes_ParteId",
                table: "Advogados");

            migrationBuilder.DropIndex(
                name: "IX_Advogados_ParteId",
                table: "Advogados");

            migrationBuilder.DropColumn(
                name: "ParteId",
                table: "Advogados");

            migrationBuilder.AddColumn<int>(
                name: "AdvogadoId",
                table: "Partes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Partes_AdvogadoId",
                table: "Partes",
                column: "AdvogadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Partes_Advogados_AdvogadoId",
                table: "Partes",
                column: "AdvogadoId",
                principalTable: "Advogados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partes_Advogados_AdvogadoId",
                table: "Partes");

            migrationBuilder.DropIndex(
                name: "IX_Partes_AdvogadoId",
                table: "Partes");

            migrationBuilder.DropColumn(
                name: "AdvogadoId",
                table: "Partes");

            migrationBuilder.AddColumn<int>(
                name: "ParteId",
                table: "Advogados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Advogados_ParteId",
                table: "Advogados",
                column: "ParteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Advogados_Partes_ParteId",
                table: "Advogados",
                column: "ParteId",
                principalTable: "Partes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
