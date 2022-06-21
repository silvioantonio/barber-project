using AutoMapper;
using CloudinaryDotNet;
using MeuBarbeiro.API.Config;
using MeuBarbeiro.API.Context;
using MeuBarbeiro.API.Repository.Appointment;
using MeuBarbeiro.API.Repository.Provider;
using MeuBarbeiro.API.Repository.User;
using MeuBarbeiro.API.Repository.Worker;
using MeuBarbeiro.API.Services.Appointment;
using MeuBarbeiro.API.Services.Provider;
using MeuBarbeiro.API.Services.User;
using MeuBarbeiro.API.Services.Worker;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();

//ConnectionString
var connection = builder.Configuration["MySQLConnection:MySQLConnectionString"];
var cloudName = builder.Configuration["AccountSettings:CloudName"];
var apiKey = builder.Configuration["AccountSettings:ApiKey"];
var apiSecret = builder.Configuration["AccountSettings:ApiSecret"];

if (new[] { cloudName, apiKey, apiSecret }.Any(string.IsNullOrWhiteSpace))
{
    throw new ArgumentException("Please specify Cloudinary account details!");
}

builder.Services.AddSingleton(new Cloudinary(new Account(cloudName, apiKey, apiSecret)));

builder.Services.AddDbContext<MySQLContext>(options => options.UseMySql(connection, new MySqlServerVersion(new Version(8, 0, 28))));

//automapper
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();

builder.Services.AddSingleton(mapper);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Scope Service
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IWorkerService, WorkerService>();
builder.Services.AddScoped<IProviderService, ProviderService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();

//Scope Repository
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IWorkerRepository, WorkerRepository>();
builder.Services.AddScoped<IProviderRepository, ProviderRepository>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

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

app.UseCors(x => x.AllowAnyHeader()
      .AllowAnyMethod()
      .WithOrigins("http://localhost:3000"));

app.UseAuthorization();

app.MapControllers();

app.Run();
