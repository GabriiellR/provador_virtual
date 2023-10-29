using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProvadorVirtual.Infraestrutura.Data.Migrations
{
    /// <inheritdoc />
    public partial class Create_Entityes3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoImagensProvador_produtos_ProdutoId",
                table: "ProdutoImagensProvador");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProdutoImagensProvador",
                table: "ProdutoImagensProvador");

            migrationBuilder.RenameTable(
                name: "ProdutoImagensProvador",
                newName: "produto_iamgem_provador");

            migrationBuilder.RenameColumn(
                name: "Imagem",
                table: "produto_iamgem_provador",
                newName: "imagem");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "produto_iamgem_provador",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ProdutoId",
                table: "produto_iamgem_provador",
                newName: "produto_id");

            migrationBuilder.RenameIndex(
                name: "IX_ProdutoImagensProvador_ProdutoId",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_produto_iamgem_provador_produtos_produto_id",
                table: "produto_iamgem_provador");

            migrationBuilder.DropPrimaryKey(
                name: "PK_produto_iamgem_provador",
                table: "produto_iamgem_provador");

            migrationBuilder.RenameTable(
                name: "produto_iamgem_provador",
                newName: "ProdutoImagensProvador");

            migrationBuilder.RenameColumn(
                name: "imagem",
                table: "ProdutoImagensProvador",
                newName: "Imagem");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ProdutoImagensProvador",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "produto_id",
                table: "ProdutoImagensProvador",
                newName: "ProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_produto_iamgem_provador_produto_id",
                table: "ProdutoImagensProvador",
                newName: "IX_ProdutoImagensProvador_ProdutoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProdutoImagensProvador",
                table: "ProdutoImagensProvador",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoImagensProvador_produtos_ProdutoId",
                table: "ProdutoImagensProvador",
                column: "ProdutoId",
                principalTable: "produtos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
