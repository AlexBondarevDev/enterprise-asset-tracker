using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EnterpriseAssetTracker.Scripts;
using MySql.Data.MySqlClient;

namespace EnterpriseAssetTracker.Forms
{
    public partial class RegisteredForm : Form
    {
        DatabaseHelper dbHelper = new DatabaseHelper();

        public RegisteredForm()
        {
            InitializeComponent();
            bunifuSurnameTextBox.Focus();
        }

        private void BunifuRegisteredButton_Click(object sender, EventArgs e)
        {
            string AccessСode = GetAccessСode();
            if (AccessСode == null) return;

            if (!ValidityСheck(AccessСode)) return;

            string username = $"{bunifuSurnameTextBox.Text} {bunifuNameTextBox.Text} {bunifuFatherNameTextBox.Text}";

            dbHelper.openConnection();
            try
            {
                using (var connection = dbHelper.GetConnection())
                {
                    using (var command = new MySqlCommand("INSERT INTO `authorization` (`name_economist`, `password`, `isAdmin`) VALUES (@name_economist, @password, @isAdmin)", connection))
                    {
                        command.Parameters.AddWithValue("@name_economist", username);
                        command.Parameters.AddWithValue("@password", bunifuPasswordTextBox.Text);
                        command.Parameters.AddWithValue("@isAdmin", false);

                        if (command.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show($"Экономист {username} успешно зарегистрирован!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            MessageBox.Show("Ошибка регистрации! Попробуете ещё раз или перезагрузите программу!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Связь с базой данных не установлена! Проверьте соединение с сетью и перезапустите программу!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbHelper.closeConnection();
            }

            bunifuSurnameTextBox.Text = "";
            bunifuNameTextBox.Text = "";
            bunifuFatherNameTextBox.Text = "";
            bunifuPasswordTextBox.Text = "";
            bunifuAccessСodeTextBox.Text = "";
            bunifuSurnameTextBox.Focus();
        }

        /// <summary>
        /// Returns the access code that is required to perform Administrator level actions.
        /// </summary>
        public string GetAccessСode()
        {
            string AccessСode = null;
            string query = "SELECT value FROM access_code";

            try
            {
                using (var connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    using (var command = new MySqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                AccessСode = reader.GetString(0);
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch
            {
                MessageBox.Show("Связь с базой данных не установлена! Проверьте соединение с сетью и перезапустите программу!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return AccessСode;
        }

        public bool ValidityСheck(string AccessСode)
        {
            if (bunifuAccessСodeTextBox.Text != AccessСode)
            {
                MessageBox.Show("Неверный код доступа!!!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bunifuAccessСodeTextBox.Focus();
                return false;
            }

            if (bunifuSurnameTextBox.Text == ""
                || bunifuNameTextBox.Text == ""
                || bunifuFatherNameTextBox.Text == ""
                || bunifuPasswordTextBox.Text == ""
                || bunifuAccessСodeTextBox.Text == "")
            {
                MessageBox.Show("Пожалуйста, введите все данные!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (bunifuSurnameTextBox.Text == "")
                {
                    bunifuSurnameTextBox.Focus();
                }
                else if (bunifuNameTextBox.Text == "")
                {
                    bunifuNameTextBox.Focus();
                }
                else if (bunifuFatherNameTextBox.Text == "")
                {
                    bunifuFatherNameTextBox.Focus();
                }
                else if (bunifuPasswordTextBox.Text == "")
                {
                    bunifuPasswordTextBox.Focus();
                }
                else if (bunifuAccessСodeTextBox.Text == "")
                {
                    bunifuAccessСodeTextBox.Focus();
                }
                return false;
            }

            if (bunifuPasswordTextBox.TextLength < 4)
            {
                MessageBox.Show("Ваш пароль короче минимального. Пожалуйста, введите минимум 4 символа.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bunifuPasswordTextBox.Focus();
                return false;
            }

            if (bunifuPasswordTextBox.TextLength > 8)
            {
                MessageBox.Show("Ваш пароль длиннее максимального. Пожалуйста, введите максимум 8 символов.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bunifuPasswordTextBox.Focus();
                return false;
            }


            string newUsername = $"{bunifuSurnameTextBox.Text} {bunifuNameTextBox.Text} {bunifuFatherNameTextBox.Text}";
            string[] userArray = GetUsers().Select(n => n.ToString()).ToArray();

            if (userArray.Contains(newUsername))
            {
                MessageBox.Show("Экономист с таким ФИО уже зарегистрирован!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bunifuSurnameTextBox.Focus();
                return false;
            }

            return true;
        }

        public List<string> GetUsers()
        {
            List<string> userList = dbHelper.GetUsers_fieldName();

            return userList ?? new List<string>();
        }

        private void BunifuGeneratePassButton_Click(object sender, EventArgs e)
        {
            const string passwordAlphabet = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Random random = new Random();
            StringBuilder randomPassword = new StringBuilder();

            for (int i = 0; i < 8; i++)
            {
                randomPassword.Append(passwordAlphabet[random.Next(0, passwordAlphabet.Length)]);
            }

            bunifuPasswordTextBox.Text = randomPassword.ToString();
            bunifuRegisteredButton.Focus();
        }

        private void BunifuClearPassButton_Click(object sender, EventArgs e)
        {
            bunifuPasswordTextBox.Text = "";
            bunifuPasswordTextBox.Focus();
        }

        private void BunifuCopyPassButton_Click(object sender, EventArgs e)
        {
            if (bunifuPasswordTextBox.Text == "" || bunifuPasswordTextBox.TextLength < 4 || bunifuPasswordTextBox.TextLength > 8)
            {
                MessageBox.Show("Пароль не введён либо введено недопустимое колличество символов!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Clipboard.SetText("Пароль от учётной записи пользователя: " + bunifuPasswordTextBox.Text);
            MessageBox.Show("Пароль сохранён в буфер обмена!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            bunifuRegisteredButton.Focus();
        }

        private void BunifuCloseButton_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        private void BunifuSurnameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char key = e.KeyChar;
            e.Handled = true;
            if (Char.IsLetter(key) || Char.IsControl(key))
            {
                if (bunifuSurnameTextBox.Text.Length == 0)
                {
                    e.KeyChar = char.ToUpper(e.KeyChar);
                }
                else
                {
                    e.KeyChar = char.ToLower(e.KeyChar);
                }
                e.Handled = false;
            }
        }

        private void BunifuNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char key = e.KeyChar;
            e.Handled = true;
            if (Char.IsLetter(key) || Char.IsControl(key))
            {
                if (bunifuNameTextBox.Text.Length == 0)
                {
                    e.KeyChar = char.ToUpper(e.KeyChar);
                }
                else
                {
                    e.KeyChar = char.ToLower(e.KeyChar);
                }
                e.Handled = false;
            }
        }

        private void BunifuFatherNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char key = e.KeyChar;
            e.Handled = true;
            if (Char.IsLetter(key) || Char.IsControl(key))
            {
                if (bunifuFatherNameTextBox.Text.Length == 0)
                {
                    e.KeyChar = char.ToUpper(e.KeyChar);
                }
                else
                {
                    e.KeyChar = char.ToLower(e.KeyChar);
                }
                e.Handled = false;
            }
        }
    }
}