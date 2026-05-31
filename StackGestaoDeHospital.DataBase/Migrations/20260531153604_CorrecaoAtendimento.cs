using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StackGestaoDeHospital.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class CorrecaoAtendimento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PacienteId",
                schema: "GESTAOHOSPITAL",
                table: "Atendimento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_PacienteId",
                schema: "GESTAOHOSPITAL",
                table: "Atendimento",
                column: "PacienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimento_Paciente_PacienteId",
                schema: "GESTAOHOSPITAL",
                table: "Atendimento",
                column: "PacienteId",
                principalSchema: "GESTAOHOSPITAL",
                principalTable: "Paciente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atendimento_Paciente_PacienteId",
                schema: "GESTAOHOSPITAL",
                table: "Atendimento");

            migrationBuilder.DropIndex(
                name: "IX_Atendimento_PacienteId",
                schema: "GESTAOHOSPITAL",
                table: "Atendimento");

            migrationBuilder.DropColumn(
                name: "PacienteId",
                schema: "GESTAOHOSPITAL",
                table: "Atendimento");
        }
    }
}
