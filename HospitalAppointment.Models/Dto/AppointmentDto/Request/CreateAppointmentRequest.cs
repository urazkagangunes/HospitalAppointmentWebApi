namespace HospitalAppointment.Models.Dto.AppointmentDto.Request;

public sealed record CreateAppointmentRequest
    (
        string? PatientName,
        DateTime AppointmentDate,
        int DoctorId
    );
