﻿// <auto-generated />
using System;
using CatalogoDeJogos.Data.ContextDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CatalogoDeJogos.Data.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20210911235846_tabelaInicial")]
    partial class tabelaInicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CatalogoDeJogos.Model.Entities.Jogo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Genero")
                        .HasColumnType("int");

                    b.Property<Guid>("IdPlataforma")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Preco")
                        .HasColumnType("float");

                    b.Property<string>("Produtora")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdPlataforma");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("CatalogoDeJogos.Model.Entities.Plataforma", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Ano")
                        .HasColumnType("int");

                    b.Property<string>("Desenvolvedor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Console");
                });

            modelBuilder.Entity("CatalogoDeJogos.Model.Entities.Jogo", b =>
                {
                    b.HasOne("CatalogoDeJogos.Model.Entities.Plataforma", "PlataformaConsole")
                        .WithMany("Jogos")
                        .HasForeignKey("IdPlataforma")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlataformaConsole");
                });

            modelBuilder.Entity("CatalogoDeJogos.Model.Entities.Plataforma", b =>
                {
                    b.Navigation("Jogos");
                });
#pragma warning restore 612, 618
        }
    }
}
