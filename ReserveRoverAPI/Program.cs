using AutoMapper;
using Firebase.Auth;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using ReserveRoverBLL.Configurations;
using ReserveRoverBLL.FirebaseAuth;
using ReserveRoverBLL.Services.Abstract;
using ReserveRoverBLL.Services.Concrete;
using ReserveRoverDAL;
using ReserveRoverDAL.Repositories.Abstract;
using ReserveRoverDAL.Repositories.Concrete;
using ReserveRoverDAL.UnitOfWork.Abstract;
using ReserveRoverDAL.UnitOfWork.Concrete;

var builder = WebApplication.CreateBuilder(args);

var authConfig = new FirebaseConfig(builder.Configuration["FirebaseClientKey"]);

var connection = builder.Configuration.GetConnectionString("PGSQLConnection");

builder.Services
    .AddSingleton(new FirebaseAuthProvider(authConfig))
    .AddSingleton(FirebaseApp.Create(new AppOptions
    {
        Credential = GoogleCredential.FromFile(builder.Configuration["FirebaseServerKeyPath"])
    }))
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddScheme<AuthenticationSchemeOptions, FirebaseAuthenticationHandler>(JwtBearerDefaults.AuthenticationScheme,
        _ => { });

// Add DAL services
builder.Services
    .AddDbContext<ReserveRoverDbContext>(options => options.UseNpgsql(connection))
    .AddTransient<ILocationsRepository, LocationsRepository>()
    .AddTransient<IPlacesRepository, PlacesRepository>()
    .AddTransient<IPlaceImagesRepository, PlaceImagesRepository>()
    .AddTransient<IPlacesPaymentMethodsRepository, PlacesPaymentMethodsRepository>()
    .AddTransient<ITableSetsRepository, TableSetsRepository>()
    .AddTransient<IModerationRepository, ModerationRepository>()
    .AddTransient<IReservationsRepository, ReservationsRepository>()
    .AddTransient<IReviewsRepository, ReviewsRepository>()
    .AddTransient<ICitiesRepository, CitiesRepository>()
    .AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddCoreAdmin();

//Add BLL services
var mapperConfig = new MapperConfiguration(mc =>
    mc.AddProfile(new AutoMapperProfile()));
var mapper = mapperConfig.CreateMapper();

builder.Services
    .AddSingleton(mapper)
    .AddTransient<IPlacesService, PlacesService>()
    .AddTransient<IModerationService, ModerationService>()
    .AddTransient<IReservationService, ReservationService>()
    .AddTransient<ICitiesService, CitiesService>()
    .AddTransient<IIdentityService, IdentityService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.MapType<DateOnly>(() => new OpenApiSchema
    {
        Type = "string",
        Format = "date",
        Example = new OpenApiString("2023-12-29")
    });
    options.MapType<TimeOnly>(() => new OpenApiSchema
    {
        Type = "string",
        Format = "time",
        Example = new OpenApiString("23:12:08")
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(options => options
    .WithOrigins("http://localhost:5173")
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials());

app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseCoreAdminCustomTitle("ReserveRover Admin");
app.MapDefaultControllerRoute();

app.Run();