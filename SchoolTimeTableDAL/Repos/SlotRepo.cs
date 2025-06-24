using SchoolTimeTableDAL.EF.Tables;
using SchoolTimeTableDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTimeTableDAL.Repos
{
    internal class SlotRepo : Repo, IRepo<Slot, int, Slot>
    {
        public Slot Get(int id)
        {
            return db.Slots.Find(id);
        }

        public List<Slot> Get()
        {
            return db.Slots.ToList();
        }

        public Slot Add(Slot slot)
        {
            db.Slots.Add(slot);
            db.SaveChanges();
            return slot;
        }

        public Slot Update(Slot slot)
        {
            var existingSlot = db.Slots.Find(slot.Id);
            if (existingSlot != null)
            {
                existingSlot.StartTime = slot.StartTime;
                existingSlot.EndTime = slot.EndTime;
                existingSlot.Status = slot.Status;
                db.SaveChanges();
            }
            return existingSlot;
        }
        public void Delete(int id)
        {
            var slot = db.Slots.Find(id);
            if (slot != null)
            {
                db.Slots.Remove(slot);
                db.SaveChanges();
            }
        }
    }
}
