using CustomerOrders.Components;
using CustomerOrders.Models;
using CustomerOrders.Services;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;

var builder = WebApplication.CreateBuilder(args);

// SQL Server LocalDB
string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CustomerOrdersDB;Integrated Security=True;";
XpoDefault.DataLayer = XpoDefault.GetDataLayer(connectionString, AutoCreateOption.DatabaseAndSchema);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<UnitOfWork>(provider => new UnitOfWork());

var app = builder.Build();

DataSeeder.SeedData();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
