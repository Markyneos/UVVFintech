using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UvvFintech.Data.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "ContaSequence");

            migrationBuilder.CreateTable(
                name: "ClienteS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numero = table.Column<int>(type: "int", nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Deposito",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    ContaId = table.Column<int>(type: "int", nullable: false),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContaId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deposito", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Saque",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    ContaId = table.Column<int>(type: "int", nullable: false),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContaId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saque", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transferencia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    ContaId = table.Column<int>(type: "int", nullable: false),
                    ContaDestinoId = table.Column<int>(type: "int", nullable: false),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Metodo = table.Column<int>(type: "int", nullable: false),
                    ContaId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transferencia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContaCorrente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [ContaSequence]"),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Saldo = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    LimiteSaque = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContaCorrente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContaCorrente_ClienteS_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "ClienteS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContaPoupanca",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [ContaSequence]"),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Saldo = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    LimiteSaque = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContaPoupanca", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContaPoupanca_ClienteS_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "ClienteS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContaCorrente_ClienteId",
                table: "ContaCorrente",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ContaPoupanca_ClienteId",
                table: "ContaPoupanca",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Deposito_ContaId",
                table: "Deposito",
                column: "ContaId");

            migrationBuilder.CreateIndex(
                name: "IX_Deposito_ContaId1",
                table: "Deposito",
                column: "ContaId1");

            migrationBuilder.CreateIndex(
                name: "IX_Saque_ContaId",
                table: "Saque",
                column: "ContaId");

            migrationBuilder.CreateIndex(
                name: "IX_Saque_ContaId1",
                table: "Saque",
                column: "ContaId1");

            migrationBuilder.CreateIndex(
                name: "IX_Transferencia_ContaDestinoId",
                table: "Transferencia",
                column: "ContaDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Transferencia_ContaId",
                table: "Transferencia",
                column: "ContaId");

            migrationBuilder.CreateIndex(
                name: "IX_Transferencia_ContaId1",
                table: "Transferencia",
                column: "ContaId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContaCorrente");

            migrationBuilder.DropTable(
                name: "ContaPoupanca");

            migrationBuilder.DropTable(
                name: "Deposito");

            migrationBuilder.DropTable(
                name: "Saque");

            migrationBuilder.DropTable(
                name: "Transferencia");

            migrationBuilder.DropTable(
                name: "ClienteS");

            migrationBuilder.DropSequence(
                name: "ContaSequence");
        }
    }
}
