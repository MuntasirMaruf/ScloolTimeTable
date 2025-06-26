using SchoolTimeTableDAL.EF.Tables;
using SchoolTimeTableDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTimeTableDAL.Repos
{
    internal class ClassSectionRoomSlotRepo : Repo, IRepo<ClassSectionRoomSlot, int, ClassSectionRoomSlot>
    {
        public ClassSectionRoomSlot Get(int id)
        {
            return db.ClassSectionRoomSlots.Find(id);
        }

        public List<ClassSectionRoomSlot> Get()
        {
            return db.ClassSectionRoomSlots.ToList();
        }

        public ClassSectionRoomSlot Add(ClassSectionRoomSlot ClassSectionRoomSlot)
        {
            db.ClassSectionRoomSlots.Add(ClassSectionRoomSlot);
            db.SaveChanges();
            return ClassSectionRoomSlot;
        }


        public ClassSectionRoomSlot Update(ClassSectionRoomSlot ClassSectionRoomSlot)
        {
            var existingClassSectionSubject = db.ClassSectionSubjects.Find(ClassSectionRoomSlot.Id);
            if (existingClassSectionSubject != null)
            {
                existingClassSectionSubject.ClassSectionId = ClassSectionRoomSlot.ClassSectionId;
                existingClassSectionSubject.SubjectId = ClassSectionRoomSlot.RoomSlotId;
                db.SaveChanges();
            }
            return ClassSectionRoomSlot;
        }

        public void Delete(int id)
        {
            var ClassSectionRoomSlot = db.ClassSectionSubjects.Find(id);
            if (ClassSectionRoomSlot != null)
            {
                db.ClassSectionSubjects.Remove(ClassSectionRoomSlot);
                db.SaveChanges();
            }
        }
    }
}
