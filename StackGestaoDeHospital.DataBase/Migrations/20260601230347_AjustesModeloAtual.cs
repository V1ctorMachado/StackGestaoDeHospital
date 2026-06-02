using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StackGestaoDeHospital.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class AjustesModeloAtual : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartamentoId",
                schema: "GESTAOHOSPITAL",
                table: "Funcionario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartamentoId1",
                schema: "GESTAOHOSPITAL",
                table: "Funcionario",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EspecialidadeId",
                schema: "GESTAOHOSPITAL",
                table: "Atendimento",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DepartamentoId",
                schema: "GESTAOHOSPITAL",
                table: "Atendimento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_DepartamentoId",
                schema: "GESTAOHOSPITAL",
                table: "Funcionario",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_DepartamentoId1",
                schema: "GESTAOHOSPITAL",
                table: "Funcionario",
                column: "DepartamentoId1");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_DepartamentoId",
                schema: "GESTAOHOSPITAL",
                table: "Atendimento",
                column: "DepartamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimento_Departamento_DepartamentoId",
                schema: "GESTAOHOSPITAL",
                table: "Atendimento",
                column: "DepartamentoId",
                principalSchema: "GESTAOHOSPITAL",
                principalTable: "Departamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionario_Departamento_DepartamentoId",
                schema: "GESTAOHOSPITAL",
                table: "Funcionario",
                column: "DepartamentoId",
                principalSchema: "GESTAOHOSPITAL",
                principalTable: "Departamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionario_Departamento_DepartamentoId1",
                schema: "GESTAOHOSPITAL",
                table: "Funcionario",
                column: "DepartamentoId1",
                principalSchema: "GESTAOHOSPITAL",
                principalTable: "Departamento",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atendimento_Departamento_DepartamentoId",
                schema: "GESTAOHOSPITAL",
                table: "Atendimento");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionario_Departamento_DepartamentoId",
                schema: "GESTAOHOSPITAL",
                table: "Funcionario");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionario_Departamento_DepartamentoId1",
                schema: "GESTAOHOSPITAL",
                table: "Funcionario");

            migrationBuilder.DropIndex(
                name: "IX_Funcionario_DepartamentoId",
                schema: "GESTAOHOSPITAL",
                table: "Funcionario");

            migrationBuilder.DropIndex(
                name: "IX_Funcionario_DepartamentoId1",
                schema: "GESTAOHOSPITAL",
                table: "Funcionario");

            migrationBuilder.DropIndex(
                name: "IX_Atendimento_DepartamentoId",
                schema: "GESTAOHOSPITAL",
                table: "Atendimento");

            migrationBuilder.DropColumn(
                name: "DepartamentoId",
                schema: "GESTAOHOSPITAL",
                table: "Funcionario");

            migrationBuilder.DropColumn(
                name: "DepartamentoId1",
                schema: "GESTAOHOSPITAL",
                table: "Funcionario");

            migrationBuilder.DropColumn(
                name: "DepartamentoId",
                schema: "GESTAOHOSPITAL",
                table: "Atendimento");

            migrationBuilder.AlterColumn<int>(
                name: "EspecialidadeId",
                schema: "GESTAOHOSPITAL",
                table: "Atendimento",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
