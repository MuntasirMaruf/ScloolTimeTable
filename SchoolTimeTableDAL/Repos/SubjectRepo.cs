using SchoolTimeTableDAL.EF.Tables;
using SchoolTimeTableDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTimeTableDAL.Repos
{
    internal class SubjectRepo : Repo, IRepo<Subject, int, Subject>
    {
        public Subject Get(int id)
        {
            return db.Subjects.Find(id);
        }

        public List<Subject> Get()
        {
            return db.Subjects.ToList();
        }


        public Subject Add(Subject subject)
        {
            db.Subjects.Add(subject);
            db.SaveChanges();
            return subject;
        }

        public Subject Update(Subject subject)
        {
            var existingSubject = db.Subjects.Find(subject.Id);
            if (existingSubject != null)
            {
                existingSubject.Name = subject.Name;
                existingSubject.Status = subject.Status;
                existingSubject.UpdatedAt = DateTime.Now;
                db.SaveChanges();
            }
            return existingSubject;
        }

        public void Delete(int id)
        {
            var subject = db.Subjects.Find(id);
            if (subject != null)
            {
                db.Subjects.Remove(subject);
                db.SaveChanges();
            }
        }
    }
}
