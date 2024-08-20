using FrontEnd.Helpers.Implemetations;
using FrontEnd.Helpers.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(x => x.LoginPath = "/account/login");

builder.Services.AddSession();

#region DI
builder.Services.AddHttpClient<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IProductoHelper, ProductoHelper>();
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

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
