using AutoMapper;
using HospitalAppointment.Models.Dto.DoctorDto.Request;
using HospitalAppointment.Models.Dto.DoctorDto.Response;
using HospitalAppointment.Models.Entities;

namespace HospitalAppointment.Service.Profiles;

public class DoctorMappingProfile : Profile
{
    public DoctorMappingProfile()
    {
        CreateMap<Doctor, DoctorResponseDto>()
            .ForMember(dest => dest.Branch, opt => opt.MapFrom(src => src.Branch.ToString())).ReverseMap();

        CreateMap<CreateDoctorRequest, Doctor>();

        CreateMap<UpdateDoctorRequest, Doctor>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Branch, opt => opt.MapFrom(src => src.Branch));
    }
}
