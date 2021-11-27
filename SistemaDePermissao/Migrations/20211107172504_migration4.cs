using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaDePermissao.Migrations
{
    public partial class migration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoDeUsuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descriçao = table.Column<string>(nullable: true),
                    UsuarioID = table.Column<int>(nullable: false),
                    LinksID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDeUsuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TipoDeUsuario_links_LinksID",
                        column: x => x.LinksID,
                        principalTable: "links",
                        principalColumn: "LinksID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TipoDeUsuario_usuario_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "usuario",
                        principalColumn: "UsuarioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TipoDeUsuario_LinksID",
                table: "TipoDeUsuario",
                column: "LinksID");

            migrationBuilder.CreateIndex(
                name: "IX_TipoDeUsuario_UsuarioID",
                table: "TipoDeUsuario",
                column: "UsuarioID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TipoDeUsuario");
        }
    }
}
