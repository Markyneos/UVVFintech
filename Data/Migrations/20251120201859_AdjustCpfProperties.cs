using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UvvFintech.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdjustCpfProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Cliente",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(11)",
                oldFixedLength: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Cliente",
                type: "char(11)",
                fixedLength: true,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);
        }
    }
}
