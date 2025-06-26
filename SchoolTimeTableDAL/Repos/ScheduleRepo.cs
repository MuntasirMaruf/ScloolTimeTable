using SchoolTimeTableDAL.EF.Tables;
using SchoolTimeTableDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace SchoolTimeTableDAL.Repos
{
    internal class ScheduleRepo : Repo, IRepo<Schedule, int, Schedule>, IAssign, ISchedule<object>, ISendEmail
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

        public void Assign()
        {

        }

        public dynamic GetSchedule(int id)
        {
            var classSectionStudent = (from css in db.ClassSectionStudents
                                       where css.StudentId == id
                                       select css).SingleOrDefault();
            
            if(classSectionStudent == null)
            {
                throw new Exception("Student not found in any class section.");
            }
            
            var classSection = (from cs in db.ClassSections
                                where cs.Id == classSectionStudent.ClassSectionId
                                select cs).SingleOrDefault();
            

            var student = (from s in db.Students
                           where s.Id == id
                           select s).SingleOrDefault();

            var cls = (from c in db.Classes
                       where c.Id == classSection.ClassId
                       select c).SingleOrDefault();

            

            var section = (from s in db.Sections
                           where s.Id == classSection.SectionId
                           select s).SingleOrDefault();





            var classSectionRoomSlot = (from csr in db.ClassSectionRoomSlots
                                        where csr.ClassSectionId == classSectionStudent.ClassSectionId
                                        select csr).FirstOrDefault();


            var roomSlot = (from rs in db.RoomSlots
                            where rs.Id == classSectionRoomSlot.RoomSlotId
                            select rs).FirstOrDefault();


            var room = (from r in db.Rooms
                        where r.Id == roomSlot.RoomId
                        select r).FirstOrDefault();


            var slot = (from s in db.Slots
                        where s.Id == roomSlot.SlotId
                        select s).FirstOrDefault();


            var result = new
            {
                Name = student.Name,
                Class = cls.Name,
                Section = section.Name,
                Room = room.Number,
                Start = slot.StartTime,
                End = slot.EndTime,
            };

            return result;

        }

        public void SendScheduleEmail(string toEmail, string subject, string body)
        {
            var fromAddress = new MailAddress("maruf.prottoy26@gmail.com", "School");
            var toAddress = new MailAddress(toEmail);
            const string fromPassword = "baju jlfg ynuj iuwn";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }

        public void SendEmail(int id)
        {
            var data = GetSchedule(id);

            string emailBody =
                "Name: " + data.Name + "\n" +
                "Class: " + data.Class + "\n" +
                "Section: " + data.Section + "\n" +
                "Room: " + data.Room + "\n" +
                "Start: " + data.Start + "\n" +
                "End: " + data.End + "\n";

            var toEmail = (from s in db.Students
                           where s.Id == id
                           select s.Email).SingleOrDefault();

            SendScheduleEmail(toEmail, "Your Schedule", emailBody);
        }
    }
}
