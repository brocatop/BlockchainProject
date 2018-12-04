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

        public BlockchainWindow()
        {
            InitializeComponent();
        }

        public void PopulateBlockchainFields()
        {
            Employee emp1 = help.GetEmployeeAt(1);
            Employee emp2 = help.GetEmployeeAt(2);
            Employee emp3 = help.GetEmployeeAt(3);
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
        }

        private void BlockchainWindow_Load(object sender, EventArgs e)
        {
            PopulateBlockchainFields();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            TempValues();
        }

        private void TempValues()
        {
            Employee TEmp1 = new Employee(int.Parse(Block1ID.Text), Block1Name.Text, Block1Department.Text);
            Employee TEmp2 = new Employee(int.Parse(Block1ID.Text), Block1Name.Text, Block1Department.Text);
            Employee TEmp3 = new Employee(int.Parse(Block1ID.Text), Block1Name.Text, Block1Department.Text);

            Block newblock1 = new Block(DateTime.Parse(Block1TimeStamp.Text), Block1PrevHash.Text, TEmp1, 1);
            Block newblock2 = new Block(DateTime.Parse(Block1TimeStamp.Text), Block1PrevHash.Text, TEmp1, 2);
            Block newblock3 = new Block(DateTime.Parse(Block1TimeStamp.Text), Block1PrevHash.Text, TEmp1, 3);
            CheckHashes(newblock1, newblock2, newblock3);

        }
        private void CheckHashes(Block b1, Block b2, Block b3)
        {
            if (chain.GetBlockAt(1).PrevHash.ToString() == b1.PrevHash.ToString())
            {
                Block1PrevHash.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                Block1PrevHash.ForeColor = System.Drawing.Color.Red;
            }
            if (chain.GetBlockAt(2).PrevHash.ToString() == b2.PrevHash.ToString())
            {
                Block2PrevHash.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                Block2PrevHash.ForeColor = System.Drawing.Color.Red;
            }
            if (chain.GetBlockAt(3).PrevHash.ToString() == b3.PrevHash.ToString())
            {
                Block3PrevHash.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                Block3PrevHash.ForeColor = System.Drawing.Color.Red;
            }
            if (chain.GetBlockAt(1).Hash.ToString() == b1.Hash.ToString())
            {
                Block1Hash.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                Block1Hash.ForeColor = System.Drawing.Color.Red;
            }
            if (chain.GetBlockAt(2).Hash.ToString() == b2.Hash.ToString())
            {
                Block2Hash.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                Block2Hash.ForeColor = System.Drawing.Color.Red;
            }
            if (chain.GetBlockAt(3).Hash.ToString() == b3.Hash.ToString())
            {
                Block3Hash.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                Block3Hash.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            PopulateBlockchainFields();
            TempValues();
        }
    }
}
