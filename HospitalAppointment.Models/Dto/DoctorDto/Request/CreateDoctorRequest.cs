using HospitalAppointment.Models.Entities.Enums;

namespace HospitalAppointment.Models.Dto.DoctorDto.Request;

public sealed record CreateDoctorRequest
    (
        string? Name,
        Branch Branch
    );
