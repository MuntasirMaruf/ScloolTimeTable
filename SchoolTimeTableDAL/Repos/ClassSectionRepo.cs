using SchoolTimeTableDAL.EF.Tables;
using SchoolTimeTableDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTimeTableDAL.Repos
{
    internal class ClassSectionRepo : Repo, IRepo<ClassSection, int, ClassSection>, IAssign
    {
        public ClassSection Add(ClassSection entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ClassSection Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<ClassSection> Get()
        {
            return db.ClassSections.ToList();
        }

        public ClassSection Update(ClassSection entity)
        {
            throw new NotImplementedException();
        }

        public void Assign()
        {
            var classObjs = db.Classes.ToList();
            var sectionObjs = db.Sections.ToList();

            var existingClassSections = db.ClassSections
                .Select(cs => new { cs.ClassId, cs.SectionId })
                .ToHashSet();

            var newClassSections = new List<ClassSection>();

            // Generate all combinations
            foreach (var cls in classObjs)
            {
                foreach (var sec in sectionObjs)
                {
                    var key = new { ClassId = cls.Id, SectionId = sec.Id };

                    // Avoid duplicates using anonymous type comparison
                    if (!existingClassSections.Contains(key))
                    {
                        newClassSections.Add(new ClassSection
                        {
                            ClassId = cls.Id,
                            SectionId = sec.Id,
                            Status = 1
                        });
                    }
                }
            }

            db.ClassSections.AddRange(newClassSections);
            db.SaveChanges();
        }
    }
}
