using Administrator.API.Middleware;
using Administrator.API.Utilities;
using Administrator.Application;
using Administrator.Identity;
using Administrator.Infrastructure;
using Administrator.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo 
    { 
        Title = "AdministratorApi", 
        Version = "v1",
        Description = "Administrator API for personal backend",
        Contact = new OpenApiContact
        {
            Email = "gabrielfloresmonsalve@gmail.com",
            Name = "Gabriel Flores",
            Url = new Uri("https://gabrielflores.cl")
        }
    });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlRoute = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlRoute);
});

builder.Services.AddControllers(options =>
{
    options.Conventions.Add(new SwaggerGroupPerVersion());
}).AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddAplicationServices();
builder.Services.ConfigureIdentityServices(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => 
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
    );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "AdministratorAPI V1");
        //c.SwaggerEndpoint("/swagger/v2/swagger.json", "AdministratorAPI V2");
    });
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthentication();

app.UseAuthorization();

app.UseCors("CorsPolicy");

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var service = scope.ServiceProvider;
    var loggerFactory = service.GetRequiredService<ILoggerFactory>();

    try
    {
        var context = service.GetRequiredService<PortfolioDbContext>();

        await context.Database.MigrateAsync();
        await PortfolioDbContextSeed.SeedAsync(context, loggerFactory);
        await PortfolioDbContextSeedData.LoadDataAsync(context, loggerFactory);

        var contextIdentity = service.GetRequiredService<AdministratorIdentityDbContext>();
        await contextIdentity.Database.MigrateAsync();
    }
    catch (Exception ex)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(ex, "Error in migration");
    }
}

app.Run();
