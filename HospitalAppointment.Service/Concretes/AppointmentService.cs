using AutoMapper;
using HospitalAppointment.DataAccess.Abstract;
using HospitalAppointment.DataAccess.Context;
using HospitalAppointment.Models.Dto.AppointmentDto.Request;
using HospitalAppointment.Models.Dto.AppointmentDto.Response;
using HospitalAppointment.Models.Entities;
using HospitalAppointment.Service.Abstracts;
using HospitalAppointment.Models.Dto; 
using System.Net;

namespace HospitalAppointment.Service.Concretes
{
    public class AppointmentService : IAppointmentService
    {
        private readonly BaseDbContext _context;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;

        public AppointmentService(IAppointmentRepository appointmentRepository, IDoctorRepository doctorRepository, IMapper mapper, BaseDbContext context)
        {
            _appointmentRepository = appointmentRepository;
            _doctorRepository = doctorRepository;
            _mapper = mapper;
            _context = context;
        }

        public ReturnModel<List<AppointmentResponseDto>> GetByDoctorId(int doctorId)
        {
            try
            {
                var appointments = _context.Appointments
                    .Where(a => a.DoctorId == doctorId)
                    .ToList();

                var appointmentDtos = _mapper.Map<List<AppointmentResponseDto>>(appointments);

                return new ReturnModel<List<AppointmentResponseDto>>
                {
                    Success = true,
                    Data = appointmentDtos,
                    Message = "Appointments retrieved successfully.",
                    StatusCode = HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new ReturnModel<List<AppointmentResponseDto>>
                {
                    Success = false,
                    Message = $"Error retrieving appointments: {ex.Message}",
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
        }

        public ReturnModel<Appointment> Add(CreateAppointmentRequest createAppointment)
        {
            try
            {
                var appointment = _mapper.Map<Appointment>(createAppointment);
                _appointmentRepository.Add(appointment);

                return new ReturnModel<Appointment>
                {
                    Success = true,
                    Data = appointment,
                    Message = "Appointment added successfully.",
                    StatusCode = HttpStatusCode.Created
                };
            }
            catch (Exception ex)
            {
                return new ReturnModel<Appointment>
                {
                    Success = false,
                    Message = $"Error adding appointment: {ex.Message}",
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
        }

        public ReturnModel<Appointment> Update(UpdateAppointmentRequest updateAppointment)
        {
            try
            {
                if (!updateAppointment.Id.HasValue)
                {
                    throw new Exception("Appointment ID cannot be null.");
                }

                var existingAppointment = _appointmentRepository.GetById(updateAppointment.Id.Value);
                if (existingAppointment == null)
                {
                    throw new Exception("Appointment not found.");
                }

                if (string.IsNullOrEmpty(updateAppointment.PatientName))
                {
                    throw new Exception("Patient name cannot be empty.");
                }

                if (!updateAppointment.DoctorId.HasValue)
                {
                    throw new Exception("Doctor ID cannot be null.");
                }

                var doctor = _doctorRepository.GetById(updateAppointment.DoctorId.Value);
                if (doctor == null)
                {
                    throw new Exception("Doctor must be specified.");
                }

                _mapper.Map(updateAppointment, existingAppointment);
                var updatedAppointment = _appointmentRepository.Update(existingAppointment);

                return new ReturnModel<Appointment>
                {
                    Success = true,
                    Data = updatedAppointment,
                    Message = "Appointment updated successfully.",
                    StatusCode = HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new ReturnModel<Appointment>
                {
                    Success = false,
                    Message = $"Error updating appointment: {ex.Message}",
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
        }

        public ReturnModel<List<AppointmentResponseDto>> GetAll()
        {
            try
            {
                var appointments = _appointmentRepository.GetAll();

                foreach (var appointment in appointments)
                {
                    if (appointment.AppointmentDate < DateTime.Now)
                    {
                        _appointmentRepository.Remove(appointment);
                    }
                }

                var appointmentDtos = _mapper.Map<List<AppointmentResponseDto>>(appointments);

                return new ReturnModel<List<AppointmentResponseDto>>
                {
                    Success = true,
                    Data = appointmentDtos,
                    Message = "Appointments retrieved successfully.",
                    StatusCode = HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new ReturnModel<List<AppointmentResponseDto>>
                {
                    Success = false,
                    Message = $"Error retrieving appointments: {ex.Message}",
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
        }

        public ReturnModel<AppointmentResponseDto> GetById(Guid id)
        {
            try
            {
                Appointment? appointment = _appointmentRepository.GetById(id);
                if (appointment == null)
                {
                    throw new Exception("Appointment not found.");
                }

                var appointmentDto = _mapper.Map<AppointmentResponseDto>(appointment);

                return new ReturnModel<AppointmentResponseDto>
                {
                    Success = true,
                    Data = appointmentDto,
                    Message = "Appointment retrieved successfully.",
                    StatusCode = HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new ReturnModel<AppointmentResponseDto>
                {
                    Success = false,
                    Message = $"Error retrieving appointment by ID: {ex.Message}",
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
        }

        public ReturnModel<Appointment> Remove(Guid id)
        {
            try
            {
                var appointment = _appointmentRepository.GetById(id);
                if (appointment == null)
                {
                    throw new Exception("Appointment not found.");
                }

                _appointmentRepository.Remove(appointment);

                return new ReturnModel<Appointment>
                {
                    Success = true,
                    Data = appointment,
                    Message = "Appointment removed successfully.",
                    StatusCode = HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new ReturnModel<Appointment>
                {
                    Success = false,
                    Message = $"Error removing appointment: {ex.Message}",
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
        }



    }
}
