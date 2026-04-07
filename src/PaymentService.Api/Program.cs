using Microsoft.EntityFrameworkCore;
using Confluent.Kafka;
using PaymentService.Application.Interfaces;
using PaymentService.Application.Services;
using PaymentService.Infrastructure.Kafka;
using PaymentService.Infrastructure.Persistence;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<PaymentDbContext>(options =>
    options.UseNpgsql(connectionString));
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddScoped<IPaymentService, PaymentService.Application.Services.PaymentService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(
            new JsonStringEnumConverter()
        );
    });

var kafkaSection = builder.Configuration.GetSection("Kafka");

var producerConfig = kafkaSection.Get<ProducerConfig>();
builder.Services.AddSingleton(producerConfig);

builder.Services.AddSingleton<IPaymentEventProducer, PaymentEventProducer>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.MapControllers();
app.Run();