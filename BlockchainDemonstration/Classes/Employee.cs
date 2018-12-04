using System.Collections.Generic;

namespace BlockchainDemonstration.Classes
{
    class Employee
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Department { get; set; }

        public Employee()
        {

        }

        public Employee (int id, string name, string department)
        {
            EmployeeID = id;
            EmployeeName = name;
            Department = department;
        }

        public override string ToString()
        {
            return (EmployeeID + " " + EmployeeName + " " + Department);
        }


        public List<Employee> CreateListofEmployees()
        {
            Employee Al = new Employee(1, "Al", "Accounting");
            Employee Allen = new Employee(2, "Allen", "HR");
            Employee TaylaAnn = new Employee(3, "Tayla-Ann", "Customer Service");
            Employee Seth = new Employee(4, "Seth Rogen", "Customer Service");
            Employee George = new Employee(5, "George of the Jungle", "Physical Plant");
            Employee Sally = new Employee(6, "Sally", "Management");
            List<Employee> employees = new List<Employee> { Al, Allen, TaylaAnn, Seth, George, Sally};

            return employees;
        }
    }
}
