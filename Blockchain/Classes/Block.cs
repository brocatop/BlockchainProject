using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain.Classes
{
    public class Block
    {
        public int Index { get; set; }
        public DateTime TimeStamp { get; set; }
        public string PrevHash { get; set; }
        public string Hash { get; set; }
        public string Data { get; set; }

        public Block(DateTime ts, string ph, string d)
        {
            Index = 0;
            TimeStamp = ts;
            PrevHash = ph;
            Data = d;
            // Hash = MakeHash();
        }

        public string CalculateHash()
        {
            SHA256 s = SHA256.Create();

            byte[] input = Encoding.ASCII.GetBytes($"{TimeStamp}-{PrevHash ?? ""}-{Data}");
            byte[] output = s.ComputeHash(input);

            return output.ToString();
        }
    }
}
