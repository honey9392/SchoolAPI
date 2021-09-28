using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAPI.Models.Attendance
{
    public interface IAttendanceInterface
    {
        Object GetUpdate(string s_no);
    }
}
