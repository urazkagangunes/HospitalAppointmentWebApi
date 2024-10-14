using Microsoft.AspNetCore.Mvc;
using HospitalAppointment.Service.Abstracts;
using HospitalAppointment.Models.Dto.DoctorDto.Request;
using HospitalAppointment.Models.Dto.DoctorDto.Response;
using HospitalAppointment.Models.Dto;
using System.Net;

namespace HospitalAppointment.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DoctorController : ControllerBase
{
    private readonly IDoctorService _doctorService;

    public DoctorController(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }

    [HttpGet("getall")]
    public ActionResult<ReturnModel<List<DoctorResponseDto>>> GetAll()
    {
        try
        {
            var result = _doctorService.GetAll();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new ReturnModel<List<DoctorResponseDto>>
            {
                Success = false,
                Message = ex.Message,
                StatusCode = HttpStatusCode.BadRequest
            });
        }
    }

    [HttpGet("getbyid{id}")]
    public ActionResult<ReturnModel<DoctorResponseDto>> GetById(int id)
    {
        try
        {
            var result = _doctorService.GetById(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return NotFound(new ReturnModel<DoctorResponseDto>
            {
                Success = false,
                Message = ex.Message,
                StatusCode = HttpStatusCode.NotFound
            });
        }
    }

    [HttpPost("add")]
    public ActionResult<ReturnModel<DoctorResponseDto>> Add(CreateDoctorRequest request)
    {
        try
        {
            var result = _doctorService.Add(request);
            return CreatedAtAction(nameof(GetById), new { id = result.Data?.Id }, result);
        }
        catch (Exception ex)
        {
            return BadRequest(new ReturnModel<DoctorResponseDto>
            {
                Success = false,
                Message = ex.Message,
                StatusCode = HttpStatusCode.BadRequest
            });
        }
    }

    [HttpPut("update")]
    public ActionResult<ReturnModel<DoctorResponseDto>> Update(UpdateDoctorRequest request)
    {
        try
        {
            var result = _doctorService.Update(request);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new ReturnModel<DoctorResponseDto>
            {
                Success = false,
                Message = ex.Message,
                StatusCode = HttpStatusCode.BadRequest
            });
        }
    }

    [HttpDelete("remove{id}")]
    public ActionResult<ReturnModel<DoctorResponseDto>> Remove(int id)
    {
        try
        {
            var result = _doctorService.Remove(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return NotFound(new ReturnModel<DoctorResponseDto>
            {
                Success = false,
                Message = ex.Message,
                StatusCode = HttpStatusCode.NotFound
            });
        }
    }
}
