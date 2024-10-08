﻿// <auto-generated />
using System;
using GirlsRide.Web.Percistencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GirlsRide.Web.Migrations
{
    [DbContext(typeof(GirlsRideContext))]
    partial class GirlsRideContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GirlsRide.Web.Models.Agendamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("AgendamentoNo")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Agendamentos");
                });

            modelBuilder.Entity("GirlsRide.Web.Models.Avaliacao", b =>
                {
                    b.Property<int>("AvaliacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AvaliacaoId"), 1L, 1);

                    b.Property<int>("Nota")
                        .HasColumnType("int");

                    b.Property<string>("comentario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AvaliacaoId");

                    b.ToTable("Avaliacoes");
                });

            modelBuilder.Entity("GirlsRide.Web.Models.Carro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CarroId")
                        .HasColumnType("int");

                    b.Property<string>("ModeloCarro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SenhaPorta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CarroId");

                    b.ToTable("Carros");
                });

            modelBuilder.Entity("GirlsRide.Web.Models.Cartao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CartaoId")
                        .HasColumnType("int");

                    b.Property<int>("cvv")
                        .HasColumnType("int");

                    b.Property<string>("nomeImpresso")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nrCartao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("validade")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CartaoId");

                    b.ToTable("Cartoes");
                });

            modelBuilder.Entity("GirlsRide.Web.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CarroId")
                        .HasColumnType("int");

                    b.Property<int>("CartaoId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PagamentosId")
                        .HasColumnType("int");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("chegada")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("partida")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CarroId");

                    b.HasIndex("CartaoId");

                    b.HasIndex("PagamentosId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("GirlsRide.Web.Models.ClienteAgendamento", b =>
                {
                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("AgendamentoId")
                        .HasColumnType("int");

                    b.HasKey("ClienteId", "AgendamentoId");

                    b.HasIndex("AgendamentoId");

                    b.ToTable("clienteAgendamentos");
                });

            modelBuilder.Entity("GirlsRide.Web.Models.Pagamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("pagamentos");
                });

            modelBuilder.Entity("GirlsRide.Web.Models.Carro", b =>
                {
                    b.HasOne("GirlsRide.Web.Models.Carro", null)
                        .WithMany("Carros")
                        .HasForeignKey("CarroId");
                });

            modelBuilder.Entity("GirlsRide.Web.Models.Cartao", b =>
                {
                    b.HasOne("GirlsRide.Web.Models.Cartao", null)
                        .WithMany("Cartoes")
                        .HasForeignKey("CartaoId");
                });

            modelBuilder.Entity("GirlsRide.Web.Models.Cliente", b =>
                {
                    b.HasOne("GirlsRide.Web.Models.Carro", "Carros")
                        .WithMany()
                        .HasForeignKey("CarroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GirlsRide.Web.Models.Cartao", "Cartoes")
                        .WithMany()
                        .HasForeignKey("CartaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GirlsRide.Web.Models.Pagamento", "Pagamentos")
                        .WithMany()
                        .HasForeignKey("PagamentosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carros");

                    b.Navigation("Cartoes");

                    b.Navigation("Pagamentos");
                });

            modelBuilder.Entity("GirlsRide.Web.Models.ClienteAgendamento", b =>
                {
                    b.HasOne("GirlsRide.Web.Models.Agendamento", "Agendamento")
                        .WithMany("clienteAgendamentos")
                        .HasForeignKey("AgendamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GirlsRide.Web.Models.Cliente", "Cliente")
                        .WithMany("clienteAgendamentos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agendamento");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("GirlsRide.Web.Models.Agendamento", b =>
                {
                    b.Navigation("clienteAgendamentos");
                });

            modelBuilder.Entity("GirlsRide.Web.Models.Carro", b =>
                {
                    b.Navigation("Carros");
                });

            modelBuilder.Entity("GirlsRide.Web.Models.Cartao", b =>
                {
                    b.Navigation("Cartoes");
                });

            modelBuilder.Entity("GirlsRide.Web.Models.Cliente", b =>
                {
                    b.Navigation("clienteAgendamentos");
                });
#pragma warning restore 612, 618
        }
    }
}
