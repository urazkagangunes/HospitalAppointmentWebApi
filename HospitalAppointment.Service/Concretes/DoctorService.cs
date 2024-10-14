using AutoMapper;
using HospitalAppointment.DataAccess.Abstract;
using HospitalAppointment.Models.Dto.DoctorDto.Request;
using HospitalAppointment.Models.Dto.DoctorDto.Response;
using HospitalAppointment.Models.Entities;
using HospitalAppointment.Service.Abstracts;
using HospitalAppointment.Models.Dto; 
using System.Net;

namespace HospitalAppointment.Service.Concretes
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;

        public DoctorService(IDoctorRepository doctorRepository, IAppointmentRepository appointmentRepository, IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
        }

        public ReturnModel<DoctorResponseDto> Add(CreateDoctorRequest createDoctor)
        {
            try
            {
                if (string.IsNullOrEmpty(createDoctor.Name))
                {
                    return new ReturnModel<DoctorResponseDto>
                    {
                        Success = false,
                        Message = "Doctor name cannot be empty.",
                        StatusCode = HttpStatusCode.BadRequest
                    };
                }

                Doctor doctor = _mapper.Map<Doctor>(createDoctor);
                var addedDoctor = _doctorRepository.Add(doctor);

                return new ReturnModel<DoctorResponseDto>
                {
                    Success = true,
                    Data = _mapper.Map<DoctorResponseDto>(addedDoctor),
                    StatusCode = HttpStatusCode.Created
                };
            }
            catch (Exception ex)
            {
                return new ReturnModel<DoctorResponseDto>
                {
                    Success = false,
                    Message = $"Error adding doctor: {ex.Message}",
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
        }

        public ReturnModel<DoctorResponseDto> Update(UpdateDoctorRequest updateDoctor)
        {
            try
            {
                var existingDoctor = _doctorRepository.GetById(updateDoctor.Id);
                if (existingDoctor == null)
                {
                    return new ReturnModel<DoctorResponseDto>
                    {
                        Success = false,
                        Message = "Doctor not found.",
                        StatusCode = HttpStatusCode.NotFound
                    };
                }

                if (string.IsNullOrEmpty(updateDoctor.Name))
                {
                    return new ReturnModel<DoctorResponseDto>
                    {
                        Success = false,
                        Message = "Doctor name cannot be empty.",
                        StatusCode = HttpStatusCode.BadRequest
                    };
                }

                _mapper.Map(updateDoctor, existingDoctor);
                var updatedDoctor = _doctorRepository.Update(existingDoctor);

                return new ReturnModel<DoctorResponseDto>
                {
                    Success = true,
                    Data = _mapper.Map<DoctorResponseDto>(updatedDoctor),
                    StatusCode = HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new ReturnModel<DoctorResponseDto>
                {
                    Success = false,
                    Message = $"Error updating doctor: {ex.Message}",
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
        }

        public ReturnModel<DoctorResponseDto> GetById(int doctorId) 
        {
            try
            {
                var doctor = _doctorRepository.GetById(doctorId);
                if (doctor == null)
                {
                    return new ReturnModel<DoctorResponseDto>
                    {
                        Success = false,
                        Message = "Doctor not found.",
                        StatusCode = HttpStatusCode.NotFound
                    };
                }

                return new ReturnModel<DoctorResponseDto>
                {
                    Success = true,
                    Data = _mapper.Map<DoctorResponseDto>(doctor),
                    StatusCode = HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new ReturnModel<DoctorResponseDto>
                {
                    Success = false,
                    Message = $"Error retrieving doctor by ID: {ex.Message}",
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
        }

        public ReturnModel<List<DoctorResponseDto>> GetAll()
        {
            try
            {
                var doctors = _doctorRepository.GetAll();
                var doctorDtos = _mapper.Map<List<DoctorResponseDto>>(doctors);

                return new ReturnModel<List<DoctorResponseDto>>
                {
                    Success = true,
                    Data = doctorDtos,
                    StatusCode = HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new ReturnModel<List<DoctorResponseDto>>
                {
                    Success = false,
                    Message = $"Error retrieving doctors: {ex.Message}",
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
        }

        public ReturnModel<DoctorResponseDto> Remove(int doctorId) 
        {
            try
            {
                var doctor = _doctorRepository.GetById(doctorId);
                if (doctor == null)
                {
                    return new ReturnModel<DoctorResponseDto>
                    {
                        Success = false,
                        Message = "Doctor not found.",
                        StatusCode = HttpStatusCode.NotFound
                    };
                }

                var deletedDoctor = _doctorRepository.Remove(doctor);
                return new ReturnModel<DoctorResponseDto>
                {
                    Success = true,
                    Data = _mapper.Map<DoctorResponseDto>(deletedDoctor),
                    StatusCode = HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new ReturnModel<DoctorResponseDto>
                {
                    Success = false,
                    Message = $"Error removing doctor: {ex.Message}",
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
        }
    }
}
