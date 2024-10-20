using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using EnterpriseAssetTracker.Scripts;
using MySql.Data.MySqlClient;



namespace EnterpriseAssetTracker.UsersControlers
{
    /// <summary>
    /// Realization of functionality for assigning fixed assets to asset custodians.
    /// </summary>
    public partial class AssignmentEA_UC : UserControl
    {
        #region Component initialization.

        public string userName;

        DatabaseHelper dbHelper = new DatabaseHelper();
        bool isSelectEditRecord;
        List<string> fieldsEditedRecord = new List<string>();

        public AssignmentEA_UC(string userName)
        {
            InitializeComponent();

            LoadDataInMainDataGridView(dbHelper.selectAssignmentEA);

            LoadDataInDropdowns();

            string[] transformUserName = userName.Split(' ');
            this.userName = $"{transformUserName[0]} {transformUserName[1][0]}. {transformUserName[2][0]}.";
        }

        private void LoadDataInMainDataGridView(string query)
        {
            using (var connection = dbHelper.GetConnection())
            {
                connection.Open();

                using (var command = new MySqlCommand(query, connection))
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
            isSelectEditRecord = false;
            fieldsEditedRecord.Clear();
        }

        private void LoadDataInDropdowns()
        {
            string[] assetCustodianNamesArray = dbHelper.GetAssetCustodian_fieldName("").Select(n => n.ToString()).ToArray();
            bunifuEditRecordDropdown.Items.AddRange(assetCustodianNamesArray);
            bunifuEditRecordDropdown.SelectedIndex = 1;

            bunifuFiltrACustodianDropdown.Items.AddRange(assetCustodianNamesArray);
            bunifuFiltrACustodianDropdown.SelectedIndex = 1;

            bunifuCreateDocumentDropdown.Items.AddRange(assetCustodianNamesArray);
            bunifuCreateDocumentDropdown.SelectedIndex = 1;


            string[] positionsNamesArray = dbHelper.GetPositions_fieldName("").Select(n => n.ToString()).ToArray();
            bunifuFiltrPositionDropdown.Items.AddRange(positionsNamesArray);
            bunifuFiltrPositionDropdown.SelectedIndex = 1;

            bunifuFiltrationDropdown.SelectedIndex = 0;
        }

        #endregion Component initialization.



        #region Realization of data modification functionality.

        private void BunifuGoEditPageButton_Click(object sender, EventArgs e)
        {
            if (!isSelectEditRecord)
            {
                MessageBox.Show("Не выбран элемент для изменения!", "Внимание!");
                return;
            }

            bunifuOperationPages.SelectedTab = EditPage;
            groupBox.Text = "Операция: Изменение данных";
            bunifuNameEATextBox.Text = fieldsEditedRecord[3].ToString();
            bunifuAssetTagLabel.Text = fieldsEditedRecord[4].ToString();
            bunifuEditRecordDropdown.Text = fieldsEditedRecord[5].ToString();
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
            }
            catch
            {
                isSelectEditRecord = false;
                fieldsEditedRecord.Clear();
            }
        }

        private void BunifuEditRecordDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            bunifuEditRecordButton.Enabled = true;
        }

        private void BunifuEditRecordButton_Click(object sender, EventArgs e)
        {
            string[] selectAC_Name = bunifuEditRecordDropdown.Text.Split(' ');

            int id_NewAssetCustodian = dbHelper.GetIdByName_AssetCustodian((selectAC_Name[0], selectAC_Name[1], selectAC_Name[2]));

            try
            {
                dbHelper.openConnection();

                using (var connection = dbHelper.GetConnection())
                using (var command = new MySqlCommand("UPDATE `assignment_ea` SET `id_enterprise_assets` = @id_enterprise_assets, `id_asset_custodian` = @id_asset_custodian WHERE `id_assignment_ea` = @id_assignment_ea;", connection))
                {
                    command.Parameters.AddWithValue("@id_enterprise_assets", fieldsEditedRecord[1]);
                    command.Parameters.AddWithValue("@id_asset_custodian", id_NewAssetCustodian);
                    command.Parameters.AddWithValue("@id_assignment_ea", fieldsEditedRecord[0]);

                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Основное средство успешно закреплено за материально ответственным лицом!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        dbHelper.closeConnection();

                        LoadDataInMainDataGridView(dbHelper.selectAssignmentEA);

                        isSelectEditRecord = false;
                        fieldsEditedRecord.Clear();
                        bunifuOperationPages.SelectedTab = StartPage;
                        groupBox.Text = "Операция:";
                    }
                    else
                    {
                        MessageBox.Show("Ошибка закрепления основного средства! Попробуете ещё раз или перезагрузите программу.", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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



        #region Realization of data filtration functionality.

        private void BunifuGoFiltrPageButton_Click(object sender, EventArgs e)
        {
            bunifuOperationPages.SelectedTab = FiltrationPage;
            groupBox.Text = "Операция: Фильтрация";
        }
       
        private void BunifuFiltrationDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (bunifuFiltrationDropdown.Text)
            {
                case "материально ответственному лицу": { bunifuFiltrationPages.SelectedTab = FiltrAssetCustodianPage; break; }
                case "должности": { bunifuFiltrationPages.SelectedTab = FiltrPositionPage; break; }
            }
        }

        private void BunifuFiltrationButton_Click(object sender, EventArgs e)
        {
            string queri = "";

            if (bunifuFiltrationDropdown.Text == "материально ответственному лицу")
            {
                string[] selectAC_Name = bunifuFiltrACustodianDropdown.Text.Split(' ');

                queri = $"WHERE `asset_custodian`.`surname` = '{selectAC_Name[0]}' and `asset_custodian`.`name` = '{selectAC_Name[1]}' and `asset_custodian`.`father_name` = '{selectAC_Name[2]}';";
            }
            else
            {
                queri = "WHERE `positions`.`name` = '" + bunifuFiltrPositionDropdown.Text + "';";
            }

            LoadDataInMainDataGridView($"{dbHelper.selectAssignmentEA} {queri}");
        }

        #endregion Realization of data filtration functionality.



        #region Realization of document creation functionality based on data.

        private void BunifuGoCreateDocPageButton_Click(object sender, EventArgs e)
        {
            bunifuOperationPages.SelectedTab = CreateDocPage;
            groupBox.Text = "Операция: Отчёт на МОЛ";
        }

        private void BunifuCreateReportButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Подтвердите формирование списка ОС, закреплённых за сотрудником {bunifuCreateDocumentDropdown.Text}!", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
            {
                return;
            }

            MessageBox.Show("Начало процесса формирования документа!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            bunifuCreateReportButton.Enabled = false;

            DateTime currentDateTime = DateTime.Now;
            string[] selectAC_Name = bunifuCreateDocumentDropdown.Text.Split(' ');

            int id_AssetCustodian_ForCreateDoc = dbHelper.GetIdByName_AssetCustodian((selectAC_Name[0], selectAC_Name[1], selectAC_Name[2]));
            DataTable reportTable = dbHelper.GetReport_EAassignedACustodian(id_AssetCustodian_ForCreateDoc);

            string newFileName = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\Список ОС на МОЛ {bunifuCreateDocumentDropdown.Text}.docx";

            WordHelper wordHelper = new WordHelper(Application.StartupPath + @"\\document_templates\Report_EAassignedACustodian.docx");

            var items = new Dictionary<string, string>
            {
                {"$docNumber$", $"№{currentDateTime.Day}-{id_AssetCustodian_ForCreateDoc}"},
                {"$createDate$", $"{currentDateTime:dd.MM.yyyy}"},
                {"$assetCustodian$", bunifuCreateDocumentDropdown.Text},
                {"$economistName$", userName},
            };

            if (wordHelper.Process(items, newFileName))
            {
                wordHelper.InsertTable(reportTable, 2);

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

            bunifuCreateReportButton.Enabled = true;
        }

        #endregion Realization of document creation functionality based on data.
    }
}