using Microsoft.EntityFrameworkCore;

namespace CrudNovedad.Models
{
    public class NovedadDbContext : DbContext
    {
        public NovedadDbContext(DbContextOptions<NovedadDbContext> options): base(options){ }

        public DbSet<Novedad> NovedadSet { get; set; } 

        public DbSet<TipoNov> TipoNovSet { get;set; }

        public DbSet<ListaDeVariables> ListaDeVariablesSet { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Novedad>().ToTable("Novedad");
        //    modelBuilder.Entity<TipoNov>().ToTable("TipoNov");

        //}
    }
}
