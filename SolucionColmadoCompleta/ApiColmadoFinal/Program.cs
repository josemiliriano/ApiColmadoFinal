using Application.Contract;
using Application.Core;
using Domain.Entities;
using Infraestructure.Data;
using Infraestructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped(typeof(GeneralRepository<CDCategory>));
builder.Services.AddScoped<ICategoryAppService, CategoryAppService>();
builder.Services.AddScoped(typeof(GeneralRepository<CDProduct>));
builder.Services.AddScoped<IProductAppServices, ProductAppServices>();
builder.Services.AddScoped(typeof(GeneralRepository<CDProvider>));
builder.Services.AddScoped<IProviderAppService, ProviderAppService>();
builder.Services.AddScoped(typeof(GeneralRepository<CDInventoryMovement>));
builder.Services.AddScoped<IInventoryMovementAppService, InventoryMovementAppService>();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MyDataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
