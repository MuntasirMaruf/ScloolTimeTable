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
    public class ScheduleService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Schedule, ScheduleDTO>().ReverseMap();
            });
            return new Mapper(config);
        }
        public static List<ScheduleDTO> Get()
        {
            var data = DataAccess.ScheduleData();
            return GetMapper().Map<List<ScheduleDTO>>(data.Get());
        }

        public static ScheduleDTO Get(int id)
        {
            var data = DataAccess.ScheduleData();
            return GetMapper().Map<ScheduleDTO>(data.Get(id));
        }

        public static void Add(ScheduleDTO ScheduleDTO)
        {
            var data = DataAccess.ScheduleData();
            var Schedule = GetMapper().Map<Schedule>(ScheduleDTO);
            data.Add(Schedule);
        }

        public static void Update(ScheduleDTO ScheduleDTO)
        {
            var data = DataAccess.ScheduleData();
            var Schedule = GetMapper().Map<Schedule>(ScheduleDTO);
            data.Update(Schedule);
        }

        public static void Delete(int id)
        {
            var data = DataAccess.ScheduleData();
            data.Delete(id);
        }
        public static void AssignSchedule()
        {
            DataAccess.AssignSchedule().Assign();
        }

        public static object GetSchedule(int id)
        {
            return DataAccess.GetSchedule().GetSchedule(id);
        }

        public static void SendEmail(int id)
        {
            DataAccess.SendEmail().SendEmail(id);
        }
    }
}
