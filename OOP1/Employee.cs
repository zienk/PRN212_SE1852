using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP1
{
    internal class Employee
    {
        #region Nhóm các thuộc tính của Employee
        private int _id;           //instance variables
        private string _name;
        private string _email;
        private string _phone;
        #endregion
        #region Nhóm Constructors của Employee
        public Employee()
        {

        }

        public Employee(int id, string name, string email, string phone) //local variables
        {
            _id = id;
            _name = name;
            Email = email;
            Phone = phone;
        }
        #endregion
        #region Nhóm các phương thức của Employee
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        #endregion
        public void PrintInfo()
        {
            Console.WriteLine($"{_id}\t{_name}\t{_email}\t{_phone}");
        }

        public override string ToString()
        {
            string msg = $"{_id}\t{_name}\t{_email}\t{_phone}";
            return msg;
        }

    }
}
