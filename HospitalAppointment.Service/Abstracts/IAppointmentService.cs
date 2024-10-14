using HospitalAppointment.Models.Dto.AppointmentDto.Request;
using HospitalAppointment.Models.Dto.AppointmentDto.Response;
using HospitalAppointment.Models.Entities;
using HospitalAppointment.Models.Dto; 

namespace HospitalAppointment.Service.Abstracts
{
    public interface IAppointmentService
    {
        ReturnModel<List<AppointmentResponseDto>> GetAll();
        ReturnModel<AppointmentResponseDto> GetById(Guid id);
        ReturnModel<Appointment> Add(CreateAppointmentRequest createAppointment);
        ReturnModel<Appointment> Update(UpdateAppointmentRequest updateAppointment);
        ReturnModel<Appointment> Remove(Guid id);
        ReturnModel<List<AppointmentResponseDto>> GetByDoctorId(int doctorId);
    }
}

