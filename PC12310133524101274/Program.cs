using Microsoft.EntityFrameworkCore;
using TALLERMECÁNICO.CORE.Core.Interfaces;
using TALLERMECÁNICO.CORE.Core.Services;
using TALLERMECÁNICO.CORE.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var cnx = builder.Configuration.GetConnectionString("TallerMecanicoDB");
builder.Services.AddDbContext<TALLERMECÁNICO.CORE.Core.Entities.TallerMecanicoDbContext>(options =>
    options.UseSqlServer(cnx));

builder.Services.AddTransient<IOrdenServicioRepository, OrdenServicioRepository>();
builder.Services.AddTransient<IOrdenServicioService, OrdenServicioService>();       

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
