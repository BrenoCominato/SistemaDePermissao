using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaDePermissao.Migrations
{
    public partial class migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "links",
                columns: table => new
                {
                    LinksID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descricao = table.Column<string>(nullable: true),
                    datacadastro = table.Column<DateTime>(nullable: false),
                    dataatualizacao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_links", x => x.LinksID);
                });

            migrationBuilder.CreateTable(
                name: "permissao",
                columns: table => new
                {
                    PermissaoID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UsuarioID = table.Column<int>(nullable: false),
                    LinksID = table.Column<int>(nullable: false),
                    descricao = table.Column<string>(nullable: true),
                    datacadastro = table.Column<DateTime>(nullable: false),
                    dataatualizacao = table.Column<DateTime>(nullable: false)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "permissao");

            migrationBuilder.DropTable(
                name: "links");
        }
    }
}
