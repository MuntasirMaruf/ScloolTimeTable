using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTimeTableDAL.Interfaces
{
    public interface IMail
    {
        void EmailTimeSlot(int id, string cls, string sec, string sub);
        void SendScheduleEmail(string toEmail, string subject, string body);
    }
}
