using MyApp.Domain.Contracts.Application;
using MyApp.Application.Services;
using MyApp.Infrastructure.Data;
using MyApp.Domain.Contracts.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.ConfigureData(builder.Configuration);
builder.Services.ConfigureServices();

builder.Services.AddControllers();

string origins = "cors";
builder.Services.AddCors(options=>
{
    options.AddPolicy(origins, policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(origins);

app.UseAuthorization();

app.MapControllers();

await InitializeDataBase();

app.Run();

async Task InitializeDataBase()
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    try
    {
        Console.WriteLine("Applying migration...");
        await context.Database.MigrateAsync();
        Console.WriteLine("Migration applied successfully.");

        Console.WriteLine("Seeding database...");
        SeedData.Seed(context);
        Console.WriteLine("Seeding completed.");
    }
    catch (Exception e)
    {
        throw;
    }
}