using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReserveRoverBLL.Configurations;
using ReserveRoverBLL.Services.Abstract;
using ReserveRoverBLL.Services.Concrete;
using ReserveRoverDAL;
using ReserveRoverDAL.Repositories.Abstract;
using ReserveRoverDAL.Repositories.Concrete;
using ReserveRoverDAL.UnitOfWork.Abstract;
using ReserveRoverDAL.UnitOfWork.Concrete;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("PGSQLConnection");

// Add DAL services
builder.Services
    .AddDbContext<ReserveRoverDbContext>(options => options.UseNpgsql(connection))
    .AddTransient<ILocationsRepository, LocationsRepository>()
    .AddTransient<IPlacesRepository, PlacesRepository>()
    .AddTransient<IPlaceImagesRepository, PlaceImagesRepository>()
    .AddTransient<IPlacesPaymentMethodsRepository, PlacesPaymentMethodsRepository>()
    .AddTransient<ITablesRepository, TablesRepository>()
    .AddTransient<IModerationRepository, ModerationRepository>()
    .AddTransient<IUnitOfWork, UnitOfWork>();

//Add BLL services
var mapperConfig = new MapperConfiguration(mc =>
    mc.AddProfile(new AutoMapperProfile()));
var mapper = mapperConfig.CreateMapper();

builder.Services
    .AddSingleton(mapper)
    .AddTransient<IPlacesService, PlacesService>()
    .AddTransient<IModerationService, ModerationService>();

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

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();