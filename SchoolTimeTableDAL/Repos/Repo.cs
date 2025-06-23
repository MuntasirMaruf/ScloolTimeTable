using SchoolTimeTableDAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTimeTableDAL.Repos
{
    internal class Repo
    {
        protected SchoolTimeTableDbContext db;

        internal Repo()
        {
            db = new SchoolTimeTableDbContext();
        }

    }
}
