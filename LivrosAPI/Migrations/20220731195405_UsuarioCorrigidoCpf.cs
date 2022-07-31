using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LivrosAPI.Migrations
{
    public partial class UsuarioCorrigidoCpf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cpf",
                table: "usuario",
                newName: "cpf");

            migrationBuilder.AlterColumn<DateTime>(
                name: "validade_token",
                table: "usuario",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<string>(
                name: "token",
                table: "usuario",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "cpf",
                table: "usuario",
                newName: "Cpf");

            migrationBuilder.AlterColumn<DateTime>(
                name: "validade_token",
                table: "usuario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "usuario",
                keyColumn: "token",
                keyValue: null,
                column: "token",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "token",
                table: "usuario",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
