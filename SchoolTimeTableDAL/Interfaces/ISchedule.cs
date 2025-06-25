using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTimeTableDAL.Interfaces
{
    public interface ISchedule<RET>
    {
        //RET GetSchedule();
        RET GetSchedule(int id);
        //RET GetSchedule(string cls);
        //RET GetSchedule(string cls, string sec);
    }
}
