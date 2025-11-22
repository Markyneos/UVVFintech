using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UvvFintech.Data.Migrations
{
    /// <inheritdoc />
    public partial class TurnedContaNumeroUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ContaPoupanca_Numero",
                table: "ContaPoupanca",
                column: "Numero",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ContaPoupanca_Numero",
                table: "ContaPoupanca");
        }
    }
}
