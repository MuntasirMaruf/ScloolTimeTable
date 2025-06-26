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
    public class ClassSectionSubjectService
    {
        public static Mapper GetMapper() 
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ClassSectionSubject, ClassSectionSubjectDTO>().ReverseMap();
            });
            return new Mapper(config);
        }
        public static List<ClassSectionSubjectDTO> Get()
        {
            var data = DataAccess.ClassSectionSubjectData();
            return GetMapper().Map<List<ClassSectionSubjectDTO>>(data.Get());
        }

        public static ClassSectionSubjectDTO Get(int id)
        {
            var data = DataAccess.ClassSectionSubjectData();
            return GetMapper().Map<ClassSectionSubjectDTO>(data.Get(id));
        }

        public static void Add(ClassSectionSubjectDTO ClassSectionSubjectDTO)
        {
            var data = DataAccess.ClassSectionSubjectData();
            var ClassSectionSubject = GetMapper().Map<ClassSectionSubject>(ClassSectionSubjectDTO);
            data.Add(ClassSectionSubject);
        }

        public static void Update(ClassSectionSubjectDTO ClassSectionSubjectDTO)
        {
            var data = DataAccess.ClassSectionSubjectData();
            var ClassSectionSubject = GetMapper().Map<ClassSectionSubject>(ClassSectionSubjectDTO);
            data.Update(ClassSectionSubject);
        }

        public static void Delete(int id)
        {
            var data = DataAccess.ClassSectionSubjectData();
            data.Delete(id);
        }
        public static void AssignClassSectionSubject()
        {
            DataAccess.AssignClassSectionSubject().Assign();
        }
    }
}
