using Core.Repositories;
using HospitalAppointment.DataAccess.Abstract;
using HospitalAppointment.DataAccess.Context;
using HospitalAppointment.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HospitalAppointment.DataAccess.Concretes;

public class EfDoctorRepository : EfRepositoryBase<BaseDbContext, Doctor, int>, IDoctorRepository
{
    public EfDoctorRepository(BaseDbContext context) : base(context)
    {

    }
}
