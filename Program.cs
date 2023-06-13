using Microsoft.EntityFrameworkCore;
using FoodDelivery.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

Console.WriteLine(builder.Configuration.GetConnectionString("Ef_Postgres_Db"));

// Add services to the container.
builder.Services.AddDbContext<FoodDelivery_DataContext>(
                o => o.UseNpgsql(builder.Configuration.GetConnectionString("Ef_Postgres_Db"))
            );
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();