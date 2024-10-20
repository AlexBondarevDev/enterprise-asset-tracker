using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using EnterpriseAssetTracker.Scripts;
using MySql.Data.MySqlClient;



namespace EnterpriseAssetTracker.UsersControlers
{
    /// <summary>
    /// Realization of functionality for writing off enterprise assets.
    /// </summary>
    public partial class WriteOffEA_UC : UserControl
    {
        #region Component initialization.

        public string userName;

        DatabaseHelper dbHelper = new DatabaseHelper();
        bool isSelectEditRecord = false;
        List<string> fieldsEditedRecord = new List<string>();


        public WriteOffEA_UC(string userName)
        {
            InitializeComponent();

            LoadDataInMainDataGridView(dbHelper.selectWriteOffEA);

            foreach (DataGridViewColumn col in bunifuMainDataGridView.Columns)
            {
                bunifuCreateDocDataGridView.Columns.Add((DataGridViewColumn)col.Clone());
            }

            LoadDataInDropdowns();

            SetValueInDatePickers();

            string[] transformUserName = userName.Split(' ');
            this.userName = $"{transformUserName[0]} {transformUserName[1][0]}. {transformUserName[2][0]}.";
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
                        bunifuMainDataGridView.Columns[2].Visible = false;
                    }
                }
            }
            isSelectEditRecord = false;
            fieldsEditedRecord.Clear();
        }

        private void LoadDataInDropdowns()
        {

            string[] reasonsWriteoffArray = dbHelper.GetReasonsWriteoff_fieldName("").Select(n => n.ToString()).ToArray();
            bunifuAddRecordReasonWriteoffDropdown.Items.AddRange(reasonsWriteoffArray);
            bunifuAddRecordReasonWriteoffDropdown.SelectedIndex = 1;

            bunifuEditRecordReasonWriteoffDropdown.Items.AddRange(reasonsWriteoffArray);
            bunifuEditRecordReasonWriteoffDropdown.SelectedIndex = 1;

            bunifuFiltrReasonWriteoffDropdown.Items.AddRange(reasonsWriteoffArray);
            bunifuFiltrReasonWriteoffDropdown.SelectedIndex = 1;

            bunifuFiltrationDropdown.SelectedIndex = 0;
        }

        private void SetValueInDatePickers()
        {
            BunifuDatePicker[] datePickers = {
                bunifuAddRecordDatePicker,
                bunifuEditRecordDatePicker,
                bunifuFiltrStartDatePicker,
                bunifuFiltrEndDatePicker
            };

            DateTime currentDateTime = DateTime.Now;

            foreach (var datePicker in datePickers)
            {
                datePicker.Value = currentDateTime;
                datePicker.MaxDate = currentDateTime;
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

                if (bunifuOperationPages.SelectedTab == CreateDocPage)
                {
                    LoadDateInCreateDocDGV(e);
                }
                else if (bunifuOperationPages.SelectedTab == EditRecordPage)
                {
                    SetMinDateForEditRecord();
                }
            }
            catch
            {
                isSelectEditRecord = false;
                fieldsEditedRecord.Clear();
            }
        }

        #endregion Component initialization.



        #region Realization of the functionality for adding data.

        private void BunifuGoAddRecordButton_Click(object sender, EventArgs e)
        {
            bunifuOperationPages.SelectedTab = AddRecordPage;
            groupBox.Text = "Операция: Списание ОС";

            isSelectEditRecord = false;
            fieldsEditedRecord.Clear();


            using (var connection = dbHelper.GetConnection())
            {
                connection.Open();

                using (var command = new MySqlCommand("SELECT `id_enterprise_assets`, `name` as `Наименование ОС`, `asset_tag` AS `Инвентарный номер`, `receipt_date` AS `Дата принятия` FROM `enterprise_assets` WHERE `status` = 1", connection))
                {
                    using (var adapter = new MySqlDataAdapter(command))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        bunifuAddRecordDataGridView.DataSource = table.DefaultView;
                        bunifuAddRecordDataGridView.Columns[0].Visible = false;
                    }
                }
            }
        }

        private void BunifuAddRecordDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                isSelectEditRecord = true;
                fieldsEditedRecord.Clear();

                for (int i = 0; i < bunifuAddRecordDataGridView.ColumnCount; i++)
                {
                    fieldsEditedRecord.Add(bunifuAddRecordDataGridView.Rows[e.RowIndex].Cells[i].Value.ToString());
                }

                bunifuAddRecord_EANameTextBox.Text = fieldsEditedRecord[1];
                bunifuAddRecord_EAtagLabel.Text = fieldsEditedRecord[2].ToString();

                try
                {
                    using (var connection = dbHelper.GetConnection())
                    {
                        connection.Open();

                        using (var command = new MySqlCommand("SELECT MAX(`end_date`) FROM `repair` INNER JOIN `enterprise_assets` ON `repair`.`id_enterprise_assets` = `enterprise_assets`.`id_enterprise_assets` WHERE `enterprise_assets`.`id_enterprise_assets` = @idEA;", connection))
                        {
                            command.Parameters.AddWithValue("@idEA", fieldsEditedRecord[0]);

                            using (var adapter = new MySqlDataAdapter(command))
                            {
                                DataTable table = new DataTable();
                                adapter.Fill(table);
                                foreach (DataRow item in table.Rows)
                                {
                                    bunifuAddRecordDatePicker.MinDate = Convert.ToDateTime(item[0]);
                                }
                            }
                        }
                    }
                }
                catch
                {
                    bunifuAddRecordDatePicker.MinDate = Convert.ToDateTime(fieldsEditedRecord[3]);
                }
            }
            catch
            {
                isSelectEditRecord = false;
                fieldsEditedRecord.Clear();
            }
        }

        private void BunifuAddRecordButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlCommand command = new MySqlCommand("INSERT INTO `writeoff_ea` (`id_enterprise_assets`, `id_reason_writeoff`, `writeoff_date`) VALUES (@id_enterprise_assets, @id_reason_writeoff, @writeoff_date);", dbHelper.GetConnection()))
                {
                    command.Parameters.AddWithValue("@id_enterprise_assets", fieldsEditedRecord[0]);
                    command.Parameters.AddWithValue("@id_reason_writeoff", dbHelper.GetIdByName_ReasonsWriteoff(bunifuAddRecordReasonWriteoffDropdown.Text));
                    command.Parameters.AddWithValue("@writeoff_date", $"{bunifuAddRecordDatePicker.Value:yyyy.MM.dd}");

                    dbHelper.openConnection();

                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Основное средство успешно списано!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        dbHelper.closeConnection();

                        LoadDataInMainDataGridView(dbHelper.selectWriteOffEA);

                        bunifuAddRecord_EANameTextBox.Text = "";
                        bunifuAddRecord_EAtagLabel.Text = "";

                        isSelectEditRecord = false;
                        fieldsEditedRecord.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка списания основного средства! Попробуете ещё раз или перезагрузите программу!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dbHelper.closeConnection();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Связь с базой данных не установлена! Проверьте соединение с сетью и перезапустите программу!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dbHelper.closeConnection();
            }
        }

        #endregion Realization of the functionality for adding data.



        #region Realization of data modification functionality.

        private void BunifuGoEditRecordPageButton_Click(object sender, EventArgs e)
        {
            if (!isSelectEditRecord)
            {
                MessageBox.Show("Не выбрана запись для изменения!", "Внимание!");
                return;
            }

            bunifuOperationPages.SelectedTab = EditRecordPage;
            groupBox.Text = "Операция: Изменение данных";

            bunifuEditRecord_EANameTextBox.Text = fieldsEditedRecord[3];
            bunifuEditRecord_EAtagLabel.Text = fieldsEditedRecord[4];
            bunifuEditRecordReasonWriteoffDropdown.Text = fieldsEditedRecord[5];
            bunifuEditRecordDatePicker.Value = Convert.ToDateTime(fieldsEditedRecord[6]);

            SetMinDateForEditRecord();
        }

        private void BunifuEditRecordButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlCommand command = new MySqlCommand("UPDATE `writeoff_ea` SET `id_reason_writeoff` = @id_reason_writeoff, `writeoff_date` = @writeoff_date WHERE `writeoff_ea`.`id_writeoff_ea` = @id_writeoff_ea", dbHelper.GetConnection()))
                {
                    command.Parameters.AddWithValue("@id_reason_writeoff", dbHelper.GetIdByName_ReasonsWriteoff(bunifuEditRecordReasonWriteoffDropdown.Text));
                    command.Parameters.AddWithValue("@writeoff_date", $"{bunifuEditRecordDatePicker.Value:yyyy.MM.dd}");
                    command.Parameters.AddWithValue("@id_writeoff_ea", fieldsEditedRecord[0]);

                    dbHelper.openConnection();

                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Данные успешно изменены!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        dbHelper.closeConnection();

                        LoadDataInMainDataGridView(dbHelper.selectWriteOffEA);

                        bunifuEditRecord_EANameTextBox.Text = "";
                        bunifuEditRecord_EAtagLabel.Text = "";

                        bunifuOperationPages.SelectedTab = StartPage;
                        groupBox.Text = "Операция:";

                        isSelectEditRecord = false;
                        fieldsEditedRecord.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка изменения данных! Попробуете ещё раз или перезагрузите программу!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dbHelper.closeConnection();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Связь с базой данных не установлена! Проверьте соединение с сетью и перезапустите программу!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dbHelper.closeConnection();
            }
        }

        private void SetMinDateForEditRecord()
        {
            try
            {
                using (var connection = dbHelper.GetConnection())
                {
                    connection.Open();

                    using (var command = new MySqlCommand("SELECT receipt_date FROM `enterprise_assets` WHERE `enterprise_assets`.`id_enterprise_assets` = @idEA;", connection))
                    {
                        command.Parameters.AddWithValue("@idEA", fieldsEditedRecord[1]);

                        using (var adapter = new MySqlDataAdapter(command))
                        {
                            DataTable table = new DataTable();
                            adapter.Fill(table);
                            foreach (DataRow item in table.Rows)
                            {
                                bunifuEditRecordDatePicker.MinDate = Convert.ToDateTime(item[0]);
                            }
                        }
                    }
                }
            }
            catch
            {
                bunifuEditRecordDatePicker.MinDate = DateTime.Now;
            }
        }

        #endregion Realization of data modification functionality.



        #region Realization of data filtration functionality.

        private void BunifuGoFiltrPageButton_Click(object sender, EventArgs e)
        {
            bunifuOperationPages.SelectedTab = FiltrationPage;
            groupBox.Text = "Операция: Фильтрация";
        }

        private void BunifuFiltrStartDatePicker_ValueChanged(object sender, EventArgs e)
        {
            bunifuFiltrEndDatePicker.MinDate = bunifuFiltrStartDatePicker.Value;
        }

        private void BunifuFiltrEndDatePicker_ValueChanged(object sender, EventArgs e)
        {
            bunifuFiltrStartDatePicker.MaxDate = bunifuFiltrEndDatePicker.Value;
        }

        private void BunifuFiltrationDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (bunifuFiltrationDropdown.Text)
            {
                case "причине списания": { bunifuFiltrPages.SelectedTab = FiltrReasonWriteoffPage; break; }
                case "дате списания": { bunifuFiltrPages.SelectedTab = FiltrDateWriteoffPage; break; }
            }
        }

        private void BunifuFiltrationButton_Click(object sender, EventArgs e)
        {
            string queri = "";

            if (bunifuFiltrationDropdown.Text == "причине списания")
            {
                queri = $"{dbHelper.selectWriteOffEA} WHERE `reasons_writeoff`.`name` = '{bunifuFiltrReasonWriteoffDropdown.Text}';";
            }
            else
            {
                queri = $"{dbHelper.selectWriteOffEA} WHERE `writeoff_date` BETWEEN '{bunifuFiltrStartDatePicker.Value:yyyy.MM.dd}' AND '{bunifuFiltrEndDatePicker.Value:yyyy.MM.dd}'";
            }
            try
            {
                LoadDataInMainDataGridView(queri);
            }
            catch
            {
                MessageBox.Show("Ошибка фильтрации! Повторить попытку или перезагрузите программу!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion Realization of data filtration functionality.



        #region Realization of document creation functionality based on data.

        private void BunifuGoWriteoffActPageButton_Click(object sender, EventArgs e)
        {
            bunifuOperationPages.SelectedTab = CreateDocPage;
            groupBox.Text = "Операция: Акт списания";

            isSelectEditRecord = false;
            fieldsEditedRecord.Clear();
            bunifuCreateDocDataGridView.Rows.Clear();
        }

        private void LoadDateInCreateDocDGV(DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = bunifuMainDataGridView.Rows[e.RowIndex];

            object[] rowData = new object[selectedRow.Cells.Count];


            bunifuCreateDocDataGridView.Rows.Clear();

            for (int i = 0; i < selectedRow.Cells.Count; i++)
            {
                if (i == 6)
                {
                    rowData[i] = $"{Convert.ToDateTime(selectedRow.Cells[i].Value):dd.MM.yyyy}";
                    break;
                }
                rowData[i] = selectedRow.Cells[i].Value;
            }

            bunifuCreateDocDataGridView.Rows.Add(rowData);
        }

        private void BunifuCreateDocButton_Click(object sender, EventArgs e)
        {
            if (!isSelectEditRecord)
            {
                MessageBox.Show("Не выбрана запись для формирования документа!", "Внимание!");
                return;
            }

            MessageBox.Show("Начало процесса формирования документа!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            bunifuCreateDocButton.Enabled = false;

            string newFileName = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\Акт списания ОС №{fieldsEditedRecord[4]}.docx";

            WordHelper wordHelper = new WordHelper(Application.StartupPath + @"\\document_templates\Act_WriteOffEA.docx");

            var items = new Dictionary<string, string>
            {
                {"$docNumber$", $"№{DateTime.Now.Day}-{fieldsEditedRecord[2]}"},
                {"$createDate$", $"{DateTime.Now:dd.MM.yyyy}"},
                {"$eaName$", fieldsEditedRecord[3]},
                {"$assetTag$", fieldsEditedRecord[4]},
                {"$reason_writeoff$", fieldsEditedRecord[5]},
                {"$writeoff_date$", $"{Convert.ToDateTime(fieldsEditedRecord[6]):dd.MM.yyyy}"},
                {"$economistName$", userName}
            };

            if (wordHelper.Process(items, newFileName))
            {
                if (MessageBox.Show("Акт сформирован! Открыть сформированный акт?", "Открыть документ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(newFileName);
                }
            }
            else
            {
                MessageBox.Show("Произошла ошибка при формировании акта! Повторите попытку или перезагрузите программу!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            wordHelper.SaveAndClose(newFileName);

            bunifuCreateDocButton.Enabled = true;

            isSelectEditRecord = false;
            fieldsEditedRecord.Clear();
            bunifuCreateDocDataGridView.Rows.Clear();
        }

        #endregion Realization of document creation functionality based on data.



        #region Realization of data search functionality.

        private void BunifuGoSearchPageButton_Click(object sender, EventArgs e)
        {
            bunifuOperationPages.SelectedTab = SearchPage;
            groupBox.Text = "Операция: Поиск";
            bunifuSearchTextBox.Focus();
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

        #endregion Realization of data search functionality.
    }
}