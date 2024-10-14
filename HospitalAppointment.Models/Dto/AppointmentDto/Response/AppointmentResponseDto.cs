namespace HospitalAppointment.Models.Dto.AppointmentDto.Response;

public sealed record AppointmentResponseDto
    (
        Guid? Id,
        string? PatientName,
        DateTime AppointmentDate,
        int DoctorId,
        string DoctorName
    );
