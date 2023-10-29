using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProvadorVirtual.Infraestrutura.Data.Migrations
{
    /// <inheritdoc />
    public partial class Create_Entityes2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagemGravataProvador",
                table: "produtos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ProdutoImagensProvador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    Imagem = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoImagensProvador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdutoImagensProvador_produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "produtos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoImagensProvador_ProdutoId",
                table: "ProdutoImagensProvador",
                column: "ProdutoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdutoImagensProvador");

            migrationBuilder.DropColumn(
                name: "ImagemGravataProvador",
                table: "produtos");
        }
    }
}
