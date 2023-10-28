using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProvadorVirtual.Dominio.Models;

namespace ProvadorVirtual.Data.Map
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuarios");
            builder.HasKey(prop => prop.Id);
            builder.Property(prop => prop.Id).HasColumnName("id");

            builder.Property(prop => prop.Nome).HasColumnName("nome").HasColumnType("varchar").HasMaxLength(70);
            builder.Property(prop => prop.Senha).HasColumnName("senha").HasColumnType("varchar").HasMaxLength(30);
            builder.Property(prop => prop.Email).HasColumnName("email").HasColumnType("varchar").HasMaxLength(50);
            builder.Property(prop => prop.cep).HasColumnName("cep").HasColumnType("varchar").HasMaxLength(9);
            builder.Property(prop => prop.Bairro).HasColumnName("bairro").HasColumnType("varchar").HasMaxLength(150);
            builder.Property(prop => prop.Cidade).HasColumnName("cidade").HasColumnType("varchar").HasMaxLength(150);
            builder.Property(prop => prop.Endereco).HasColumnName("endereco").HasColumnType("varchar").HasMaxLength(100);
            builder.Property(prop => prop.DataNascimento).HasColumnName("data_nascimento");
        }
    }
}
