using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTimeTableDAL.Interfaces
{
    public interface ITimeTable<RET>
    {
        void AddTimeTable(string cls, string sec, string subject, int room, int slot);
        RET GetTimeSlot(string cls, string sec, string subject);
    }
}
