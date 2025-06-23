using SchoolTimeTableDAL.EF.Tables;
using SchoolTimeTableDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTimeTableDAL.Repos
{
    internal class StudentRepo : Repo, IRepo<Student, int, Student>
    {
        public Student Get(int id)
        {
            return db.Students.Find(id);
        }

        public List<Student> Get()
        {
            return db.Students.ToList();
        }

        public Student Add(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
            return student;
        }

        public Student Update(Student student)
        {
            var existingStudent = db.Students.Find(student.Id);
            if (existingStudent != null)
            {
                existingStudent.Name = student.Name;
                existingStudent.Roll = student.Roll;
                existingStudent.Email = student.Email;
                existingStudent.Phone = student.Phone;
                existingStudent.BirthDate = student.BirthDate;
                existingStudent.Gender = student.Gender;
                existingStudent.Address = student.Address;
                existingStudent.Password = student.Password;
                existingStudent.Status = student.Status;
                existingStudent.UpdatedAt = DateTime.Now;
                db.SaveChanges();
            }
            return existingStudent;
        }

        public void Delete(int id)
        {
            var student = db.Students.Find(id);
            if (student != null)
            {
                db.Students.Remove(student);
                db.SaveChanges();
            }
        }
    }
}
