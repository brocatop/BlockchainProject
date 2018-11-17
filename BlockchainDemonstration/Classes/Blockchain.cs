using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainDemonstration.Classes
{
    class Blockchain
    {
        public IList<Block> Chain { get; set; }

        public void InitializeChain()
        {
            Chain = new List<Block>();
        }

        public Block CreateBeginningBlock()
        {
            return new Block(DateTime.Now, null, "{}");
        }

        public void AddBeginningBlock()
        {
            Chain.Add(CreateBeginningBlock());
        }

        public Block GetNewestBlock()
        {
            return Chain[Chain.Count - 1];
        }

        public void AddBlock(Block block)
        {
            Block newestBlock = GetNewestBlock();
            block.Index = newestBlock.Index + 1;
            block.PrevHash = newestBlock.Hash;
            block.Hash = block.MakeHash();
            Chain.Add(block);
        }

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

        public Blockchain ReadBlockChainContents()
        {
            Blockchain bc = new Blockchain();


            return bc;
        }
    }
}
