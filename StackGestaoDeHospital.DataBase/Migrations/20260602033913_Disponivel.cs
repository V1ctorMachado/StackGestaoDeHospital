using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StackGestaoDeHospital.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class Disponivel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Disponivel",
                schema: "GESTAOHOSPITAL",
                table: "Funcionario",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Disponivel",
                schema: "GESTAOHOSPITAL",
                table: "Funcionario");
        }
    }
}
