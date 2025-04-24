using Microsoft.AspNetCore.SignalR;
using NotificationService.API;
using NotificationService.API.Application;
using NotificationService.API.Hubs;
using NotificationService.API.Repositories;
using NotificationService.API.Services;
using NotificationService.API.Services.RabbitMQ;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials());
});

// Adiciona o serviço do repositório
builder.Services.AddScoped<INotificationRepository, MongoNotificationRepository>();
builder.Services.AddScoped<INotificationDispatcherRepository, SignalRNotificationDispatcher>();

builder.Services.AddSingleton<IMessageProcessor, MessageProcessor>();
builder.Services.AddApplication();

builder.Services.AddSignalR();

builder.Services.AddSingleton<IUserIdProvider, QueryStringUserIdProvider>();

builder.Services.AddHttpClient();

builder.Services.AddSingleton<IRabbitMqConnection, RabbitMqConnection>();
builder.Services.AddHostedService<RabbitMqMessageConsumer>();

// Configura o Kestrel para escutar em HTTP na porta 5231
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5231);
});

var app = builder.Build();

app.UseCors();

app.MapControllers();
app.MapHub<NotificationHub>("/hubs/notifications");

Console.WriteLine("NotificationService rodando na porta 5231...");

app.Run();
