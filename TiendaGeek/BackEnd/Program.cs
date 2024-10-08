using BackEnd.Services.Implemetations;
using BackEnd.Services.Interfaces;
using DAL.Implementations;
using DAL.Impletations;
using DAL.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region DI

builder.Services.AddDbContext<TiendaGeekContext>();
builder.Services.AddDbContext<AuthDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IProductoDAL, ProductoDALImpl>();
builder.Services.AddScoped<IProductoService, ProductoService>();

builder.Services.AddScoped<IImagenProductoDAL, ImplImagenProductoDAL>();
builder.Services.AddScoped<IImagenProductoServices, ImplImagenProductoServices>();

builder.Services.AddScoped<ICategoriumDAL, CategoriumDALImpl>();
builder.Services.AddScoped<ICategoriumService, CategoriumService>();

builder.Services.AddScoped<IHistorialPedidoDAL, ImplHistorialPedidoDAL>();
builder.Services.AddScoped<IHistorialPedidoServices, ImplHistorialPedidoServices>();

builder.Services.AddScoped<ICarritoDAL, ImplCarritoDAL>();
builder.Services.AddScoped<ICarritoService, ImplCarritoService>();

builder.Services.AddScoped<IItemCarritoDAL, ImplItemCarritoDAL>();
builder.Services.AddScoped<IItemCarritoService, ItemCarritoService>();

builder.Services.AddScoped<IContactoDAL, ContactoDALImpl>();
builder.Services.AddScoped<IContactoService, ContactoService>();

builder.Services.AddScoped<IUnidadDeTrabajo, UnidadDeTrabajo>();


builder.Services.AddScoped<ITokenService, TokenService>();

#endregion

#region Identity

builder.Services.AddIdentityCore<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("TiendaGeek")
    .AddEntityFrameworkStores<AuthDBContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 10;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
});

#endregion

#region JWT

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})

    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidAudience = builder.Configuration["JWT:ValidAudience"],
            ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
        };
    });

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
