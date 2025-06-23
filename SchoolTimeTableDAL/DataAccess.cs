using SchoolTimeTableDAL.EF.Tables;
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

        public static IAuth AuthTeacher()
        {
            return new TeacherRepo();
        }
    }
}
