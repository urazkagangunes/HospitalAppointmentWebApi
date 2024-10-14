namespace HospitalAppointment.Models.Dto.AppointmentDto.Request;

public sealed record UpdateAppointmentRequest
    (
        Guid? Id,
        string? PatientName,
        DateTime AppointmentDate,
        int? DoctorId
    );
