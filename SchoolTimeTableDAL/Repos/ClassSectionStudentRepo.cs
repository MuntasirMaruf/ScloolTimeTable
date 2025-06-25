
using SchoolTimeTableDAL.EF.Tables;
using SchoolTimeTableDAL.Interfaces;
using System;
using System.Collections.Generic;
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
            
            var student = db.Students.FirstOrDefault(s => s.Id == roll);
            var classEntity = db.Classes.FirstOrDefault(c => c.Name == cls);
            var sectionEntity = db.Sections.FirstOrDefault(s => s.Name == section);
            if (student == null || classEntity == null || sectionEntity == null)
            {
                throw new Exception("Invalid roll number, class, or section.");
            }

            // Check if the student is already admitted to the class and section
            var alreadyExists = (from s in db.ClassSectionStudents
                            where s.StudentId == student.Id
                                 select s).SingleOrDefault();

            if (alreadyExists != null)
            {
                throw new Exception("Student is already admitted.");
            }
            else
            {
                var classSectionsCount = (from s in db.ClassSectionStudents
                                where s.SectionId  == sectionEntity.Id && s.ClassId == classEntity.Id
                                select s).Count();
                var exactSection = db.Sections.Find(sectionEntity.Id);
                var capacity = exactSection.Capacity;

                if (classSectionsCount < capacity)
                {
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
                else
                {
                    throw new Exception("Class section is full. Cannot admit more students.");
                }
            }      
        }
    }
}
