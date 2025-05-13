

using App.FantasyUser.Domain;
using App.FantasyUser.Features;
using Core.App.Domain;
using Core.App.Interfaces;
using Core.App.Managers;
using Core.App.Processors;
using Core.App.Publishers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<AccessTokenSettings>(builder.Configuration.GetSection(nameof(AccessTokenSettings)));
builder.Services.Configure<RabbitMqConfiguration>(builder.Configuration.GetSection(nameof(RabbitMqConfiguration)));

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

// Enable JWT Bearer authentication as the default scheme.

AccessTokenSettings? accessTokenSettings = builder.Configuration.GetSection(nameof(AccessTokenSettings)).Get<AccessTokenSettings>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(config =>
    {
        config.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = accessTokenSettings?.Issuer,
            ValidAudience = accessTokenSettings?.Audience,
            IssuerSigningKey = accessTokenSettings?.SigningKey,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true
        };
    });



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Configure Swagger/OpenAPI documentation, including JWT auth support in the UI.
builder.Services.AddSwaggerGen(c =>
{
    // Define the basic information for your API.
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API",
        Version = "v1"
    });

    // Add the JWT Bearer scheme to the Swagger UI so tokens can be tested in requests.
    c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = """
        JWT Authorization header using the Bearer scheme.
        Enter your token as: Bearer your_token_here
        Example: "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
        """
    });

    // Add the security requirement globally so all endpoints are secured unless specified otherwise.
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = JwtBearerDefaults.AuthenticationScheme
                }
            },
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseCors("AllowFrontend");

app.MapControllers();

app.Run();
