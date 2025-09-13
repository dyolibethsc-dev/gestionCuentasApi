using Microsoft.EntityFrameworkCore;
using gestionCuentasApi.Data;
using gestionCuentasApi.Interfaces;
using gestionCuentasApi.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options =>options.UseSqlite(builder.Configuration.GetConnectionString("ConnectionBD")));


// Add services to the container.
builder.Services.AddScoped<IClientesRepository, ClientesRepository>();
builder.Services.AddScoped<ICuentasRepository, CuentasRepository>();


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
