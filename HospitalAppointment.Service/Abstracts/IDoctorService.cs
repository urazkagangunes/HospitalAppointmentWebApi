using HospitalAppointment.Models.Dto;
using HospitalAppointment.Models.Dto.DoctorDto.Request;
using HospitalAppointment.Models.Dto.DoctorDto.Response;

namespace HospitalAppointment.Service.Abstracts;

public interface IDoctorService
{
    ReturnModel<List<DoctorResponseDto>> GetAll();
    ReturnModel<DoctorResponseDto> GetById(int id);
    ReturnModel<DoctorResponseDto> Add(CreateDoctorRequest createDoctor);
    ReturnModel<DoctorResponseDto> Update(UpdateDoctorRequest updateDoctor);
    ReturnModel<DoctorResponseDto> Remove(int id);
}
