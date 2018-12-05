using BlockchainDemonstration.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockchainDemonstration
{
    public partial class BlockchainWindow : Form
    {
        private static Helper help = new Helper();
        Blockchain chain = help.GenerateChain();
        Blockchain chainCopy = new Blockchain();

        public BlockchainWindow()
        {
            InitializeComponent();
        }


        private void BlockchainWindow_Load(object sender, EventArgs e)
        {
            PopulateBlockchainFields();
        }

        public void PopulateBlockchainFields()
        {

            Employee emp1 = help.GetEmployeeAt(chain.GetBlockAt(1).Data.EmployeeID);
            Employee emp2 = help.GetEmployeeAt(chain.GetBlockAt(2).Data.EmployeeID);
            Employee emp3 = help.GetEmployeeAt(chain.GetBlockAt(3).Data.EmployeeID);

            Block1ID.Text = emp1.EmployeeID.ToString();
            Block2ID.Text = emp2.EmployeeID.ToString();
            Block3ID.Text = emp3.EmployeeID.ToString();

            Block1Name.Text = emp1.EmployeeName;
            Block2Name.Text = emp2.EmployeeName;
            Block3Name.Text = emp3.EmployeeName;

            Block1Department.Text = emp1.Department;
            Block2Department.Text = emp2.Department;
            Block3Department.Text = emp3.Department;

            Block1PrevHash.Text = chain.GetBlockAt(1).PrevHash.ToString();
            Block2PrevHash.Text = chain.GetBlockAt(2).PrevHash.ToString();
            Block3PrevHash.Text = chain.GetBlockAt(3).PrevHash.ToString();

            Block1Hash.Text = chain.GetBlockAt(1).Hash.ToString();
            Block2Hash.Text = chain.GetBlockAt(2).Hash.ToString();
            Block3Hash.Text = chain.GetBlockAt(3).Hash.ToString();

            Block1TimeStamp.Text = chain.GetBlockAt(1).TimeStamp.ToString();
            Block2TimeStamp.Text = chain.GetBlockAt(2).TimeStamp.ToString();
            Block3TimeStamp.Text = chain.GetBlockAt(3).TimeStamp.ToString();

            chainCopy.CopyChain(chain);
        }


        private void SaveButton_Click(object sender, EventArgs e)
        {
            CheckForChanges(chain);
        }

        private void CheckForChanges(Blockchain CheckChain)
        {
            bool firstBlockchain = true;
            bool secBlockchain = true;
            bool thirdBlockchain = true;
          //  Blockchain b = new Blockchain();
            Employee TEmp1 = new Employee(int.Parse(Block1ID.Text), Block1Name.Text, Block1Department.Text);
            Employee TEmp2 = new Employee(int.Parse(Block2ID.Text), Block2Name.Text, Block2Department.Text);
            Employee TEmp3 = new Employee(int.Parse(Block3ID.Text), Block3Name.Text, Block3Department.Text);

            Block newblock1 = new Block(DateTime.Parse(Block1TimeStamp.Text), Block1PrevHash.Text, TEmp1, 1);
            Block newblock2 = new Block(DateTime.Parse(Block2TimeStamp.Text), Block2PrevHash.Text, TEmp2, 2);
            Block newblock3 = new Block(DateTime.Parse(Block3TimeStamp.Text), Block3PrevHash.Text, TEmp3, 3);

            List<Block> testChain = new List<Block> { newblock1, newblock2, newblock3 };
           // List<String> chainStrings = b.CopyChain(chain);
           // String[] textboxes = new String[] { Block1ID.Text, Block1Name.Text, Block1Department.Text, Block2ID.Text, Block2Name.Text, Block2Department.Text, Block3ID.Text, Block3Name.Text, Block3Department.Text };
            int i = 1;

            foreach (Block block in testChain)
            {
                if (CheckChain.GetBlockAt(i+1).Data.EmployeeID != block.Data.EmployeeID || CheckChain.GetBlockAt(i+1).Data.EmployeeName != block.Data.EmployeeName || CheckChain.GetBlockAt(i+1).Data.Department != block.Data.Department)
                {
                    if (i == 1)
                    {
                        firstBlockchain = false;
                        secBlockchain = false;
                        thirdBlockchain = false;
                    }
                    else if (i == 2)
                    {
                        secBlockchain = false;
                        thirdBlockchain = false;
                    }
                    else if (i == 3)
                    {
                        thirdBlockchain = false;
                    }
                }
                i++;

            }

            if (firstBlockchain == false)
            {
                Block1Hash.ForeColor = Color.Red;
            }
            if (secBlockchain == false)
            {
                Block2Hash.ForeColor = Color.Red;
                Block2PrevHash.ForeColor = Color.Red;
            }
            if (thirdBlockchain == false)
            {
                Block3Hash.ForeColor = Color.Red;
                Block3PrevHash.ForeColor = Color.Red;
            }

           
        }


        private void ResetButton_Click(object sender, EventArgs e)
        {
            PopulateBlockchainFields();

            Block1ID.ForeColor = Color.Black;
            Block2ID.ForeColor = Color.Black;
            Block3ID.ForeColor = Color.Black;

            Block1Name.ForeColor = Color.Black;
            Block2Name.ForeColor = Color.Black;
            Block3Name.ForeColor = Color.Black;

            Block1Department.ForeColor = Color.Black;
            Block2Department.ForeColor = Color.Black;
            Block3Department.ForeColor = Color.Black;

            Block1PrevHash.ForeColor = Color.Black;
            Block2PrevHash.ForeColor = Color.Black;
            Block3PrevHash.ForeColor = Color.Black;

            Block1Hash.ForeColor = Color.Black;
            Block2Hash.ForeColor = Color.Black;
            Block3Hash.ForeColor = Color.Black;

            Block1TimeStamp.ForeColor = Color.Black;
            Block2TimeStamp.ForeColor = Color.Black;
            Block3TimeStamp.ForeColor = Color.Black;

            Block1PrevHash.Text = chain.GetBlockAt(1).PrevHash.ToString();
            Block2PrevHash.Text = chain.GetBlockAt(2).PrevHash.ToString();
            Block3PrevHash.Text = chain.GetBlockAt(3).PrevHash.ToString();

            Block1Hash.Text = chain.GetBlockAt(1).Hash.ToString();
            Block2Hash.Text = chain.GetBlockAt(2).Hash.ToString();
            Block3Hash.Text = chain.GetBlockAt(3).Hash.ToString();
        }
    }
}
