using LibraryApiLinux.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();


builder.Services.AddScoped<IWebApiRepo, MySqlWebApiRepo>();


string _connectionstring = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddDbContext<WebApiContext>(opt =>
    opt.UseMySql(_connectionstring, ServerVersion.AutoDetect(_connectionstring))
);


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
