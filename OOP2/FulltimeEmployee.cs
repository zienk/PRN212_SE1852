﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2
{
    public class FulltimeEmployee : Employee
    {
        public override double CalculateSalary()
        {
            return base.CalculateSalary() + 5000000; 
        }
    }
}
