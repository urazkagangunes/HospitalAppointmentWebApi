using Microsoft.AspNetCore.Mvc;
using HospitalAppointment.Service.Abstracts;
using HospitalAppointment.Models.Dto.AppointmentDto.Request;
using HospitalAppointment.Models.Dto.AppointmentDto.Response;
using System.Net;
using HospitalAppointment.Models.Entities;
using HospitalAppointment.Models.Dto;

namespace HospitalAppointment.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AppointmentController : ControllerBase
{
    private readonly IAppointmentService _appointmentService;

    public AppointmentController(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }

    [HttpGet("getall")]
    public ActionResult<ReturnModel<List<AppointmentResponseDto>>> GetAll()
    {
        try
        {
            var result = _appointmentService.GetAll();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new ReturnModel<List<AppointmentResponseDto>>
            {
                Success = false,
                Message = ex.Message,
                StatusCode = HttpStatusCode.BadRequest
            });
        }
    }

    [HttpGet("getbyid{id}")]
    public ActionResult<ReturnModel<AppointmentResponseDto>> GetById(Guid id)
    {
        try
        {
            var result = _appointmentService.GetById(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return NotFound(new ReturnModel<AppointmentResponseDto>
            {
                Success = false,
                Message = ex.Message,
                StatusCode = HttpStatusCode.NotFound
            });
        }
    }

    [HttpPost("add")]
    public ActionResult<ReturnModel<AppointmentResponseDto>> Add(CreateAppointmentRequest request)
    {
        try
        {
            var result = _appointmentService.Add(request);

            if (result.Data == null || result.Data.Id == Guid.Empty)
            {
                return BadRequest(new ReturnModel<AppointmentResponseDto>
                {
                    Success = false,
                    Message = "Invalid appointment data",
                    StatusCode = HttpStatusCode.BadRequest
                });
            }

            return CreatedAtAction(nameof(GetById), new { id = result.Data?.Id }, result);
        }
        catch (Exception ex)
        {
            return BadRequest(new ReturnModel<AppointmentResponseDto>
            {
                Success = false,
                Message = ex.Message,
                StatusCode = HttpStatusCode.BadRequest
            });
        }
    }

    [HttpPut("update")]
    public ActionResult<ReturnModel<Appointment>> Update(UpdateAppointmentRequest request)
    {
        try
        {
            var result = _appointmentService.Update(request);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new ReturnModel<Appointment>
            {
                Success = false,
                Message = ex.Message,
                StatusCode = HttpStatusCode.BadRequest
            });
        }
    }

    [HttpDelete("remove{id}")]
    public ActionResult<ReturnModel<Appointment>> Remove(Guid id)
    {
        try
        {
            var result = _appointmentService.Remove(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return NotFound(new ReturnModel<Appointment>
            {
                Success = false,
                Message = ex.Message,
                StatusCode = HttpStatusCode.NotFound
            });
        }
    }
}

