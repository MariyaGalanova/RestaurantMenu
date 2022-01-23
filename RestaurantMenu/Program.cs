using Microsoft.EntityFrameworkCore;
using RestaurantMenu.Database;
using RestaurantMenu.Database.Repositories;
using RestaurantMenu.Database.Repositories.Interfaces;
using RestaurantMenu.Infrastructure.Services;
using RestaurantMenu.Infrastructure.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Register database context
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionString));

//  Register services
builder.Services.AddTransient<IDisheService, DisheService>();
builder.Services.AddTransient<IOrderService, OrderService>();

//  Register repositories
builder.Services.AddTransient<IDisheRepository, DisheRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
