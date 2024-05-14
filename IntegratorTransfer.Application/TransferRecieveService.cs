using IntegratorTransfer.Domain;
using IntegratorTransfer.Infraestructure.Queue.Client;
using IntegratorTransfer.Persistencia;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Reactive.Linq;
using System.Runtime;
using System.Text;


namespace IntegratorTransfer.Application
{
    public class TransferRecieveService : ITransferRecieveService
    {
        private IConnection _connection;
        private IModel _channel;
        private readonly TransferQueueSetting _settings;
        private readonly ITransferenciaRepository _transferenciaRepository;
        private readonly TransferenciaDBContext _transferenciaDBContext;
        private readonly ILogger<TransferRecieveService> _logger;
        public TransferRecieveService(TransferQueueSetting settings, 
                                      ITransferenciaRepository transferenciaRepository,
                                      TransferenciaDBContext transferenciaDBContext,
                                      ILogger<TransferRecieveService> logger)
        {

            _settings = settings;
            _transferenciaRepository = transferenciaRepository;
            _transferenciaDBContext = transferenciaDBContext;
            _logger = logger;
        }

        public void Dispose()
        {
            if (_connection!=null)
            {
                _connection.Dispose();

            }

            if (_connection !=null)
            {
                _channel.Dispose();
            }
            
        }

        public async Task SuscribeAsync(CancellationToken stoppingToken)
        {

            var factory = new ConnectionFactory() { HostName = _settings.HostName };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += async (model, ea) =>
            {
                _logger.LogInformation("Recibiendo .....");

                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var messageTyped =  JsonConvert.DeserializeObject<TransaccionFinanciera>(message);

                _transferenciaRepository.Add(messageTyped);
                _transferenciaDBContext.SaveChanges();

                _logger.LogInformation("Guardando transferencia ID: {id}.", messageTyped.Id);

                await Task.Delay(1000); // Simulando procesamiento
            };


            _channel.BasicConsume(queue: "Transfer",
                                    autoAck: true,
                                    consumer: consumer);

            await Task.Delay(Timeout.Infinite, stoppingToken);

        }
    }
}
