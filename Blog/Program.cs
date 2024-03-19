using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Blog.DataAccess;
using MediatR;
using Blog.AppServices.API.Handlers;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BlogstorageContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BlogDatabaseConnection")));
builder.Services.AddMediatR(typeof(GetPostsHandler).GetTypeInfo().Assembly);

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

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
