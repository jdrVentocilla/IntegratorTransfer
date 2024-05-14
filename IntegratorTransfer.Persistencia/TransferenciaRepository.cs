
using IntegratorTransfer.Domain;
using Microsoft.EntityFrameworkCore;


namespace IntegratorTransfer.Persistencia
{
    public class TransferenciaRepository : ITransferenciaRepository
    {

        private DbSet<TransaccionFinanciera> _dbset;

        public TransferenciaRepository(TransferenciaDBContext dbContext)
        {
            _dbset = dbContext.Set<TransaccionFinanciera>();
        }

        public void Add(TransaccionFinanciera entidad)
        {
            _dbset.Add(entidad);
        }
    }
}
