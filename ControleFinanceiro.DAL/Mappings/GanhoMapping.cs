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
    public class GanhoMapping : IEntityTypeConfiguration<Ganho>
    {
        public void Configure(EntityTypeBuilder<Ganho> builder)
        {

            builder.HasKey(x => x.GanhoId);

            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(50);

            builder.Property(x => x.Valor).IsRequired();

            builder.Property(x => x.Dia).IsRequired();

            builder.Property(x => x.Ano).IsRequired();

            builder.HasOne(x => x.Categoria).WithMany(x => x.Ganhos).HasForeignKey(x => x.CategoriaId).IsRequired();

            builder.HasOne(x => x.Mes).WithMany(x => x.Ganhos).HasForeignKey(x => x.MesId).IsRequired();

            builder.HasOne(x => x.Usuario).WithMany(x => x.Ganhos).HasForeignKey(x => x.UsuarioId).IsRequired();

            builder.ToTable("Ganhos");
        }
    }
}
