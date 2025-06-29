﻿using SchoolTimeTableDAL.EF.Tables;
using SchoolTimeTableDAL.Interfaces;
using SchoolTimeTableDAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTimeTableDAL
{
    public class DataAccess
    {
        public static IRepo<Teacher, int, Teacher> TeacherData()
        {
            return new TeacherRepo();
        }
        public static IRepo<Student, int, Student> StudentData()
        {
            return new StudentRepo();
        }
        public static IRepo<Class, int, Class> ClassData()
        {
            return new ClassRepo();
        }
        public static IRepo<Section, int, Section> SectionData()
        {
            return new SectionRepo();
        }
        public static IRepo<Token, string, Token> TokenData()
        {
            return new TokenRepo();
        }
        public static IRepo<TokenStudent, string, TokenStudent> TokenStudentData()
        {
            return new TokenStudentRepo();
        }
        public static IRepo<Subject, int, Subject> SubjectData()
        {
            return new SubjectRepo();
        }
        public static IRepo<Room, int, Room> RoomData()
        {
            return new RoomRepo();
        }
        public static IRepo<Slot, int, Slot> SlotData()
        {
            return new SlotRepo();
        }
        public static IRepo<RoomSlot, int, RoomSlot> RoomSlotData()
        {
            return new RoomSlotRepo();
        }
        public static IRepo<ClassSectionStudent, int, ClassSectionStudent> ClassSectionStudentData()
        {
            return new ClassSectionStudentRepo();
        }
        public static IRepo<Status, int, Status> StatusData()
        {
            return new StatusRepo();
        }
        public static IRepo<Schedule, int, Schedule> ScheduleData()
        {
            return new ScheduleRepo();
        }
        public static IRepo<ClassSection, int, ClassSection> ClassSectionData()
        {
            return new ClassSectionRepo();
        }
        public static IAuth<Teacher> AuthTeacher()
        {
            return new TeacherRepo();
        }
        public static IAuth<Student> AuthStudent()
        {
            return new StudentRepo();
        }

        public static IAdmit AdmitStudent()
        {
            return new ClassSectionStudentRepo();
        }

        public static IAssign AssignRoomSlot()
        {
            return new RoomSlotRepo();
        }
        public static IRepo<SchoolDocument, int, SchoolDocument> SchoolDocumentData()
        {
            return new SchoolDocumentRepo();
        }

        public static IAssign AssignSchedule()
        {
            return new ScheduleRepo();

        }
        public static ISchedule<object> GetSchedule()
        {
            return new ScheduleRepo();

        }
        public static ISendEmail SendEmail()
        {
            return new ScheduleRepo();
        }

        public static IAssign AssignClassSection()
        {
            return new ClassSectionRepo();
        }
        public static IRepo<ClassSectionSubject, int, ClassSectionSubject> ClassSectionSubjectData()
        {
            return new ClassSectionSubjectRepo();
        }
        public static IAssign AssignClassSectionSubject()
        {
            return new ClassSectionSubjectRepo();
        }

        public static IRepo<TimeTable, int, TimeTable> TimeTableData()
        {
            return new TimeTableRepo();
        }

        public static ITimeTable<object> AddTimeTable()
        {
            return new TimeTableRepo();
        }
        public static ITimeTable<object> GetTimeSlot()
        {
            return new TimeTableRepo();
        }

        public static IMail EmailTimeSlot()
        {
            return new TimeTableRepo();
        }
    }
}
