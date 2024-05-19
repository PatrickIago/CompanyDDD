using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyDDD.Infra.Migrations;

/// <inheritdoc />
public partial class AddDataNascimentoAndSalarioToFuncionario : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "tipoFuncionario",
            table: "Funcionarios");

        migrationBuilder.AddColumn<DateTime>(
            name: "DataNascimento",
            table: "Funcionarios",
            type: "datetime2",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

        migrationBuilder.AddColumn<decimal>(
            name: "Salario",
            table: "Funcionarios",
            type: "decimal(18,2)",
            nullable: false,
            defaultValue: 0m);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "DataNascimento",
            table: "Funcionarios");

        migrationBuilder.DropColumn(
            name: "Salario",
            table: "Funcionarios");

        migrationBuilder.AddColumn<int>(
            name: "tipoFuncionario",
            table: "Funcionarios",
            type: "int",
            nullable: false,
            defaultValue: 0);
    }
}
