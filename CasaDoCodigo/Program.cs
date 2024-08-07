using CasaDoCodigo;
using Microsoft.EntityFrameworkCore;
using CasaDoCodigo.Models;
using Microsoft.AspNetCore.Mvc.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

public void ConfigureServices(IServiceCollection services)
{
    services.AddMvc();
    String connectionString = @"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CasaDoCodigo;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
    services.AddDbContext<Contexto>(options => options.UseSqlServer(connectionString));
}


builder.Services.AddDbContext<Contexto>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString(@"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CasaDoCodigo;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"));
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Pedido}/{action=Carrosel}/{id?}");

app.Run();
