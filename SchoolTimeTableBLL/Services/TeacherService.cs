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
    public class TeacherService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Teacher, TeacherDTO>().ReverseMap();
            });
            return new Mapper(config);
        }
        public static List<TeacherDTO> Get()
        {
            var data = DataAccess.TeacherData();
            return GetMapper().Map<List<TeacherDTO>>(data.Get());
        }
        public static TeacherDTO Get(int id)
        {
            var data = DataAccess.TeacherData();
            return GetMapper().Map<TeacherDTO>(data.Get(id));
        }
        public static void Add(TeacherDTO teacherDTO)
        {
            var data = DataAccess.TeacherData();
            var teacher = GetMapper().Map<Teacher>(teacherDTO);
            data.Add(teacher);
        }
        public static void Update(TeacherDTO teacherDTO)
        {
            var data = DataAccess.TeacherData();
            var teacher = GetMapper().Map<Teacher>(teacherDTO);
            data.Update(teacher);
        }
        public static void Delete(int id)
        {
            var data = DataAccess.TeacherData();
            data.Delete(id);
        }
    }
}
