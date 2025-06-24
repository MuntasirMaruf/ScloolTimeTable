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
    public class RoomSlotService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RoomSlot, RoomSlotDTO>().ReverseMap();
            });
            return new Mapper(config);
        }
        public static List<RoomSlotDTO> Get()
        {
            var data = DataAccess.RoomSlotData();
            return GetMapper().Map<List<RoomSlotDTO>>(data.Get());
        }

        public static void AssignRoomSlot()
        {
            DataAccess.AssignRoomSlot().Assign();
        }
    }
}
