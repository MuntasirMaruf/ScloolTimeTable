using SchoolTimeTableDAL.EF.Tables;
using SchoolTimeTableDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace SchoolTimeTableDAL.Repos
{
    internal class TimeTableRepo : Repo, IRepo<TimeTable, int, TimeTable>, ITimeTable<object>, IMail
    {

        public TimeTable Get(int id)
        {
            return db.TimeTables.Find(id);
        }
        public List<TimeTable> Get()
        {
            return db.TimeTables.ToList();
        }
        public TimeTable Add(TimeTable timeTable)
        {
            db.TimeTables.Add(timeTable);
            db.SaveChanges();
            return timeTable;
        }
        public TimeTable Update(TimeTable timeTable)
        {
            var existingTimeTable = db.TimeTables.Find(timeTable.Id);
            if (existingTimeTable != null)
            {
                existingTimeTable.ClassSectionSubjectId = timeTable.ClassSectionSubjectId;
                existingTimeTable.RoomSlotId = timeTable.RoomSlotId;
                db.SaveChanges();
            }
            return existingTimeTable;
        }
        public void Delete(int id)
        {
            var timeTable = db.TimeTables.Find(id);
            if (timeTable != null)
            {
                db.TimeTables.Remove(timeTable);
                db.SaveChanges();
            }
        }

        public void AddTimeTable(string cls, string sec, string subject, int room, int slot)
        {
            var clsObj = (from c in db.Classes where c.Name == cls select c).SingleOrDefault();
            var secObj = (from s in db.Sections where s.Name == sec select s).SingleOrDefault();
            var subjectObj = (from sub in db.Subjects where sub.Name == subject select sub).SingleOrDefault();
            var roomObj = (from r in db.Rooms where r.Number == room select r).SingleOrDefault();
            var slotobj = db.Slots
                .FirstOrDefault(s => s.Id == slot);

            if (clsObj == null || secObj == null || subjectObj == null || roomObj == null || slotobj == null)
            {
                throw new ArgumentException("Invalid class, section, or subject.");
            }

            var classSection = db.ClassSections
                .FirstOrDefault(cs => cs.ClassId == clsObj.Id && cs.SectionId == secObj.Id);


            var roomSlot = db.RoomSlots
                .FirstOrDefault(rs => rs.RoomId == roomObj.Id && rs.SlotId == slot);


            var classSectionSubject = db.ClassSectionSubjects
                .FirstOrDefault(css => css.ClassSectionId == classSection.Id && css.SubjectId == subjectObj.Id);


            var csssrs = db.TimeTables
                .FirstOrDefault(t => t.ClassSectionSubjectId == classSectionSubject.Id && t.RoomSlotId == roomSlot.Id);

            if (csssrs != null)
            {                 
                throw new InvalidOperationException("This class section subject is already assigned to this room slot.");
            }

            var timeTable = new TimeTable
            {
                ClassSectionSubjectId = classSectionSubject.Id,
                RoomSlotId = roomSlot.Id
            };

            db.TimeTables.Add(timeTable);
            db.SaveChanges();
        }

        public dynamic GetTimeSlot(string cls, string sec, string subject)
        {
            var clsObj = (from c in db.Classes where c.Name == cls select c).SingleOrDefault();
            var secObj = (from s in db.Sections where s.Name == sec select s).SingleOrDefault();
            var subjectObj = (from sub in db.Subjects where sub.Name == subject select sub).SingleOrDefault();

            if (clsObj == null || secObj == null || subjectObj == null)
            {
                throw new ArgumentException("Invalid class, section, or subject.");
            }

            var classSection = db.ClassSections
                .FirstOrDefault(cs => cs.ClassId == clsObj.Id && cs.SectionId == secObj.Id);

            var classSectionSubject = db.ClassSectionSubjects
                .FirstOrDefault(cs => cs.ClassSectionId == classSection.Id && cs.SubjectId == subjectObj.Id);

            var timeTables = db.TimeTables
                .FirstOrDefault(cs => cs.ClassSectionSubjectId == classSectionSubject.Id);

            var roomSlot = db.RoomSlots.Find(timeTables.RoomSlotId);

            var room = db.Rooms.Find(roomSlot.RoomId);

            var slot = db.Slots.Find(roomSlot.SlotId);

            var result = new
            {
                Class = cls,
                Section = sec,
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

        public void EmailTimeSlot(int id, string cls, string sec, string subject)
        {
            var data = GetTimeSlot(cls, sec, subject);

            string emailBody =
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
