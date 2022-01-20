using ChannelEngineApi.BusinessLogic.Implementations;
using ChannelEngineApi.BusinessLogic.Interfaces;
using ChannelEngineApi.BusinessLogic.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.Configure<Settings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderWrapper, OrderWrapper>();

var app = builder.Build();

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
    pattern: "{controller=Order}/{action=GetByStatus}/{status?}");

app.Run();