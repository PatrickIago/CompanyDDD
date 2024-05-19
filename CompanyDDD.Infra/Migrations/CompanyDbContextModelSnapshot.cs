﻿using CompanyDDD.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

#nullable disable

namespace CompanyDDD.Infra.Migrations;

[DbContext(typeof(CompanyDbContext))]
partial class CompanyDbContextModelSnapshot : ModelSnapshot
{
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
        modelBuilder
            .HasAnnotation("ProductVersion", "8.0.5")
            .HasAnnotation("Relational:MaxIdentifierLength", 128);

        SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

        modelBuilder.Entity("CompanyDDD.Domain.Entities.Funcionario", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));


                b.Property<DateTime>("DataNascimento")
                    .HasColumnType("datetime2");


                b.Property<string>("Nome")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");


                b.Property<decimal>("Salario")
                    .HasColumnType("decimal(18,2)");

                b.Property<int>("tipoFuncionario")
                    .HasColumnType("int");


                b.HasKey("Id");

                b.ToTable("Funcionarios");
            });
#pragma warning restore 612, 618
    }
}
