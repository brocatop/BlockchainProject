using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blockchain.Classes
{
    public class Blockchain
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
            block.Hash = block.CalculateHash();
            Chain.Add(block);
        }
    }
}
