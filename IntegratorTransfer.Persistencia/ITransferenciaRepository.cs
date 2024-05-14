
using IntegratorTransfer.Domain;

namespace IntegratorTransfer.Persistencia
{
    public interface ITransferenciaRepository
    {
        void Add(TransaccionFinanciera entidad);
    }
}