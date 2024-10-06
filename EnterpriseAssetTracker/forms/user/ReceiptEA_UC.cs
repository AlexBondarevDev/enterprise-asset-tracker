using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using EnterpriseAssetTracker.Scripts;
using MySql.Data.MySqlClient;
using Bunifu.UI.WinForms;
using BunifuTextbox = Bunifu.UI.WinForms.BunifuTextbox;



namespace EnterpriseAssetTracker.UsersControlers
{
    public partial class ReceiptEA_UC : UserControl
    {
        public string userName;

        DatabaseHelper dbHelper = new DatabaseHelper();
        List<string> fieldsEditedRecord = new List<string>();
        bool isSelectEditRecord = false;

        bool isSuccessCalculation = false;

        public ReceiptEA_UC(string userName)
        {
            InitializeComponent();

            RefreshData("");

            foreach (DataGridViewColumn col in bunifuMainDataGridView.Columns)
            {
                bunifuCreateDocDataGridView.Columns.Add((DataGridViewColumn)col.Clone());
            }

            LoadDataInDropdowns();

            SetValueInDatePickers();

            string[] transformUserName = userName.Split(' ');
            this.userName = $"{transformUserName[0]} {transformUserName[1][0]}. {transformUserName[2][0]}.";
        }


        private void RefreshData(string addFilteringConditions)
        {
            string query = "";
            if (bunifuAddViewWriteoffEACheckBox.Checked == true)
            {
                if (addFilteringConditions == "")
                {
                    query = dbHelper.selectEA_on_writeoff;
                }
                else
                {
                    query = $"{dbHelper.selectEA_on_writeoff} WHERE {addFilteringConditions}";
                }
            }
            else
            {
                if (addFilteringConditions == "")
                {
                    query = $"{dbHelper.selectEA_on_writeoff} WHERE `status` = 1";
                }
                else
                {
                    query = $"{dbHelper.selectEA_on_writeoff} WHERE `status` = 1 AND {addFilteringConditions}";
                }
            }

            LoadDataInDGV(bunifuMainDataGridView, query);

            bunifuMainDataGridView.Columns[0].Visible = false;
            bunifuMainDataGridView.Columns[12].Visible = false;

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
            string[] typeEAArray = dbHelper.GetTypesEA_fieldName("").Select(n => n.ToString()).ToArray();

            bunifuAddR_TypeEADropdown.Items.AddRange(typeEAArray);
            bunifuAddR_TypeEADropdown.SelectedIndex = 1;

            bunifuEditR_TypeEADropdown.Items.AddRange(typeEAArray);
            bunifuEditR_TypeEADropdown.SelectedIndex = 1;

            bunifuFiltr_TypeEADropdown.Items.AddRange(typeEAArray);
            bunifuFiltr_TypeEADropdown.SelectedIndex = 1;


            string[] assetCustodianArray = dbHelper.GetAssetCustodian_fieldName("").Select(n => n.ToString()).ToArray();

            bunifuAddR_AssetCustodianDropdown.Items.AddRange(assetCustodianArray);
            bunifuAddR_AssetCustodianDropdown.SelectedIndex = 1;

            bunifuEditR_AssetCustodianDropdown.Items.AddRange(assetCustodianArray);
            bunifuEditR_AssetCustodianDropdown.SelectedIndex = 1;

            bunifuAddR_VatRateDropdown.SelectedIndex = 0;
            bunifuEditR_VatRateDropdown.SelectedIndex = 0;

            bunifuFiltrationDropdown.SelectedIndex = 0;
        }

        private void SetValueInDatePickers()
        {
            BunifuDatePicker[] datePickers = {
                bunifuAddR_ReceiptDateDatePicker,
                bunifuEditR_ReceiptDateDatePicker,
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

        private void BunifuAddViewWriteoffEACheckBox_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
        {
            RefreshData("");
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

                if (bunifuOperationPages.SelectedTab == EditRecordPage)
                {
                    LoadDataInFieldsForEditRecord();
                }
                else if (bunifuOperationPages.SelectedTab == CreateDocPage)
                {
                    LoadDateInCreateDocDGV(e);
                }
            }
            catch
            {
                ClearFieldsForEditRecord();
                bunifuCreateDocDataGridView.Rows.Clear();
            }
        }




        private void ValidateEAtagTextBoxes(object sender, KeyPressEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                char key = e.KeyChar;

                bool isControl = Char.IsControl(key);
                bool isDigit = Char.IsDigit(key);

                if (isControl || isDigit)
                {
                    if (isControl || textBox.Text.Length < 3)
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void ValidateInitialCostTextBoxes(object sender, KeyPressEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                char key = e.KeyChar;
                e.Handled = true;

                bool isControl = Char.IsControl(key);
                bool isDigit = Char.IsDigit(key);
                bool isSeparator = key == ',';

                if (isDigit || isControl || isSeparator)
                {
                    if (textBox.Text == "0" && key == '0')
                    {
                        e.Handled = true;
                    }
                    else if (textBox.Text.Length == 0 && isSeparator)
                    {
                        e.Handled = true;
                    }
                    else if (textBox.Text.Contains(",") && isSeparator)
                    {
                        e.Handled = true;
                    }
                    else if (textBox.Text.Contains(",") && textBox.Text.Split(',')[1].Length >= 2 && !isControl)
                    {
                        e.Handled = true;
                    }
                    else
                    {
                        e.Handled = false;
                    }
                }
            }
        }




        private void BunifuGoAddPageButton_Click(object sender, EventArgs e)
        {
            bunifuOperationPages.SelectedTab = AddRecordPage;
            groupBox.Text = "Операция: Принятие основного средства";
            bunifuAddR_EANameTextBox.Focus();
        }

        private void BunifuAddR_AddYearButton_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(bunifuAddR_ServiceLifeTextBox.Text) < 25)
            {
                bunifuAddR_ServiceLifeTextBox.Text = Convert.ToString(Convert.ToInt32(bunifuAddR_ServiceLifeTextBox.Text) + 1);

                bunifuAddRecordButton.Enabled = false;
                bunifuAddR_CalculationButton.Enabled = true;

                isSuccessCalculation = false;
            }
        }

        private void BunifuAddR_ReduceYearButton_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(bunifuAddR_ServiceLifeTextBox.Text) > 1)
            {
                bunifuAddR_ServiceLifeTextBox.Text = Convert.ToString(Convert.ToInt32(bunifuAddR_ServiceLifeTextBox.Text) - 1);

                bunifuAddRecordButton.Enabled = false;
                bunifuAddR_CalculationButton.Enabled = true;

                isSuccessCalculation = false;
            }
        }

        private void BunifuAddR_EANameTextBox_TextChange(object sender, EventArgs e)
        {
            bunifuAddRecordButton.Enabled = false;
            bunifuAddR_CalculationButton.Enabled = true;

            isSuccessCalculation = false;
        }

        private void BunifuAddR_TypeEADropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            bunifuAddR_EAtagTextBox.Visible = true;

            bunifuAddR_EAtagLabel.Text = "10" + (dbHelper.GetIdByName_TypeEA(bunifuAddR_TypeEADropdown.Text)).ToString();
            bunifuAddR_EAtagTextBox.Focus();

            isSuccessCalculation = false;
            bunifuAddRecordButton.Enabled = false;
            bunifuAddR_CalculationButton.Enabled = true;
        }

        private void BunifuAddR_CalculationButton_Click(object sender, EventArgs e)
        {
            BunifuTextbox.BunifuTextBox[] nameTextBoxesArray = {
                bunifuAddR_EANameTextBox,
                bunifuAddR_EAtagTextBox,
                bunifuAddR_InitialCostTextBox
            };

            var emptyTextBox = nameTextBoxesArray.FirstOrDefault(textField => string.IsNullOrEmpty(textField.Text));
            if (emptyTextBox != null)
            {
                MessageBox.Show("Пожалуйста, введите все данные!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                emptyTextBox.Focus();
                return;
            }

            if (bunifuAddR_EANameTextBox.TextLength < 3)
            {
                MessageBox.Show("Наименование ОС короче минимального! Пожалуйста, введите минимум 3 символа!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bunifuAddR_EANameTextBox.Focus();
                return;
            }

            if (bunifuAddR_EAtagTextBox.TextLength < 3)
            {
                MessageBox.Show("Инвентарный номар ОС короче 3 символов!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bunifuAddR_EAtagTextBox.Focus();
                return;
            }

            string eaTag = $"{bunifuAddR_EAtagLabel.Text}{bunifuAddR_EAtagTextBox.Text}";
            string[] eaTagArray = dbHelper.GetEATagArray("").Select(n => n.ToString()).ToArray();

            if (eaTagArray.Contains(eaTag))
            {
                MessageBox.Show("ОС с таким инвентарным номером уже состоит на учёте!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bunifuAddR_EAtagTextBox.Focus();
                return;
            }

            try
            {
                isSuccessCalculation = true;
                bunifuAddRecordButton.Enabled = true;
                bunifuAddR_CalculationButton.Enabled = false;

                bunifuAddR_VATAmountTextBox.Text = $"{Math.Round(Convert.ToDouble(bunifuAddR_InitialCostTextBox.Text) * Convert.ToDouble(bunifuAddR_VatRateDropdown.Text) / 100, 2)}";
                bunifuAddR_TotalCostTextBox.Text = $"{Math.Round(Convert.ToDouble(bunifuAddR_InitialCostTextBox.Text) + Convert.ToDouble(bunifuAddR_VATAmountTextBox.Text), 2)}";
                bunifuAddR_ADABox.Text = $"{Math.Round(Convert.ToDouble(bunifuAddR_TotalCostTextBox.Text) / Convert.ToDouble(bunifuAddR_ServiceLifeTextBox.Text), 2)}";

            }
            catch
            {
                MessageBox.Show("Проверьте корректность введённых данных!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BunifuAddRecordButton_Click(object sender, EventArgs e)
        {

            string initial_cost = Math.Round(Convert.ToDouble(bunifuAddR_InitialCostTextBox.Text), 2).ToString(System.Globalization.CultureInfo.InvariantCulture);

            string vat_amount = Math.Round(Convert.ToDouble(bunifuAddR_VATAmountTextBox.Text), 2).ToString(System.Globalization.CultureInfo.InvariantCulture);

            string total_cost = Math.Round(Convert.ToDouble(bunifuAddR_TotalCostTextBox.Text), 2).ToString(System.Globalization.CultureInfo.InvariantCulture);

            string annualDepreciationAmount = Math.Round(Convert.ToDouble(bunifuAddR_ADABox.Text), 2).ToString(System.Globalization.CultureInfo.InvariantCulture);


            int idNewEA = 0;
            try
            {
                using (MySqlCommand command = new MySqlCommand("INSERT INTO `enterprise_assets` (`name`, `asset_tag`, `id_type_ea`, `receipt_date`, `initial_cost`, `service_life`, `vat_rate`, `vat_amount`, `total_cost`, `annual_depreciation_amount`, `status`) VALUES (@name, @asset_tag, @id_type_ea, @receipt_date, @initial_cost, @service_life, @vat_rate, @vat_amount, @total_cost, @annual_depreciation_amount, @status)", dbHelper.GetConnection()))
                {
                    command.Parameters.AddWithValue("@name", bunifuAddR_EANameTextBox.Text);
                    command.Parameters.AddWithValue("@asset_tag", Convert.ToInt32(bunifuAddR_EAtagLabel.Text + bunifuAddR_EAtagTextBox.Text));
                    command.Parameters.AddWithValue("@id_type_ea", dbHelper.GetIdByName_TypeEA(bunifuAddR_TypeEADropdown.Text));
                    command.Parameters.AddWithValue("@receipt_date", $"{bunifuAddR_ReceiptDateDatePicker.Value:yyyy.MM.dd}");
                    command.Parameters.AddWithValue("@initial_cost", initial_cost);
                    command.Parameters.AddWithValue("@service_life", bunifuAddR_ServiceLifeTextBox.Text);
                    command.Parameters.AddWithValue("@vat_rate", Convert.ToInt32(bunifuAddR_VatRateDropdown.Text));
                    command.Parameters.AddWithValue("@vat_amount", vat_amount);
                    command.Parameters.AddWithValue("@total_cost", total_cost);
                    command.Parameters.AddWithValue("@annual_depreciation_amount", annualDepreciationAmount);
                    command.Parameters.AddWithValue("@status", "1");

                    dbHelper.openConnection();

                    if (command.ExecuteNonQuery() == 1)
                    {
                        MySqlCommand getIdCommand = new MySqlCommand("SELECT LAST_INSERT_ID();", dbHelper.GetConnection());
                        idNewEA = Convert.ToInt32(getIdCommand.ExecuteScalar());

                        MessageBox.Show("Основное средство принято на учёт!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        dbHelper.closeConnection();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка принятия основного средства! Попробуете ещё раз или перезагрузите программу!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dbHelper.closeConnection();
                        return;
                    }
                }

                string[] selectAC_Name = bunifuAddR_AssetCustodianDropdown.Text.Split(' ');
                int idAssetCustodian = dbHelper.GetIdByName_AssetCustodian((selectAC_Name[0], selectAC_Name[1], selectAC_Name[2]));

                using (MySqlCommand command = new MySqlCommand("INSERT INTO `assignment_ea` (`id_enterprise_assets`, `id_asset_custodian`) VALUES (@id_enterprise_assets, @id_asset_custodian);", dbHelper.GetConnection()))
                {
                    command.Parameters.AddWithValue("@id_enterprise_assets", idNewEA);
                    command.Parameters.AddWithValue("@id_asset_custodian", idAssetCustodian);

                    dbHelper.openConnection();

                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Основное средство закреплено за материально ответственным лицом!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        dbHelper.closeConnection();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка закрепления основного средства! Попробуете ещё раз или перезагрузите программу!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dbHelper.closeConnection();
                    }
                }

                RefreshData("");
                ClearFieldsForAddRecord();
            }
            catch
            {
                MessageBox.Show("Связь с базой данных не установлена. Пожалуйста, проверьте соединение с интернетом и перезапустите программу.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFieldsForAddRecord()
        {
            bunifuAddR_EANameTextBox.Text = "";
            bunifuAddR_EANameTextBox.Focus();
            bunifuAddR_EAtagTextBox.Text = "";
            bunifuAddR_InitialCostTextBox.Text = "";
            bunifuAddR_ServiceLifeTextBox.Text = "1";
            bunifuAddR_VATAmountTextBox.Text = "";
            bunifuAddR_ADABox.Text = "";
            bunifuAddR_TotalCostTextBox.Text = "";
        }




        private void BunifuGoEditPageButton_Click(object sender, EventArgs e)
        {
            if (!isSelectEditRecord)
            {
                MessageBox.Show("Не выбран элемент для изменения!", "Внимание!");
                return;
            }

            bunifuOperationPages.SelectedTab = EditRecordPage;
            groupBox.Text = "Операция: Изменение записи об основном средстве";
            bunifuEditR_EANameTextBox.Focus();

            LoadDataInFieldsForEditRecord();
        }

        private void LoadDataInFieldsForEditRecord()
        {
            bunifuEditR_EANameTextBox.Text = fieldsEditedRecord[1];
            bunifuEditR_TypeEADropdown.Text = fieldsEditedRecord[3];
            bunifuEditR_EAtagLabel.Text = fieldsEditedRecord[2][0].ToString() + fieldsEditedRecord[2][1].ToString() + fieldsEditedRecord[2][2].ToString();
            bunifuEditR_EAtagTextBox.Text = fieldsEditedRecord[2][3].ToString() + fieldsEditedRecord[2][4].ToString() + fieldsEditedRecord[2][5].ToString();
            bunifuEditR_InitialCostTextBox.Text = fieldsEditedRecord[5];
            bunifuEditR_ServiceLifeTextBox.Text = fieldsEditedRecord[6];
            bunifuEditR_VatRateDropdown.Text = fieldsEditedRecord[7];
            bunifuEditR_ReceiptDateDatePicker.Value = Convert.ToDateTime(fieldsEditedRecord[4]);
            bunifuEditR_VATAmountTextBox.Text = fieldsEditedRecord[8];
            bunifuEditR_ADABox.Text = fieldsEditedRecord[9];
            bunifuEditR_TotalCostTextBox.Text = fieldsEditedRecord[11];

            if (bunifuAddViewWriteoffEACheckBox.Checked == false)
            {
                bunifuEditR_AssetCustodianDropdown.Text = dbHelper.GetAssetCustodian_fieldName($"INNER JOIN `assignment_ea` ON `asset_custodian`.`id_asset_custodian` = `assignment_ea`.`id_asset_custodian` WHERE `id_enterprise_assets` = {fieldsEditedRecord[0]}")[0];

                bunifuEditR_AssetCustodianDropdown.Enabled = true;
            }
            else
            {
                bunifuEditR_AssetCustodianDropdown.Text = "";

                bunifuEditR_AssetCustodianDropdown.Enabled = false;
            }

        }

        private void ClearFieldsForEditRecord()
        {
            isSelectEditRecord = false;
            fieldsEditedRecord.Clear();

            bunifuEditR_EANameTextBox.Text = "";
            bunifuEditR_EAtagLabel.Text = "000";
            bunifuEditR_EAtagTextBox.Text = "";
            bunifuEditR_InitialCostTextBox.Text = "";
            bunifuEditR_ServiceLifeTextBox.Text = "";
            bunifuEditR_VATAmountTextBox.Text = "";
            bunifuEditR_ADABox.Text = "";
            bunifuEditR_TotalCostTextBox.Text = "";
        }

        private void BunifuEditR_AddYearButton_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(bunifuEditR_ServiceLifeTextBox.Text) < 25)
            {
                bunifuEditR_ServiceLifeTextBox.Text = Convert.ToString(Convert.ToInt32(bunifuEditR_ServiceLifeTextBox.Text) + 1);

                bunifuEditRecordButton.Enabled = false;
                bunifuEditR_CalculationButton.Enabled = true;

                isSuccessCalculation = false;
            }
        }

        private void BunifuEditR_ReduceYearButton_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(bunifuEditR_ServiceLifeTextBox.Text) > 1)
            {
                bunifuEditR_ServiceLifeTextBox.Text = Convert.ToString(Convert.ToInt32(bunifuEditR_ServiceLifeTextBox.Text) - 1);

                bunifuEditRecordButton.Enabled = false;
                bunifuEditR_CalculationButton.Enabled = true;

                isSuccessCalculation = false;
            }
        }

        private void BunifuEditR_EANameTextBox_TextChange(object sender, EventArgs e)
        {
            bunifuEditRecordButton.Enabled = false;
            bunifuEditR_CalculationButton.Enabled = true;

            isSuccessCalculation = false;
        }

        private void BunifuEditR_TypeEADropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            bunifuEditR_EAtagLabel.Text = "10" + (dbHelper.GetIdByName_TypeEA(bunifuEditR_TypeEADropdown.Text)).ToString();
            bunifuEditR_EAtagTextBox.Focus();

            bunifuEditRecordButton.Enabled = false;
            bunifuEditR_CalculationButton.Enabled = true;

            isSuccessCalculation = false;
        }

        private void BunifuEditR_CalculationButton_Click(object sender, EventArgs e)
        {
            BunifuTextbox.BunifuTextBox[] nameTextBoxesArray = {
                bunifuEditR_EANameTextBox,
                bunifuEditR_EAtagTextBox,
                bunifuEditR_InitialCostTextBox
            };

            var emptyTextBox = nameTextBoxesArray.FirstOrDefault(textField => string.IsNullOrEmpty(textField.Text));
            if (emptyTextBox != null)
            {
                MessageBox.Show("Пожалуйста, введите все данные!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                emptyTextBox.Focus();
                return;
            }

            if (bunifuEditR_EANameTextBox.TextLength < 3)
            {
                MessageBox.Show("Наименование ОС короче минимального! Пожалуйста, введите минимум 3 символа!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bunifuEditR_EANameTextBox.Focus();
                return;
            }

            if (bunifuEditR_EAtagTextBox.TextLength < 3)
            {
                MessageBox.Show("Инвентарный номар ОС короче 3 символов!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bunifuEditR_EAtagTextBox.Focus();
                return;
            }

            string eaTag = $"{bunifuEditR_EAtagLabel.Text}{bunifuEditR_EAtagTextBox.Text}";
            string[] eaTagArray = dbHelper.GetEATagArray($"WHERE `asset_tag` != {fieldsEditedRecord[2]}").Select(n => n.ToString()).ToArray();

            if (eaTagArray.Contains(eaTag))
            {
                MessageBox.Show("ОС с таким инвентарным номером уже состоит на учёте!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bunifuEditR_EAtagTextBox.Focus();
                return;
            }

            int idUpdateEA = Convert.ToInt32(fieldsEditedRecord[0]);

            if (!ValidateEditedReceiptDate(idUpdateEA))
            {
                return;
            }

            try
            {
                isSuccessCalculation = true;
                bunifuEditRecordButton.Enabled = true;
                bunifuEditR_CalculationButton.Enabled = false;

                bunifuEditR_VATAmountTextBox.Text = $"{Math.Round(Convert.ToDouble(bunifuEditR_InitialCostTextBox.Text) * Convert.ToDouble(bunifuEditR_VatRateDropdown.Text) / 100, 2)}";
                bunifuEditR_TotalCostTextBox.Text = $"{Math.Round(Convert.ToDouble(bunifuEditR_InitialCostTextBox.Text) + Convert.ToDouble(bunifuEditR_VATAmountTextBox.Text), 2)}";
                bunifuEditR_ADABox.Text = $"{Math.Round(Convert.ToDouble(bunifuEditR_TotalCostTextBox.Text) / Convert.ToDouble(bunifuEditR_ServiceLifeTextBox.Text), 2)}";
            }
            catch
            {
                MessageBox.Show("Проверьте корректность введённых данных!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BunifuEditRecordButton_Click(object sender, EventArgs e)
        {
            string initial_cost = Math.Round(Convert.ToDouble(bunifuEditR_InitialCostTextBox.Text), 2).ToString(System.Globalization.CultureInfo.InvariantCulture);

            string vat_amount = Math.Round(Convert.ToDouble(bunifuEditR_VATAmountTextBox.Text), 2).ToString(System.Globalization.CultureInfo.InvariantCulture);

            string total_cost = Math.Round(Convert.ToDouble(bunifuEditR_TotalCostTextBox.Text), 2).ToString(System.Globalization.CultureInfo.InvariantCulture);

            string annualDepreciationAmount = Math.Round(Convert.ToDouble(bunifuEditR_ADABox.Text), 2).ToString(System.Globalization.CultureInfo.InvariantCulture);

            int idUpdateEA = Convert.ToInt32(fieldsEditedRecord[0]);

            try
            {
                using (MySqlCommand command = new MySqlCommand("UPDATE `enterprise_assets` SET `name` = @name, `asset_tag` = @asset_tag, `id_type_ea` = @id_type_ea, `receipt_date` = @receipt_date, `initial_cost` = @initial_cost, `service_life` = @service_life, `vat_rate` = @vat_rate, `vat_amount` = @vat_amount, `total_cost` = @total_cost, `annual_depreciation_amount` = @annual_depreciation_amount WHERE `id_enterprise_assets` = @id_enterprise_assets;", dbHelper.GetConnection()))
                {
                    command.Parameters.AddWithValue("@name", bunifuEditR_EANameTextBox.Text);
                    command.Parameters.AddWithValue("@asset_tag", Convert.ToInt32(bunifuEditR_EAtagLabel.Text + bunifuEditR_EAtagTextBox.Text));
                    command.Parameters.AddWithValue("@id_type_ea", dbHelper.GetIdByName_TypeEA(bunifuEditR_TypeEADropdown.Text));
                    command.Parameters.AddWithValue("@receipt_date", $"{bunifuEditR_ReceiptDateDatePicker.Value:yyyy.MM.dd}");
                    command.Parameters.AddWithValue("@initial_cost", initial_cost);
                    command.Parameters.AddWithValue("@service_life", bunifuEditR_ServiceLifeTextBox.Text);
                    command.Parameters.AddWithValue("@vat_rate", Convert.ToInt32(bunifuEditR_VatRateDropdown.Text));
                    command.Parameters.AddWithValue("@vat_amount", vat_amount);
                    command.Parameters.AddWithValue("@total_cost", total_cost);
                    command.Parameters.AddWithValue("@annual_depreciation_amount", annualDepreciationAmount);
                    command.Parameters.AddWithValue("@id_enterprise_assets", idUpdateEA);

                    dbHelper.openConnection();

                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Данные обновлены!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        dbHelper.closeConnection();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка обновления даннх! Попробуете ещё раз или перезагрузите программу!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dbHelper.closeConnection();
                        return;
                    }
                }

                if (Convert.ToInt32(fieldsEditedRecord[12]) == 1)
                {
                    string[] selectAC_Name = bunifuEditR_AssetCustodianDropdown.Text.Split(' ');
                    int idAssetCustodian = dbHelper.GetIdByName_AssetCustodian((selectAC_Name[0], selectAC_Name[1], selectAC_Name[2]));

                    using (MySqlCommand command = new MySqlCommand("UPDATE `assignment_ea` SET `id_asset_custodian` = @id_asset_custodian WHERE `id_enterprise_assets` = @id_enterprise_assets;", dbHelper.GetConnection()))
                    {
                        command.Parameters.AddWithValue("@id_asset_custodian", idAssetCustodian);
                        command.Parameters.AddWithValue("@id_enterprise_assets", idUpdateEA);

                        dbHelper.openConnection();

                        if (command.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Данный о закреплении обновлены!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            dbHelper.closeConnection();
                        }
                        else
                        {
                            MessageBox.Show("Ошибка обновления данных о закреплении! Попробуете ещё раз или перезагрузите программу!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dbHelper.closeConnection();
                        }
                    }
                }

                RefreshData("");
                ClearFieldsForEditRecord();
            }
            catch
            {
                MessageBox.Show("Связь с базой данных не установлена. Пожалуйста, проверьте соединение с интернетом и перезапустите программу.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateEditedReceiptDate(int idUpdateEA)
        {
            DateTime oldReceiptDate = Convert.ToDateTime(fieldsEditedRecord[4]);
            DateTime newReceiptDate = bunifuEditR_ReceiptDateDatePicker.Value;

            if (newReceiptDate <= oldReceiptDate)
            {
                return true;
            }


            List<string> repairDateList = new List<string>();

            try
            {
                using (var connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    using (var command = new MySqlCommand($"SELECT `start_date` FROM `repair` WHERE `id_enterprise_assets` = {idUpdateEA} AND `start_date` < '{newReceiptDate:yyyy.MM.dd}'", connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                repairDateList.Add(reader.GetString(0));
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch
            {
                MessageBox.Show("Связь с базой данных не установлена! Проверьте соединение с сетью и перезапустите программу!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (repairDateList.Count != 0)
            {
                MessageBox.Show("Невозможно изменить дату принятия ОС! В системе уже содержаться данный о ремонтах, которые противоречат новым данным!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            if (Convert.ToInt32(fieldsEditedRecord[12]) == 0)
            {
                List<string> writeoffDateList = new List<string>();

                try
                {
                    using (var connection = dbHelper.GetConnection())
                    {
                        connection.Open();
                        using (var command = new MySqlCommand($"SELECT `writeoff_date` FROM `writeoff_ea` WHERE `id_enterprise_assets` = {idUpdateEA} AND `writeoff_date` < '{newReceiptDate:yyyy.MM.dd}'", connection))
                        {
                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    writeoffDateList.Add(reader.GetString(0));
                                }
                            }
                        }
                        connection.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("Связь с базой данных не установлена! Проверьте соединение с сетью и перезапустите программу!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (writeoffDateList.Count != 0)
                {
                    MessageBox.Show("Невозможно изменить дату принятия ОС! Данное ОС уже списано и текущая дата списания нарушает корректность данных!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }




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




        private void BunifuGoFiltrationPageButton_Click(object sender, EventArgs e)
        {
            bunifuOperationPages.SelectedTab = FiltrPage;
            groupBox.Text = "Операция: Фильтрация";
        }

        private void BunifuFiltrationDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (bunifuFiltrationDropdown.Text)
            {
                case "виду основного средства": { bunifuFiltrationPages.SelectedTab = FiltrTypeEAPage; break; }
                case "дате принятия": { bunifuFiltrationPages.SelectedTab = FiltrReceiptDatePage; break; }
                case "первоначальной стоимости": { bunifuFiltrationPages.SelectedTab = FiltrCostsPage; bunifuFiltrStartCostsTextBox.Focus(); break; }
                case "финальной стоимости": { bunifuFiltrationPages.SelectedTab = FiltrCostsPage; bunifuFiltrStartCostsTextBox.Focus(); break; }
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

        private void BunifuFiltrationButton_Click(object sender, EventArgs e)
        {
            if ((bunifuFiltrationDropdown.Text == "первоначальной стоимости" || bunifuFiltrationDropdown.Text == "финальной стоимости") && bunifuFiltrStartCostsTextBox.Text == "")
            {
                MessageBox.Show("Пожалуйста, введите сумму для фильтрации!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bunifuFiltrStartCostsTextBox.Focus();
                return;
            }

            string query = "";

            if (bunifuFiltrationDropdown.Text == "виду основного средства")
            {
                query = $"`enterprise_assets`.`id_type_ea` = {dbHelper.GetIdByName_TypeEA(bunifuFiltr_TypeEADropdown.Text)};";
            }
            else if (bunifuFiltrationDropdown.Text == "дате принятия")
            {
                query = $"`receipt_date` BETWEEN '{bunifuFiltrStartDate_DatePicker.Value:yyyy.MM.dd}' AND '{bunifuFiltrEndDate_DatePicker.Value:yyyy.MM.dd}';";
            }
            else
            {
                try
                {
                    double parsedFiltrCost = Convert.ToDouble(bunifuFiltrStartCostsTextBox.Text);
                    string filtrStartCost = Math.Round(parsedFiltrCost, 2).ToString(System.Globalization.CultureInfo.InvariantCulture);

                    parsedFiltrCost = Convert.ToDouble(bunifuFiltrEndCostsTextBox.Text);
                    string filtrEndCost = Math.Round(parsedFiltrCost, 2).ToString(System.Globalization.CultureInfo.InvariantCulture);

                    string filtrFieldName = bunifuFiltrationDropdown.Text == "первоначальной стоимости" ? "initial_cost" : "total_cost";

                    query = $"`{filtrFieldName}` BETWEEN {filtrStartCost} AND {filtrEndCost};";
                }
                catch
                {
                    MessageBox.Show("Пожалуйста, проверьте корректность введённой суммы!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bunifuFiltrStartCostsTextBox.Focus();
                    return;
                }
            }

            try
            {
                RefreshData(query);
            }
            catch
            {
                MessageBox.Show("Запрос не обработан! Повторите попытку или перезагрузите программу!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }




        private void BunifuGoCreateDocPageButton_Click(object sender, EventArgs e)
        {
            bunifuOperationPages.SelectedTab = CreateDocPage;
            groupBox.Text = "Операция: Документы";
            bunifuCreateDocDataGridView.Rows.Clear();
        }

        private void LoadDateInCreateDocDGV(DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = bunifuMainDataGridView.Rows[e.RowIndex];

            object[] rowData = new object[selectedRow.Cells.Count];


            bunifuCreateDocDataGridView.Rows.Clear();

            for (int i = 0; i < selectedRow.Cells.Count; i++)
            {
                if (i == 4 || i == 10)
                {
                    if (i == 10 && selectedRow.Cells[i].Value.ToString() == "")
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

        private void BunifuCreateReceiptEAActButton_Click(object sender, EventArgs e)
        {
            if (!isSelectEditRecord)
            {
                MessageBox.Show("Не выбрана запись для формирования документа!", "Внимание!");
                return;
            }

            if (fieldsEditedRecord[10] != "")
            {
                MessageBox.Show("Нельзя сформировать Акт принятия, так как данное основное средство уже претерпело процедуру списания!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Начало процесса формирования документа!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            bunifuCreateReceiptEAActButton.Enabled = false;

            string newFileName = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\Акт поступления ОС №{fieldsEditedRecord[2]}.docx";

            WordHelper wordHelper = new WordHelper(Application.StartupPath + @"\\document_templates\Act_ReceiptEA.docx");



            DateTime currentDateTime = DateTime.Now;

            string acName = dbHelper.GetAssetCustodian_fieldName($"INNER JOIN `assignment_ea` ON `asset_custodian`.`id_asset_custodian` = `assignment_ea`.`id_asset_custodian` WHERE `id_enterprise_assets` = {fieldsEditedRecord[0]}")[0];

            string[] transformACName = acName.Split(' ');
            string acName_sign = $"{transformACName[0]} {transformACName[1][0]}. {transformACName[2][0]}.";


            var items = new Dictionary<string, string>
                    {
                        {"$docNumber$", $"№{currentDateTime.Day}-{fieldsEditedRecord[0]}"},
                        {"$createDate$", $"{currentDateTime:dd.MM.yyyy}"},
                        {"$eaName$", fieldsEditedRecord[1]},
                        {"$assetTag$", fieldsEditedRecord[2]},
                        {"$typeEA$", fieldsEditedRecord[3]},
                        {"$receiptDate$", $"{Convert.ToDateTime(fieldsEditedRecord[4]):dd.MM.yyyy}"},
                        {"$initialCost$", fieldsEditedRecord[5]},
                        {"$vatRate$", fieldsEditedRecord[7]},
                        {"$vatAmount$", fieldsEditedRecord[8]},
                        {"$serviceLife$", fieldsEditedRecord[6]},
                        {"$adAmount$", fieldsEditedRecord[9]},
                        {"$totalCost$", fieldsEditedRecord[11]},
                        {"$acName$", acName},
                        {"$acName_sign$", acName_sign},
                        {"$economistName$", userName}
                    };



            if (wordHelper.Process(items, newFileName))
            {
                if (MessageBox.Show("Отчёт сформирован! Открыть сформированный документ?", "Открыть документ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(newFileName);
                }
            }
            else
            {
                MessageBox.Show("Произошла ошибка при создании отчёта! Повторите попытку или перезагрузите программу!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            wordHelper.SaveAndClose(newFileName);

            bunifuCreateReceiptEAActButton.Enabled = true;
        }

        private void BunifuCreateReport_InventoryCardButton_Click(object sender, EventArgs e)
        {
            if (!isSelectEditRecord)
            {
                MessageBox.Show("Не выбрана запись для формирования документа!", "Внимание!");
                return;
            }


            MessageBox.Show("Начало процесса формирования документа!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            bunifuCreateReport_InventoryCardButton.Enabled = false;

            string newFileName = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\Инвентарная карточка ОС №{fieldsEditedRecord[2]}.docx";

            WordHelper wordHelper = new WordHelper(Application.StartupPath + @"\\document_templates\Report_InventoryCardEA.docx");


            DateTime currentDateTime = DateTime.Now;

            string acName = "";
            if (fieldsEditedRecord[10].ToString() == "")
            {
                acName = dbHelper.GetAssetCustodian_fieldName($"INNER JOIN `assignment_ea` ON `asset_custodian`.`id_asset_custodian` = `assignment_ea`.`id_asset_custodian` WHERE `id_enterprise_assets` = {fieldsEditedRecord[0]}")[0];
            }
            else acName = "отсутствует";


            string writeoffInfo = GetWriteoffInfoForReport_InventoryCardEA();

            if (writeoffInfo == null)
            {
                return;
            }

            var items = new Dictionary<string, string>
                    {
                        {"$docNumber$", $"№{currentDateTime.Day}-{fieldsEditedRecord[0]}"},
                        {"$createDate$", $"{currentDateTime:dd.MM.yyyy}"},
                        {"$eaName$", fieldsEditedRecord[1]},
                        {"$assetTag$", fieldsEditedRecord[2]},
                        {"$typeEA$", fieldsEditedRecord[3]},
                        {"$acName$", acName},
                        {"$receiptDate$", $"{Convert.ToDateTime(fieldsEditedRecord[4]):dd.MM.yyyy}"},
                        {"$initialCost$", fieldsEditedRecord[5]},
                        {"$vatRate$", fieldsEditedRecord[7]},
                        {"$vatAmount$", fieldsEditedRecord[8]},
                        {"$serviceLife$", fieldsEditedRecord[6]},
                        {"$adAmount$", fieldsEditedRecord[9]},
                        {"$totalCost$", fieldsEditedRecord[11]},
                        {"$writeoffInfo$", writeoffInfo},
                        {"$economistName$", userName}
                    };


            DataTable reportTable = dbHelper.GetReport_InventoryCardEA_repairEAInfo(Convert.ToInt32(fieldsEditedRecord[0]));

            if (wordHelper.Process(items, newFileName))
            {
                wordHelper.InsertTable(reportTable, 3);

                if (MessageBox.Show("Отчёт сформирован! Открыть сформированный документ?", "Открыть документ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(newFileName);
                }
            }
            else
            {
                MessageBox.Show("Произошла ошибка при создании отчёта! Повторите попытку или перезагрузите программу!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            wordHelper.SaveAndClose(newFileName);

            bunifuCreateReport_InventoryCardButton.Enabled = true;
        }

        private string GetWriteoffInfoForReport_InventoryCardEA()
        {
            string writeoffInfo = "";

            try
            {
                using (var connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    using (var command = new MySqlCommand($"SELECT `reasons_writeoff`.`name`, `writeoff_date` FROM `writeoff_ea` INNER JOIN `enterprise_assets` ON `writeoff_ea`.`id_enterprise_assets` = `enterprise_assets`.`id_enterprise_assets` INNER JOIN `reasons_writeoff` ON `writeoff_ea`.`id_reason_writeoff` = `reasons_writeoff`.`id_reason_writeoff` WHERE `enterprise_assets`.`id_enterprise_assets` = {fieldsEditedRecord[0]}", connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                writeoffInfo = $"Объект основных средств в наименовании '{fieldsEditedRecord[1]}' проходит процедуру списания и снимается с учёта {Convert.ToDateTime(reader.GetString(1)):dd.MM.yyyy} по причине '{reader.GetString(0)}'.";
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch
            {
                MessageBox.Show("Связь с базой данных не установлена! Проверьте соединение с сетью и перезапустите программу!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            if (writeoffInfo == "")
            {
                writeoffInfo = "На момент составления документа объект основных средств состоит на учёте.";
            }

            return writeoffInfo;
        }
    }
}