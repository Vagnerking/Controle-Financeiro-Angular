using ControleFinanceiro.BLL.Models;
using ControleFinanceiro.DAL.Mappings;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro.DAL
{
    public class Contexto : IdentityDbContext<Usuario, Funcao, string>
    {

        public DbSet<Cartao> Cartoes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Despesa> Despesas { get; set; }
        public DbSet<Funcao> Funcoes { get; set; }
        public DbSet<Ganho> Ganhos { get; set; }
        public DbSet<Mes> Meses { get; set; }
        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new CartaoMapping());
            builder.ApplyConfiguration(new CategoriaMapping());
            builder.ApplyConfiguration(new DespesaMapping());
            builder.ApplyConfiguration(new FuncaoMapping());
            builder.ApplyConfiguration(new GanhoMapping());
            builder.ApplyConfiguration(new MesMapping());
            builder.ApplyConfiguration(new TipoMapping());
            builder.ApplyConfiguration(new UsuarioMapping());
        }

    }
}
