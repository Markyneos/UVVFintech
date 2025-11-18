using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UvvFintech.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenomearTabelaCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContaCorrente_ClienteS_ClienteId",
                table: "ContaCorrente");

            migrationBuilder.DropForeignKey(
                name: "FK_ContaPoupanca_ClienteS_ClienteId",
                table: "ContaPoupanca");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClienteS",
                table: "ClienteS");

            migrationBuilder.RenameTable(
                name: "ClienteS",
                newName: "Cliente");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContaCorrente_Cliente_ClienteId",
                table: "ContaCorrente",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContaPoupanca_Cliente_ClienteId",
                table: "ContaPoupanca",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContaCorrente_Cliente_ClienteId",
                table: "ContaCorrente");

            migrationBuilder.DropForeignKey(
                name: "FK_ContaPoupanca_Cliente_ClienteId",
                table: "ContaPoupanca");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente");

            migrationBuilder.RenameTable(
                name: "Cliente",
                newName: "ClienteS");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClienteS",
                table: "ClienteS",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContaCorrente_ClienteS_ClienteId",
                table: "ContaCorrente",
                column: "ClienteId",
                principalTable: "ClienteS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContaPoupanca_ClienteS_ClienteId",
                table: "ContaPoupanca",
                column: "ClienteId",
                principalTable: "ClienteS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
