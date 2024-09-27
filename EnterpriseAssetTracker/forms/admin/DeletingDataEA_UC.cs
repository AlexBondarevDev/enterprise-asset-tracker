using System;
using System.Data;
using System.Windows.Forms;
using EnterpriseAssetTracker.Scripts;
using MySql.Data.MySqlClient;



namespace EnterpriseAssetTracker.UsersControlers
{
    public partial class DeletingDataEA_UC : UserControl
    {
        DatabaseHelper dbHelper = new DatabaseHelper();
        bool isSelectEditRecord;
        (int, int) idRecordAndIdEAForEdit;

        public DeletingDataEA_UC()
        {
            InitializeComponent();
            LoadEA_on_writeoff_Data();
        }


        private void LoadEA_on_writeoff_Data()
        {
            LoadDataInMainDataGridView(dbHelper.selectEA_on_writeoff);

            bunifuMainDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            bunifuMainDataGridView.Columns[0].Visible = false;
            bunifuMainDataGridView.Columns[1].Visible = true;
            bunifuMainDataGridView.Columns[2].Visible = true;
        }

        private void LoadRepairEA_Data()
        {
            LoadDataInMainDataGridView(dbHelper.selectRepairEA);

            bunifuMainDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            bunifuMainDataGridView.Columns[0].Visible = false;
            bunifuMainDataGridView.Columns[1].Visible = false;
            bunifuMainDataGridView.Columns[2].Visible = false;
        }

        private void LoadWriteOffEA_Data()
        {
            LoadDataInMainDataGridView(dbHelper.selectWriteOffEA);

            bunifuMainDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            bunifuMainDataGridView.Columns[0].Visible = false;
            bunifuMainDataGridView.Columns[1].Visible = false;
            bunifuMainDataGridView.Columns[2].Visible = false;
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
                    }
                }
            }
        }

        private void LoadDataInEditRecordDataGridView(string query)
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
                        bunifuEditRecordDataGridView.DataSource = table.DefaultView;
                        bunifuEditRecordDataGridView.Visible = true;
                    }
                }
            }
        }



        private void bunifuDeletingButton_Click(object sender, EventArgs e)
        {
            if (!isSelectEditRecord)
            {
                MessageBox.Show("Не выбрана запись для удаления!", "Внимание!");
                return;
            }

            if (MessageBox.Show($"Вы уверены, что хотите удалить запись?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            if (bunifu_EA_on_writeoff_CheckBox.Checked == true)
            {
                DeleteRecord(new MySqlCommand("DELETE FROM `enterprise_assets` WHERE `enterprise_assets`.`id_enterprise_assets` = @idDeletedRecord;", dbHelper.GetConnection()));
                LoadEA_on_writeoff_Data();
            }
            else if (bunifuRepairEA_CheckBox.Checked == true)
            {
                DeleteRecord(new MySqlCommand("DELETE FROM `repair` WHERE `repair`.`id_repair` = @idDeletedRecord;", dbHelper.GetConnection()));
                LoadRepairEA_Data();
            }
            else
            {
                DeleteRecord(new MySqlCommand("DELETE FROM `writeoff_ea` WHERE `writeoff_ea`.`id_writeoff_ea` = @idDeletedRecord;", dbHelper.GetConnection()));
                RestoringRelationsAfterWriteoff();
                LoadWriteOffEA_Data();
            }
        }

        private void DeleteRecord(MySqlCommand command)
        {
            dbHelper.openConnection();
            try
            {
                using (var connection = dbHelper.GetConnection())
                {
                    command.Parameters.AddWithValue("@idDeletedRecord", idRecordAndIdEAForEdit.Item1);

                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Запись успешно удалена!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        MessageBox.Show("Ошибка удаления! Попробуете ещё раз или перезагрузите программу!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    isSelectEditRecord = false;
                    bunifuEditRecordDataGridView.Visible = false;
                }
            }
            catch
            {
                MessageBox.Show("Связь с базой данных потеряна! Проверьте соединение с сетью и перезапустите программу!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbHelper.closeConnection();
            }
        }

        /// <summary>
        /// When deleting a record of writing off an EA, it is also necessary to restore the status of the EA as unwritten off, as well as the record of assignment to an asset custodian.
        /// </summary>
        private void RestoringRelationsAfterWriteoff()
        {
            try
            {
                dbHelper.openConnection();

                string updateQuery = "UPDATE `enterprise_assets` SET `status` = 1 WHERE `id_enterprise_assets` = @id";
                MySqlCommand command = new MySqlCommand(updateQuery, dbHelper.GetConnection());
                command.Parameters.AddWithValue("@id", idRecordAndIdEAForEdit.Item2);

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Статус учёта ОС обновлён!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ошибка обновления статуса! Попробуйте ещё раз или перезагрузите программу!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                string insertQuery = "INSERT INTO `assignment_ea` (`id_enterprise_assets`, `id_asset_custodian`) VALUES (@id, 1)";
                command = new MySqlCommand(insertQuery, dbHelper.GetConnection());
                command.Parameters.AddWithValue("@id", idRecordAndIdEAForEdit.Item2);

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Запись о закреплении ОС за МОЛ добавлена! Основное средство закреплено за директором!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ошибка добавления записи о закреплении! Попробуйте ещё раз или перезагрузите программу!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbHelper.closeConnection();
            }
        }



        private void BunifuMainDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                isSelectEditRecord = true;

                idRecordAndIdEAForEdit.Item1 = Convert.ToInt32(bunifuMainDataGridView.Rows[e.RowIndex].Cells[0].Value);

                if (int.TryParse(bunifuMainDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString(), out int idEA))
                {
                    idRecordAndIdEAForEdit.Item2 = idEA;
                }
                else
                {
                    idRecordAndIdEAForEdit.Item2 = -1;
                }

                if (bunifu_EA_on_writeoff_CheckBox.Checked == true)
                {
                    LoadDataInEditRecordDataGridView(dbHelper.selectEA_on_writeoff + "WHERE `enterprise_assets`.`id_enterprise_assets` = " + idRecordAndIdEAForEdit.Item1);

                    bunifuEditRecordDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    bunifuEditRecordDataGridView.Columns[0].Visible = false;
                    bunifuEditRecordDataGridView.Columns[1].Visible = true;
                    bunifuEditRecordDataGridView.Columns[2].Visible = true;
                }
                else if (bunifuRepairEA_CheckBox.Checked == true)
                {
                    LoadDataInEditRecordDataGridView(dbHelper.selectRepairEA + "WHERE `repair`.`id_repair` = " + idRecordAndIdEAForEdit.Item1);

                    bunifuEditRecordDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    bunifuEditRecordDataGridView.Columns[0].Visible = false;
                    bunifuEditRecordDataGridView.Columns[1].Visible = false;
                    bunifuEditRecordDataGridView.Columns[2].Visible = false;
                }
                else if (bunifuWriteOffEA_CheckBox.Checked == true)
                {
                    LoadDataInEditRecordDataGridView(dbHelper.selectWriteOffEA + "WHERE `writeoff_ea`.`id_writeoff_ea` = " + idRecordAndIdEAForEdit.Item1);

                    bunifuEditRecordDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    bunifuEditRecordDataGridView.Columns[0].Visible = false;
                    bunifuEditRecordDataGridView.Columns[1].Visible = false;
                    bunifuEditRecordDataGridView.Columns[2].Visible = false;
                }

                bunifuEditRecordDataGridView.Visible = true;
            }
            catch
            {
                isSelectEditRecord = false;
                idRecordAndIdEAForEdit = (-1,-1);
                bunifuEditRecordDataGridView.Visible = false;
            }
        }



        private void Bunifu_EA_on_writeoff_CheckBox_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (bunifu_EA_on_writeoff_CheckBox.Checked == true)
            {
                bunifu_EA_on_writeoff_CheckBox.Enabled = false;
                bunifuRepairEA_CheckBox.Enabled = true;
                bunifuWriteOffEA_CheckBox.Enabled = true;
                bunifuRepairEA_CheckBox.Checked = false;
                bunifuWriteOffEA_CheckBox.Checked = false;

                LoadEA_on_writeoff_Data();

                bunifuEditRecordDataGridView.Visible = false;
                isSelectEditRecord = false;
            }
        }

        private void BunifuRepairEA_CheckBox_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (bunifuRepairEA_CheckBox.Checked == true)
            {
                bunifu_EA_on_writeoff_CheckBox.Enabled = true;
                bunifuRepairEA_CheckBox.Enabled = false;
                bunifuWriteOffEA_CheckBox.Enabled = true;
                bunifu_EA_on_writeoff_CheckBox.Checked = false;
                bunifuWriteOffEA_CheckBox.Checked = false;

                LoadRepairEA_Data();

                bunifuEditRecordDataGridView.Visible = false;
                isSelectEditRecord = false;
            }
        }

        private void BunifuWriteOffEA_CheckBox_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (bunifuWriteOffEA_CheckBox.Checked == true)
            {
                bunifu_EA_on_writeoff_CheckBox.Enabled = true;
                bunifuRepairEA_CheckBox.Enabled = true;
                bunifuWriteOffEA_CheckBox.Enabled = false;
                bunifuRepairEA_CheckBox.Checked = false;
                bunifu_EA_on_writeoff_CheckBox.Checked = false;

                LoadWriteOffEA_Data();

                bunifuEditRecordDataGridView.Visible = false;
                isSelectEditRecord = false;
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