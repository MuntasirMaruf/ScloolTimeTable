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
    public class RoomService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Room, RoomDTO>().ReverseMap();
            });
            return new Mapper(config);
        }
        public static List<RoomDTO> Get()
        {
            var data = DataAccess.RoomData();
            return GetMapper().Map<List<RoomDTO>>(data.Get());
        }

        public static RoomDTO Get(int id)
        {
            var data = DataAccess.RoomData();
            return GetMapper().Map<RoomDTO>(data.Get(id));
        }

        public static void Add(RoomDTO RoomDTO)
        {
            var data = DataAccess.RoomData();
            var Room = GetMapper().Map<Room>(RoomDTO);
            data.Add(Room);
        }

        public static void Update(RoomDTO RoomDTO)
        {
            var data = DataAccess.RoomData();
            var Room = GetMapper().Map<Room>(RoomDTO);
            data.Update(Room);
        }

        public static void Delete(int id)
        {
            var data = DataAccess.RoomData();
            data.Delete(id);
        }
    }
}
