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
    public class CartaoMapping : IEntityTypeConfiguration<Cartao>
    {
        public void Configure(EntityTypeBuilder<Cartao> builder)
        {

            builder.HasKey(x => x.CartaoId);

            builder.Property(x => x.Nome).IsRequired().HasMaxLength(20);
            builder.HasIndex(x => x.Nome).IsUnique();

            builder.Property(x => x.Bandeira).IsRequired().HasMaxLength(15);
            builder.Property(x => x.Numero).IsRequired().HasMaxLength(20);
            builder.HasIndex(x => x.Numero).IsUnique();

            builder.Property(x => x.Limite).IsRequired();

            builder.HasOne(x => x.Usuario).WithMany(x => x.Cartoes).HasForeignKey(x => x.UsuarioId).IsRequired().OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.Despesas).WithOne(x => x.Cartao);

            builder.ToTable("Cartoes");
        }
    }
}
