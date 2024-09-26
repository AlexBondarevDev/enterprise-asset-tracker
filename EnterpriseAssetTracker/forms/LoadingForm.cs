using System;
using System.Windows.Forms;



namespace EnterpriseAssetTracker.Forms
{
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();
        }


        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (bunifuCircleProgress.Value == 100)
            {
                timer.Enabled = false;
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                return;
            }
            bunifuCircleProgress.Value += 2;
        }
    }
}