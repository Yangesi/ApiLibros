﻿// <auto-generated />
using System;
using APILibros.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APILibros.Migrations
{
    [DbContext(typeof(StoreContext))]
    partial class StoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("APILibros.Models.Autor", b =>
                {
                    b.Property<int>("AutorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AutorId"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nacionalidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AutorId");

                    b.ToTable("autores");
                });

            modelBuilder.Entity("APILibros.Models.Departamento", b =>
                {
                    b.Property<int>("CodigoPais")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("CodigoDepartamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodigoDepartamento"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CodigoPais", "CodigoDepartamento");

                    b.ToTable("Departamentos");
                });

            modelBuilder.Entity("APILibros.Models.Libro", b =>
                {
                    b.Property<int>("LibroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LibroId"));

                    b.Property<int>("AutorId")
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LibroDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LibroName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Precio")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("LibroId");

                    b.HasIndex("AutorId");

                    b.ToTable("libros");
                });

            modelBuilder.Entity("APILibros.Models.Municipio", b =>
                {
                    b.Property<int>("CodigoPais")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("CodigoDepartamento")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<int>("CodigoMunicipio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(2);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodigoMunicipio"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CodigoPais", "CodigoDepartamento", "CodigoMunicipio");

                    b.ToTable("Municipios");
                });

            modelBuilder.Entity("APILibros.Models.Pais", b =>
                {
                    b.Property<int>("CodigoPais")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodigoPais"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CodigoPais");

                    b.ToTable("Paises");
                });

            modelBuilder.Entity("APILibros.Models.Departamento", b =>
                {
                    b.HasOne("APILibros.Models.Pais", "Pais")
                        .WithMany("Departamentos")
                        .HasForeignKey("CodigoPais")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pais");
                });

            modelBuilder.Entity("APILibros.Models.Libro", b =>
                {
                    b.HasOne("APILibros.Models.Autor", "Autor")
                        .WithMany("Libros")
                        .HasForeignKey("AutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autor");
                });

            modelBuilder.Entity("APILibros.Models.Municipio", b =>
                {
                    b.HasOne("APILibros.Models.Departamento", "Departamento")
                        .WithMany("Municipios")
                        .HasForeignKey("CodigoPais", "CodigoDepartamento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departamento");
                });

            modelBuilder.Entity("APILibros.Models.Autor", b =>
                {
                    b.Navigation("Libros");
                });

            modelBuilder.Entity("APILibros.Models.Departamento", b =>
                {
                    b.Navigation("Municipios");
                });

            modelBuilder.Entity("APILibros.Models.Pais", b =>
                {
                    b.Navigation("Departamentos");
                });
#pragma warning restore 612, 618
        }
    }
}