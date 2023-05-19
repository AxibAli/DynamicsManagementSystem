using DMS.API.Models;
using DMS.BL.DTOs.TeacherDTOs;
using DMS.BL.Services;
using DMS.Common;
using DMS.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DMS.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TeacherController : ControllerBase
    {
        private ILogger<TeacherController> _logger;
        private ITeacherRepo _teacherService;
        public TeacherController(ILogger<TeacherController> logger, ITeacherRepo teacherService)
        {
            _logger = logger;
            _teacherService = teacherService;
        }

        [HttpGet("GetTeacherbyId")]
        public IActionResult GetTeacherbyId(int teacherId)
        {
            try
            {
                var data = _teacherService.GetTeacherById(teacherId);
                return Ok(new JSONResponse
                {
                    Status = CustomMessage.SUCCESS,
                    Data = data
                });
            }
            catch (Exception ex)
            {
                return Ok(new JSONResponse
                {
                    Status = CustomMessage.FAILURE,
                    ErrorMessage = ex.Message,
                    ErrorDetail = ex?.InnerException?.ToString() ?? string.Empty
                });
            }
        }

        [HttpGet("GetTeacherAllTeachers")]
        public IActionResult GetTeacherAllTeachers(int pageNo, string? query)
        {
            try
            {
                var data = _teacherService.GetAllTeachers(pageNo, query);
                return Ok(new JSONResponse
                {
                    Status = CustomMessage.SUCCESS,
                    Data = data
                });
            }
            catch (Exception ex)
            {
                return Ok(new JSONResponse
                {
                    Status = CustomMessage.FAILURE,
                    ErrorMessage = ex.Message,
                    ErrorDetail = ex?.InnerException?.ToString() ?? string.Empty
                });
            }
        }

        [HttpPost("AddTeacher")]
        public IActionResult AddTeacher([FromBody] AddTeacherDTO teacherDTO)
        {
            try
            {
                var teacherId = _teacherService.AddTeacher(teacherDTO);
                return Ok(new JSONResponse
                {
                    Status = CustomMessage.SUCCESS,
                    Data = new { insertID = teacherId }
                });
            }
            catch (Exception ex)
            {
                return Ok(new JSONResponse
                {
                    Status = CustomMessage.FAILURE,
                    ErrorMessage = ex.Message,
                    ErrorDetail = ex?.InnerException?.ToString() ?? string.Empty
                });
            }
        }

        [HttpPut("UpdateTeacher")]
        public IActionResult UpdateTeacher([FromBody] UpdateTeacherDTO teacherDTO)
        {
            try
            {
                var data = _teacherService.UpdateTeacher(teacherDTO);

                if(data != null)
                {
                    return Ok(new JSONResponse
                    {
                        Status = CustomMessage.SUCCESS,
                        Data = data
                    });
                }
                else
                {
                    return Ok(new JSONResponse 
                    {
                        Status = CustomMessage.FAILURE,
                        ErrorMessage = string.Format(CustomMessage.NOTFOUND,"Teacher")
                    });
                }
                
            }
            catch (Exception ex)
            {
                return Ok(new JSONResponse
                {
                    Status = CustomMessage.FAILURE,
                    ErrorMessage = ex.Message,
                    ErrorDetail = ex?.InnerException?.ToString() ?? string.Empty
                });
            }
        }

        [HttpDelete("DeleteTeacher")]
        public IActionResult DeleteTeacher(int teacherId)
        {
            try
            {
                bool isDeleted = _teacherService.DeleteTeacher(teacherId);

                if (isDeleted == true)
                {
                    return Ok(new JSONResponse
                    {
                        Status = CustomMessage.SUCCESS,
                        Data = new { DeletedTeacherID = teacherId }
                    });
                }
                else
                {
                    return Ok(new JSONResponse
                    {
                        Status = CustomMessage.FAILURE,
                        ErrorMessage = string.Format(CustomMessage.NOTFOUND, "Teacher")
                    });
                }

            }
            catch (Exception ex)
            {
                return Ok(new JSONResponse
                {
                    Status = CustomMessage.FAILURE,
                    ErrorMessage = ex.Message,
                    ErrorDetail = ex?.InnerException?.ToString() ?? string.Empty
                });
            }
        }
    }
}