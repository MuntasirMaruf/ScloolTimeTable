using SchoolTimeTableDAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTimeTableDAL.Interfaces
{
    public interface IAuth
    {
        Teacher Authenticate(string uname, string pass);
    }
}