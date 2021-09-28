using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAPI.Models.Information
{
    public interface IInformationInterface
    {
        Object GetUpdate(string sno);
    }
}