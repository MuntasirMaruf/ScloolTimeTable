using SchoolTimeTableDAL.EF.Tables;
using SchoolTimeTableDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTimeTableDAL.Repos
{
    internal class RoomSlotRepo : Repo, IRepo<RoomSlot, int, RoomSlot>, IAssign
    {
        public RoomSlot Get(int id)
        {
            return db.RoomSlots.Find(id);
        }

        public List<RoomSlot> Get()
        {
            return db.RoomSlots.ToList();
        }

        public RoomSlot Add(RoomSlot roomSlot)
        {
            db.RoomSlots.Add(roomSlot);
            db.SaveChanges();
            return roomSlot;
        }

        public RoomSlot Update(RoomSlot roomSlot)
        {
            var existingRoomSlot = db.RoomSlots.Find(roomSlot.Id);
            if (existingRoomSlot != null)
            {
                existingRoomSlot.RoomId = roomSlot.RoomId;
                existingRoomSlot.SlotId = roomSlot.SlotId;
                existingRoomSlot.Status = roomSlot.Status;
                db.SaveChanges();
            }
            return existingRoomSlot;
        }

        public void Delete(int id)
        {
            var roomSlot = db.RoomSlots.Find(id);
            if (roomSlot != null)
            {
                db.RoomSlots.Remove(roomSlot);
                db.SaveChanges();
            }
        }

        public void Assign()
        {
            var slots = db.Slots.ToList();
            var rooms = db.Rooms.ToList();

            if (slots.Count == 0 || rooms.Count == 0)
            {
                throw new InvalidOperationException("No slots or rooms available for assignment.");
            }

            var existingRoomSlots = db.RoomSlots
                .Select(rs => new { rs.SlotId, rs.RoomId })
                .ToHashSet();

            var newRoomSlots = new List<RoomSlot>();

            // Generate all combinations
            foreach (var slot in slots)
            {
                foreach (var room in rooms)
                {
                    var key = new { SlotId = slot.Id, RoomId = room.Id };

                    // Avoid duplicates using anonymous type comparison
                    if (!existingRoomSlots.Contains(key))
                    {
                        newRoomSlots.Add(new RoomSlot
                        {
                            SlotId = slot.Id,
                            RoomId = room.Id,
                            Status = 1
                        });
                    }
                }
            }

            db.RoomSlots.AddRange(newRoomSlots);
            db.SaveChanges();
        }
    }
}
