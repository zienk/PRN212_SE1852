using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2
{
    public class ParttimeEmployee : Employee
    {
        public int WorkingHours { get; set; } // Số giờ làm việc
        public override double CalculateSalary()
        {
            return 100000 * WorkingHours;
        }
    }
}
