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
    public partial class AssetCustodian_UC : UserControl
    {
        DatabaseHelper dbHelper = new DatabaseHelper();
        bool isSelectEditRecord;
        List<string> fieldsEditedRecord = new List<string>();

        public AssetCustodian_UC()
        {
            InitializeComponent();

            LoadDataInMainDataGridView(dbHelper.selectAsset_custodian);

            LoadDataInDropdowns();
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
                        bunifuMainDataGridView.Columns[1].Visible = false;
                    }
                }
            }
        }

        private void LoadDataInDropdowns()
        {
            string[] positionsNamesArray = dbHelper.GetPositions_fieldName("").Select(n => n.ToString()).ToArray();

            bunifuAddPageDropdown.Items.AddRange(positionsNamesArray);
            bunifuAddPageDropdown.SelectedIndex = 1;
            bunifuEditPageDropdown.Items.AddRange(positionsNamesArray);
            bunifuFiltrationDropdown.Items.AddRange(positionsNamesArray);
            bunifuFiltrationDropdown.SelectedIndex = 1;
        }


        private void BunifuAddButton_Click(object sender, EventArgs e)
        {
            BunifuTextbox.BunifuTextBox[] nameTextBoxesArray = {
                bunifuAddSurnameTextBox,
                bunifuAddNameTextBox,
                bunifuAddFather_nameTextBox
            };

            if (!CheckValidation(nameTextBoxesArray))
            {
                return;
            }

            try
            {
                int positionId = dbHelper.GetIdByName_Positions(bunifuAddPageDropdown.Text);
                string newCustodianName = $"{nameTextBoxesArray[0].Text} {nameTextBoxesArray[1].Text} {nameTextBoxesArray[2].Text}";

                dbHelper.openConnection();

                using (var connection = dbHelper.GetConnection())
                {
                    using (var command = new MySqlCommand("INSERT INTO `asset_custodian` (`id_position`, `surname`, `name`, `father_name`) VALUES (@id_position, @surname, @name, @father_name)", connection))
                    {
                        command.Parameters.AddWithValue("@id_position", positionId);
                        command.Parameters.AddWithValue("@surname", bunifuAddSurnameTextBox.Text);
                        command.Parameters.AddWithValue("@name", bunifuAddNameTextBox.Text);
                        command.Parameters.AddWithValue("@father_name", bunifuAddFather_nameTextBox.Text);

                        if (command.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show($"Экономист {newCustodianName} успешно зарегистрирован!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                            foreach (var textBox in nameTextBoxesArray)
                            {
                                textBox.Text = "";
                            }

                            dbHelper.closeConnection();

                            LoadDataInMainDataGridView(dbHelper.selectAsset_custodian);
                        }
                        else
                        {
                            MessageBox.Show("Ошибка регистрации! Попробуете ещё раз или перезагрузите программу!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private bool CheckValidation(BunifuTextbox.BunifuTextBox[] nameTextBoxesArray)
        {
            var emptyTextBox = nameTextBoxesArray.FirstOrDefault(textField => string.IsNullOrEmpty(textField.Text));
            if (emptyTextBox != null)
            {
                MessageBox.Show("Пожалуйста, введите все данные!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                emptyTextBox.Focus();
                return false;
            }


            if (bunifuPages.SelectedTab == AddPage && bunifuAddPageDropdown.Text == "Директор")
            {
                MessageBox.Show("Нельзя назначить сотрудника на выбранную должность!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (bunifuPages.SelectedTab == EditPage && bunifuEditPageDropdown.Text == "Директор")
            {
                MessageBox.Show("Нельзя изменить назначение сотрудника на выбранную должность!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            string WHERE_IfSelectedEdit = bunifuPages.SelectedTab == EditPage ? $"WHERE `id_asset_custodian`!='{fieldsEditedRecord[0]}';" : "";
            
            string[] userArray = dbHelper.GetAssetCustodian_fieldName(WHERE_IfSelectedEdit).Select(n => n.ToString()).ToArray();

            string newCustodianName = $"{nameTextBoxesArray[0].Text} {nameTextBoxesArray[1].Text} {nameTextBoxesArray[2].Text}";

            if (userArray.Contains(newCustodianName))
            {
                MessageBox.Show("Сотрудник с таким ФИО уже зарегистрирован!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void BunifuMainDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                isSelectEditRecord = true;
                fieldsEditedRecord.Clear();

                bunifuEditSurnameTextBox.Text = bunifuMainDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                bunifuEditNameTextBox.Text = bunifuMainDataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                bunifuEditFather_nameTextBox.Text = bunifuMainDataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
                bunifuEditPageDropdown.Text = bunifuMainDataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();

                if (bunifuEditPageDropdown.Text == "Директор")
                {
                    bunifuEditPageDropdown.Enabled = false;
                }
                else bunifuEditPageDropdown.Enabled = true;


                for (int i = 0; i < bunifuMainDataGridView.ColumnCount; i++)
                {
                    fieldsEditedRecord.Add(bunifuMainDataGridView.Rows[e.RowIndex].Cells[i].Value.ToString());
                }
            }
            catch
            {
                isSelectEditRecord = false;
                fieldsEditedRecord.Clear();
            }
        }

        private void BunifuEditButton_Click(object sender, EventArgs e)
        {
            BunifuTextbox.BunifuTextBox[] nameTextBoxesArray = {
                bunifuEditSurnameTextBox,
                bunifuEditNameTextBox,
                bunifuEditFather_nameTextBox
            };

            if (!CheckValidation(nameTextBoxesArray))
            {
                return;
            }

            try
            {
                int positionId = dbHelper.GetIdByName_Positions(bunifuEditPageDropdown.Text);
                string newCustodianName = $"{nameTextBoxesArray[0].Text} {nameTextBoxesArray[1].Text} {nameTextBoxesArray[2].Text}";

                dbHelper.openConnection();

                using (var connection = dbHelper.GetConnection())
                {
                    using (var command = new MySqlCommand("UPDATE `asset_custodian` SET `id_position` = @id_position, `surname` = @surname, `name` = @name, `father_name` = @father_name WHERE `asset_custodian`.`id_asset_custodian` = @editRecordId;", connection))
                    {
                        command.Parameters.AddWithValue("@id_position", positionId);
                        command.Parameters.AddWithValue("@surname", bunifuEditSurnameTextBox.Text);
                        command.Parameters.AddWithValue("@name", bunifuEditNameTextBox.Text);
                        command.Parameters.AddWithValue("@father_name", bunifuEditFather_nameTextBox.Text);
                        command.Parameters.AddWithValue("@editRecordId", Convert.ToInt32(fieldsEditedRecord[0]));


                        if (command.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show($"Данные о материально ответственном лице изменены!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            
                            dbHelper.closeConnection();

                            isSelectEditRecord = false;
                            fieldsEditedRecord.Clear();
                            bunifuPages.SelectedTab = StartPage;

                            foreach (var textBox in nameTextBoxesArray)
                            {
                                textBox.Text = "";
                            }

                            LoadDataInMainDataGridView(dbHelper.selectAsset_custodian);
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
                dbHelper.closeConnection();
            }
        }
        
        private void BunifuDeleteButton_Click(object sender, EventArgs e)
        {
            if (!isSelectEditRecord)
            {
                MessageBox.Show("Не выбрано МОЛ для удаления!", "Внимание!");
                return;
            }

            if (fieldsEditedRecord[5] == "Директор")
            {
                MessageBox.Show("Нельзя удалить базовую запись!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string fullName_DelAssetCustodian = fieldsEditedRecord[2] + " " + fieldsEditedRecord[3] + " " + fieldsEditedRecord[4];

            DialogResult result = MessageBox.Show($"Вы уверены, что хотите удалить сотрудника '" + fullName_DelAssetCustodian + "'?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Information); ;
            if (result.ToString() == "No")
            {
                return;
            }


            try
            {
                dbHelper.openConnection();

                using (var connection = dbHelper.GetConnection())
                {
                    using (var command = new MySqlCommand("DELETE FROM `asset_custodian` WHERE `asset_custodian`.`id_asset_custodian` = @editRecordId;", connection))
                    {
                        command.Parameters.AddWithValue("@editRecordId", Convert.ToInt32(fieldsEditedRecord[0]));

                        if (command.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show($"Материально ответственное лицо удалёно! Ответственность за ОС, закреплённые за материально ответственным лицом '{fullName_DelAssetCustodian}' перекладывается на директора организации!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                            dbHelper.closeConnection();

                            isSelectEditRecord = false;
                            fieldsEditedRecord.Clear();
                            bunifuPages.SelectedTab = StartPage;

                            LoadDataInMainDataGridView(dbHelper.selectAsset_custodian);
                        }
                        else
                        {
                            MessageBox.Show("Ошибка удаления данных о МОЛ! Попробуете ещё раз или перезагрузите программу!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                dbHelper.closeConnection();
            }
        }


        private void BunifuFiltrationButton_Click(object sender, EventArgs e)
        {
            try
            {
                LoadDataInMainDataGridView(dbHelper.selectAsset_custodian + $" WHERE `positions`.`name` = '{bunifuFiltrationDropdown.Text}';");
            }
            catch
            {
                MessageBox.Show("Связь с базой данных не установлена! Пожалуйста, проверьте соединение с интернетом и перезапустите программу!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BunifuSearchTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            for (int i = 0; i < bunifuMainDataGridView.RowCount; i++)
            {
                bunifuMainDataGridView.Rows[i].Selected = false;
                for (int j = 0; j < bunifuMainDataGridView.ColumnCount; j++)
                    if (bunifuMainDataGridView.Rows[i].Cells[j].Value != null)
                        if (bunifuMainDataGridView.Rows[i].Cells[j].Value.ToString().ToLower().Contains(bunifuSearchTextBox.Text.ToLower()))
                        {
                            bunifuMainDataGridView.Rows[i].Selected = true;
                            break;
                        }
            }
            if (bunifuSearchTextBox.Text == "")
            {
                bunifuMainDataGridView.ClearSelection();
            }
        }



        private void BunifuGoAddPageButton_Click(object sender, EventArgs e)
        {
            bunifuPages.SelectedTab = AddPage;
            groupBox.Text = "Операция: Добавление МОЛ";
            bunifuAddSurnameTextBox.Focus();
        }

        private void BunifuGoEditPageButton_Click(object sender, EventArgs e)
        {
            if (!isSelectEditRecord)
            {
                MessageBox.Show("Не выбран элемент для изменения!", "Внимание!");
                return;
            }

            bunifuEditSurnameTextBox.Text = fieldsEditedRecord[2];
            bunifuEditNameTextBox.Text = fieldsEditedRecord[3];
            bunifuEditFather_nameTextBox.Text = fieldsEditedRecord[4];
            bunifuEditPageDropdown.Text = fieldsEditedRecord[5];

            bunifuPages.SelectedTab = EditPage;
            groupBox.Text = "Операция: Изменение данных";
            bunifuEditSurnameTextBox.Focus();
        }

        private void BunifuGoFiltrationPageButton_Click(object sender, EventArgs e)
        {
            bunifuPages.SelectedTab = FiltrationPage;
            groupBox.Text = "Операция: Фильтрация по должности";
        }

        private void BunifuGoSearchPageButton_Click(object sender, EventArgs e)
        {
            bunifuPages.SelectedTab = SearchPage;
            groupBox.Text = "Операция: Поиск";
            bunifuSearchTextBox.Focus();
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
                if (textBox.Text.Length == 0)
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