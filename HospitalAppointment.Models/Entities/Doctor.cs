using Core.Entities;
using HospitalAppointment.Models.Entities.Enums;

namespace HospitalAppointment.Models.Entities;

public sealed class Doctor : Entity<int>
{
    public string? Name { get; set; }
    public Branch Branch { get; set; }
    public IEnumerable<Appointment> Appointments { get; set; }
    public Doctor()
    {
        
    }
}
   
