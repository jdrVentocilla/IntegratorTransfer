using IntegratorTransfer;
using IntegratorTransfer.Application;
using IntegratorTransfer.Infraestructure;
using IntegratorTransfer.Persistencia;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfraestructure(builder.Configuration);
builder.Services.AddHostedService<Worker>();
builder.Services.AddPersistence(builder.Configuration);

var host = builder.Build();
host.Run();
