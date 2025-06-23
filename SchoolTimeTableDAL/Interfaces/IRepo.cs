using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTimeTableDAL.Interfaces
{
    public interface IRepo<CLASS, TYPE, RET>
    {
        RET Add(CLASS entity);
        CLASS Get(TYPE id);
        List<CLASS> Get();
        RET Update(CLASS entity);
        void Delete(TYPE id);
    }
}
