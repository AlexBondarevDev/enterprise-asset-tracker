using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using EnterpriseAssetTracker.Scripts;
using MySql.Data.MySqlClient;
using BunifuTextbox = Bunifu.UI.WinForms.BunifuTextbox;



namespace EnterpriseAssetTracker.UsersControlers
{
    /// <summary>
    /// Realization user account management and access level control.
    /// </summary>
    public partial class EditingLogin_UC : UserControl
    {
        #region Component initialization.

        DatabaseHelper dbHelper = new DatabaseHelper();
        bool isSelectEditRecord;
        List<string> fieldsEditedRecord = new List<string>();

        public EditingLogin_UC()
        {
            InitializeComponent();

            RefreshDataInDGV();
        }

        private void LoadDataInMainDataGridView(string query)
        {
            using (var connection = dbHelper.GetConnection())
            {
                connection.Open();

                using (var command = new MySqlCommand(query, connection))
                {
                    using (var adapter = new MySqlDataAdapter(command))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        bunifuMainDataGridView.DataSource = table.DefaultView;
                        bunifuMainDataGridView.Columns[0].Visible = false;
                        bunifuMainDataGridView.Columns[3].Visible = false;
                    }
                }
            }
        }

        private void RefreshDataInDGV()
        {
            if (bunifuAllUsersCheckBox.Checked == true)
            {
                LoadDataInMainDataGridView(dbHelper.selectAuthorization);
            }
            else if (bunifuEconomistCheckBox.Checked == true)
            {
                LoadDataInMainDataGridView($"{dbHelper.selectAuthorization} WHERE `isAdmin` = 0");
            }
            else LoadDataInMainDataGridView($"{dbHelper.selectAuthorization} WHERE `isAdmin` = 1");
        }

        #endregion Component initialization.



        #region Realization of data modification functionality.

        private void BunifuEditRecordButton_Click(object sender, EventArgs e)
        {
            BunifuTextbox.BunifuTextBox[] nameTextBoxesArray = {
                bunifuEditSurnameTextBox,
                bunifuEditNameTextBox,
                bunifuEditFather_nameTextBox,
                bunifuPasswordTextBox
            };

            if (!CheckValidation(nameTextBoxesArray))
            {
                return;
            }

            try
            {
                string newEconomistName = $"{nameTextBoxesArray[0].Text} {nameTextBoxesArray[1].Text} {nameTextBoxesArray[2].Text}";

                dbHelper.openConnection();

                using (var connection = dbHelper.GetConnection())
                {
                    using (var command = new MySqlCommand("UPDATE `authorization` SET `name_economist` = @name_economist, `password` = @password WHERE `authorization`.`id_economist` = @id_editRecord;", connection))
                    {
                        command.Parameters.AddWithValue("@name_economist", newEconomistName);
                        command.Parameters.AddWithValue("@password", nameTextBoxesArray[3].Text);
                        command.Parameters.AddWithValue("@id_editRecord", Convert.ToInt32(fieldsEditedRecord[0]));

                        if (command.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show($"Данные об экономисте изменены!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                            dbHelper.closeConnection();

                            isSelectEditRecord = false;
                            fieldsEditedRecord.Clear();

                            foreach (var textBox in nameTextBoxesArray)
                            {
                                textBox.Text = "";
                            }

                            RefreshDataInDGV();
                            bunifuPages.SelectedTab = StartPage;
                            groupBox.Text = "Операция:";
                        }
                        else
                        {
                            MessageBox.Show("Ошибка изменения данных о МОЛ! Попробуете ещё раз или перезагрузите программу!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dbHelper.closeConnection();
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Связь с базой данных не установлена! Пожалуйста, проверьте соединение с интернетом и перезапустите программу!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isSelectEditRecord = false;
                fieldsEditedRecord.Clear();
                bunifuPages.SelectedTab = StartPage;
                groupBox.Text = "Операция:";
                dbHelper.closeConnection();
            }
        }

        private bool CheckValidation(BunifuTextbox.BunifuTextBox[] nameTextBoxesArray)
        {
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


            string WHERE_IfSelectedEdit = $"WHERE `id_economist`!='{fieldsEditedRecord[0]}'";

            string[] userArray = dbHelper.GetUsers_fieldName(WHERE_IfSelectedEdit).Select(n => n.ToString()).ToArray();

            string newUsername = $"{nameTextBoxesArray[0].Text} {nameTextBoxesArray[1].Text} {nameTextBoxesArray[2].Text}";

            if (userArray.Contains(newUsername))
            {
                MessageBox.Show("Экономист с таким ФИО уже зарегистрирован!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nameTextBoxesArray[0].Focus();
                return false;
            }
            
            return true;
        }

        #endregion Realization of data modification functionality.



        #region Realization of the functionality for data deletion.

        private void BunifuDeleteRecordButton_Click(object sender, EventArgs e)  
        {
            if (!isSelectEditRecord)
            {
                MessageBox.Show("Не выбран сотрудник для удаления!", "Внимание!");
                return;
            }

            if (MessageBox.Show($"Вы уверены, что хотите удалить сотрудника '{fieldsEditedRecord[1]}'?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            try
            {
                using (var connection = dbHelper.GetConnection())
                {
                    connection.Open();

                    using (var command = new MySqlCommand("DELETE FROM `authorization` WHERE `authorization`.`id_economist` = @id_economist;", connection))
                    {
                        command.Parameters.AddWithValue("@id_economist", fieldsEditedRecord[0]);

                        if (command.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Сотрудник удалён!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); 
                            isSelectEditRecord = false;
                            fieldsEditedRecord.Clear();
                            dbHelper.closeConnection();

                            RefreshDataInDGV();
                            bunifuPages.SelectedTab = StartPage;
                            groupBox.Text = "Операция:";
                        }
                        else
                        {
                            MessageBox.Show("Ошибка удаления! Попробуете ещё раз или перезагрузите программу!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dbHelper.closeConnection();
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Связь с базой данных не установлена! Проверьте соединение с сетью и перезапустите программу!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dbHelper.closeConnection();
            }
        }

        private void BunifuPromotionToAdminButton_Click(object sender, EventArgs e)
        {
            if (!isSelectEditRecord)
            {
                MessageBox.Show("Не выбран сотрудник для повышения до администратора!", "Внимание!");
                return;
            }

            if (Convert.ToBoolean(fieldsEditedRecord[3]))
            {
                MessageBox.Show("Сотрудник уже является администратором!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            try
            {
                using (var connection = dbHelper.GetConnection())
                {
                    connection.Open();

                    using (var command = new MySqlCommand("UPDATE `authorization` SET `isAdmin` = 1 WHERE `authorization`.`id_economist` = @id_economist;", connection))
                    {
                        command.Parameters.AddWithValue("@id_economist", fieldsEditedRecord[0]);

                        if (command.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Сотрудник повышен до администратора!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            isSelectEditRecord = false;
                            fieldsEditedRecord.Clear();
                            dbHelper.closeConnection();

                            RefreshDataInDGV();
                        }
                        else
                        {
                            MessageBox.Show("Ошибка! Попробуете ещё раз или перезагрузите программу!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dbHelper.closeConnection();
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Связь с базой данных не установлена! Проверьте соединение с сетью и перезапустите программу!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dbHelper.closeConnection();
            }
        }

        private void BunifuEditCodeButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (var connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    using (var command = new MySqlCommand("UPDATE `access_code` SET `value` = @accessCode WHERE `id_access_code` = 1;", connection))
                    {
                        command.Parameters.AddWithValue("@accessCode", bunifuEditCodeTextBox.Text);

                        if (command.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Код доступа успешно изменён!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            bunifuPages.SelectedTab = StartPage;
                            bunifuEditCodeTextBox.Text = "";
                            groupBox.Text = "Операция:";
                        }
                        else
                        {
                            MessageBox.Show("Ошибка изменения кода доступа! Попробуете ещё раз или перезагрузите программу.", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        }

        #endregion Realization of the functionality for data deletion.



        #region Realization of data modification functionality.

        private void BunifuGoEditRecordPageButton_Click(object sender, EventArgs e)
        {
            if (!isSelectEditRecord)
            {
                MessageBox.Show("Не выбран элемент для изменения!", "Внимание!");
                return;
            }

            bunifuPages.SelectedTab = EditRecordPage;
            groupBox.Text = "Операция: Изменение данных";

            bunifuEditSurnameTextBox.Focus();
            string[] mas = fieldsEditedRecord[1].Split(' ');

            (bunifuEditSurnameTextBox.Text, bunifuEditNameTextBox.Text, bunifuEditFather_nameTextBox.Text) = (mas[0], mas[1], mas[2]);

            bunifuPasswordTextBox.Text = fieldsEditedRecord[2].ToString();
        }

        private void BunifuGoEditCodePageButton_Click(object sender, EventArgs e)
        {
            bunifuPages.SelectedTab = EditCodePage;
            groupBox.Text = "Операция: Изменение кода доступа администратора";

            bunifuEditCodeTextBox.Text = dbHelper.GetAccessСode();
            bunifuEditCodeTextBox.Focus();

            bunifuEditCodeButton.Enabled = false;
        }

        #endregion Realization of data modification functionality.



        #region Realization of auxiliary functionality.

        private void BunifuAllUsersCheckBox_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (bunifuAllUsersCheckBox.Checked == true)
            {
                bunifuAllUsersCheckBox.Enabled = false;
                bunifuEconomistCheckBox.Enabled = true;
                bunifuAdminsCheckBox.Enabled = true;

                bunifuEconomistCheckBox.Checked = false;
                bunifuAdminsCheckBox.Checked = false;

                LoadDataInMainDataGridView(dbHelper.selectAuthorization);

                isSelectEditRecord = false;
                fieldsEditedRecord.Clear();
            }
        }

        private void BunifuEconomistCheckBox_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (bunifuEconomistCheckBox.Checked == true)
            {
                bunifuAllUsersCheckBox.Enabled = true;
                bunifuEconomistCheckBox.Enabled = false;
                bunifuAdminsCheckBox.Enabled = true;

                bunifuAllUsersCheckBox.Checked = false;
                bunifuAdminsCheckBox.Checked = false;

                LoadDataInMainDataGridView($"{dbHelper.selectAuthorization} WHERE `isAdmin` = 0");

                isSelectEditRecord = false;
                fieldsEditedRecord.Clear();
            }
        }

        private void BunifuAdminsCheckBox_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (bunifuAdminsCheckBox.Checked == true)
            {
                bunifuAllUsersCheckBox.Enabled = true;
                bunifuEconomistCheckBox.Enabled = true;
                bunifuAdminsCheckBox.Enabled = false;

                bunifuAllUsersCheckBox.Checked = false;
                bunifuEconomistCheckBox.Checked = false;

                LoadDataInMainDataGridView($"{dbHelper.selectAuthorization} WHERE `isAdmin` = 1");

                isSelectEditRecord = false;
                fieldsEditedRecord.Clear();
            }
        }



        private void BunifuMainDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                isSelectEditRecord = true;
                fieldsEditedRecord.Clear();

                for (int i = 0; i < bunifuMainDataGridView.ColumnCount; i++)
                {
                    fieldsEditedRecord.Add(bunifuMainDataGridView.Rows[e.RowIndex].Cells[i].Value.ToString());
                }

                if (bunifuPages.SelectedTab == EditRecordPage)
                {
                    bunifuEditSurnameTextBox.Focus();
                    string[] mas = fieldsEditedRecord[1].Split(' ');

                    (bunifuEditSurnameTextBox.Text, bunifuEditNameTextBox.Text, bunifuEditFather_nameTextBox.Text) = (mas[0], mas[1], mas[2]);

                    bunifuPasswordTextBox.Text = fieldsEditedRecord[2].ToString();
                }
            }
            catch
            {
                isSelectEditRecord = false;
                fieldsEditedRecord.Clear();
            }
        }

        private void BunifuNameTextBoxes_KeyPress(object sender, KeyPressEventArgs e)
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

        private void BunifuEditCodeTextBox_TextChange(object sender, EventArgs e)
        {
            bunifuEditCodeButton.Enabled = true;
        }

        #endregion Realization of auxiliary functionality.
    }
}