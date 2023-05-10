using DMS.API.Models;
using DMS.BL.Services;
using DMS.Common;
using Microsoft.AspNetCore.Mvc;

namespace DMS.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class StudentController : ControllerBase
    {
        private ILogger<StudentController> _logger;
        private IStudentRepo _studentService;
        public StudentController(ILogger<StudentController> logger, IStudentRepo studentService)
        {
            _logger = logger;
            _studentService = studentService;
        }

        [HttpGet("GetStudentbyId")]
        public IActionResult GetStudentbyId(int studentId)
        {
            try
            {
                var data = _studentService.GetStudentById(studentId);
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


        [HttpGet("GetStudentAllStudents")]
        public IActionResult GetStudentAllStudents(int pageNo, string? query)
        {
            try
            {
                var data = _studentService.GetAlltudents(pageNo, query);
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
    }
}