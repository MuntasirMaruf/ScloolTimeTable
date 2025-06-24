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
    public class StudentAdmissionService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ClassSectionStudent, ClassSectionStudentDTO>().ReverseMap();
            });
            return new Mapper(config);
        }

        public static List<ClassSectionStudentDTO> Get()
        {
            var data = DataAccess.ClassSectionStudentData();
            return GetMapper().Map<List<ClassSectionStudentDTO>>(data.Get());
        }

        public static ClassSectionStudentDTO Get(int id)
        {
            var data = DataAccess.ClassSectionStudentData();
            return GetMapper().Map<ClassSectionStudentDTO>(data.Get(id));
        }

        public static void Add(ClassSectionStudentDTO ClassSectionStudentDTO)
        {
            var data = DataAccess.ClassSectionStudentData();
            var ClassSectionStudent = GetMapper().Map<ClassSectionStudent>(ClassSectionStudentDTO);
            data.Add(ClassSectionStudent);
        }

        public static void Update(ClassSectionStudentDTO ClassSectionStudentDTO)
        {
            var data = DataAccess.ClassSectionStudentData();
            var ClassSectionStudent = GetMapper().Map<ClassSectionStudent>(ClassSectionStudentDTO);
            data.Update(ClassSectionStudent);
        }

        public static void Delete(int id)
        {
            var data = DataAccess.ClassSectionStudentData();
            data.Delete(id);
        }

        public static void Admit(int roll, string cls, string section)
        {
            DataAccess.AdmitStudent().Admit(roll, cls, section);
        }
    }
}
