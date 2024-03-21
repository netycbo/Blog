using Microsoft.EntityFrameworkCore;
using Blog.DataAccess;
using MediatR;
using Blog.AppServices.API.Handlers;
using System.Reflection;
using Blog_AppServices.Mappings;
using Blog.DataAccess.CQRS;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BlogstorageContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BlogDatabaseConnection")));
builder.Services.AddMediatR(typeof(GetPostsHandler).GetTypeInfo().Assembly);
builder.Services.AddAutoMapper(typeof(UserProfile).GetTypeInfo().Assembly, typeof(UserProfile).Assembly);
builder.Services.AddTransient<IQueryExecutor, QueryExecutor>();
builder.Services.AddTransient<ICommandsExecutor, CommandsExecutor>();

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
