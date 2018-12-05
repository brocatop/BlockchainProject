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
            Employee blank = new Employee();
            return new Block(DateTime.Now, null, blank, 0);
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

        public List<string> CopyChain(Blockchain c)
        {
            List<string> copiedChain = new List<string>();
            foreach (Block b in c.Chain)
            {
                copiedChain.Add(b.Data.EmployeeID.ToString());
                copiedChain.Add(b.Data.EmployeeName);
                copiedChain.Add(b.Data.Department);
            }
            return copiedChain;
        }

        public bool ValidateChain(string originalChainData, string textBoxData)
        {
            if (!textBoxData.Equals(originalChainData))
            {
                return false;
            }
            return true;
        }

        public Block GetBlockAt(int index)
        {
            return Chain.ElementAt<Block>(index);
        }

    }
}
