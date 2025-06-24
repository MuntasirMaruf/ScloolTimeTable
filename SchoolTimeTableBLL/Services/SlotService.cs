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
    public class SlotService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Slot, SlotDTO>().ReverseMap();
            });
            return new Mapper(config);
        }
        public static List<SlotDTO> Get()
        {
            var data = DataAccess.SlotData();
            return GetMapper().Map<List<SlotDTO>>(data.Get());
        }

        public static SlotDTO Get(int id)
        {
            var data = DataAccess.SlotData();
            return GetMapper().Map<SlotDTO>(data.Get(id));
        }

        public static void Add(SlotDTO SlotDTO)
        {
            var data = DataAccess.SlotData();
            var Slot = GetMapper().Map<Slot>(SlotDTO);
            data.Add(Slot);
        }

        public static void Update(SlotDTO SlotDTO)
        {
            var data = DataAccess.SlotData();
            var Slot = GetMapper().Map<Slot>(SlotDTO);
            data.Update(Slot);
        }

        public static void Delete(int id)
        {
            var data = DataAccess.SlotData();
            data.Delete(id);
        }
    }
}
