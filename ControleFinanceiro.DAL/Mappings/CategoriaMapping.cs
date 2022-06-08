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
    public class CategoriaMapping : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(x => x.CategoriaId);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Icone).IsRequired().HasMaxLength(15);
            builder.HasOne(x => x.Tipo).WithMany(x => x.Categorias).HasForeignKey(x => x.TipoId).IsRequired();
            builder.HasMany(x => x.Ganhos).WithOne(x => x.Categoria);
            builder.HasMany(x => x.Despesas).WithOne(x => x.Categoria);

            builder.ToTable("Categorias");
        }
    }
}
