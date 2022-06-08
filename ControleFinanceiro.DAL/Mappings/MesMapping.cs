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
    public class MesMapping : IEntityTypeConfiguration<Mes>
    {
        public void Configure(EntityTypeBuilder<Mes> builder)
        {
            builder.HasKey(x => x.MesId);

            builder.Property(x => x.Nome).IsRequired().HasMaxLength(20);

            builder.HasIndex(x => x.Nome).IsUnique();

            builder.HasMany(x => x.Ganhos).WithOne(x => x.Mes);

            builder.HasMany(x => x.Despesas).WithOne(x => x.Mes);

            builder.HasData(new Mes()
            {
                MesId = 1,
                Nome = "Janeiro"
            }, new Mes()
            {
                MesId = 2,
                Nome = "Fevereiro"
            },
            new Mes()
            {
                MesId = 3,
                Nome = "Março"
            },
            new Mes()
            {
                MesId = 4,
                Nome = "Abril"
            },
            new Mes()
            {
                MesId = 5,
                Nome = "Maio"
            },
            new Mes()
            {
                MesId = 6,
                Nome = "Junho"
            },
            new Mes()
            {
                MesId = 7,
                Nome = "Julho"
            },
            new Mes()
            {
                MesId = 8,
                Nome = "Agosto"
            },
            new Mes()
            {
                MesId = 9,
                Nome = "Setembro"
            },
            new Mes()
            {
                MesId = 10,
                Nome = "Outubro"
            },
            new Mes()
            {
                MesId = 11,
                Nome = "Novembro"
            },
            new Mes()
            {
                MesId = 12,
                Nome = "Dezembro"
            }
            );

            builder.ToTable("Meses");
        }
    }
}
