using CompanyDDD.API.Services;
<<<<<<< HEAD
using CompanyDDD.Infra.Data;
using Microsoft.EntityFrameworkCore;

=======
using CompanyDDD.Domain.Repositories;
using CompanyDDD.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
>>>>>>> 9f39fbdd47bc3f59741e5548af1d6781e3827fbe

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<FuncionarioService>();

builder.Services.AddDbContext<CompanyDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
