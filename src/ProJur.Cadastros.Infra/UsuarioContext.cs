using Microsoft.EntityFrameworkCore;
using ProJur.Cadastros.Domain;
using ProJur.Core.Data;
using System.Threading.Tasks;

namespace ProJur.Cadastros.Infra
{
    public class UsuarioContext : DbContext, IUnitOfWork
    {
        public UsuarioContext(DbContextOptions<UsuarioContext> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UsuarioContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }
    }
}
