using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaDePermissao.Migrations
{
    public partial class migration6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TipoDeUsuario_links_LinksID",
                table: "TipoDeUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_TipoDeUsuario_usuario_UsuarioID",
                table: "TipoDeUsuario");

            migrationBuilder.DropIndex(
                name: "IX_TipoDeUsuario_LinksID",
                table: "TipoDeUsuario");

            migrationBuilder.DropIndex(
                name: "IX_TipoDeUsuario_UsuarioID",
                table: "TipoDeUsuario");

            migrationBuilder.DropColumn(
                name: "dataatualizacao",
                table: "usuario");

            migrationBuilder.DropColumn(
                name: "datacadastro",
                table: "usuario");

            migrationBuilder.DropColumn(
                name: "LinksID",
                table: "TipoDeUsuario");

            migrationBuilder.DropColumn(
                name: "UsuarioID",
                table: "TipoDeUsuario");

            migrationBuilder.DropColumn(
                name: "dataatualizacao",
                table: "links");

            migrationBuilder.DropColumn(
                name: "datacadastro",
                table: "links");

            migrationBuilder.AddColumn<string>(
                name: "senha",
                table: "usuario",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "tipoDeUsuarioId",
                table: "usuario",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "tipoDeUsuarioId",
                table: "links",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_usuario_tipoDeUsuarioId",
                table: "usuario",
                column: "tipoDeUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_links_tipoDeUsuarioId",
                table: "links",
                column: "tipoDeUsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_links_TipoDeUsuario_tipoDeUsuarioId",
                table: "links",
                column: "tipoDeUsuarioId",
                principalTable: "TipoDeUsuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_usuario_TipoDeUsuario_tipoDeUsuarioId",
                table: "usuario",
                column: "tipoDeUsuarioId",
                principalTable: "TipoDeUsuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_links_TipoDeUsuario_tipoDeUsuarioId",
                table: "links");

            migrationBuilder.DropForeignKey(
                name: "FK_usuario_TipoDeUsuario_tipoDeUsuarioId",
                table: "usuario");

            migrationBuilder.DropIndex(
                name: "IX_usuario_tipoDeUsuarioId",
                table: "usuario");

            migrationBuilder.DropIndex(
                name: "IX_links_tipoDeUsuarioId",
                table: "links");

            migrationBuilder.DropColumn(
                name: "senha",
                table: "usuario");

            migrationBuilder.DropColumn(
                name: "tipoDeUsuarioId",
                table: "usuario");

            migrationBuilder.DropColumn(
                name: "tipoDeUsuarioId",
                table: "links");

            migrationBuilder.AddColumn<DateTime>(
                name: "dataatualizacao",
                table: "usuario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "datacadastro",
                table: "usuario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "LinksID",
                table: "TipoDeUsuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioID",
                table: "TipoDeUsuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "dataatualizacao",
                table: "links",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "datacadastro",
                table: "links",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_TipoDeUsuario_LinksID",
                table: "TipoDeUsuario",
                column: "LinksID");

            migrationBuilder.CreateIndex(
                name: "IX_TipoDeUsuario_UsuarioID",
                table: "TipoDeUsuario",
                column: "UsuarioID");

            migrationBuilder.AddForeignKey(
                name: "FK_TipoDeUsuario_links_LinksID",
                table: "TipoDeUsuario",
                column: "LinksID",
                principalTable: "links",
                principalColumn: "LinksID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TipoDeUsuario_usuario_UsuarioID",
                table: "TipoDeUsuario",
                column: "UsuarioID",
                principalTable: "usuario",
                principalColumn: "UsuarioID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
