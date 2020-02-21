﻿// <auto-generated />
using System;
using BibliotecaPessoal.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BibliotecaPessoal.Migrations
{
    [DbContext(typeof(BibliotecaPessoalContext))]
    [Migration("20200221132440_AdiTableBibliotecas")]
    partial class AdiTableBibliotecas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BibliotecaPessoal.Models.Biblioteca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Avaliacao");

                    b.Property<string>("Comentario")
                        .HasMaxLength(200);

                    b.Property<DateTime>("FinalLeitura");

                    b.Property<DateTime>("InicioLeitura");

                    b.Property<int>("LivroID");

                    b.Property<int>("Situacao");

                    b.Property<int>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("LivroID");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Biblioteca");
                });

            modelBuilder.Entity("BibliotecaPessoal.Models.Editora", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Editora");
                });

            modelBuilder.Entity("BibliotecaPessoal.Models.Livro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EditoraId");

                    b.Property<string>("Isbn10")
                        .HasMaxLength(20);

                    b.Property<string>("Isbn30")
                        .HasMaxLength(20);

                    b.Property<string>("Nome")
                        .HasMaxLength(50);

                    b.Property<int>("Paginas");

                    b.HasKey("Id");

                    b.HasIndex("EditoraId");

                    b.ToTable("Livro");
                });

            modelBuilder.Entity("BibliotecaPessoal.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCadastro");

                    b.Property<string>("Login")
                        .HasMaxLength(10);

                    b.Property<string>("Nome")
                        .HasMaxLength(60);

                    b.Property<string>("Senha")
                        .HasMaxLength(8);

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("BibliotecaPessoal.Models.Biblioteca", b =>
                {
                    b.HasOne("BibliotecaPessoal.Models.Livro", "Livro")
                        .WithMany()
                        .HasForeignKey("LivroID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BibliotecaPessoal.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BibliotecaPessoal.Models.Livro", b =>
                {
                    b.HasOne("BibliotecaPessoal.Models.Editora", "Editora")
                        .WithMany()
                        .HasForeignKey("EditoraId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
