

using System.ComponentModel.DataAnnotations;

namespace IntegratorTransfer.Domain
{
    public class TransaccionFinanciera
    {
        public enum Movimiento
        {
            Cargo, Abono
        }
        [Key]
        public string Id { get; set; }
        public string NCuentaOrigen { get; set; }
        public string NCuentaDestino { get; set; }

        public string BancoDestino { get; set; }
        public string BancoOrigen { get; set; }
        public double Monto { get; set; }
        public DateTime FechaOperacion { get; set; }
        public Movimiento TMovimiento { get; set; }

        public TransaccionFinanciera(string id , 
                                string nCuentaOrigen , 
                                string nCuentaDestino ,
                                string bancoDestino ,
                                string bancoOrigen,
                                double monto ,
                                DateTime fechaOperacion,
                                Movimiento tMovimiento)
        {
            this.Id = id;
            this.NCuentaOrigen = nCuentaOrigen;
            this.NCuentaDestino = nCuentaDestino;
            this.BancoDestino = bancoDestino;
            this.BancoDestino = bancoDestino;
            this.Monto = monto;
            this.FechaOperacion = fechaOperacion;
            this.TMovimiento = tMovimiento;
            this.BancoOrigen = bancoOrigen;
           
        }
        public TransaccionFinanciera() { 
        
        }
    }
}
