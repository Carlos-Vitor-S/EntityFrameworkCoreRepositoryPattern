using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;

namespace RepositoryPatternEF.DataContext {
    class ApplicationContext : DbContext {

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }

        //DbSets

        public DbSet<Produto> Produto { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Cliente> Cliente { get; set; }

    }
}
