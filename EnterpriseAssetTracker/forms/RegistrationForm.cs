using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EnterpriseAssetTracker.Scripts;
using MySql.Data.MySqlClient;
using BunifuTextbox = Bunifu.UI.WinForms.BunifuTextbox;



namespace EnterpriseAssetTracker.Forms
{
    /// <summary>
    /// Serves for registering new users in the system.
    /// </summary>
    public partial class RegistrationForm : Form
    {
        #region Component initialization.

        DatabaseHelper dbHelper = new DatabaseHelper();

        public RegistrationForm()
        {
            InitializeComponent();
            bunifuSurnameTextBox.Focus();
        }

        #endregion Component initialization.



        private void BunifuRegistrationButton_Click(object sender, EventArgs e)
        {
            string AccessСode = dbHelper.GetAccessСode();
            if (AccessСode == null) return;

            if (!ValidityСheck(AccessСode)) return;

            string username = $"{bunifuSurnameTextBox.Text} {bunifuNameTextBox.Text} {bunifuFatherNameTextBox.Text}";

            try
            {
                dbHelper.openConnection();

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

        private bool ValidityСheck(string AccessCode)
        {
            if (bunifuAccessСodeTextBox.Text != AccessCode)
            {
                MessageBox.Show("Неверный код доступа!!!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bunifuAccessСodeTextBox.Focus();
                return false;
            }

            BunifuTextbox.BunifuTextBox[] nameTextBoxesArray = {
                bunifuSurnameTextBox,
                bunifuNameTextBox,
                bunifuFatherNameTextBox,
                bunifuPasswordTextBox
            };

            var emptyTextBox = nameTextBoxesArray.FirstOrDefault(textField => string.IsNullOrEmpty(textField.Text));
            if (emptyTextBox != null)
            {
                MessageBox.Show("Пожалуйста, введите все данные!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                emptyTextBox.Focus();
                return false;
            }

            if (bunifuPasswordTextBox.TextLength < 4 || bunifuPasswordTextBox.TextLength > 8)
            {
                string message = bunifuPasswordTextBox.TextLength < 4
                    ? "Ваш пароль короче минимального. Пожалуйста, введите минимум 4 символа."
                    : "Ваш пароль длиннее максимального. Пожалуйста, введите максимум 8 символов.";

                MessageBox.Show(message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bunifuPasswordTextBox.Focus();
                return false;
            }

            string newUsername = $"{bunifuSurnameTextBox.Text} {bunifuNameTextBox.Text} {bunifuFatherNameTextBox.Text}";
            string[] userArray = dbHelper.GetUsers_fieldName("").Select(n => n.ToString()).ToArray();

            if (userArray.Contains(newUsername))
            {
                MessageBox.Show("Экономист с таким ФИО уже зарегистрирован!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bunifuSurnameTextBox.Focus();
                return false;
            }

            return true;
        }



        private void BunifuValidationNameTextBoxes_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox == null)
            {
                return;
            }

            char key = e.KeyChar;
            e.Handled = true;

            if (Char.IsLetter(key) || Char.IsControl(key))
            {
                if (textBox.Text.Length == 0 || textBox.SelectionLength == textBox.Text.Length)
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
            bunifuRegistrationButton.Focus();
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
            bunifuRegistrationButton.Focus();
        }



        private void BunifuFormCloseButton_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }
    }
}