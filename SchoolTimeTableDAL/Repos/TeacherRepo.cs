using SchoolTimeTableDAL.EF.Tables;
using SchoolTimeTableDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTimeTableDAL.Repos
{
    internal class TeacherRepo : Repo, IRepo<Teacher, int, Teacher>, IAuth
    {
        public Teacher Get(int id)
        {
            return db.Teachers.Find(id);
        }
        public List<Teacher> Get()
        {
            return db.Teachers.ToList();
        }

        public Teacher Add(Teacher teacher)
        {
            db.Teachers.Add(teacher);
            db.SaveChanges();
            return teacher;
        }

        public Teacher Update(Teacher teacher)
        {
            var existingTeacher = db.Teachers.Find(teacher.Id);
            if (existingTeacher != null)
            {
                existingTeacher.Name = teacher.Name;
                existingTeacher.Email = teacher.Email;
                existingTeacher.Phone = teacher.Phone;
                existingTeacher.BirthDate = teacher.BirthDate;
                existingTeacher.Gender = teacher.Gender;
                existingTeacher.Address = teacher.Address;
                existingTeacher.Subject = teacher.Subject;
                existingTeacher.Status = teacher.Status;
                existingTeacher.Salary = teacher.Salary;
                existingTeacher.Password = teacher.Password;
                existingTeacher.UpdatedAt = DateTime.Now;
                db.SaveChanges();
            }
            return existingTeacher;
        }

        public void Delete(int id)
        {
            var teacher = db.Teachers.Find(id);
            if (teacher != null)
            {
                db.Teachers.Remove(teacher);
                db.SaveChanges();
            }
        }

        public Teacher Authenticate(string email, string password)
        {
            var teacher = (from t in db.Teachers
                        where t.Email.Equals(email) &&
                        t.Password.Equals(password)
                        select t).SingleOrDefault();
            return teacher;
        }
    }
}
