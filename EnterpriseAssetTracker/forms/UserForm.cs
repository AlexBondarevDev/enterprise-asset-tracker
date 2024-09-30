using System;
using System.Windows.Forms;
using EnterpriseAssetTracker.UsersControlers;



namespace EnterpriseAssetTracker.Forms
{
    public partial class UserForm : Form
    {
        public string User;

        public UserForm()
        {
            InitializeComponent();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            bunifuCustomLabel1.Text += User;
        }



        private void BunifuCloseButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"{User}, Вы уверены, что хотите закончить работу?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }



        /// <summary>
        /// Switch between expanded and collapsed menu positions.
        /// </summary>
        private void MenyButton_Click(object sender, EventArgs e)
        {
            if (menuPanel.Width == 60)
            {
                menuPanel.Visible = false;
                menuPanel.Width = 240;
                panelAnimator2.ShowSync(menuPanel);
                logoAnimator.ShowSync(logo);
            }
            else
            {
                logoAnimator.HideSync(logo);
                menuPanel.Visible = false;
                menuPanel.Width = 60;
                panelAnimator1.ShowSync(menuPanel);
            }
        }



        private void BunifuAnalyticButton_Click(object sender, EventArgs e)
        {
            AnalyticForm analyticForm = new AnalyticForm();
            analyticForm.Show();
        }

        private void BunifuReceiptEAButton_Click(object sender, EventArgs e)
        {
            ReceiptEA_UC receiptEA_UC = new ReceiptEA_UC();
            AddControll(receiptEA_UC);
        }

        private void BunifuRepairEAButton_Click(object sender, EventArgs e)
        {
            RepairEA_UC repairEA_UC = new RepairEA_UC();
            AddControll(repairEA_UC);
        }

        private void BunifuWriteOffEAButton_Click(object sender, EventArgs e)
        {
            WriteOffEA_UC writeOffEA_UC = new WriteOffEA_UC(User);
            AddControll(writeOffEA_UC);
        }

        private void BunifuAssignmentEAButton_Click(object sender, EventArgs e)
        {
            AssignmentEA_UC assignmentEA_UC = new AssignmentEA_UC(User);
            AddControll(assignmentEA_UC);
        }

        /// <summary>
        /// Adding user сontrols to the work panel.
        /// </summary>
        private void AddControll(UserControl userControl)
        {
            workPanel.Controls.Clear();
            userControl.Dock = DockStyle.Fill;
            workPanel.Controls.Add(userControl);
            userControl.BringToFront();
        }
    }
}