using SchoolTimeTableDAL.EF.Tables;
using SchoolTimeTableDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTimeTableDAL.Repos
{
    internal class RoomRepo : Repo, IRepo<Room, int, Room>
    {
        public Room Get(int id)
        {
            return db.Rooms.Find(id);
        }

        public List<Room> Get()
        {
            return db.Rooms.ToList();
        }

        public Room Add(Room room)
        {
            db.Rooms.Add(room);
            db.SaveChanges();
            return room;
        }

        public Room Update(Room room)
        {
            var existingRoom = db.Rooms.Find(room.Id);
            if (existingRoom != null)
            {
                existingRoom.Number = room.Number;
                existingRoom.Capacity = room.Capacity;
                existingRoom.Status = room.Status;
                db.SaveChanges();
            }
            return existingRoom;
        }

        public void Delete(int id)
        {
            var room = db.Rooms.Find(id);
            if (room != null)
            {
                db.Rooms.Remove(room);
                db.SaveChanges();
            }
        }
    }
}
