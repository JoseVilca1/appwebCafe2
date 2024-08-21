using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using appwebCafe2.Data;
using Microsoft.Extensions.ML;
using Clase_semana6_modelo;
using appwebCafe2.Models;
using appwebCafe2.Service;

var builder = WebApplication.CreateBuilder(args);
// en el MLModel1 falta importa la clase_semana6_modelo
builder.Services.AddPredictionEnginePool<MLModel1.ModelInput, MLModel1.ModelOutput>()
    .FromFile("MLModel1.mlnet");

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("PostgreSQLConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));
// esta en la  appsettings.json -- para poder conectar con el PostgreSQL
// reempazamos DefaultConnection : PostgreSQLConnection
// reemplazamos UseSqlite : UseNpgsql


builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ProductoService, ProductoService>();//se le aplica porque estamos creando un carpeta service

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
