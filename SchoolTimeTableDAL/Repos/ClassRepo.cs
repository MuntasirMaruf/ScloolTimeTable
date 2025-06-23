using SchoolTimeTableDAL.EF.Tables;
using SchoolTimeTableDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTimeTableDAL.Repos
{
    internal class ClassRepo : Repo, IRepo<Class, int, Class>
    {
        public Class Get(int id)
        {
            return db.Classes.Find(id);
        }
        public List<Class> Get()
        {
            return db.Classes.ToList();
        }
        public Class Add(Class classEntity)
        {
            db.Classes.Add(classEntity);
            db.SaveChanges();
            return classEntity;
        }
        
        public Class Update(Class classEntity)
        {
            var existingClass = db.Classes.Find(classEntity.Id);
            if (existingClass != null)
            {
                existingClass.Name = classEntity.Name;
                existingClass.Status = classEntity.Status;
                existingClass.UpdatedAt = DateTime.Now;  
                db.SaveChanges();
            }
            return existingClass;
        }

        public void Delete(int id)
        {
            var classEntity = db.Classes.Find(id);
            if (classEntity != null)
            {
                db.Classes.Remove(classEntity);
                db.SaveChanges();
            }
        }
    }
}
