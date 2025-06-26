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
    public class ClassSectionService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ClassSection, ClassSectionDTO>().ReverseMap();
            });
            return new Mapper(config);
        }
        public static List<ClassSectionDTO> Get()
        {
            var data = DataAccess.ClassSectionData();
            return GetMapper().Map<List<ClassSectionDTO>>(data.Get());
        }

        public static ClassSectionDTO Get(int id)
        {
            var data = DataAccess.ClassSectionData();
            return GetMapper().Map<ClassSectionDTO>(data.Get(id));
        }

        public static void Add(ClassSectionDTO ClassSectionDTO)
        {
            var data = DataAccess.ClassSectionData();
            var ClassSection = GetMapper().Map<ClassSection>(ClassSectionDTO);
            data.Add(ClassSection);
        }

        public static void Update(ClassSectionDTO ClassSectionDTO)
        {
            var data = DataAccess.ClassSectionData();
            var ClassSection = GetMapper().Map<ClassSection>(ClassSectionDTO);
            data.Update(ClassSection);
        }

        public static void Delete(int id)
        {
            var data = DataAccess.ClassSectionData();
            data.Delete(id);
        }
        public static void AssignClassSection()
        {
            DataAccess.AssignClassSection().Assign();
        }
    }
}
