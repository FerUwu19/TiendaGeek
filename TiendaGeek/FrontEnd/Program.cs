using FrontEnd.Helpers.Implemetations;
using FrontEnd.Helpers.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/account/login";
                });

builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

#region DI
builder.Services.AddHttpClient<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddHttpContextAccessor(); // Registrar IHttpContextAccessor
builder.Services.AddScoped<IProductoHelper, ProductoHelper>();
builder.Services.AddScoped<ICarritoHelper, CarritoHelper>();
builder.Services.AddScoped<IItemCarritoHelper, ItemCarritoHelper>();
builder.Services.AddScoped<IImagenProductoHelper, ImagenProductoHelper>();
builder.Services.AddScoped<ICategoriumHelper, CategoriumHelper>();
builder.Services.AddScoped<IHistorialPedidoHelper, ImpHistorialPedidoHelper>();
builder.Services.AddScoped<IContactoHelper, ContactoHelper>();
builder.Services.AddScoped<ISecurityHelper, SecurityHelper>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Importante: asegurarse de que UseAuthentication esté antes de UseAuthorization
app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
