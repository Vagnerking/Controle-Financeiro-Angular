using ControleFinanceiro.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.DAL.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.CPF).IsRequired().HasMaxLength(20);
            builder.HasIndex(x => x.CPF).IsUnique();
            builder.Property(x => x.Profissao).IsRequired().HasMaxLength(30);

            builder.HasMany(x => x.Cartoes).WithOne(x => x.Usuario).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.Despesas).WithOne(x => x.Usuario).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.Ganhos).WithOne(x => x.Usuario).OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("Usuarios");
        }
    }
}
