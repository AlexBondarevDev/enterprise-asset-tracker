using EnterpriseAssetTracker.Scripts;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;



namespace EnterpriseAssetTracker.Forms
{
    public partial class LoginForm : Form
    {
        DatabaseHelper dbHelper = new DatabaseHelper();

        public LoginForm()
        {
            InitializeComponent();
            string[] userArray = GetUsers().Select(n => n.ToString()).ToArray();
            bunifuUserDropdown.Items.AddRange(userArray);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            bunifuUserDropdown.Text = null;
        }

        /// <summary>
        /// Getting a list of users from the database.
        /// </summary>
        private List<string> GetUsers()
        {
            List<string> userList = dbHelper.GetUsers_fieldName();

            if (userList == null)
            {
                bunifuLoginButton.Visible = false;
                bunifuRegisteredButton.Visible = false;
                userList = new List<string>();
            }

            return userList;
        }

        

        private void BunifuLoginButton_Click(object sender, EventArgs e)
        {
            if (bunifuUserDropdown.Text == null)
            {
                MessageBox.Show("Пожалуйста, выберите сотрудника!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bunifuPasswordTextBox.Text = "";
                return;
            }
            if (bunifuPasswordTextBox.TextLength < 1)
            {
                MessageBox.Show("Пожалуйста, введите пароль!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            PasswordVerification(bunifuUserDropdown.Text, bunifuPasswordTextBox.Text);
            bunifuPasswordTextBox.Text = "";
        }

        /// <summary>
        /// Checking the password and going to the User/Admin forms.
        /// </summary>
        private void PasswordVerification(string username, string password)
        {
            string query = "SELECT isAdmin FROM authorization WHERE name_economist = @username AND password = @password";

            try
            {
                using (var connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                bool isAdmin = Convert.ToBoolean(reader["isAdmin"]);

                                if (isAdmin)
                                {
                                    AdminForm adminForm = new AdminForm();
                                    adminForm.User = username;
                                    adminForm.Show();
                                }
                                else
                                {
                                    UserForm userForm = new UserForm();
                                    userForm.User = username;
                                    userForm.Show();
                                }

                                bunifuUserDropdown.Text = null;
                            }
                            else
                            {
                                MessageBox.Show("Неверный пароль! В доступе отказано!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Связь с базой данных не установлена! Проверьте соединение с сетью и перезапустите программу!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void BunifuRegisteredButton_Click(object sender, EventArgs e)
        {
            RegisteredForm registeredForm = new RegisteredForm();
            registeredForm.Show();
            this.Close();
        }


        private void BunifuCloseButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите выйти?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result.ToString() == "Yes")
            {
                Application.Exit();
            }
        }



        private void BunifuUserDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            bunifuPasswordTextBox.Focus();
        }
    }
}