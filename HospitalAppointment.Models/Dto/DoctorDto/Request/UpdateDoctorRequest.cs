using HospitalAppointment.Models.Entities.Enums;

namespace HospitalAppointment.Models.Dto.DoctorDto.Request;

public sealed record UpdateDoctorRequest
    (
        int Id,
        string? Name,
        Branch Branch
    );
