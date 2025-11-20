using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UvvFintech.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnClienteNome : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Cliente",
                type: "char(11)",
                fixedLength: true,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Cliente",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Cliente");

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Cliente",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(11)",
                oldFixedLength: true);
        }
    }
}
