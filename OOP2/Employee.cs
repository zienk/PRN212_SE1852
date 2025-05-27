using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IdCard { get; set; }
        public DateTime BirthDay { get; set; }
        public virtual double CalculateSalary()
        {
            return 4000000; // Giả sử lương cơ bản là 4 triệu
        }

        public override string ToString()
        {
            return Id + "\t" + IdCard + "\t" + Name + "\t" + BirthDay.ToString("dd/MM/yyyy") + "\t" + CalculateSalary();
        }
    }
}
