using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaDePermissao.Migrations
{
    public partial class migration5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "permissao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "permissao",
                columns: table => new
                {
                    PermissaoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LinksID = table.Column<int>(type: "int", nullable: false),
                    UsuarioID = table.Column<int>(type: "int", nullable: false),
                    datacadastro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    descricao = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissao", x => x.PermissaoID);
                    table.ForeignKey(
                        name: "FK_permissao_links_LinksID",
                        column: x => x.LinksID,
                        principalTable: "links",
                        principalColumn: "LinksID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_permissao_usuario_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "usuario",
                        principalColumn: "UsuarioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_permissao_LinksID",
                table: "permissao",
                column: "LinksID");

            migrationBuilder.CreateIndex(
                name: "IX_permissao_UsuarioID",
                table: "permissao",
                column: "UsuarioID");
        }
    }
}
