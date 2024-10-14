using AutoMapper;
using HospitalAppointment.Models.Dto.AppointmentDto.Request;
using HospitalAppointment.Models.Dto.AppointmentDto.Response;
using HospitalAppointment.Models.Entities;

namespace HospitalAppointment.Service.Profiles;

public class AppointmentMappingProfile : Profile
{
    public AppointmentMappingProfile()
    {
        CreateMap<Appointment, AppointmentResponseDto>()
            .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor.Name));
        {
            CreateMap<CreateAppointmentRequest, Appointment>().ReverseMap();

            CreateMap<UpdateAppointmentRequest, Appointment>().ReverseMap();
        }
    }
}
