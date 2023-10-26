using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProvadorVirtual.Dominio.Models;

namespace ProvadorVirtual.Infraestrutura.Data.Map
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuarios");
            builder.HasKey(prop => prop.Id);
            builder.Property(prop => prop.Id).HasColumnName("id");

            builder.Property(prop => prop.Nome).HasColumnName("nome").HasColumnType("varchar").HasMaxLength(150);
            builder.Property(prop => prop.Senha).HasColumnName("senha").HasColumnType("varchar").HasMaxLength(40);
            builder.Property(prop => prop.Email).HasColumnName("email").HasColumnType("varchar").HasMaxLength(150);
        }
    }
}
