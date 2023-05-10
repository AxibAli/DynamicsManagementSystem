using DMS.BL.ServiceModels;
using DMS.Common;
using DMS.DAL;
using DMS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.BL.Services
{
    public interface IStudentRepo
    {
        GetStudentDTO? GetStudentById(int id);
        PaginationModel GetAlltudents(int pageNo, string? query);
    }

    public class StudentRepo : IStudentRepo
    {
        private ApplicationDBContext _context;

        public StudentRepo(ApplicationDBContext context)
        {
            _context = context;
        }

        public PaginationModel GetAlltudents(int pageNo, string? query)
        {
            List<GetStudentDTO> studentList = new List<GetStudentDTO>();
            var dbResponse = _context.Students.AsQueryable();
            if (dbResponse != null)
            {
                var TotalPages = dbResponse.Count();
                var students = dbResponse.Skip(pageNo * 10).Take(10).ToList();
                students.ForEach(student => studentList.Add(Omu.ValueInjecter.Mapper.Map<GetStudentDTO>(student)));
                return new PaginationModel
                {
                    TotalPages = CommonHelper.PaginationTotalPages(TotalPages),
                    CurrentPage = pageNo,
                    Data = studentList
                };
            }
            return null;
        }

        public GetStudentDTO? GetStudentById(int id)
        {
            var student = _context.Students.FirstOrDefault(x => x.Id == id);
            if (student != null)
            {
                var dbRequest = Omu.ValueInjecter.Mapper.Map<GetStudentDTO>(student);
                return dbRequest;
            }
            return null;
        }
    }
}
