using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StackGestaoDeHospital.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class CorrecaoAtendimentoEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                schema: "GESTAOHOSPITAL",
                table: "Atendimento",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MedicoId",
                schema: "GESTAOHOSPITAL",
                table: "Atendimento",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EnfermeiroId",
                schema: "GESTAOHOSPITAL",
                table: "Atendimento",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                schema: "GESTAOHOSPITAL",
                table: "Atendimento",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "MedicoId",
                schema: "GESTAOHOSPITAL",
                table: "Atendimento",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EnfermeiroId",
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
