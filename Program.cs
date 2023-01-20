using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MuniApp.Negocio.entidades;
using MuniApp.Models;
using MuniApp.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ODAMuniDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ODAMuniDBContext") ?? throw new InvalidOperationException("Connection string 'ODAMuniDBContext' not found.")));
builder.Services.AddScoped<IDeudas, DeudasRepositorioEF>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    Data.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
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

app.Run();
