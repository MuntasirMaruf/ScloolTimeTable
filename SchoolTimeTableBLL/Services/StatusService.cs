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
    public class StatusService
    {
         public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Status, StatusDTO>().ReverseMap();
            });
            return new Mapper(config);
        }
        public static List<StatusDTO> Get()
        {
            var data = DataAccess.StatusData();
            return GetMapper().Map<List<StatusDTO>>(data.Get());
        }

        public static StatusDTO Get(int id)
        {
            var data = DataAccess.StatusData();
            return GetMapper().Map<StatusDTO>(data.Get(id));
        }

        public static void Add(StatusDTO StatusDTO)
        {
            var data = DataAccess.StatusData();
            var Status = GetMapper().Map<Status>(StatusDTO);
            data.Add(Status);
        }

        public static void Update(StatusDTO StatusDTO)
        {
            var data = DataAccess.StatusData();
            var Status = GetMapper().Map<Status>(StatusDTO);
            data.Update(Status);
        }

        public static void Delete(int id)
        {
            var data = DataAccess.StatusData();
            data.Delete(id);
        }
    }
}
