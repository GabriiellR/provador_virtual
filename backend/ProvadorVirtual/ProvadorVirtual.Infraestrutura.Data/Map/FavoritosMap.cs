using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProvadorVirtual.Dominio.Models;

namespace ProvadorVirtual.Data.Map
{
    public class FavoritosMap : IEntityTypeConfiguration<Favoritos>
    {
        public void Configure(EntityTypeBuilder<Favoritos> builder)
        {
            builder.ToTable("favoritos");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.UsuarioId).HasColumnName("usuario_id");
            builder.Property(x => x.ProdutoId).HasColumnName("produto_id");

            builder.HasOne(x => x.Usuario).WithMany(x => x.Favoritos).HasForeignKey(x => x.UsuarioId);
            builder.HasOne(x => x.Produto).WithMany(x => x.Favoritos).HasForeignKey(x => x.ProdutoId);
        }
    }
}
