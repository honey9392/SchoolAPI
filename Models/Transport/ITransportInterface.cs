using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAPI.Models.Transport
{
    public interface ITransportInterface
    {
        Object GetUpdate(string sNo);
        Object Verify(string mobile, string regNo);
    }
}
