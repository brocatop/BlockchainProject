using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainDemonstration.Classes
{
    class Employee
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Department { get; set; }

        public Employee (int id, string name, string department)
        {
            EmployeeID = id;
            EmployeeName = name;
            Department = department;
        }

        //create a method to generate these, but somewhere else
        public Employee Al = new Employee(1, "Al", "Accounting");
        public Employee Allen = new Employee(2, "Allen", "HR");
        public Employee TaylaAnn = new Employee(3, "Tayla-Ann", "Customer Service");
        public Employee Seth = new Employee(4, "Seth Rogen", "Customer Service");
        public Employee George = new Employee(5, "George of the Jungle", "Physical Plant");
        public Employee Sally = new Employee(6, "Sally", "Management");
    }
}
