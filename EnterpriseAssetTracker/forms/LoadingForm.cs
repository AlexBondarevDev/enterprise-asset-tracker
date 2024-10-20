using System;
using System.Windows.Forms;



namespace EnterpriseAssetTracker.Forms
{
    /// <summary>
    /// Serves as the aplication loading form.
    /// </summary>
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();
        }

        private void Timer_Tick(object sender, EventArgs e)
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