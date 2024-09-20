using InventoryManager.Infrastructure;
using InventoryManager.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Infrastructure related services
var connectionString = builder.Configuration.GetConnectionString("InventoryDbConnection")
                ?? throw new InvalidOperationException("db connection string wasn't found");
builder.Services.AddInventoryDbContext(connectionString);
builder.Services.AddRepository();

// Entities services
builder.Services.AddEntitiesServices();

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
