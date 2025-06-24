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
    public class SectionService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Section, SectionDTO>().ReverseMap();
            });
            return new Mapper(config);
        }
        public static List<SectionDTO> Get()
        {
            var data = DataAccess.SectionData();
            return GetMapper().Map<List<SectionDTO>>(data.Get());
        }

        public static SectionDTO Get(int id)
        {
            var data = DataAccess.SectionData();
            return GetMapper().Map<SectionDTO>(data.Get(id));
        }

        public static void Add(SectionDTO SectionDTO)
        {
            var data = DataAccess.SectionData();
            var Section = GetMapper().Map<Section>(SectionDTO);
            data.Add(Section);
        }

        public static void Update(SectionDTO SectionDTO)
        {
            var data = DataAccess.SectionData();
            var Section = GetMapper().Map<Section>(SectionDTO);
            data.Update(Section);
        }

        public static void Delete(int id)
        {
            var data = DataAccess.SectionData();
            data.Delete(id);
        }
    }
}
