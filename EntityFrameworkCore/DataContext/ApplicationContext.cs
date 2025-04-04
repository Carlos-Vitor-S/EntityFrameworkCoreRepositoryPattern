using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;



namespace RepositoryPatternEF.DataContext {
    class ApplicationContext : DbContext {
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Cliente> Cliente { get; set; }

        //private static readonly ILoggerFactory _logger = LoggerFactory.Create(l => l.AddConsole()); 

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }

        internal object Find(int id) {
            throw new NotImplementedException();
        }
    }
}
