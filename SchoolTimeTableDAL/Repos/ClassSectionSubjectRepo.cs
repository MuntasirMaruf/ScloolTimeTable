using SchoolTimeTableDAL.EF.Tables;
using SchoolTimeTableDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTimeTableDAL.Repos
{
    internal class ClassSectionSubjectRepo : Repo, IRepo<ClassSectionSubject, int, ClassSectionSubject>, IAssign
    {
        public ClassSectionSubject Get(int id)
        {
            return db.ClassSectionSubjects.Find(id);
        }

        public List<ClassSectionSubject> Get()
        {
            return db.ClassSectionSubjects.ToList();
        }

        public ClassSectionSubject Add(ClassSectionSubject ClassSectionSubject)
        {
            db.ClassSectionSubjects.Add(ClassSectionSubject);
            db.SaveChanges();
            return ClassSectionSubject;
        }


        public ClassSectionSubject Update(ClassSectionSubject ClassSectionSubject)
        {
            var existingClassSectionSubject = db.ClassSectionSubjects.Find(ClassSectionSubject.Id);
            if (existingClassSectionSubject != null)
            {
                existingClassSectionSubject.ClassSectionId = ClassSectionSubject.ClassSectionId;
                existingClassSectionSubject.SubjectId = ClassSectionSubject.SubjectId;
                db.SaveChanges();
            }
            return existingClassSectionSubject;
        }

        public void Delete(int id)
        {
            var ClassSectionSubject = db.ClassSectionSubjects.Find(id);
            if (ClassSectionSubject != null)
            {
                db.ClassSectionSubjects.Remove(ClassSectionSubject);
                db.SaveChanges();
            }
        }

        public void Assign()
        {
            var classObjs = db.ClassSections.ToList();
            var subjectObjs = db.Subjects.ToList();

            var existingClassSectionSubjects = db.ClassSectionSubjects
                .Select(cs => new { cs.ClassSectionId, cs.SubjectId })
                .ToHashSet();

            var newClassSectionSubjects = new List<ClassSectionSubject>();

            // Generate all combinations
            foreach (var cls in classObjs)
            {
                foreach (var sec in subjectObjs)
                {
                    var key = new { ClassSectionId = cls.Id, SubjectId = sec.Id };

                    // Avoid duplicates using anonymous type comparison
                    if (!existingClassSectionSubjects.Contains(key))
                    {
                        newClassSectionSubjects.Add(new ClassSectionSubject
                        {
                            ClassSectionId = cls.Id,
                            SubjectId = sec.Id,
                        });
                    }
                }
            }

            db.ClassSectionSubjects.AddRange(newClassSectionSubjects);
            db.SaveChanges();
        }
    }
}
