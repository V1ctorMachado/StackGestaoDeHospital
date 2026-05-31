using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StackGestaoDeHospital.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class Atendimento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Especialidade",
                schema: "GESTAOHOSPITAL",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                schema: "GESTAOHOSPITAL",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Sobrenome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                schema: "GESTAOHOSPITAL",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Matricula = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Salario = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funcionario_Pessoa_Id",
                        column: x => x.Id,
                        principalSchema: "GESTAOHOSPITAL",
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                schema: "GESTAOHOSPITAL",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    NumeroCarteirinha = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PlanoSaude = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paciente_Pessoa_Id",
                        column: x => x.Id,
                        principalSchema: "GESTAOHOSPITAL",
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enfermeiro",
                schema: "GESTAOHOSPITAL",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CRE = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enfermeiro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enfermeiro_Funcionario_Id",
                        column: x => x.Id,
                        principalSchema: "GESTAOHOSPITAL",
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medico",
                schema: "GESTAOHOSPITAL",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CRM = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medico_Funcionario_Id",
                        column: x => x.Id,
                        principalSchema: "GESTAOHOSPITAL",
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Atendimento",
                schema: "GESTAOHOSPITAL",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Queixa = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Diagnostico = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    EspecialidadeId = table.Column<int>(type: "int", nullable: false),
                    EnfermeiroId = table.Column<int>(type: "int", nullable: false),
                    MedicoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atendimento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atendimento_Enfermeiro_EnfermeiroId",
                        column: x => x.EnfermeiroId,
                        principalSchema: "GESTAOHOSPITAL",
                        principalTable: "Enfermeiro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Atendimento_Especialidade_EspecialidadeId",
                        column: x => x.EspecialidadeId,
                        principalSchema: "GESTAOHOSPITAL",
                        principalTable: "Especialidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Atendimento_Medico_MedicoId",
                        column: x => x.MedicoId,
                        principalSchema: "GESTAOHOSPITAL",
                        principalTable: "Medico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedicoEspecialidade",
                schema: "GESTAOHOSPITAL",
                columns: table => new
                {
                    EspecialidadesId = table.Column<int>(type: "int", nullable: false),
                    MedicoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicoEspecialidade", x => new { x.EspecialidadesId, x.MedicoId });
                    table.ForeignKey(
                        name: "FK_MedicoEspecialidade_Especialidade_EspecialidadesId",
                        column: x => x.EspecialidadesId,
                        principalSchema: "GESTAOHOSPITAL",
                        principalTable: "Especialidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicoEspecialidade_Medico_MedicoId",
                        column: x => x.MedicoId,
                        principalSchema: "GESTAOHOSPITAL",
                        principalTable: "Medico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_EnfermeiroId",
                schema: "GESTAOHOSPITAL",
                table: "Atendimento",
                column: "EnfermeiroId");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_EspecialidadeId",
                schema: "GESTAOHOSPITAL",
                table: "Atendimento",
                column: "EspecialidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_MedicoId",
                schema: "GESTAOHOSPITAL",
                table: "Atendimento",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Enfermeiro_CRE",
                schema: "GESTAOHOSPITAL",
                table: "Enfermeiro",
                column: "CRE",
                unique: true,
                filter: "[CRE] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_Matricula",
                schema: "GESTAOHOSPITAL",
                table: "Funcionario",
                column: "Matricula",
                unique: true,
                filter: "[Matricula] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Medico_CRM",
                schema: "GESTAOHOSPITAL",
                table: "Medico",
                column: "CRM",
                unique: true,
                filter: "[CRM] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MedicoEspecialidade_MedicoId",
                schema: "GESTAOHOSPITAL",
                table: "MedicoEspecialidade",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_CPF",
                schema: "GESTAOHOSPITAL",
                table: "Pessoa",
                column: "CPF",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atendimento",
                schema: "GESTAOHOSPITAL");

            migrationBuilder.DropTable(
                name: "MedicoEspecialidade",
                schema: "GESTAOHOSPITAL");

            migrationBuilder.DropTable(
                name: "Paciente",
                schema: "GESTAOHOSPITAL");

            migrationBuilder.DropTable(
                name: "Enfermeiro",
                schema: "GESTAOHOSPITAL");

            migrationBuilder.DropTable(
                name: "Especialidade",
                schema: "GESTAOHOSPITAL");

            migrationBuilder.DropTable(
                name: "Medico",
                schema: "GESTAOHOSPITAL");

            migrationBuilder.DropTable(
                name: "Funcionario",
                schema: "GESTAOHOSPITAL");

            migrationBuilder.DropTable(
                name: "Pessoa",
                schema: "GESTAOHOSPITAL");
        }
    }
}
