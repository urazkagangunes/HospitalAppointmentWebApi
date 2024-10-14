using HospitalAppointment.DataAccess.Abstract;
using HospitalAppointment.DataAccess.Concretes;
using HospitalAppointment.DataAccess.Context;
using HospitalAppointment.Service.Abstracts;
using HospitalAppointment.Service.Concretes;
using HospitalAppointment.Service.Profiles;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<BaseDbContext>(options =>
    options.UseSqlServer("Server=localhost,1433;Database=HospitalAppointment_db;User Id=sa;Password=admin1234567;TrustServerCertificate=true"));

builder.Services.AddScoped<IAppointmentRepository, EfAppointmentRepository>();
builder.Services.AddScoped<IDoctorRepository, EfDoctorRepository>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddAutoMapper(typeof(DoctorMappingProfile));
builder.Services.AddAutoMapper(typeof(AppointmentMappingProfile));


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