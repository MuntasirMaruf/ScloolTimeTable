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
    public class ClassService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Class, ClassDTO>().ReverseMap();
            });
            return new Mapper(config);
        }
        public static List<ClassDTO> Get()
        {
            var data = DataAccess.ClassData();
            return GetMapper().Map<List<ClassDTO>>(data.Get());
        }
        public static ClassDTO Get(int id)
        {
            var data = DataAccess.ClassData();
            return GetMapper().Map<ClassDTO>(data.Get(id));
        }
        public static void Add(ClassDTO classDTO)
        {
            var data = DataAccess.ClassData();
            var classEntity = GetMapper().Map<Class>(classDTO);
            data.Add(classEntity);
        }
        public static void Update(ClassDTO classDTO)
        {
            var data = DataAccess.ClassData();
            var classEntity = GetMapper().Map<Class>(classDTO);
            data.Update(classEntity);
        }
        public static void Delete(int id)
        {
            var data = DataAccess.ClassData();
            data.Delete(id);
        }
    }
}
