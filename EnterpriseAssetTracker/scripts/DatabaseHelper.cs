using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

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



        public List<string> GetUsers_fieldName()
        {
            return GetDirectories("SELECT name_economist FROM authorization ORDER BY name_economist ASC");
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



        public string selectEA_on_writeoff =
            "SELECT `enterprise_assets`.`id_enterprise_assets`, " +
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

        public string selectRepairEA = 
            "SELECT `id_repair`, " +
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
            "SELECT `id_writeoff_ea`, " +
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





















        public string selectOS_so_spis = "SELECT `ос`.`id_ос`, `ос`.`наименование` AS `Наименование ОС`, `ин` AS `Инвентарный номер`, `вид_ос`.`наименование` AS `Вид ОС`, `дата_принятия` AS `Дата принятия`, `пер_стоимость` AS `Первоначальная стоимость: руб.`, `спи` AS `СПИ: лет`, `норма_ндс` AS `Норма НДС: %`, `сумма_ндс` AS `Сумма НДС: руб.`, `год_сум_а` AS `ГСА: руб.`, `списание`.`дата_списания` AS `Дата списания` , `фин_стоимость` AS `Финальная стоимость: руб.`FROM `вид_ос` INNER JOIN (`ос` LEFT JOIN `списание` ON `ос`.`id_ос`=`списание`.`id_ос`) ON `вид_ос`.`id_вида_ос`=`ос`.`id_вида_ос`;";




        public string selectREM_OS = "SELECT `id_р`, `ремонт`.`id_ос`, `ремонт`.`id_вида_р`, `ос`.`наименование` AS `Наименование ОС`, `ин` AS `Инвентарный номер`, `вид_р`.`наименование` AS `Вид ремонта`, `дата_начала` AS `Дата начала ремонта`, `дата_окончания` AS `Дата окончания ремонта`, `сум_затрат` AS `Сумма затрат на ремонт: руб.` FROM `ремонт` INNER JOIN `ос` ON `ремонт`.`id_ос`=`ос`.`id_ос` INNER JOIN `вид_р` ON `ремонт`.`id_вида_р`=`вид_р`.`id_вида_р`";

        public string selectSPIS_OS = "SELECT `id_спис`, `ос`.`id_ос`, `причины`.`id_причины`, `ос`.`наименование` AS `Наименование ОС`, `ин` AS `Инвентарный номер`, `причины`.`наименование` AS `Причина списания`, `дата_списания` AS `Дата списания` FROM `списание` INNER JOIN `ос` ON `списание`.`id_ос`=`ос`.`id_ос` INNER JOIN `причины` ON `списание`.`id_причины`=`причины`.`id_причины`;";










        public string selectOS_bez_spis = "SELECT `ос`.`id_ос`, `ос`.`наименование` AS `Наименование ОС`, `ин` AS `Инвентарный номер`, `вид_ос`.`наименование` AS `Вид ОС`, `дата_принятия` AS `Дата принятия`, `пер_стоимость` AS `Первоначальная стоимость: руб.`, `спи` AS `СПИ: лет`, `норма_ндс` AS `Норма НДС: %`, `сумма_ндс` AS `Сумма НДС: руб.`, `год_сум_а` AS `ГСА: руб.`, `фин_стоимость` AS `Финальная стоимость: руб.`FROM `вид_ос` INNER JOIN `ос` ON `вид_ос`.`id_вида_ос`=`ос`.`id_вида_ос` WHERE `статус`=1;";
        
        public string selectRemU = "SELECT `id_р`, `ремонт`.`id_ос`, `ремонт`.`id_вида_р`, `ос`.`наименование` AS `Наименование ОС`, `ин` AS `Инвентарный номер`, `вид_р`.`наименование` AS `Вид ремонта`, `дата_начала` AS `Дата начала ремонта`, `дата_окончания` AS `Дата окончания ремонта`, `сум_затрат` AS `Сумма затрат на ремонт: руб.` FROM `ремонт` INNER JOIN `ос` ON `ремонт`.`id_ос`=`ос`.`id_ос` INNER JOIN `вид_р` ON `ремонт`.`id_вида_р`=`вид_р`.`id_вида_р` WHERE `ос`.`статус`=1";
        public string selectRemS = "SELECT `id_р`, `ремонт`.`id_ос`, `ремонт`.`id_вида_р`, `ос`.`наименование` AS `Наименование ОС`, `ин` AS `Инвентарный номер`, `вид_р`.`наименование` AS `Вид ремонта`, `дата_начала` AS `Дата начала ремонта`, `дата_окончания` AS `Дата окончания ремонта`, `сум_затрат` AS `Сумма затрат на ремонт: руб.` FROM `ремонт` INNER JOIN `ос` ON `ремонт`.`id_ос`=`ос`.`id_ос` INNER JOIN `вид_р` ON `ремонт`.`id_вида_р`=`вид_р`.`id_вида_р` WHERE `ос`.`статус`=0";


        public string selectMOL_Zakrep = "SELECT `id_закреп`, `ос`.`id_ос`, `мол`.`id_мол`, `ос`.`наименование` AS `Наименование ОС`, `ин` AS `Инвентарный номер`, CONCAT(`мол`.`ф`,' ',`мол`.`и`,' ',`мол`.`о`) AS `Материально ответственное лицо`, `должности`.`наименование` AS `Должность` FROM `ос` INNER JOIN (`закрепление` INNER JOIN (`мол` INNER JOIN `должности` ON `мол`.`id_должности`=`должности`.`id_должности`) ON `закрепление`.`id_мол`=`мол`.`id_мол` ) ON `ос`.`id_ос`=`закрепление`.`id_ос`;";

        public string selectAvtorisaciaVse = "SELECT `id_эко`, `fio` AS `ФИО работника`, `password` AS `Пароль`,`admin` FROM `авторизация`;";
        public string selectAvtorisaciaEko = "SELECT `id_эко`, `fio` AS `ФИО работника`, `password` AS `Пароль`,`admin` FROM `авторизация` WHERE `admin`=0;";
        public string selectAvtorisaciaAdmin = "SELECT `id_эко`, `fio` AS `ФИО работника`, `password` AS `Пароль`,`admin` FROM `авторизация` WHERE `admin`=1;";

        public string selectMOL = "SELECT `id_мол`, `мол`.`id_должности`, `ф` AS `Фамилия`, `и` AS `Имя`, `о` AS `Отчество`, `должности`.`наименование` AS `Должность` FROM `мол` INNER JOIN `должности` on `мол`.`id_должности`=`должности`.`id_должности`;";
    }
}
