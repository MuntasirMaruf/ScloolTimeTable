using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTimeTableDAL.Interfaces
{
    public interface ISendEmail
    {
        void SendEmail(int id);
        void SendScheduleEmail(string toEmail, string subject, string body);
    }
}
