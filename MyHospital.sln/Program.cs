using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyHospital_Business.Abstraction;
using MyHospital_Business.Conctrete;
using MyHospital_Data.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext ekleme
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));

// AutoMapper konfigürasyonu
builder.Services.AddAutoMapper(typeof(Program).Assembly);

// DI (Dependency Injection) için servisler ekleme
builder.Services.AddScoped<IPatientService, PatientService>();

// Eðer IUnitOfWork kullanýyorsanýz, o da burada eklenmeli
// builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(); 

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
