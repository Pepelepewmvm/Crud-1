using Microsoft.EntityFrameworkCore;

namespace CrudNovedad.Models
{
    public class NovedadDbContext : DbContext
    {
        public NovedadDbContext(DbContextOptions<NovedadDbContext> options): base(options){ }

        public DbSet<Novedad> Novedad { get; set; } 

        public DbSet<TipoNov> TipoNov { get;set; }

        public DbSet<InventarioVariable> InventarioVariables { get; set; }

        public DbSet<Etiqueta> Etiqueta { get; set; }

        
    }
}
