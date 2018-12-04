using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainDemonstration.Classes
{
    class Block
    {
        public int Index { get; set; }
        public DateTime TimeStamp { get; set; }
        public string PrevHash { get; set; }
        public string Hash { get; set; }
        public Employee Data { get; set; }

        public Block(DateTime ts, string ph, Employee d, int index)
        {
            Index = index;
            TimeStamp = ts;
            PrevHash = ph;
            Data = d;
            Hash = MakeHash();
        }

        public override string ToString()
        {
            return (Index + " " + TimeStamp + " " + PrevHash + " " + Hash + " " + Data.ToString());
        }
        public string MakeHash()
        {
            SHA256 s = SHA256.Create();
            
            byte[] input = Encoding.UTF8.GetBytes($"{TimeStamp}-{PrevHash ?? ""}-{Data}");
            byte[] output = s.ComputeHash(input);

            return String.Concat(output);
        }
    }
}
