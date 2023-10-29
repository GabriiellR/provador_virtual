using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProvadorVirtual.Dominio.Models;

namespace ProvadorVirtual.Data.Map
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("produtos");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasColumnName("nome");
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Preco).HasColumnName("preco").HasColumnType("decimal(10,2)");
            builder.Property(x => x.Cor).HasColumnName("cor");
            builder.Property(x => x.Tamanho).HasColumnName("tamanho");
            builder.Property(x => x.Material).HasColumnName("material");
            builder.Property(x => x.Imagem).HasColumnName("imagem");
            builder.Property(x => x.ImagemGravataProvador).HasColumnName("imagem_gravata_provador");
            builder.Property(x => x.Descricao).HasColumnName("descricao");

            builder.Property(x => x.CategoriaId).HasColumnName("categoria_id");
            builder.HasOne(x => x.Categoria).WithMany(x => x.Produtos).HasForeignKey(x => x.CategoriaId);

        }
    }
}
