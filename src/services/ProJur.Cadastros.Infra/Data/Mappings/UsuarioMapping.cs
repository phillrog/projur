using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProJur.Cadastros.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProJur.Cadastros.Infra.Data.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(c => c.Sobrenome)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(c => c.Email)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(c => c.DataNascimento);

            builder.Property(c => c.Escolaridade)
                .HasColumnType("int");

            builder.ToTable("Usuarios");
        }
    }
}
