using SchoolTimeTableDAL.EF.Tables;
using SchoolTimeTableDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTimeTableDAL.Repos
{
    internal class SectionRepo : Repo, IRepo<Section, int, Section>
    {
        public Section Get(int id)
        {
            return db.Sections.Find(id);
        }

        public List<Section> Get()
        {
            return db.Sections.ToList();
        }   

        public Section Add(Section section)
        {
            db.Sections.Add(section);
            db.SaveChanges();
            return section;
        }

        public Section Update(Section section)
        {
            var existingSection = db.Sections.Find(section.Id);
            if (existingSection != null)
            {
                existingSection.Name = section.Name;
                existingSection.Status = section.Status;
                existingSection.Capacity = section.Capacity;
                db.SaveChanges();
            }

            return existingSection;
        }

        public void Delete(int id)
        {
            var section = db.Sections.Find(id);
            if (section != null)
            {
                db.Sections.Remove(section);
                db.SaveChanges();
            }
        }
    }
}
