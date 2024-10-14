using Core.Entities;

namespace HospitalAppointment.Models.Entities;

public sealed class Appointment : Entity<Guid>
{
    public string? PatientName { get; set; }
    public DateTime AppointmentDate { get; set; }
    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; }

    public Appointment()
    {
        
    }
}
   
