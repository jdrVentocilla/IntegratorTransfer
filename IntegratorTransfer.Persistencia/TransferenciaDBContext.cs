
using IntegratorTransfer.Domain;
using Microsoft.EntityFrameworkCore;

namespace IntegratorTransfer.Persistencia
{
    public class TransferenciaDBContext : DbContext
    {
        public DbSet<TransaccionFinanciera> transaccionFinanciera { get; set; }
        public TransferenciaDBContext(DbContextOptions<TransferenciaDBContext> options): base (options)
        {
            Database.EnsureCreated();    
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }

    }
}
