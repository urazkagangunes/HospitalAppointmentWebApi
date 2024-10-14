using HospitalAppointment.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalAppointment.DataAccess.Configurations;

public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.ToTable("Appointments");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.PatientName)
            .IsRequired()
            .HasMaxLength(100); 

        builder.Property(a => a.AppointmentDate)
            .IsRequired();

        builder.HasOne<Doctor>() 
            .WithMany() 
            .HasForeignKey(a => a.DoctorId); 
    }
}
