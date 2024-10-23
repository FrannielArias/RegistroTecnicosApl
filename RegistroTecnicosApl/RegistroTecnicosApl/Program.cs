using Microsoft.EntityFrameworkCore;
using RegistroTecnicosApl.Components;
using RegistroTecnicosApl.DAL;
using RegistroTecnicosApl.Models;
using RegistroTecnicosApl.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var ConStr = builder.Configuration.GetConnectionString("ConStr");
builder.Services.AddDbContextFactory<Contexto>(t => t.UseSqlServer(ConStr));

builder.Services.AddScoped<TecnicoServices>();
builder.Services.AddScoped<TiposTecnicosServices>();
builder.Services.AddScoped<ClientesServices>();
builder.Services.AddScoped<TrabajosServices>();
builder.Services.AddScoped<PrioridadesServices>();
builder.Services.AddScoped<ArticulosService>();
builder.Services.AddScoped<DetalleService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())   
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
