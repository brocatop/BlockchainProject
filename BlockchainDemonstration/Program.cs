using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlockchainDemonstration.Classes;

namespace BlockchainDemonstration
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

        }

        public Blockchain GenerateChain()
        {
            Blockchain newChain = new Blockchain();
            newChain.InitializeChain();
            newChain.CreateBeginningBlock();
            newChain.AddBeginningBlock();

            Employee emp;
            Random rnd = new Random();
            for (int i = 0; i < 20; i++)
            {
                
            }



            return newChain;
        }
    }
}
