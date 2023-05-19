using DMS.BL.DTOs.TeacherDTOs;
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
    public interface ITeacherRepo
    {
        GetTeacherDTO? GetTeacherById(int id);
        PaginationModel GetAllTeachers(int pageNo, string? query);
        int AddTeacher(AddTeacherDTO teacherDTO);
        Teacher? UpdateTeacher(UpdateTeacherDTO teacherDTO);
        bool DeleteTeacher(int id);
    }

    public class TeacherRepo : ITeacherRepo
    {
        private ApplicationDBContext _context;

        public TeacherRepo(ApplicationDBContext context)
        {
            _context = context;
        }

        public PaginationModel GetAllTeachers(int pageNo, string? query)
        {
            List<GetTeacherDTO> teacherList = new List<GetTeacherDTO>();
            var dbResponse = _context.Teachers.AsQueryable();
            if (dbResponse != null)
            {
                var TotalPages = dbResponse.Count();
                var teachers = dbResponse.Skip(pageNo * 10).Take(10).ToList();
                teachers.ForEach(teacher => teacherList.Add(Omu.ValueInjecter.Mapper.Map<GetTeacherDTO>(teacher)));
                return new PaginationModel
                {
                    TotalPages = CommonHelper.PaginationTotalPages(TotalPages),
                    CurrentPage = pageNo,
                    Data = teacherList
                };
            }
            return null;
        }

        public GetTeacherDTO? GetTeacherById(int id)
        {
            var teacher = _context.Teachers.FirstOrDefault(x => x.Id == id);
            if (teacher != null)
            {
                var dbRequest = Omu.ValueInjecter.Mapper.Map<GetTeacherDTO>(teacher);
                return dbRequest;
            }
            return null;
        }

        public int AddTeacher(AddTeacherDTO teacherDTO)
        {
            var teacher = new Teacher
            {
                Picture = teacherDTO.Picture,
                FirstName = teacherDTO.FirstName,
                LastName = teacherDTO.LastName,
                Cnic = teacherDTO.Cnic,
                Gender = teacherDTO.Gender,
                DoB = teacherDTO.DoB,
                Age = teacherDTO.Age,
                PrimaryPhoneNumber = teacherDTO.PrimaryPhoneNumber,
                SecondaryPhoneNumber = teacherDTO.SecondaryPhoneNumber,
                Address = teacherDTO.Address,
                IsActive = teacherDTO.IsActive,
                IsDeleted = teacherDTO.IsDeleted
            };

            _context.Teachers.Add(teacher);
            _context.SaveChanges();

            return teacher.Id;
        }

        public Teacher? UpdateTeacher(UpdateTeacherDTO teacherDTO)
        {
            var teacher = _context.Teachers.FirstOrDefault(t => t.Id == teacherDTO.Id);
            if (teacher != null)
            {
                teacher.Picture = teacherDTO.Picture;
                teacher.FirstName = teacherDTO.FirstName;
                teacher.LastName = teacherDTO.LastName;
                teacher.Cnic = teacherDTO.Cnic;
                teacher.Gender = teacherDTO.Gender;
                teacher.DoB = teacherDTO.DoB;
                teacher.Age = teacherDTO.Age;
                teacher.PrimaryPhoneNumber = teacherDTO.PrimaryPhoneNumber;
                teacher.SecondaryPhoneNumber = teacherDTO.SecondaryPhoneNumber;
                teacher.Address = teacherDTO.Address;
                teacher.IsActive = teacherDTO.IsActive;
                teacher.IsDeleted = teacherDTO.IsDeleted;

                _context.SaveChanges();

                return teacher;
            }

            return null;
        }

        public bool DeleteTeacher(int id)
        {
            var teacher = _context.Teachers.FirstOrDefault(x => x.Id == id);

            if (teacher != null)
            {
                _context.Teachers.Remove(teacher);
                _context.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
