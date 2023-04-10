using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReserveRoverBLL.Configurations;
using ReserveRoverDAL;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("PGSQLConnection");
var mapperConfig = new MapperConfiguration(mc =>
    mc.AddProfile(new AutoMapperProfile()));
var mapper = mapperConfig.CreateMapper();

// Add services to the container.
builder.Services
    .AddSingleton(mapper)
    .AddDbContext<ReserveRoverDbContext>(options => options.UseNpgsql(connection));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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