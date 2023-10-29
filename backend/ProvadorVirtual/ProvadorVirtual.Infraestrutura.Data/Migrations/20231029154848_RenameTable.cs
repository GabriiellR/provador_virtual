using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProvadorVirtual.Infraestrutura.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenameTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_produto_iamgem_provador_produtos_produto_id",
                table: "produto_iamgem_provador");

            migrationBuilder.DropPrimaryKey(
                name: "PK_produto_iamgem_provador",
                table: "produto_iamgem_provador");

            migrationBuilder.RenameTable(
                name: "produto_iamgem_provador",
                newName: "produto_imagem_provador");

            migrationBuilder.RenameIndex(
                name: "IX_produto_iamgem_provador_produto_id",
                table: "produto_imagem_provador",
                newName: "IX_produto_imagem_provador_produto_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_produto_imagem_provador",
                table: "produto_imagem_provador",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_produto_imagem_provador_produtos_produto_id",
                table: "produto_imagem_provador",
                column: "produto_id",
                principalTable: "produtos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_produto_imagem_provador_produtos_produto_id",
                table: "produto_imagem_provador");

            migrationBuilder.DropPrimaryKey(
                name: "PK_produto_imagem_provador",
                table: "produto_imagem_provador");

            migrationBuilder.RenameTable(
                name: "produto_imagem_provador",
                newName: "produto_iamgem_provador");

            migrationBuilder.RenameIndex(
                name: "IX_produto_imagem_provador_produto_id",
                table: "produto_iamgem_provador",
                newName: "IX_produto_iamgem_provador_produto_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_produto_iamgem_provador",
                table: "produto_iamgem_provador",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_produto_iamgem_provador_produtos_produto_id",
                table: "produto_iamgem_provador",
                column: "produto_id",
                principalTable: "produtos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
