using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAPI.Models.Fee
{
    public interface IFeeInterface
    {
        Object GetUpdate(string s_no);

        Object GetInstallments(string s_no);
    }
}
