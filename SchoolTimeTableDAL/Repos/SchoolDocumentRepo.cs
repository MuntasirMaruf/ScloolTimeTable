using SchoolTimeTableDAL.EF.Tables;
using SchoolTimeTableDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTimeTableDAL.Repos
{
    internal class SchoolDocumentRepo : Repo, IRepo<SchoolDocument, int, SchoolDocument>
    {
        public SchoolDocument Get(int id)
        {
            return db.SchoolDocuments.Find(id);
        }
        public List<SchoolDocument> Get()
        {
            return db.SchoolDocuments.ToList();
        }
        public SchoolDocument Add(SchoolDocument schoolDocument)
        {
            db.SchoolDocuments.Add(schoolDocument);
            db.SaveChanges();
            return schoolDocument;
        }
        public SchoolDocument Update(SchoolDocument schoolDocument)
        {
            var existingSchoolDocument = db.SchoolDocuments.Find(schoolDocument.Id);
            return existingSchoolDocument;
        }
        public void Delete(int id)
        {
            var schoolDocument = db.SchoolDocuments.Find(id);
            if (schoolDocument != null)
            {
                db.SchoolDocuments.Remove(schoolDocument);
                db.SaveChanges();
            }
        }
    }
}
