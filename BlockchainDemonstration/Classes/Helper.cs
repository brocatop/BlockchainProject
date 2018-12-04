using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainDemonstration.Classes
{
    class Helper
    {
        List<Employee> employees = new List<Employee>();
        public Blockchain GenerateChain()
        {
            Blockchain newChain = new Blockchain();
            newChain.InitializeChain();
            newChain.CreateBeginningBlock();
            newChain.AddBeginningBlock();

            Employee emp = new Employee();
            employees = emp.CreateListofEmployees();
            Random rnd = new Random();
            int i = 1;
            foreach (Employee e in employees)
            {
                int index = rnd.Next(employees.Count);
                newChain.AddBlock(new Block(DateTime.Now, "prevhash", employees[index], i));
                i++;
            }
            return newChain;
        }

        public Employee GetEmployeeAt(int i)
        {
            return employees.ElementAt<Employee>(i);
        }

        public void ReadBlockChainContents(Blockchain chainRead)
        {

            foreach (Block e in chainRead.Chain)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
