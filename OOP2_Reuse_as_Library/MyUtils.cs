using OOP2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_Reuse_as_Library
{
    public static class MyUtils
    {
        public static int TinhTuoi(this Employee emp)
        {
            return DateTime.Now.Year - emp.BirthDay.Year + 1;
        }
    }
}
