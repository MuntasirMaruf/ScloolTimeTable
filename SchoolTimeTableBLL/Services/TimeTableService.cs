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
    public class TimeTableService
    {

        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TimeTable, TimeTableDTO>().ReverseMap();
            });
            return new Mapper(config);
        }
        public static List<TimeTableDTO> Get()
        {
            var data = DataAccess.TimeTableData();
            return GetMapper().Map<List<TimeTableDTO>>(data.Get());
        }

        public static TimeTableDTO Get(int id)
        {
            var data = DataAccess.TimeTableData();
            return GetMapper().Map<TimeTableDTO>(data.Get(id));
        }

        public static void Add(TimeTableDTO TimeTableDTO)
        {
            var data = DataAccess.TimeTableData();
            var TimeTable = GetMapper().Map<TimeTable>(TimeTableDTO);
            data.Add(TimeTable);
        }

        public static void Update(TimeTableDTO TimeTableDTO)
        {
            var data = DataAccess.TimeTableData();
            var TimeTable = GetMapper().Map<TimeTable>(TimeTableDTO);
            data.Update(TimeTable);
        }

        public static void Delete(int id)
        {
            var data = DataAccess.TimeTableData();
            data.Delete(id);
        }
        public static void AddTimeTable(string cls, string sec, string sub, int room, int slot)
        {
            DataAccess.AddTimeTable().AddTimeTable(cls, sec, sub, room, slot);
        }

        public static object GetTimeSlot(string cls, string sec, string sub)
        {
            return DataAccess.GetTimeSlot().GetTimeSlot(cls, sec, sub);
        }

        public static void EmailTimeSlot(int id, string cls, string sec, string sub)
        {
            DataAccess.EmailTimeSlot().EmailTimeSlot(id, cls, sec, sub);
        }
    }
}
