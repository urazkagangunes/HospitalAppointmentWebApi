using Core.Repositories;
using HospitalAppointment.Models.Entities;

namespace HospitalAppointment.DataAccess.Abstract;

public interface IDoctorRepository : IRepository<Doctor, int>
{

}
