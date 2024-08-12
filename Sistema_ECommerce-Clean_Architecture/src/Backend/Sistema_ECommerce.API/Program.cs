using Microsoft.EntityFrameworkCore;
using Sistema_ECommerce.API.Utilities.DTOMappings;
using Sistema_ECommerce.Infra.Context;
using Sistema_ECommerce.Infra.Interfaces;
using Sistema_ECommerce.Infra.Repositories;
using Sistema_ECommerce.Services.Interfaces;
using Sistema_ECommerce.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddAutoMapper(typeof(UserDTOMappingProfile));

builder.Services.AddScoped<IClientesService, ClientesService>();
builder.Services.AddScoped<IClientesRepository, ClientesRepository>();

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
