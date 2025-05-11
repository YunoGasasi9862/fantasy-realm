

using App.FantasyUser.Domain;
using App.FantasyUser.Features;
using Core.App.Domain;
using Core.App.Interfaces;
using Core.App.Managers;
using Core.App.Processors;
using Core.App.Publishers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<AccessTokenSettings>(builder.Configuration.GetSection("AccessTokenSettings"));
builder.Services.Configure<RabbitMqConfiguration>(builder.Configuration.GetSection("RabbitMqConfiguration"));

var connectionString = builder.Configuration.GetConnectionString("FantasyUserDBConnectionString");
builder.Services.AddDbContext<FantasyUserDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(FantasyUserDbHandler).Assembly));
builder.Services.AddSingleton<IRabbitMq, RabbitMqManager>();
builder.Services.AddScoped<IRabbitMqProcessor, RabbitMqProcessor>();
builder.Services.AddScoped<IRabbitMqPublisher, RabbitMqPublisher>();
builder.Services.AddScoped<IAuthenticator, TwoFactorAuthenticator>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

builder.AddServiceDefaults();

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

app.UseCors("AllowFrontend");

app.MapControllers();

app.Run();
