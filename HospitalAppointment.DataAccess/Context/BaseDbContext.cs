using HospitalAppointment.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HospitalAppointment.DataAccess.Context;

public class BaseDbContext : DbContext
{
    public BaseDbContext(DbContextOptions<BaseDbContext> options) : base(options)
    {
    }

    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
}
