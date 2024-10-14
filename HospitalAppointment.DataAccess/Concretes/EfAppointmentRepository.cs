using Core.Repositories;
using HospitalAppointment.DataAccess.Abstract;
using HospitalAppointment.DataAccess.Context;
using HospitalAppointment.Models.Entities;

namespace HospitalAppointment.DataAccess.Concretes;

public class EfAppointmentRepository : EfRepositoryBase<BaseDbContext, Appointment, Guid>, IAppointmentRepository
{
    public EfAppointmentRepository(BaseDbContext context) : base(context)
    {

    }
}
