
using SchoolTimeTableDAL.EF.Tables;
using SchoolTimeTableDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
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
                existingClassSectionStudent.ClassSectionId = classSectionStudent.ClassSectionId;
                existingClassSectionStudent.StudentId = classSectionStudent.StudentId;
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

            var student = db.Students.FirstOrDefault(s => s.Id == roll);
            var classEntity = db.Classes.FirstOrDefault(c => c.Name == cls);
            var sectionEntity = db.Sections.FirstOrDefault(s => s.Name == section);
            if (student == null || classEntity == null || sectionEntity == null)
            {
                throw new Exception("Invalid roll number, class, or section.");
            }

            var alreadyExists = (from s in db.ClassSectionStudents
                                 where s.StudentId == student.Id
                                 select s).SingleOrDefault();

            if (alreadyExists != null)
            {
                throw new Exception("Student is already admitted.");
            }
            else
            {
                var classSection = (from cs in db.ClassSections
                                        where cs.ClassId == classEntity.Id && cs.SectionId == sectionEntity.Id
                                        select cs).SingleOrDefault();

                var studentCount = classSection.StudentCount;
                if (studentCount >= sectionEntity.Capacity)
                {
                    throw new Exception("Class section is full.");
                }
                db.ClassSectionStudents.Add(new ClassSectionStudent
                {
                    ClassSectionId = classSection.Id,
                    StudentId = student.Id
                });
                db.SaveChanges();

                classSection.StudentCount++;
                db.SaveChanges();
            }
        }
    }
}
