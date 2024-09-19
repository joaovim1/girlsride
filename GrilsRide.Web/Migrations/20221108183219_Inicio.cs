using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GirlsRide.Web.Migrations
{
    public partial class Inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agendamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgendamentoNo = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Avaliacoes",
                columns: table => new
                {
                    AvaliacaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nota = table.Column<int>(type: "int", nullable: false),
                    comentario = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacoes", x => x.AvaliacaoId);
                });

            migrationBuilder.CreateTable(
                name: "Carros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModeloCarro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Placa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenhaPorta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarroId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carros_Carros_CarroId",
                        column: x => x.CarroId,
                        principalTable: "Carros",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cartoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nrCartao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    validade = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cvv = table.Column<int>(type: "int", nullable: false),
                    nomeImpresso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CartaoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cartoes_Cartoes_CartaoId",
                        column: x => x.CartaoId,
                        principalTable: "Cartoes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "pagamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Total = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pagamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    partida = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    chegada = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarroId = table.Column<int>(type: "int", nullable: false),
                    CartaoId = table.Column<int>(type: "int", nullable: false),
                    PagamentosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clientes_Carros_CarroId",
                        column: x => x.CarroId,
                        principalTable: "Carros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clientes_Cartoes_CartaoId",
                        column: x => x.CartaoId,
                        principalTable: "Cartoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clientes_pagamentos_PagamentosId",
                        column: x => x.PagamentosId,
                        principalTable: "pagamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "clienteAgendamentos",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    AgendamentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clienteAgendamentos", x => new { x.ClienteId, x.AgendamentoId });
                    table.ForeignKey(
                        name: "FK_clienteAgendamentos_Agendamentos_AgendamentoId",
                        column: x => x.AgendamentoId,
                        principalTable: "Agendamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_clienteAgendamentos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carros_CarroId",
                table: "Carros",
                column: "CarroId");

            migrationBuilder.CreateIndex(
                name: "IX_Cartoes_CartaoId",
                table: "Cartoes",
                column: "CartaoId");

            migrationBuilder.CreateIndex(
                name: "IX_clienteAgendamentos_AgendamentoId",
                table: "clienteAgendamentos",
                column: "AgendamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_CarroId",
                table: "Clientes",
                column: "CarroId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_CartaoId",
                table: "Clientes",
                column: "CartaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_PagamentosId",
                table: "Clientes",
                column: "PagamentosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Avaliacoes");

            migrationBuilder.DropTable(
                name: "clienteAgendamentos");

            migrationBuilder.DropTable(
                name: "Agendamentos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Carros");

            migrationBuilder.DropTable(
                name: "Cartoes");

            migrationBuilder.DropTable(
                name: "pagamentos");
        }
    }
}
