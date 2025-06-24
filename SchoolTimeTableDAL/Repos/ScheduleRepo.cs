using SchoolTimeTableDAL.EF.Tables;
using SchoolTimeTableDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTimeTableDAL.Repos
{
    internal class ScheduleRepo : Repo, IRepo<Schedule, int, Schedule>
    {
        public Schedule Get(int id)
        {
            return db.Schedules.Find(id);
        }

        public List<Schedule> Get()
        {
            return db.Schedules.ToList();
        }

        public Schedule Add(Schedule schedule)
        {
            db.Schedules.Add(schedule);
            db.SaveChanges();
            return schedule;
        }

        public Schedule Update(Schedule schedule)
        {
            var existingSchedule = db.Schedules.Find(schedule.Id);
            if (existingSchedule != null)
            {
                existingSchedule.ClassSectionStudentId = schedule.ClassSectionStudentId;
                existingSchedule.TeacherId = schedule.TeacherId;
                existingSchedule.RoomSlotId = schedule.RoomSlotId;
                existingSchedule.Status = schedule.Status;
                db.SaveChanges();
            }
            return existingSchedule;
        }

        public void Delete(int id)
        {
            var schedule = db.Schedules.Find(id);
            if (schedule != null)
            {
                db.Schedules.Remove(schedule);
                db.SaveChanges();
            }
        }
    }
}
