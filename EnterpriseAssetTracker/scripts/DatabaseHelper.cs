using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;



namespace EnterpriseAssetTracker.Scripts
{
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




        //Start MainDataGridView queries

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
            "`total_cost` AS `ГСА: руб.`, " +
            "`writeoff_ea`.`writeoff_date` AS `Дата списания`, " +
            "`total_cost` AS `Финальная стоимость: руб.` " +
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


        //End MainDataGridView queries











        public string selectOS_so_spis = "SELECT `ос`.`id_ос`, `ос`.`наименование` AS `Наименование ОС`, `ин` AS `Инвентарный номер`, `вид_ос`.`наименование` AS `Вид ОС`, `дата_принятия` AS `Дата принятия`, `пер_стоимость` AS `Первоначальная стоимость: руб.`, `спи` AS `СПИ: лет`, `норма_ндс` AS `Норма НДС: %`, `сумма_ндс` AS `Сумма НДС: руб.`, `год_сум_а` AS `ГСА: руб.`, `списание`.`дата_списания` AS `Дата списания` , `фин_стоимость` AS `Финальная стоимость: руб.`FROM `вид_ос` INNER JOIN (`ос` LEFT JOIN `списание` ON `ос`.`id_ос`=`списание`.`id_ос`) ON `вид_ос`.`id_вида_ос`=`ос`.`id_вида_ос`;";





        public string selectSPIS_OS = "SELECT `id_спис`, `ос`.`id_ос`, `причины`.`id_причины`, `ос`.`наименование` AS `Наименование ОС`, `ин` AS `Инвентарный номер`, `причины`.`наименование` AS `Причина списания`, `дата_списания` AS `Дата списания` FROM `списание` INNER JOIN `ос` ON `списание`.`id_ос`=`ос`.`id_ос` INNER JOIN `причины` ON `списание`.`id_причины`=`причины`.`id_причины`;";




        public string selectOS_bez_spis = "SELECT `ос`.`id_ос`, `ос`.`наименование` AS `Наименование ОС`, `ин` AS `Инвентарный номер`, `вид_ос`.`наименование` AS `Вид ОС`, `дата_принятия` AS `Дата принятия`, `пер_стоимость` AS `Первоначальная стоимость: руб.`, `спи` AS `СПИ: лет`, `норма_ндс` AS `Норма НДС: %`, `сумма_ндс` AS `Сумма НДС: руб.`, `год_сум_а` AS `ГСА: руб.`, `фин_стоимость` AS `Финальная стоимость: руб.`FROM `вид_ос` INNER JOIN `ос` ON `вид_ос`.`id_вида_ос`=`ос`.`id_вида_ос` WHERE `статус`=1;";

        public string selectRemU = "SELECT `id_р`, `ремонт`.`id_ос`, `ремонт`.`id_вида_р`, `ос`.`наименование` AS `Наименование ОС`, `ин` AS `Инвентарный номер`, `вид_р`.`наименование` AS `Вид ремонта`, `дата_начала` AS `Дата начала ремонта`, `дата_окончания` AS `Дата окончания ремонта`, `сум_затрат` AS `Сумма затрат на ремонт: руб.` FROM `ремонт` INNER JOIN `ос` ON `ремонт`.`id_ос`=`ос`.`id_ос` INNER JOIN `вид_р` ON `ремонт`.`id_вида_р`=`вид_р`.`id_вида_р` WHERE `ос`.`статус`=1";
        public string selectRemS = "SELECT `id_р`, `ремонт`.`id_ос`, `ремонт`.`id_вида_р`, `ос`.`наименование` AS `Наименование ОС`, `ин` AS `Инвентарный номер`, `вид_р`.`наименование` AS `Вид ремонта`, `дата_начала` AS `Дата начала ремонта`, `дата_окончания` AS `Дата окончания ремонта`, `сум_затрат` AS `Сумма затрат на ремонт: руб.` FROM `ремонт` INNER JOIN `ос` ON `ремонт`.`id_ос`=`ос`.`id_ос` INNER JOIN `вид_р` ON `ремонт`.`id_вида_р`=`вид_р`.`id_вида_р` WHERE `ос`.`статус`=0";



        public string selectAvtorisaciaVse = "SELECT `id_эко`, `fio` AS `ФИО работника`, `password` AS `Пароль`,`admin` FROM `авторизация`;";
        public string selectAvtorisaciaEko = "SELECT `id_эко`, `fio` AS `ФИО работника`, `password` AS `Пароль`,`admin` FROM `авторизация` WHERE `admin`=0;";
        public string selectAvtorisaciaAdmin = "SELECT `id_эко`, `fio` AS `ФИО работника`, `password` AS `Пароль`,`admin` FROM `авторизация` WHERE `admin`=1;";










        //Start GetFieldName queries for Directories

        public List<string> GetUsers_fieldName(string optionalWHERE)
        {
            return GetDirectories($"SELECT name_economist FROM authorization {optionalWHERE} ORDER BY name_economist ASC");
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

        //End GetFieldName queries for Directories









        //Start GetIdByName queries for operation INSERT and UPDATE


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

        private int GetIdByName_ForAssetCustodian(string query, (string,string, string) searchedName)
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


        //End GetIdByName queries for operation INSERT and UPDATE






        //Start queries for documents and reports

        public DataTable GetReport_EAassignedACustodian(int id_AssetCustodian)
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

            reportCommand.Parameters.AddWithValue("@id_AssetCustodian", id_AssetCustodian);

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



        //End queries for documents and reports


    }
}
