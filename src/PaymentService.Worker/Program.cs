using Confluent.Kafka;
using PaymentService.Worker.Workers;
using PaymentService.Application.Dispatchers;
using Microsoft.Extensions.DependencyInjection;

var builder = Host.CreateApplicationBuilder(args);

var config = new ConsumerConfig
{
    BootstrapServers = "kafka-3dd27228-kafkapgp.g.aivencloud.com:14781",
    GroupId = "payment4",
    AutoOffsetReset = AutoOffsetReset.Earliest,
    EnableAutoCommit = true,
    SecurityProtocol = SecurityProtocol.Ssl,
    SslCaLocation = "ca.pem",
    SslCertificateLocation = "service.cert",
    SslKeyLocation = "service.key"
};

builder.Services.AddSingleton(config);

builder.Services.AddScoped<IEventDispatcher, EventDispatcher>();

builder.Services.AddHostedService<EventConsumer>();


var host = builder.Build();
host.Run();
