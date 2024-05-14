
using IntegratorTransfer.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace IntegratorTransfer.Persistencia
{
    public static class DependencyInjection
    {
        public static void AddPersistence(this IServiceCollection services , IConfiguration configuration) {

            services.AddDbContext<DbContext, TransferenciaDBContext>(options =>
                            
                            options.UseMySql(configuration.GetConnectionString(nameof(TransaccionFinanciera)) 
                                            ,ServerVersion.AutoDetect(configuration.GetConnectionString(nameof(TransaccionFinanciera)))
                                            ,options => options.EnableRetryOnFailure())  
                                         
                 
            );

            services.AddScoped<ITransferenciaRepository, TransferenciaRepository>();

        }
    }
}
