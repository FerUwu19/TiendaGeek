using BackEnd.Services.Implemetations;
using BackEnd.Services.Interfaces;
using DAL.Implementations;
using DAL.Impletations;
using DAL.Interfaces;
using Entities.Entities;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region DI
builder.Services.AddDbContext<TiendaGeekContext>();

builder.Services.AddScoped<IProductoDAL, ProductoDALImpl>();
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IUnidadDeTrabajo, UnidadDeTrabajo>();

builder.Services.AddScoped<IHistorialPedidoDAL, ImplHistorialPedidoDAL>();
builder.Services.AddScoped<IHistorialPedidoServices, ImplHistorialPedidoServices>();

builder.Services.AddScoped<IImagenProductoDAL, ImplImagenProductoDAL>();
builder.Services.AddScoped<IImagenProductoServices, ImplImagenProductoServices>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
