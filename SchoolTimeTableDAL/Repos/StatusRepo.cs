using SchoolTimeTableDAL.EF.Tables;
using SchoolTimeTableDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTimeTableDAL.Repos
{
    internal class StatusRepo : Repo, IRepo<Status, int, Status>
    {
        public Status Get(int id)
        {
            return db.Statuses.Find(id);
        }

        public List<Status> Get()
        {
            return db.Statuses.ToList();
        }

        public Status Add(Status status)
        {
            db.Statuses.Add(status);
            db.SaveChanges();
            return status;
        }

        public Status Update(Status status)
        {
            var existingStatus = db.Statuses.Find(status.Id);
            if (existingStatus != null)
            {
                existingStatus.Name = status.Name;
                db.SaveChanges();
            }
            return existingStatus;
        }

        public void Delete(int id)
        {
            var status = db.Statuses.Find(id);
            if (status != null)
            {
                db.Statuses.Remove(status);
                db.SaveChanges();
            }
        }
    }
}
