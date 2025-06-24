using SchoolTimeTableDAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTimeTableDAL.EF
{
    public class SchoolTimeTableDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<ClassSectionStudent> ClassSectionStudents { get; set; }
        public DbSet<RoomSlot> RoomSlots { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Slot> Slots { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<TokenStudent> TokenStudents { get; set; }

    }
}
