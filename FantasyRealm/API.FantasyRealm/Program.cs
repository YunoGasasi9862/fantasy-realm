using App.FantasyRealm.Domain;
using App.FantasyRealm.Features;
using Core.App.Domain;
using Core.App.Interfaces;
using Core.App.Managers;
using Core.App.Processors;
using Core.App.Publishers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.Configure<RabbitMqConfiguration>(builder.Configuration.GetSection("RabbitMqConfiguration"));

var connectionString = builder.Configuration.GetConnectionString("FantasyRalmDBConnectionString");
builder.Services.AddDbContext<FantasyRealmDBContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(FantasyRealmDBHandler).Assembly));
builder.Services.AddSingleton<IRabbitMq, RabbitMqManager>();
builder.Services.AddScoped<IRabbitMqProcessor, RabbitMqProcessor>();
builder.Services.AddScoped<IRabbitMqPublisher, RabbitMqPublisher>();
builder.Services.AddScoped<IAuthenticator, TwoFactorAuthenticator>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
