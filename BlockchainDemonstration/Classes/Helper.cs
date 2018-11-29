using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainDemonstration.Classes
{
    class Helper
    {
        public Blockchain GenerateChain()
        {
            Blockchain newChain = new Blockchain();
            newChain.InitializeChain();
            newChain.CreateBeginningBlock();
            newChain.AddBeginningBlock();

            Employee emp = new Employee();
            List<Employee> employees = emp.GetEmployees();
            Random rnd = new Random();

            foreach (Employee e in employees)
            {
                int index = rnd.Next(employees.Count);

                newChain.AddBlock(new Block(DateTime.Now, "prevhash", employees[index].ToString()));
            }
            return newChain;
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
