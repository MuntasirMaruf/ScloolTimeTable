using SchoolTimeTableDAL.EF.Tables;
using SchoolTimeTableDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTimeTableDAL.Repos
{
    internal class TokenStudentRepo : Repo, IRepo<TokenStudent, string, TokenStudent>
    {
        public TokenStudent Add(TokenStudent obj)
        {
            db.TokenStudents.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<TokenStudent> Get()
        {
            throw new NotImplementedException();
        }

        public TokenStudent Get(string id)
        {
            return db.TokenStudents.FirstOrDefault(t => t.Key.Equals(id));
        }

        public TokenStudent Update(TokenStudent obj)
        {
            var tk = Get(obj.Key);
            db.Entry(tk).CurrentValues.SetValues(obj);
            db.SaveChanges();
            return tk;
        }
    }
}
