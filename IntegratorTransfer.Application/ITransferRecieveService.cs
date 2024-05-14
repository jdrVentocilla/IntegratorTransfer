namespace IntegratorTransfer.Application
{
    public interface ITransferRecieveService : IDisposable
    {
        Task SuscribeAsync(CancellationToken stoppingToken);
    }
}