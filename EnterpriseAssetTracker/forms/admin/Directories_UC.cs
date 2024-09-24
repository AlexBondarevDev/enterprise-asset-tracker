using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using EnterpriseAssetTracker.Scripts;
using MySql.Data.MySqlClient;

namespace EnterpriseAssetTracker.UsersControlers
{
    public partial class Directories_UC : UserControl
    {
        DatabaseHelper dbHelper = new DatabaseHelper();
        bool isSelectEditRecord;
        int idSelectRecord;

        public Directories_UC()
        {
            InitializeComponent();
            LoadDataInMainDataGridView(dbHelper.selectTypes_ea);
        }

        private void RefreshData()
        {
            switch (bunifuSelectDirectoriesDropdown.Text)
            {
                case "Виды основных средств": { LoadDataInMainDataGridView(dbHelper.selectTypes_ea); return; }
                case "Должности": { LoadDataInMainDataGridView(dbHelper.selectPositions); return; }
                case "Виды ремонта": { LoadDataInMainDataGridView(dbHelper.selectTypes_repair); return; }
                case "Причины списания": { LoadDataInMainDataGridView(dbHelper.selectReasons_writeoff); return; }
            }
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
                    }
                }
            }
        }




        private void BunifuAddRecordButton_Click(object sender, EventArgs e)
        {
            if (bunifuAddRecordTextBox.Text == "")
            {
                MessageBox.Show("Пожалуйста, введите данные для добавления!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bunifuAddRecordTextBox.Focus();
                return;
            }

            try
            {
                string[] recordArray = GetDirectories(false).Select(n => n.ToString()).ToArray();

                if (recordArray.Contains(bunifuAddRecordTextBox.Text))
                {
                    MessageBox.Show("Запись с такими данными уже присутствует в справочниках!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bunifuAddRecordTextBox.Focus();
                    return;
                }

                dbHelper.openConnection();
                using (var connection = dbHelper.GetConnection())
                {
                    using (var command = new MySqlCommand($"INSERT INTO `{GetTableNameForOperations()}` (`name`) VALUES (@addValue);", connection))
                    {
                        command.Parameters.AddWithValue("@addValue", bunifuAddRecordTextBox.Text);

                        if (command.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show($"Данные успешно добавлены!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            dbHelper.closeConnection();
                            RefreshData();
                            bunifuAddRecordTextBox.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Ошибка добавления данных! Попробуете ещё раз или перезагрузите программу!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dbHelper.closeConnection();
                            bunifuAddRecordTextBox.Focus();
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Связь с базой данных не установлена! Пожалуйста, проверьте соединение с интернетом и перезапустите программу!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BunifuEditRecordButton_Click(object sender, EventArgs e)
        {
            if (isSelectEditRecord == false)
            {
                MessageBox.Show("Не выбрана запись для изменения!", "Внимание!");
                return;
            }

            if (bunifuSelectRecordTextBox.Text == "")
            {
                MessageBox.Show("Пожалуйста, введите изменённые данные!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bunifuSelectRecordTextBox.Focus();
                return;
            }

            if (idSelectRecord == 1 || (bunifuSelectDirectoriesDropdown.Text == "Должности" && idSelectRecord == 2))
            {
                MessageBox.Show("Данная запись является базовой, поэтому её нельзя изменять!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                isSelectEditRecord = false;
                bunifuSelectRecordTextBox.Text = "";
                return;
            }


            string[] recordArray = GetDirectories(true).Select(n => n.ToString()).ToArray();

            if (recordArray.Contains(bunifuSelectRecordTextBox.Text))
            {
                MessageBox.Show("Запись с такими данными уже присутствует в справочниках!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bunifuSelectRecordTextBox.Focus();
                return;
            }

            try
            {
                dbHelper.openConnection();
                using (var connection = dbHelper.GetConnection())
                {
                    using (var command = new MySqlCommand($"UPDATE `{GetTableNameForOperations()}` SET `name` = @newName WHERE `{GetTableNameForOperations()}`.`{GetNamePrimaryKeyForOperations()}` = @idEditRecord;", connection))
                    {
                        command.Parameters.AddWithValue("@newName", bunifuSelectRecordTextBox.Text);
                        command.Parameters.AddWithValue("@idEditRecord", idSelectRecord);

                        if (command.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Запись успешно изменена!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            dbHelper.closeConnection();
                            RefreshData();
                            isSelectEditRecord = false;
                            bunifuSelectRecordTextBox.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Ошибка изменения данных! Попробуете ещё раз или перезагрузите программу!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            bunifuSelectRecordTextBox.Focus();
                            dbHelper.closeConnection();
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Связь с базой данных не установлена! Пожалуйста, проверьте соединение с интернетом и перезапустите программу!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BunifuDeleteRecordButton_Click(object sender, EventArgs e)
        {
            if (isSelectEditRecord == false)
            {
                MessageBox.Show("Не выбрана запись для удаления!", "Внимание!");
                return;
            }

            if (idSelectRecord == 1 || (bunifuSelectDirectoriesDropdown.Text == "Должности" && idSelectRecord == 2))
            {
                MessageBox.Show("Данная запись является базовой, поэтому её нельзя удалять!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                isSelectEditRecord = false;
                bunifuSelectRecordTextBox.Text = "";
                return;
            }

            DialogResult result = MessageBox.Show($"Вы уверены, что хотите удалить запись '{bunifuSelectRecordTextBox.Text}'?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Information); ;
            if (result.ToString() == "No")
            {
                return;
            }

            try
            {
                dbHelper.openConnection();
                using (var connection = dbHelper.GetConnection())
                {
                    using (var command = new MySqlCommand($"DELETE FROM `{GetTableNameForOperations()}` WHERE `{GetNamePrimaryKeyForOperations()}` = @idDeletedRecord;", connection))
                    {
                        command.Parameters.AddWithValue("@idDeletedRecord", idSelectRecord);

                        if (command.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Запись удалёна из справочника! Информация об объектах ОС, связанная с удалённой записью, переназначена на соответсвующие значения по умолчанию!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            dbHelper.closeConnection();
                            RefreshData();
                            isSelectEditRecord = false;
                            bunifuSelectRecordTextBox.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Ошибка удаления данных! Попробуете ещё раз или перезагрузите программу!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dbHelper.closeConnection();
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Связь с базой данных не установлена! Пожалуйста, проверьте соединение с интернетом и перезапустите программу!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<string> GetDirectories(bool isOtionalWHERE)
        {
            string optionalWHERE = "";
            if (isOtionalWHERE)
            {
                switch (bunifuSelectDirectoriesDropdown.Text)
                {
                    case "Виды основных средств": { optionalWHERE = $"WHERE `id_type_ea` != '{idSelectRecord}'"; break; }
                    case "Должности": { optionalWHERE = $"WHERE `id_position` != '{idSelectRecord}'"; break; }
                    case "Виды ремонта": { optionalWHERE = $"WHERE `id_type_repair` != '{idSelectRecord}'"; break; }
                    case "Причины списания": { optionalWHERE = $"WHERE `id_reason_writeoff` != '{idSelectRecord}'"; break; }
                }
            }

            switch (bunifuSelectDirectoriesDropdown.Text)
            {
                case "Виды основных средств": { return dbHelper.GetTypesEA_fieldName(optionalWHERE); }
                case "Должности": { return dbHelper.GetPositions_fieldName(optionalWHERE); }
                case "Виды ремонта": { return dbHelper.GetTypesRepair_fieldName(optionalWHERE); }
                case "Причины списания": { return dbHelper.GetReasonsWriteoff_fieldName(optionalWHERE); }
            }
            return null;
        }

        private string GetTableNameForOperations()
        {
            switch (bunifuSelectDirectoriesDropdown.Text)
            {
                case "Виды основных средств": { return "types_ea"; }
                case "Должности": { return "positions"; }
                case "Виды ремонта": { return "types_repair"; }
                case "Причины списания": { return "reasons_writeoff"; }
            }
            return null;
        }

        private string GetNamePrimaryKeyForOperations()
        {
            switch (bunifuSelectDirectoriesDropdown.Text)
            {
                case "Виды основных средств": { return "id_type_ea"; }
                case "Должности": { return "id_position"; }
                case "Виды ремонта": { return "id_type_repair"; }
                case "Причины списания": { return "id_reason_writeoff"; }
            }
            return null;
        }




        private void BunifuSelectDirectoriesDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (bunifuSelectDirectoriesDropdown.Text)
            {
                case "Виды основных средств":
                    {
                        bunifuTypesDirectoriesLabel.Text = "НАИМЕНОВАНИЕ ВИДА ОСНОВНОГО СРЕДСТВА";
                        break;
                    }
                case "Должности":
                    {
                        bunifuTypesDirectoriesLabel.Text = "НАИМЕНОВАНИЕ ДОЛЖНОСТИ";
                        break;
                    }
                case "Виды ремонта":
                    {
                        bunifuTypesDirectoriesLabel.Text = "НАИМЕНОВАНИЕ ВИДА РЕМОНТА";
                        break;
                    }
                case "Причины списания":
                    {
                        bunifuTypesDirectoriesLabel.Text = "НАИМЕНОВАНИЕ ПРИЧИНЫ СПИСАНИЯ";
                        break;
                    }
            }
            bunifuAddRecordTextBox.Text = "";
            bunifuSelectRecordTextBox.Text = "";
            isSelectEditRecord = false;
            RefreshData();
        }

        private void BunifuMainDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                isSelectEditRecord = true;
                idSelectRecord = Convert.ToInt32(bunifuMainDataGridView.Rows[e.RowIndex].Cells[0].Value);
                bunifuSelectRecordTextBox.Text = bunifuMainDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            catch
            {
                isSelectEditRecord = false;
                bunifuSelectRecordTextBox.Text = "";
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
    }
}