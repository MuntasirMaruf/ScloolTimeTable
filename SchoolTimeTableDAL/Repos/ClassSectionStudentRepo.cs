
using SchoolTimeTableDAL.EF.Tables;
using SchoolTimeTableDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTimeTableDAL.Repos
{
    internal class ClassSectionStudentRepo : Repo, IRepo<ClassSectionStudent, int, ClassSectionStudent>, IAdmit
    {
        public ClassSectionStudent Get(int id)
        {
            return db.ClassSectionStudents.Find(id);
        }

        public List<ClassSectionStudent> Get()
        {
            return db.ClassSectionStudents.ToList();
        }

        public ClassSectionStudent Add(ClassSectionStudent classSectionStudent)
        {
            db.ClassSectionStudents.Add(classSectionStudent);
            db.SaveChanges();
            return classSectionStudent;
        }


        public ClassSectionStudent Update(ClassSectionStudent classSectionStudent)
        {
            var existingClassSectionStudent = db.ClassSectionStudents.Find(classSectionStudent.Id);
            if (existingClassSectionStudent != null)
            {
                existingClassSectionStudent.ClassId = classSectionStudent.ClassId;
                existingClassSectionStudent.SectionId = classSectionStudent.SectionId;
                existingClassSectionStudent.StudentId = classSectionStudent.StudentId;
                existingClassSectionStudent.Status = classSectionStudent.Status;
                db.SaveChanges();
            }
            return existingClassSectionStudent;
        }

        public void Delete(int id)
        {
            var classSectionStudent = db.ClassSectionStudents.Find(id);
            if (classSectionStudent != null)
            {
                db.ClassSectionStudents.Remove(classSectionStudent);
                db.SaveChanges();
            }
        }

        public void Admit(int roll, string cls, string section)
        {
            var student = db.Students.FirstOrDefault(s => s.Roll == roll);
            var classEntity = db.Classes.FirstOrDefault(c => c.Name == cls);
            var sectionEntity = db.Sections.FirstOrDefault(s => s.Name == section);
            if (student == null || classEntity == null || sectionEntity == null)
            {
                throw new Exception("Invalid roll number, class, or section.");
            }
            var classSectionStudent = new ClassSectionStudent
            {
                StudentId = student.Id,
                ClassId = classEntity.Id,
                SectionId = sectionEntity.Id,
                Status = 1
            };
            db.ClassSectionStudents.Add(classSectionStudent);
            db.SaveChanges();
        }
    }
}
