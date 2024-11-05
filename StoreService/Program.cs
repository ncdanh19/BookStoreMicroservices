using Microsoft.EntityFrameworkCore;
using StoreService.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StoreContext>(options =>
    options.UseInMemoryDatabase("StoreDb")); // For demo, using an in-memory database.

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<StoreContext>();
    await StoreDataSeeder.SeedAsync(dbContext); // Seed stores
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
