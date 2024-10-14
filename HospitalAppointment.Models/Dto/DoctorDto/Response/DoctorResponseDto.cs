using HospitalAppointment.Models.Entities.Enums;

namespace HospitalAppointment.Models.Dto.DoctorDto.Response;

public sealed record DoctorResponseDto
    (
        int Id,
        string? Name,
        Branch Branch,
        DateTime CreatedDate
    );
