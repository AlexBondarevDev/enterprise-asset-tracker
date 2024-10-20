using System;
using System.Windows.Forms;
using EnterpriseAssetTracker.UsersControlers;



namespace EnterpriseAssetTracker.Forms
{
    /// <summary>
    /// Serves as the main working form for users with the "Administrator" access level.
    /// </summary>
    public partial class AdminForm : Form
    {
        #region Component initialization.

        public string User;

        public AdminForm()
        {
            InitializeComponent();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            bunifuCustomLabel1.Text += User;
        }

        #endregion Component initialization.



        #region Implementation of section selection for work.

        private void BunifuDeletingDataEAButton_Click(object sender, EventArgs e)
        {
            DeletingDataEA_UC deletingDataEA_UC = new DeletingDataEA_UC();
            AddControll(deletingDataEA_UC);
        }

        private void BunifuDirectoriesButton_Click(object sender, EventArgs e)
        {
            Directories_UC directories_UC = new Directories_UC();
            AddControll(directories_UC);
        }

        private void BunifuAssetCustodianButton_Click(object sender, EventArgs e)
        {
            AssetCustodian_UC assetCustodian_UC = new AssetCustodian_UC();
            AddControll(assetCustodian_UC);
        }

        private void BunifuEditingLoginButton_Click(object sender, EventArgs e)
        {
            EditingLogin_UC editingLogin_UC = new EditingLogin_UC();
            AddControll(editingLogin_UC);
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

        #endregion Implementation of section selection for work.



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

        private void BunifuFormCloseButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"{User}, Вы уверены, что хотите закончить работу?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}