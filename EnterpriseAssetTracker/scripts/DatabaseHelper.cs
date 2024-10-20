using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;



namespace EnterpriseAssetTracker.Scripts
{
    /// <summary>
    /// Contains frequently used queries and methods for get data, generating directories and reports.
    /// </summary>
    class DatabaseHelper
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=eat_db");

        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public MySqlConnection GetConnection()
        {
            return connection;
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
                using (var connection = this.GetConnection())
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



        #region MainDataGridView queries.

        public string selectEA_on_writeoff =
            "SELECT " +
            "`enterprise_assets`.`id_enterprise_assets`, " +
            "`enterprise_assets`.`name` AS `Наименование ОС`, " +
            "`asset_tag` AS `Инвентарный номер`, " +
            "`types_ea`.`name` AS `Вид ОС`, " +
            "`receipt_date` AS `Дата принятия`, " +
            "`initial_cost` AS `Первоначальная стоимость: руб.`, " +
            "`service_life` AS `СПИ: лет`, " +
            "`vat_rate` AS `Норма НДС: %`, " +
            "`vat_amount` AS `Сумма НДС: руб.`, " +
            "`annual_depreciation_amount` AS `ГСА: руб.`, " +
            "`writeoff_ea`.`writeoff_date` AS `Дата списания`, " +
            "`total_cost` AS `Финальная стоимость: руб.`, " +
            "`status` " +
            "FROM `types_ea` INNER JOIN (`enterprise_assets` LEFT JOIN `writeoff_ea` ON `enterprise_assets`.`id_enterprise_assets`=`writeoff_ea`.`id_enterprise_assets`) ON `types_ea`.`id_type_ea`=`enterprise_assets`.`id_type_ea` ";

        public string selectAssignmentEA =
            "SELECT" +
            "`id_assignment_ea`," +
            "`enterprise_assets`.`id_enterprise_assets`," +
            "`asset_custodian`.`id_asset_custodian`," +
            "`enterprise_assets`.`name` AS `Наименование ОС`," +
            "`asset_tag` AS `Инвентарный номер`," +
            "CONCAT(`asset_custodian`.`surname`, ' ', `asset_custodian`.`name`, ' ', `asset_custodian`.`father_name`) AS `Материально ответственное лицо`," +
            "`positions`.`name` AS `Должность`" +
            "FROM `enterprise_assets` INNER JOIN (`assignment_ea` INNER JOIN (`asset_custodian` INNER JOIN `positions` ON `asset_custodian`.`id_position` = `positions`.`id_position`) ON `assignment_ea`.`id_asset_custodian` = `asset_custodian`.`id_asset_custodian`) ON `enterprise_assets`.`id_enterprise_assets` = `assignment_ea`.`id_enterprise_assets` ";


        public string selectRepairEA =
            "SELECT " +
            "`id_repair`, " +
            "`repair`.`id_enterprise_assets`, " +
            "`repair`.`id_type_repair`, " +
            "`enterprise_assets`.`name` AS `Наименование ОС`, " +
            "`asset_tag` AS `Инвентарный номер`, " +
            "`types_repair`.`name` AS `Вид ремонта`, " +
            "`start_date` AS `Дата начала ремонта`, " +
            "`end_date` AS `Дата окончания ремонта`, " +
            "`amount_costs` AS `Сумма затрат на ремонт: руб.` " +
            "FROM `repair` INNER JOIN `enterprise_assets` ON `repair`.`id_enterprise_assets`=`enterprise_assets`.`id_enterprise_assets` INNER JOIN `types_repair` ON `repair`.`id_type_repair`=`types_repair`.`id_type_repair` ";

        public string selectWriteOffEA =
            "SELECT " +
            "`id_writeoff_ea`, " +
            "`enterprise_assets`.`id_enterprise_assets`, " +
            "`reasons_writeoff`.`id_reason_writeoff`, " +
            "`enterprise_assets`.`name` AS `Наименование ОС`, " +
            "`asset_tag` AS `Инвентарный номер`, " +
            "`reasons_writeoff`.`name` AS `Причина списания`, " +
            "`writeoff_date` AS `Дата списания` " +
            "FROM `writeoff_ea` INNER JOIN `enterprise_assets` ON `writeoff_ea`.`id_enterprise_assets`=`enterprise_assets`.`id_enterprise_assets` INNER JOIN `reasons_writeoff` ON `writeoff_ea`.`id_reason_writeoff`=`reasons_writeoff`.`id_reason_writeoff` ";



        public string selectTypes_ea = "SELECT `id_type_ea`, `name` AS `Наименование вида ОС` FROM `types_ea`";
        public string selectPositions = "SELECT `id_position`, `name` AS `Наименование должности` FROM `positions`";
        public string selectTypes_repair = "SELECT `id_type_repair`, `name` AS `Наименование вида ремонта` FROM `types_repair`";
        public string selectReasons_writeoff = "SELECT `id_reason_writeoff`, `name` AS `Причины списания` FROM `reasons_writeoff`";

        public string selectAsset_custodian =
            "SELECT " +
            "`id_asset_custodian`," +
            "`asset_custodian`.`id_position`, " +
            "`surname` AS `Фамилия`, " +
            "`asset_custodian`.`name` AS `Имя`, " +
            "`father_name` AS `Отчество`, " +
            "`positions`.`name` AS `Должность` " +
            "FROM `asset_custodian` INNER JOIN `positions` on `asset_custodian`.`id_position`=`positions`.`id_position`";


        public string selectAuthorization =
            "SELECT" +
            "`id_economist`, " +
            "`name_economist` AS `ФИО Экономиста`, " +
            "`password` AS `Пароль`," +
            "`isAdmin` " +
            "FROM `authorization` ";

        #endregion MainDataGridView queries.



        #region GetFieldName queries for Directories.

        public List<string> GetUsers_fieldName(string optionalWHERE)
        {
            return GetDirectories($"SELECT `name_economist` FROM `authorization` {optionalWHERE} ORDER BY `name_economist` ASC");
        }

        public List<string> GetTypesEA_fieldName(string optionalWHERE)
        {
            return GetDirectories($"SELECT `name` FROM `types_ea` {optionalWHERE}");
        }

        public List<string> GetPositions_fieldName(string optionalWHERE)
        {
            return GetDirectories($"SELECT `name` FROM `positions` {optionalWHERE}");
        }

        public List<string> GetTypesRepair_fieldName(string optionalWHERE)
        {
            return GetDirectories($"SELECT `name` FROM `types_repair` {optionalWHERE}");
        }

        public List<string> GetReasonsWriteoff_fieldName(string optionalWHERE)
        {
            return GetDirectories($"SELECT `name` FROM `reasons_writeoff` {optionalWHERE}");
        }

        public List<string> GetAssetCustodian_fieldName(string optionalWHERE)
        {
            return GetDirectories($"SELECT CONCAT(`surname`,' ',`name`,' ',`father_name`) FROM `asset_custodian` {optionalWHERE}");
        }

        public List<string> GetEATagArray(string optionalWHERE)
        {
            return GetDirectories($"SELECT `asset_tag` FROM `enterprise_assets` {optionalWHERE}");
        }



        private List<string> GetDirectories(string query)
        {
            List<string> recordList = new List<string>();

            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    using (var command = new MySqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                recordList.Add(reader.GetString(0));
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

            return recordList;
        }

        #endregion GetFieldName queries for Directories.



        #region GetIdByName queries for operation INSERT and UPDATE.

        public int GetIdByName_Positions(string searchedName)
        {
            return GetIdByName($"SELECT `id_position` FROM `positions` WHERE `name` = @searchedName;", searchedName);
        }

        public int GetIdByName_AssetCustodian((string, string, string) searchedName)
        {
            return GetIdByName_ForAssetCustodian($"SELECT `id_asset_custodian` FROM `asset_custodian` WHERE `surname` = @searchedSurname AND `name` = @searchedName AND `father_name` = @searchedFather_name;", searchedName);
        }

        public int GetIdByName_TypeRepair(string searchedName)
        {
            return GetIdByName($"SELECT `id_type_repair` FROM `types_repair` WHERE `name` = @searchedName;", searchedName);
        }

        public int GetIdByName_ReasonsWriteoff(string searchedName)
        {
            return GetIdByName($"SELECT `id_reason_writeoff` FROM `reasons_writeoff` WHERE `name` = @searchedName;", searchedName);
        }

        public int GetIdByName_TypeEA(string searchedName)
        {
            return GetIdByName($"SELECT `id_type_ea` FROM `types_ea` WHERE `name` = @searchedName;", searchedName);
        }



        private int GetIdByName(string query, string searchedName)
        {
            int serchedId = 0;

            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@searchedName", searchedName);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                serchedId = Convert.ToInt32(reader.GetString(0));
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch
            {
                MessageBox.Show("Связь с базой данных не установлена! Проверьте соединение с сетью и перезапустите программу!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

            return serchedId;
        }

        private int GetIdByName_ForAssetCustodian(string query, (string, string, string) searchedName)
        {
            int serchedId = 0;

            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@searchedSurname", searchedName.Item1);
                        command.Parameters.AddWithValue("@searchedName", searchedName.Item2);
                        command.Parameters.AddWithValue("@searchedFather_name", searchedName.Item3);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                serchedId = Convert.ToInt32(reader.GetString(0));
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch
            {
                MessageBox.Show("Связь с базой данных не установлена! Проверьте соединение с сетью и перезапустите программу!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

            return serchedId;
        }

        #endregion GetIdByName queries for operation INSERT and UPDATE.



        #region Queries for documents and reports.

        public DataTable GetReport_InventoryCardEA_repairEAInfo(int idEnterpriseAssets)
        {
            string reports_selectEAassignedACustodian =
            "SELECT" +
            "`types_repair`.`name`," +
            "DATE_FORMAT(`start_date`, '%d.%m.%Y')," +
            "DATE_FORMAT(`end_date`, '%d.%m.%Y')," +
            "`amount_costs`" +
            "FROM `repair` INNER JOIN `enterprise_assets` ON `repair`.`id_enterprise_assets`=`enterprise_assets`.`id_enterprise_assets` INNER JOIN `types_repair` ON `repair`.`id_type_repair`=`types_repair`.`id_type_repair`" +
            "WHERE `enterprise_assets`.`id_enterprise_assets` = @id_enterprise_assets";

            MySqlCommand reportCommand = new MySqlCommand(reports_selectEAassignedACustodian, GetConnection());

            reportCommand.Parameters.AddWithValue("@id_enterprise_assets", idEnterpriseAssets);

            return GetDataForReport(reportCommand);
        }

        public DataTable GetReport_EAassignedACustodian(int idAssetCustodian)
        {
            string reports_selectEAassignedACustodian =
            "SELECT" +
            "`enterprise_assets`.`name`, " +
            "`enterprise_assets`.`asset_tag`, " +
            "DATE_FORMAT(`enterprise_assets`.`receipt_date`, '%d.%m.%Y') " +
            "FROM `enterprise_assets` INNER JOIN (`assignment_ea` INNER JOIN `asset_custodian` ON `assignment_ea`.`id_asset_custodian`=`asset_custodian`.`id_asset_custodian` ) ON `enterprise_assets`.`id_enterprise_assets`=`assignment_ea`.`id_enterprise_assets` " +
            "WHERE `asset_custodian`.`id_asset_custodian` = @id_AssetCustodian " +
            "ORDER BY `enterprise_assets`.`asset_tag` ASC";

            MySqlCommand reportCommand = new MySqlCommand(reports_selectEAassignedACustodian, GetConnection());

            reportCommand.Parameters.AddWithValue("@id_AssetCustodian", idAssetCustodian);

            return GetDataForReport(reportCommand);
        }

        public DataTable GetReport_RWEAList_ReceiptEA(DateTime startDate, DateTime endDate)
        {
            string reports_selectReceiptEA =
            "SELECT " +
            "`enterprise_assets`.`name`, " +
            "`asset_tag`, " +
            "DATE_FORMAT(`receipt_date`, '%d.%m.%Y') " +
            "FROM `types_ea` INNER JOIN `enterprise_assets` ON `types_ea`.`id_type_ea` = `enterprise_assets`.`id_type_ea` " +
            "WHERE `receipt_date` BETWEEN @startDate AND @endDate " +
            "ORDER BY `receipt_date` ASC";

            MySqlCommand reportCommand = new MySqlCommand(reports_selectReceiptEA, GetConnection());

            reportCommand.Parameters.AddWithValue("@startDate", $"{startDate:yyyy.MM.dd}");
            reportCommand.Parameters.AddWithValue("@endDate", $"{endDate:yyyy.MM.dd}");

            return GetDataForReport(reportCommand);
        }

        public DataTable GetReport_RWEAList_WriteoffEA(DateTime startDate, DateTime endDate)
        {
            string reports_selectReceiptEA =
            "SELECT" +
            "`enterprise_assets`.`name`, " +
            "`asset_tag`, " +
            "DATE_FORMAT(`writeoff_date`, '%d.%m.%Y') " +
            "FROM `writeoff_ea` INNER JOIN `enterprise_assets` ON `writeoff_ea`.`id_enterprise_assets`=`enterprise_assets`.`id_enterprise_assets` INNER JOIN `reasons_writeoff` ON `writeoff_ea`.`id_reason_writeoff` = `reasons_writeoff`.`id_reason_writeoff` " +
            "WHERE `writeoff_date` BETWEEN @startDate AND @endDate " +
            "ORDER BY `writeoff_date` ASC";

            MySqlCommand reportCommand = new MySqlCommand(reports_selectReceiptEA, GetConnection());

            reportCommand.Parameters.AddWithValue("@startDate", $"{startDate:yyyy.MM.dd}");
            reportCommand.Parameters.AddWithValue("@endDate", $"{endDate:yyyy.MM.dd}");

            return GetDataForReport(reportCommand);
        }

        public DataTable GetReport_YearSaldo(int reportYear)
        {
            MySqlCommand reportCommand = new MySqlCommand("CALL `GetData_YearSaldoReport`(@reportYear);", GetConnection());

            reportCommand.Parameters.AddWithValue("@reportYear", reportYear);

            return GetDataForReport(reportCommand);
        }

        public DataTable GetReport_ResponsibilityRelationshipAC()
        {
            string reports_selectEAassignedACustodian =
            "SELECT " +
            "CONCAT(`asset_custodian`.`surname`, ' ', `asset_custodian`.`name`, ' ', `asset_custodian`.`father_name`) AS `Материально ответственное лицо`, " +
            "COUNT(`assignment_ea`.`id_asset_custodian`) AS `Кол-во объектов ОС`, " +
            "ROUND((COUNT(`assignment_ea`.`id_asset_custodian`) / `total_count`.`RowsCount` * 100), 2) AS `%` " +
            "FROM `asset_custodian` LEFT JOIN `assignment_ea` ON `asset_custodian`.`id_asset_custodian` = `assignment_ea`.`id_asset_custodian` CROSS JOIN (SELECT COUNT(*) AS `RowsCount` FROM `assignment_ea`) AS `total_count` " +
            "GROUP BY `Материально ответственное лицо`, `total_count`.`RowsCount` ORDER BY `Кол-во объектов ОС` DESC;";

            MySqlCommand reportCommand = new MySqlCommand(reports_selectEAassignedACustodian, GetConnection());

            return GetDataForReport(reportCommand);
        }

        public DataTable GetReport_AnnualDynamicsReceiptEA(DateTime startDate, DateTime endDate)
        {
            string reports_selectReceiptEA =
            "SELECT " +
            "YEAR(`receipt_date`) AS `reportYear`, " +
            "SUM(`total_cost`) " +
            "FROM `enterprise_assets` " +
            "WHERE YEAR(`receipt_date`) BETWEEN YEAR(@startDate) AND YEAR(@endDate)" +
            "GROUP BY `reportYear` " +
            "ORDER BY `reportYear` ASC";

            MySqlCommand reportCommand = new MySqlCommand(reports_selectReceiptEA, GetConnection());

            reportCommand.Parameters.AddWithValue("@startDate", $"{startDate:yyyy.MM.dd}");
            reportCommand.Parameters.AddWithValue("@endDate", $"{endDate:yyyy.MM.dd}");

            return GetDataForReport(reportCommand);
        }

        public DataTable GetReport_AnnualDynamicsWriteoffEA(DateTime startDate, DateTime endDate)
        {
            string reports_selectReceiptEA =
            "SELECT " +
            "YEAR(`writeoff_date`) AS `reportYear`, " +
            "SUM(`total_cost`) " +
            "FROM `enterprise_assets` INNER JOIN `writeoff_ea` ON `enterprise_assets`.`id_enterprise_assets` = `writeoff_ea`.`id_enterprise_assets` " +
            "WHERE YEAR(`writeoff_date`) BETWEEN YEAR(@startDate) AND YEAR(@endDate) " +
            "GROUP BY `reportYear` " +
            "ORDER BY `reportYear` ASC";

            MySqlCommand reportCommand = new MySqlCommand(reports_selectReceiptEA, GetConnection());

            reportCommand.Parameters.AddWithValue("@startDate", $"{startDate:yyyy.MM.dd}");
            reportCommand.Parameters.AddWithValue("@endDate", $"{endDate:yyyy.MM.dd}");

            return GetDataForReport(reportCommand);
        }

        public DataTable GetReport_AnnualDynamicsRepairEA(DateTime startDate, DateTime endDate)
        {
            string reports_selectReceiptEA =
            "SELECT " +
            "YEAR(`end_date`) AS `reportYear`, " +
            "SUM(`amount_costs`) " +
            "FROM `enterprise_assets` INNER JOIN `repair` ON `enterprise_assets`.`id_enterprise_assets` = `repair`.`id_enterprise_assets` " +
            "WHERE YEAR(`end_date`) BETWEEN YEAR(@startDate) AND YEAR(@endDate) " +
            "GROUP BY `reportYear` " +
            "ORDER BY `reportYear` ASC";

            MySqlCommand reportCommand = new MySqlCommand(reports_selectReceiptEA, GetConnection());

            reportCommand.Parameters.AddWithValue("@startDate", $"{startDate:yyyy.MM.dd}");
            reportCommand.Parameters.AddWithValue("@endDate", $"{endDate:yyyy.MM.dd}");

            return GetDataForReport(reportCommand);
        }

        public DataTable GetReport_AnnualDynamicsCapital(DateTime startDate, DateTime endDate)
        {
            string reports_selectReceiptEA = "CALL `GetData_AnnualDynamicsCapitalReport`(@startYear, @endYear);";

            MySqlCommand reportCommand = new MySqlCommand(reports_selectReceiptEA, GetConnection());

            reportCommand.Parameters.AddWithValue("@startYear", $"{startDate.Year}");
            reportCommand.Parameters.AddWithValue("@endYear", $"{endDate.Year}");

            return GetDataForReport(reportCommand);
        }



        private DataTable GetDataForReport(MySqlCommand reportCommand)
        {
            try
            {
                openConnection();

                using (var adapter = new MySqlDataAdapter(reportCommand))
                {
                    DataTable reportTable = new DataTable();
                    adapter.Fill(reportTable);

                    closeConnection();

                    return reportTable;
                }
            }
            catch
            {
                return new DataTable();
            }
        }

        #endregion Queries for documents and reports.
    }
}