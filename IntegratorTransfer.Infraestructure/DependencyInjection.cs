using IntegratorTransfer.Infraestructure.Queue.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace IntegratorTransfer.Infraestructure
{
    public static class DependencyInjection
    {
        public static void AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton( (sp) => {

                    var transferQueueSetting = new TransferQueueSetting();  
                    configuration.GetSection(nameof(TransferQueueSetting)).Bind(transferQueueSetting);
                    return transferQueueSetting;
               
                 }
            );
        }
    }
}
