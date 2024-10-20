using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using EnterpriseAssetTracker.Scripts;
using MySql.Data.MySqlClient;
using Bunifu.UI.WinForms;



namespace EnterpriseAssetTracker.UsersControlers
{
    /// <summary>
    /// Realization of functionality for accounting repair data of enterprise assets.
    /// </summary>
    public partial class RepairEA_UC : UserControl
    {
        #region Component initialization.

        DatabaseHelper dbHelper = new DatabaseHelper();
        List<string> fieldsEditedRecord = new List<string>();
        bool isSelectEditRecord = false;

        public RepairEA_UC()
        {
            InitializeComponent();

            RefreshData("");

            foreach (DataGridViewColumn col in bunifuMainDataGridView.Columns)
            {
                bunifuCreateDocDataGridView.Columns.Add((DataGridViewColumn)col.Clone());
            }

            LoadDataInDropdowns();

            SetValueInDatePickers();
        }


        private void RefreshData(string addFilteringConditions)
        {
            string query = "";
            if (bunifuAllEA_CheckBox.Checked == true)
            {
                if (addFilteringConditions == "")
                {
                    query = dbHelper.selectRepairEA;
                }
                else
                {
                    query = $"{dbHelper.selectRepairEA} WHERE {addFilteringConditions}";
                }

            }
            else if (bunifuAssignmentEA_CheckBox.Checked == true)
            {
                if (addFilteringConditions == "")
                {
                    query = $"{dbHelper.selectRepairEA} WHERE `status` = 1";
                }
                else
                {
                    query = $"{dbHelper.selectRepairEA} WHERE `status` = 1  AND {addFilteringConditions}";
                }
            }
            else
            {
                if (addFilteringConditions == "")
                {
                    query = $"{dbHelper.selectRepairEA} WHERE `status` = 0";
                }
                else
                {
                    query = $"{dbHelper.selectRepairEA} WHERE `status` = 0  AND {addFilteringConditions}";
                }
            }

            LoadDataInDGV(bunifuMainDataGridView, query);

            bunifuMainDataGridView.Columns[0].Visible = false;
            bunifuMainDataGridView.Columns[1].Visible = false;
            bunifuMainDataGridView.Columns[2].Visible = false;

            isSelectEditRecord = false;
            fieldsEditedRecord.Clear();
        }

        private void LoadDataInDGV(BunifuDataGridView operarionDGV, string query)
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
                        operarionDGV.DataSource = table.DefaultView;
                    }
                }
            }
        }

        private void LoadDataInDropdowns()
        {
            string[] typeRepairArray = dbHelper.GetTypesRepair_fieldName("").Select(n => n.ToString()).ToArray();

            bunifuAddRecordDropdown.Items.AddRange(typeRepairArray);
            bunifuAddRecordDropdown.SelectedIndex = 1;

            bunifuEditRecordDropdown.Items.AddRange(typeRepairArray);
            bunifuEditRecordDropdown.SelectedIndex = 1;

            bunifuFiltrTypeRepairDropdown.Items.AddRange(typeRepairArray);
            bunifuFiltrTypeRepairDropdown.SelectedIndex = 1;

            bunifuFiltrationDropdown.SelectedIndex = 1;
        }

        private void SetValueInDatePickers()
        {
            BunifuDatePicker[] datePickers = {
                bunifuAddRecordDatePicker,
                bunifuCompleteR_StartDateDatePicker,
                bunifuEditR_StartDateDatePicker,
                bunifuFiltrStartDate_DatePicker,
                bunifuFiltrEndDate_DatePicker
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

                if (bunifuOperationPages.SelectedTab == CompleteRPage)
                {
                    RefreshDataInComponentForCompleteRepair();
                }
                else if (bunifuOperationPages.SelectedTab == EditRecordPage)
                {

                    RefreshDataInComponentForEditRepair();
                }
                else if (bunifuOperationPages.SelectedTab == CreateDocPage)
                {
                    LoadDateInCreateDocDGV(e);
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

        private void BunifuGoAddRPageButtonButton_Click(object sender, EventArgs e)
        {
            bunifuOperationPages.SelectedTab = AddRecordPage;
            groupBox.Text = "Операция: Новый ремонт";

            LoadDataInDGV(bunifuAddRecordDataGridView, "SELECT `id_enterprise_assets`, `name` as `Наименование ОС`, `asset_tag` AS `Инвентарный номер`, `receipt_date` FROM `enterprise_assets` WHERE `status` = 1");

            bunifuAddRecordDataGridView.Columns[0].Visible = false;
            bunifuAddRecordDataGridView.Columns[3].Visible = false;
        }

        bool isSelectAddRecord = false;
        List<string> fieldsAddRecord = new List<string>();

        private void BunifuAddRecordDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                isSelectAddRecord = true;
                fieldsAddRecord.Clear();

                for (int i = 0; i < bunifuAddRecordDataGridView.ColumnCount; i++)
                {
                    fieldsAddRecord.Add(bunifuAddRecordDataGridView.Rows[e.RowIndex].Cells[i].Value.ToString());
                }

                bunifuAddRecord_EANameTextBox.Text = fieldsAddRecord[1];
                bunifuAddRecord_AssetTagLabel.Text = fieldsAddRecord[2].ToString();
                bunifuAddRecordDatePicker.MinDate = Convert.ToDateTime(fieldsAddRecord[3]);
            }
            catch
            {
                isSelectAddRecord = false;
                fieldsAddRecord.Clear();

                bunifuAddRecord_EANameTextBox.Text = "";
                bunifuAddRecord_AssetTagLabel.Text = "";
            }
        }

        private void BunifuAddRecordButton_Click(object sender, EventArgs e)
        {
            if (!isSelectAddRecord)
            {
                MessageBox.Show("Не выбрано ОС для ремонта!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bunifuAddRecord_EANameTextBox.Focus();
                return;
            }


            try
            {
                int id_type_repair = dbHelper.GetIdByName_TypeRepair(bunifuAddRecordDropdown.Text);

                using (MySqlCommand command = new MySqlCommand("SELECT * FROM `repair` WHERE `id_enterprise_assets` = @id_enterprise_assets AND `end_date` IS null;", dbHelper.GetConnection()))
                {
                    command.Parameters.AddWithValue("@id_enterprise_assets", fieldsAddRecord[0]);

                    dbHelper.openConnection();

                    if (Convert.ToInt32(command.ExecuteScalar()) > 0)
                    {
                        MessageBox.Show("Основное средство на данный момент уже подвергнуто ремонту!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dbHelper.closeConnection();
                        return;
                    }
                }


                using (MySqlCommand command = new MySqlCommand("INSERT INTO `repair` (`id_enterprise_assets`, `id_type_repair`, `start_date`, `end_date`, `amount_costs`) VALUES (@id_enterprise_assets, @id_type_repair, @start_date, NULL, NULL);", dbHelper.GetConnection()))
                {
                    command.Parameters.AddWithValue("@id_enterprise_assets", fieldsAddRecord[0]);
                    command.Parameters.AddWithValue("@id_type_repair", id_type_repair);
                    command.Parameters.AddWithValue("@start_date", $"{bunifuAddRecordDatePicker.Value:yyyy.MM.dd}");

                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Основное средство поступило на ремонт!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        dbHelper.closeConnection();

                        RefreshData("");

                        bunifuAddRecord_EANameTextBox.Text = "";
                        bunifuAddRecord_AssetTagLabel.Text = "";

                        isSelectAddRecord = false;
                        fieldsAddRecord.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка поступления ОС на ремонт! Попробуете ещё раз или перезагрузите программу!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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





        private void BunifuGoCompleteRPageButton_Click(object sender, EventArgs e)
        {
            if (!isSelectEditRecord)
            {
                MessageBox.Show("Не выбрана запись для окончания ремонта!", "Внимание!");
                return;
            }

            if (fieldsEditedRecord[8] != "")
            {
                MessageBox.Show("Данный ремонт уже окончен!", "Внимание!");
                return;
            }

            bunifuOperationPages.SelectedTab = CompleteRPage;
            groupBox.Text = "Операция: Окончание ремонта";

            bunifuCompleteR_EANameTextBox.Text = fieldsEditedRecord[3];
            bunifuCompleteR_TypeRTextBox.Text = fieldsEditedRecord[5];
            bunifuCompleteR_EATagLabel.Text = fieldsEditedRecord[4];
            bunifuCompleteR_StartDateDatePicker.Value = Convert.ToDateTime(fieldsEditedRecord[6]);
            bunifuCompleteR_EndDateDatePicker.MinDate = bunifuCompleteR_StartDateDatePicker.Value;
        }

        private void ValidatePriceTextBox(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            char key = e.KeyChar;

            e.Handled = true;

            if (Char.IsDigit(key) || Char.IsControl(key) || key == ',')
            {
                if (textBox.Text.Length == 0 && (key == '0' || key == ','))
                {
                    e.Handled = true;
                }
                else if (key == ',' && textBox.Text.Contains(','))
                {
                    e.Handled = true;
                }
                else if (Char.IsControl(key))
                {
                    e.Handled = false;
                }
                else if (textBox.Text.Contains(',') && textBox.Text.Split(',')[1].Length >= 2)
                {
                    e.Handled = true;
                }
                else
                {
                    e.Handled = false;
                }
            }
        }

        private void BunifuCompleteRepairButton_Click(object sender, EventArgs e)
        {
            string amount_costs = "";

            try
            {
                if (string.IsNullOrWhiteSpace(bunifuCompleteR_AmountCostsTextBox.Text))
                {
                    MessageBox.Show("Введите сумму затрат на ремонт!", "Внимание!");
                    bunifuCompleteR_AmountCostsTextBox.Focus();
                    return;
                }

                double parsedAmount = Convert.ToDouble(bunifuCompleteR_AmountCostsTextBox.Text);
                amount_costs = Math.Round(parsedAmount, 2).ToString(System.Globalization.CultureInfo.InvariantCulture);
            }
            catch
            {
                MessageBox.Show("Проверьте корректность введённой суммы!", "Внимание!");
                bunifuCompleteR_AmountCostsTextBox.Focus();
                return;
            }

            try
            {
                using (MySqlCommand command = new MySqlCommand("UPDATE `repair` SET `end_date` = @end_date, `amount_costs` = @amount_costs WHERE `id_repair` = @id_repair;", dbHelper.GetConnection()))
                {
                    command.Parameters.AddWithValue("@end_date", $"{bunifuCompleteR_EndDateDatePicker.Value:yyyy.MM.dd}");
                    command.Parameters.AddWithValue("@amount_costs", amount_costs);
                    command.Parameters.AddWithValue("@id_repair", fieldsEditedRecord[0]);

                    dbHelper.openConnection();

                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Ремонт выбранного ОС окончен!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        dbHelper.closeConnection();

                        RefreshData("");

                        bunifuCompleteR_AmountCostsTextBox.Text = "";
                        bunifuOperationPages.SelectedTab = StartPage;
                        groupBox.Text = "Операция:";

                        isSelectEditRecord = false;
                        fieldsEditedRecord.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка поступления ОС на ремонт! Попробуете ещё раз или перезагрузите программу!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void RefreshDataInComponentForCompleteRepair()
        {
            if (fieldsEditedRecord[8] != "")
            {
                MessageBox.Show("Данный ремонт уже окончен!", "Внимание!");

                isSelectEditRecord = false;
                fieldsEditedRecord.Clear();

                bunifuCompleteR_EANameTextBox.Text = "";
                bunifuCompleteR_TypeRTextBox.Text = "";
                bunifuCompleteR_EATagLabel.Text = "";

                return;
            }

            bunifuCompleteR_EANameTextBox.Text = fieldsEditedRecord[3];
            bunifuCompleteR_TypeRTextBox.Text = fieldsEditedRecord[5];
            bunifuCompleteR_EATagLabel.Text = fieldsEditedRecord[4];
            bunifuCompleteR_StartDateDatePicker.Value = Convert.ToDateTime(fieldsEditedRecord[6]);
            bunifuCompleteR_EndDateDatePicker.MinDate = bunifuCompleteR_StartDateDatePicker.Value;
        }

        #endregion Realization of the functionality for adding data.



        #region Realization of data modification functionality.

        private void RefreshDataInComponentForEditRepair()
        {
            if (fieldsEditedRecord[8] == "")
            {
                MessageBox.Show("Данный ремонт ещё не окончен! Изменение данных доступно только после окончания ремонта!", "Внимание!");

                isSelectEditRecord = false;
                fieldsEditedRecord.Clear();

                bunifuEditRecord_EANameTextBox.Text = "";
                bunifuEditRecordDropdown.Text = "";
                bunifuEditR_EATagLabel.Text = "";

                bunifuEditR_AmountCostsTextBox.Text = "";

                return;
            }

            bunifuEditRecord_EANameTextBox.Text = fieldsEditedRecord[3];
            bunifuEditRecordDropdown.Text = fieldsEditedRecord[5];
            bunifuEditR_EATagLabel.Text = fieldsEditedRecord[4].ToString();

            bunifuEditR_StartDateDatePicker.MaxDate = Convert.ToDateTime("01.01.2090");
            bunifuEditR_EndDateDatePicker.MinDate = Convert.ToDateTime("01.01.1990");

            bunifuEditR_StartDateDatePicker.Value = Convert.ToDateTime(fieldsEditedRecord[6]);
            bunifuEditR_EndDateDatePicker.Value = Convert.ToDateTime(fieldsEditedRecord[7]);
            bunifuEditR_StartDateDatePicker.MaxDate = bunifuEditR_EndDateDatePicker.Value;
            bunifuEditR_EndDateDatePicker.MinDate = bunifuEditR_StartDateDatePicker.Value;

            bunifuEditR_AmountCostsTextBox.Text = fieldsEditedRecord[8];
        }

        private void BunifuGoEditRPageButtonButton_Click(object sender, EventArgs e)
        {
            if (!isSelectEditRecord)
            {
                MessageBox.Show("Не выбрана запись для изменения!", "Внимание!");
                return;
            }
            if (fieldsEditedRecord[8] == "")
            {
                MessageBox.Show("Данный ремонт ещё не окончен! Изменение данных доступно только после окончания ремонта!", "Внимание!");
                return;
            }

            bunifuOperationPages.SelectedTab = EditRecordPage;
            groupBox.Text = "Операция: Изменение данных";

            bunifuEditRecord_EANameTextBox.Text = fieldsEditedRecord[3];
            bunifuEditRecordDropdown.Text = fieldsEditedRecord[5];
            bunifuEditR_EATagLabel.Text = fieldsEditedRecord[4].ToString();


            bunifuEditR_StartDateDatePicker.MaxDate = Convert.ToDateTime("01.01.2090");
            bunifuEditR_EndDateDatePicker.MinDate = Convert.ToDateTime("01.01.1990");

            bunifuEditR_StartDateDatePicker.Value = Convert.ToDateTime(fieldsEditedRecord[6]);
            bunifuEditR_EndDateDatePicker.Value = Convert.ToDateTime(fieldsEditedRecord[7]);
            bunifuEditR_StartDateDatePicker.MaxDate = bunifuEditR_EndDateDatePicker.Value;
            bunifuEditR_EndDateDatePicker.MinDate = bunifuEditR_StartDateDatePicker.Value;

            bunifuEditR_AmountCostsTextBox.Text = fieldsEditedRecord[8];
        }

        private void BunifuEditR_StartDateDatePicker_ValueChanged(object sender, EventArgs e)
        {
            bunifuEditR_EndDateDatePicker.MinDate = bunifuEditR_StartDateDatePicker.Value;
        }

        private void BunifuEditR_EndDateDatePicker_ValueChanged(object sender, EventArgs e)
        {
            bunifuEditR_StartDateDatePicker.MaxDate = bunifuEditR_EndDateDatePicker.Value;
        }

        private void BunifuEditRecordButton_Click(object sender, EventArgs e)
        {
            string amount_costs = "";

            try
            {
                if (string.IsNullOrWhiteSpace(bunifuEditR_AmountCostsTextBox.Text))
                {
                    MessageBox.Show("Введите сумму затрат на ремонт!", "Внимание!");
                    bunifuEditR_AmountCostsTextBox.Focus();
                    return;
                }

                double parsedAmount = Convert.ToDouble(bunifuEditR_AmountCostsTextBox.Text);
                amount_costs = Math.Round(parsedAmount, 2).ToString(System.Globalization.CultureInfo.InvariantCulture);
            }
            catch
            {
                MessageBox.Show("Проверьте корректность введённой суммы!", "Внимание!");
                bunifuEditR_AmountCostsTextBox.Focus();
                return;
            }

            try
            {
                using (MySqlCommand command = new MySqlCommand("UPDATE `repair` SET `id_repair` = @id_repair, `start_date` = @start_date, `end_date` = @end_date, `amount_costs` = @amount_costs WHERE `id_repair` = @id_repair;", dbHelper.GetConnection()))
                {
                    command.Parameters.AddWithValue("@id_type_repair", dbHelper.GetIdByName_TypeRepair(bunifuEditRecordDropdown.Text));
                    command.Parameters.AddWithValue("@start_date", $"{bunifuEditR_StartDateDatePicker.Value:yyyy.MM.dd}");
                    command.Parameters.AddWithValue("@end_date", $"{bunifuEditR_EndDateDatePicker.Value:yyyy.MM.dd}");
                    command.Parameters.AddWithValue("@amount_costs", amount_costs);
                    command.Parameters.AddWithValue("@id_repair", fieldsEditedRecord[0]);

                    dbHelper.openConnection();

                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Ремонт выбранного ОС окончен!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        dbHelper.closeConnection();

                        RefreshData("");

                        bunifuCompleteR_AmountCostsTextBox.Text = "";
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

        #endregion Realization of data modification functionality.



        #region Realization of data filtration functionality.

        private void BunifuGoFiltrPageButton_Click(object sender, EventArgs e)
        {
            bunifuOperationPages.SelectedTab = FiltrPage;
            groupBox.Text = "Операция: Фильтрация";
        }

        private void BunifuFiltrationDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (bunifuFiltrationDropdown.Text)
            {
                case "основному средству":
                    {
                        bunifuFiltrationPages.SelectedTab = FiltrEAPage;

                        LoadDataInDGV(bunifuFiltrDataGridView, "SELECT `id_enterprise_assets`, `name` as `Наименование ОС`, `asset_tag` AS `Инвентарный номер`, `receipt_date` AS `Дата принятия` FROM `enterprise_assets`");

                        bunifuFiltrDataGridView.Columns[0].Visible = false;
                        break;
                    }
                case "виду ремонта": { bunifuFiltrationPages.SelectedTab = FiltrTypeRepairPage; break; }
                case "дате начала ремонта": { bunifuFiltrationPages.SelectedTab = FiltrDatePage; break; }
                case "дате окончания ремонта": { bunifuFiltrationPages.SelectedTab = FiltrDatePage; break; }
            }

            isSelectFiltrRecord = false;
            fieldsEditedRecord.Clear();
        }

        private void BunifuFiltrationButton_Click(object sender, EventArgs e)
        {
            if (bunifuFiltrationDropdown.Text == "основному средству" && !isSelectFiltrRecord)
            {
                MessageBox.Show("Пожалуйста, выберите ОС для фильтрации!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string queri = "";

            if (bunifuFiltrationDropdown.Text == "основному средству")
            {
                queri = $"`repair`.`id_enterprise_assets` = {fieldsEditedRecord[0]};";
            }
            if (bunifuFiltrationDropdown.Text == "виду ремонта")
            {
                queri = $"`types_repair`.`name` = '{bunifuFiltrTypeRepairDropdown.Text}';";
            }
            if (bunifuFiltrationDropdown.Text == "дате начала ремонта")
            {
                queri = $"`start_date` BETWEEN '{bunifuFiltrStartDate_DatePicker.Value:yyyy.MM.dd}' and '{bunifuFiltrEndDate_DatePicker.Value:yyyy.MM.dd}';";
            }
            if (bunifuFiltrationDropdown.Text == "дате окончания ремонта")
            {
                queri = $"`end_date` BETWEEN '{bunifuFiltrStartDate_DatePicker.Value:yyyy.MM.dd}' and '{bunifuFiltrEndDate_DatePicker.Value:yyyy.MM.dd}';";
            }

            RefreshData(queri);


            try
            {

                isSelectFiltrRecord = false;
                fieldsEditedRecord.Clear();
            }
            catch
            {
                MessageBox.Show("Запрос не обработан.", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BunifuFiltrStartDate_DatePicker_ValueChanged(object sender, EventArgs e)
        {
            bunifuFiltrEndDate_DatePicker.MinDate = bunifuFiltrStartDate_DatePicker.Value;
        }

        private void BunifuFiltrEndDate_DatePicker_ValueChanged(object sender, EventArgs e)
        {
            bunifuFiltrStartDate_DatePicker.MaxDate = bunifuFiltrEndDate_DatePicker.Value;
        }

        bool isSelectFiltrRecord = false;
        private void BunifuFiltrDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                isSelectFiltrRecord = true;
                fieldsEditedRecord.Clear();

                fieldsEditedRecord.Add(bunifuFiltrDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            catch
            {
                isSelectFiltrRecord = false;
                fieldsEditedRecord.Clear();
            }
        }

        #endregion Realization of data filtration functionality.



        #region Realization of data search functionality.

        private void BunifuGoSearchPageButtonButton_Click(object sender, EventArgs e)
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



        #region Realization of document creation functionality based on data.

        private void BunifuGoCreateDocPageButton_Click(object sender, EventArgs e)
        {
            bunifuOperationPages.SelectedTab = CreateDocPage;
            groupBox.Text = "Операция: Акт ремонта";
        }

        private void LoadDateInCreateDocDGV(DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = bunifuMainDataGridView.Rows[e.RowIndex];

            object[] rowData = new object[selectedRow.Cells.Count];


            bunifuCreateDocDataGridView.Rows.Clear();

            for (int i = 0; i < selectedRow.Cells.Count; i++)
            {
                if (i == 6 || i == 7)
                {
                    if (i == 7 && selectedRow.Cells[i].Value.ToString() == "")
                    {
                        rowData[i] = "";
                        continue;
                    }
                    rowData[i] = $"{Convert.ToDateTime(selectedRow.Cells[i].Value):dd.MM.yyyy}";
                    continue;
                }
                rowData[i] = selectedRow.Cells[i].Value;
            }

            bunifuCreateDocDataGridView.Rows.Add(rowData);
        }

        private void BunifuCreateRepairEAActButton_Click(object sender, EventArgs e)
        {
            if (!isSelectEditRecord)
            {
                MessageBox.Show("Не выбрана запись для формирования документа!", "Внимание!");
                return;
            }

            if (fieldsEditedRecord[8] == "")
            {
                MessageBox.Show("Акт ремонта составляется по завершении процесса ремонта!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Начало процесса формирования документа!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            bunifuCreateRepairEAActButton.Enabled = false;

            string newFileName = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\Акт ремонта ОС №{fieldsEditedRecord[4]}.docx";

            WordHelper wordHelper = new WordHelper(Application.StartupPath + @"\\document_templates\Act_RepairEA.docx");

            var items = new Dictionary<string, string>
            {
                {"$docNumber$", $"№{DateTime.Now.Day}-{fieldsEditedRecord[2]}"},
                {"$createDate$", $"{DateTime.Now:dd.MM.yyyy}"},
                {"$startDate$", $"{Convert.ToDateTime(fieldsEditedRecord[6]):dd.MM.yyyy}"},
                {"$endDate$", $"{Convert.ToDateTime(fieldsEditedRecord[7]):dd.MM.yyyy}"},
                {"$eaName$", fieldsEditedRecord[3]},
                {"$assetTag$", fieldsEditedRecord[4]},
                {"$repairType$", fieldsEditedRecord[5]},
                {"$amountCosts$", fieldsEditedRecord[8]},
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

            bunifuCreateRepairEAActButton.Enabled = true;

            isSelectEditRecord = false;
            fieldsEditedRecord.Clear();
            bunifuCreateDocDataGridView.Rows.Clear();
        }

        #endregion Realization of document creation functionality based on data.



        #region Realization of auxiliary functionality.

        private void BunifuAllEA_CheckBox_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (bunifuAllEA_CheckBox.Checked == true)
            {
                bunifuAllEA_CheckBox.Enabled = false;
                bunifuAssignmentEA_CheckBox.Enabled = true;
                bunifuWriteOffEA_CheckBox.Enabled = true;

                bunifuAssignmentEA_CheckBox.Checked = false;
                bunifuWriteOffEA_CheckBox.Checked = false;

                RefreshData("");

                isSelectEditRecord = false;
                fieldsEditedRecord.Clear();
            }
        }

        private void BunifuAssignmentEA_CheckBox_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (bunifuAssignmentEA_CheckBox.Checked == true)
            {
                bunifuAllEA_CheckBox.Enabled = true;
                bunifuAssignmentEA_CheckBox.Enabled = false;
                bunifuWriteOffEA_CheckBox.Enabled = true;

                bunifuAllEA_CheckBox.Checked = false;
                bunifuWriteOffEA_CheckBox.Checked = false;

                RefreshData("");

                isSelectEditRecord = false;
                fieldsEditedRecord.Clear();
            }
        }

        private void BunifuWriteOffEA_CheckBox_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (bunifuWriteOffEA_CheckBox.Checked == true)
            {
                bunifuAllEA_CheckBox.Enabled = true;
                bunifuAssignmentEA_CheckBox.Enabled = true;
                bunifuWriteOffEA_CheckBox.Enabled = false;

                bunifuAllEA_CheckBox.Checked = false;
                bunifuAssignmentEA_CheckBox.Checked = false;

                RefreshData("");

                isSelectEditRecord = false;
                fieldsEditedRecord.Clear();
            }
        }

        #endregion Realization of auxiliary functionality.
    }
}