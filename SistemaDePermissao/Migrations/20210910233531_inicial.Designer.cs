﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaDePermissao.Data;

namespace SistemaDePermissao.Migrations
{
    [DbContext(typeof(SistemaDePermissaoContext))]
    [Migration("20210910233531_inicial")]
    partial class inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SistemaDePermissao.Models.usuario", b =>
                {
                    b.Property<int>("UsuarioID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("cargo")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("dataatualizacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("datacadastro")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("nome")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("UsuarioID");

                    b.ToTable("usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
