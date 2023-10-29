using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProvadorVirtual.Dominio.Models;

namespace ProvadorVirtual.Data.Map
{
    public class ProdutoImagemProvadorMap : IEntityTypeConfiguration<ProdutoImagensProvador>
    {
        public void Configure(EntityTypeBuilder<ProdutoImagensProvador> builder)
        {
            builder.ToTable("produto_iamgem_provador");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Imagem).HasColumnName("imagem");
            builder.Property(x => x.ProdutoId).HasColumnName("produto_id");

            builder.HasOne(x => x.Produto).WithMany(x => x.ProdutoImagensProvador).HasForeignKey(x => x.ProdutoId);
        }
    }
}
