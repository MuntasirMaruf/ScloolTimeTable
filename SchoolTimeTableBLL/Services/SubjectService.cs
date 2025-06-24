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
    public class SubjectService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Subject, SubjectDTO>().ReverseMap();
            });
            return new Mapper(config);
        }
        public static List<SubjectDTO> Get()
        {
            var data = DataAccess.SubjectData();
            return GetMapper().Map<List<SubjectDTO>>(data.Get());
        }
        public static SubjectDTO Get(int id)
        {
            var data = DataAccess.SubjectData();
            return GetMapper().Map<SubjectDTO>(data.Get(id));
        }
        public static void Add(SubjectDTO subjectDTO)
        {
            var data = DataAccess.SubjectData();
            var subject = GetMapper().Map<Subject>(subjectDTO);
            data.Add(subject);
        }
        public static void Update(SubjectDTO subjectDTO)
        {
            var data = DataAccess.SubjectData();
            var subject = GetMapper().Map<Subject>(subjectDTO);
            data.Update(subject);
        }
        public static void Delete(int id)
        {
            var data = DataAccess.SubjectData();
            data.Delete(id);
        }
    }
}
