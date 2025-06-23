using AutoMapper;
using SchoolTimeTableBLL.DTOs;
using SchoolTimeTableDAL;
using SchoolTimeTableDAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTimeTableBLL.Services
{
    public class StudentService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Student, StudentDTO>().ReverseMap();
            });
            return new Mapper(config);
        }
        public static List<StudentDTO> Get()
        {
            var data = DataAccess.StudentData();
            return GetMapper().Map<List<StudentDTO>>(data.Get());
        }

        public static StudentDTO Get(int id)
        {
            var data = DataAccess.StudentData();
            return GetMapper().Map<StudentDTO>(data.Get(id));
        }

        public static void Add(StudentDTO studentDTO)
        {
            var data = DataAccess.StudentData();
            var student = GetMapper().Map<Student>(studentDTO);
            data.Add(student);
        }

        public static void Update(StudentDTO studentDTO)
        {
            var data = DataAccess.StudentData();
            var student = GetMapper().Map<Student>(studentDTO);
            data.Update(student);
        }

        public static void Delete(int id)
        {
            var data = DataAccess.StudentData();
            data.Delete(id);
        }

    }
}
