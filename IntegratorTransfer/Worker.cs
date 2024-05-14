using IntegratorTransfer.Application;
using Microsoft.Extensions.DependencyInjection;

namespace IntegratorTransfer
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceProvider _provider;

        public Worker(ILogger<Worker> logger , IServiceProvider provider  )
        {
            _logger = logger;
            _provider = provider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            _logger.LogInformation("Iniciando la recepciòn de datos.");
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    _logger.LogInformation("Creando SCOPE.");

                    using (var scope = _provider.CreateScope())
                    {
                        var _transferRecieveService = scope.ServiceProvider.GetService<ITransferRecieveService>();
                        await _transferRecieveService.SuscribeAsync(stoppingToken);
                    }
                }
                catch (Exception ex )
                {

                    _logger.LogInformation("Error al ejecutar la tarea. Detalles {0}.", ex.Message);
                }


                _logger.LogInformation("Reintentando ejecutar {error}.");
                await Task.Delay(5000, stoppingToken);
            }

           
        }
    }
}
