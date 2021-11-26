using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MyStore.API;
using MyStore.Application.DbRepositories;
using MyStore.Application.DTOs;
using MyStore.Application.Repositories;
using MyStore.Application.Services.Implementations;
using MyStore.Application.Services.Interfaces;
using MyStore.Domain.Models;
using MyStore.Persistance.DbRepositories;
using MyStore.Persistance.EntityFramework;
using System;

var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "MyStore.API", Version = "v1" });
});

builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name:"BlazorWebShop", builder =>
    {
        builder.WithOrigins("https://localhost:7074",
            "http://localhost:7075")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

builder.Services.AddDbContext<ApplicationDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings")["MyStoreConnectionString"].ToString());
});
builder.Services.AddAutoMapper(new Type[] { typeof(AutoMapperProfile), typeof(CustomerDTO), typeof(Customer) });

builder.Services.AddScoped<ICustomerDataRepository, CustomerDataRepository>();
builder.Services.AddScoped<IProductDataRepository, ProductDataRepository>();
builder.Services.AddScoped<IOrderDataRepository, OrderDataRepository>();

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApplication1 v1"));
}

app.UseHttpsRedirection();

app.UseCors("BlazorWebShop");
app.UseAuthorization();

app.MapControllers();

app.Run();
