﻿// <auto-generated />
using System;
using LivrosAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LivrosAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("LivrosAPI.Models.Autor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<string>("NomeCompleto")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("nome_completo");

                    b.HasKey("Id");

                    b.ToTable("autor");
                });

            modelBuilder.Entity("LivrosAPI.Models.Editora", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("editora");

                    b.HasKey("Id");

                    b.ToTable("editora");
                });

            modelBuilder.Entity("LivrosAPI.Models.Emprestimo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<long>("LivroId")
                        .HasColumnType("bigint")
                        .HasColumnName("livro_id");

                    b.Property<long>("UsuarioId")
                        .HasColumnType("bigint")
                        .HasColumnName("usuario_id");

                    b.HasKey("Id");

                    b.HasIndex("LivroId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("emprestimo");
                });

            modelBuilder.Entity("LivrosAPI.Models.Livro", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<int?>("AnoPublicacao")
                        .HasColumnType("int")
                        .HasColumnName("ano_publicacao");

                    b.Property<long>("AutorId")
                        .HasColumnType("bigint")
                        .HasColumnName("autor_id");

                    b.Property<long>("EditoraId")
                        .HasColumnType("bigint")
                        .HasColumnName("editora_id");

                    b.Property<string>("Idioma")
                        .HasColumnType("longtext")
                        .HasColumnName("idioma");

                    b.Property<string>("Isbn")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("varchar(13)")
                        .HasColumnName("isbn");

                    b.Property<int?>("NumeroDePaginas")
                        .HasColumnType("int")
                        .HasColumnName("numero_de_paginas");

                    b.Property<int?>("QuantidadeDisponivel")
                        .HasColumnType("int")
                        .HasColumnName("quantidade_disponivel");

                    b.Property<string>("Serie")
                        .HasColumnType("longtext")
                        .HasColumnName("serie");

                    b.Property<string>("Subtitulo")
                        .HasColumnType("longtext")
                        .HasColumnName("subtitulo");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("titulo");

                    b.Property<int?>("Volume")
                        .HasColumnType("int")
                        .HasColumnName("volume");

                    b.HasKey("Id");

                    b.HasIndex("AutorId");

                    b.HasIndex("EditoraId");

                    b.ToTable("livro");
                });

            modelBuilder.Entity("LivrosAPI.Models.Usuario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)")
                        .HasColumnName("cpf");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("email");

                    b.Property<string>("Matricula")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("varchar(6)")
                        .HasColumnName("matricula");

                    b.Property<string>("NomeCompleto")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("nome_completo");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("senha");

                    b.Property<string>("Token")
                        .HasColumnType("longtext")
                        .HasColumnName("token");

                    b.Property<DateTime?>("ValidadeToken")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("validade_token");

                    b.HasKey("Id");

                    b.ToTable("usuario");
                });

            modelBuilder.Entity("LivrosAPI.Models.Emprestimo", b =>
                {
                    b.HasOne("LivrosAPI.Models.Livro", "Livro")
                        .WithMany("Emprestimos")
                        .HasForeignKey("LivroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LivrosAPI.Models.Usuario", "Usuario")
                        .WithMany("Emprestimos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Livro");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("LivrosAPI.Models.Livro", b =>
                {
                    b.HasOne("LivrosAPI.Models.Autor", "Autor")
                        .WithMany("Livros")
                        .HasForeignKey("AutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LivrosAPI.Models.Editora", "Editora")
                        .WithMany("Livros")
                        .HasForeignKey("EditoraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autor");

                    b.Navigation("Editora");
                });

            modelBuilder.Entity("LivrosAPI.Models.Autor", b =>
                {
                    b.Navigation("Livros");
                });

            modelBuilder.Entity("LivrosAPI.Models.Editora", b =>
                {
                    b.Navigation("Livros");
                });

            modelBuilder.Entity("LivrosAPI.Models.Livro", b =>
                {
                    b.Navigation("Emprestimos");
                });

            modelBuilder.Entity("LivrosAPI.Models.Usuario", b =>
                {
                    b.Navigation("Emprestimos");
                });
#pragma warning restore 612, 618
        }
    }
}
