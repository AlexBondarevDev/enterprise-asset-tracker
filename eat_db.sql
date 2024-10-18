CREATE TABLE `eat_db`.`authorization`( 
`id_economist` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
`name_economist` VARCHAR(40) NOT NULL,
`password` VARCHAR(8) NOT NULL,
`isAdmin` BOOLEAN NOT NULL
) ENGINE = InnoDB;

INSERT INTO `authorization` (`id_economist`, `name_economist`, `password`, `isAdmin`) VALUES
(NULL, 'Бондарев Александр Андреевич', '111', '1'),
(NULL, 'Иваненко Жанна Викторовна', '111', '1'),
(NULL, 'Юрченко Инга Ивановна', '111', '0');

-- -------------------------------------------------------------------------

CREATE TABLE `eat_db`.`access_code` (
`id_access_code` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
`value` VARCHAR(20) NOT NULL
) ENGINE = InnoDB;

INSERT INTO `access_code` (`id_access_code`, `value`) VALUES (NULL, '1234');

-- -------------------------------------------------------------------------

CREATE TABLE `eat_db`.`types_ea` (
  `id_type_ea` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

INSERT INTO `types_ea` (`id_type_ea`, `name`) VALUES
(1, 'ОС общего назначения'),
(2, 'Производственный инвентарь'),
(3, 'Хозяйственный инвентарь'),
(4, 'Передаточные устройства'),
(5, 'Транспортные средства'),
(6, 'Машины и оборудование');

-- -------------------------------------------------------------------------

CREATE TABLE `eat_db`.`enterprise_assets` (
  `id_enterprise_assets` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `asset_tag` int(10) NOT NULL,
  `id_type_ea` int(11) NOT NULL,
  `receipt_date` date NOT NULL,
  `initial_cost` decimal(15, 2) NOT NULL,
  `annual_depreciation_amount` decimal(15, 2) NOT NULL,
  `name` varchar(150) NOT NULL,
  `vat_rate` int(11) NOT NULL,
  `service_life` int(11) NOT NULL,
  `vat_amount` decimal(15, 2) NOT NULL,
  `total_cost` decimal(15, 2) NOT NULL,
  `status` int(11) NOT NULL,
  CONSTRAINT `types_ea_enterprise_assets` FOREIGN KEY (`id_type_ea`) REFERENCES `types_ea` (`id_type_ea`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

INSERT INTO `enterprise_assets` (`id_enterprise_assets`, `asset_tag`, `id_type_ea`, `receipt_date`, `initial_cost`, `annual_depreciation_amount`, `name`, `vat_rate`, `service_life`, `vat_amount`, `total_cost`, `status`) VALUES
(1, 105001, 6, '2018-09-14', 10000, 1100, 'Фрезерный станок', 10, 10, 1000, 11000, 1),
(2, 101001, 2, '2017-11-14', 500, 60, 'Сварочный аппарат', 10, 5, 50, 550, 0),
(17, 102222, 2, '2015-02-03', 1335, 304.38, 'Резак', 14, 5, 186.9, 1521.9, 1),
(18, 101221, 1, '2015-02-27', 145, 14.5, 'Набор инструментов', 10, 11, 14.5, 159.5, 0),
(19, 103001, 3, '2015-02-10', 230, 39.43, 'Стальной тросс', 20, 7, 46, 276, 0),
(20, 104645, 4, '2015-03-11', 11489, 880.82, 'Транспортёр', 15, 15, 1723.35, 13212.35, 1),
(21, 103122, 3, '2015-03-03', 420, 46.2, 'Тележка', 10, 10, 42, 462, 1),
(22, 103147, 3, '2015-03-01', 23, 3.61, 'Набор крепежей', 10, 7, 2.3, 25.3, 0),
(23, 103123, 3, '2015-03-22', 150, 6.6, 'Стол компьютерный', 10, 25, 15, 165, 0),
(24, 105002, 5, '2015-04-06', 15260, 1338.18, 'Погрузчик', 14, 13, 2136.4, 17396.4, 1),
(25, 101103, 1, '2015-04-12', 412, 151.07, 'Колёсный вал', 10, 3, 41.2, 453.2, 0),
(26, 102146, 2, '2015-05-08', 19846.23, 2262.47, 'Станок для обработки металла', 14, 10, 2778.47, 22624.7, 1),
(27, 103698, 3, '2015-07-04', 123, 27.06, 'Набор инструментов', 10, 5, 12.3, 135.3, 1),
(28, 105100, 5, '2015-08-17', 18794, 2142.52, 'Автомобиль маз', 14, 10, 2631.16, 21425.16, 1),
(29, 101163, 1, '2015-09-10', 1000, 122.22, 'Компьютер asus', 10, 9, 100, 1100, 0),
(30, 101005, 1, '2016-07-14', 400, 88, 'Принтер samsung', 10, 5, 40, 440, 1),
(31, 101006, 1, '2016-09-21', 365.13, 138.75, 'Сканер aser', 14, 3, 51.12, 416.25, 1),
(32, 103324, 3, '2016-11-24', 41, 4.51, 'Стул металличесский', 10, 10, 4.1, 45.1, 0),
(33, 103148, 3, '2017-03-29', 135, 54, 'Тележка', 20, 3, 27, 162, 0),
(34, 102142, 2, '2017-08-18', 1345, 191.66, 'Электролобзик', 14, 8, 188.3, 1533.3, 1),
(35, 103648, 3, '2017-08-30', 560, 61.6, 'Шкаф', 10, 10, 56, 616, 1),
(36, 103120, 3, '2017-10-05', 13, 4.77, 'Стул кожанный', 10, 3, 1.3, 14.3, 1),
(37, 104145, 4, '2017-10-20', 137, 32.88, 'Сеть компьютерная', 20, 5, 27.4, 164.4, 1),
(38, 106896, 6, '2018-03-02', 15023, 2879.41, 'Малый погрузчик', 15, 6, 2253.45, 17276.45, 1),
(39, 106198, 6, '2018-03-24', 134, 29.48, 'Переносная лампа накаливания', 10, 5, 13.4, 147.4, 1),
(40, 102489, 2, '2018-05-18', 54, 15.39, 'Инструменты', 14, 4, 7.56, 61.56, 1),
(41, 101795, 1, '2018-05-27', 14, 5.13, 'Тумбочка дб', 10, 3, 1.4, 15.4, 1),
(42, 101635, 1, '2018-07-05', 134, 38.19, 'Кресло', 14, 4, 18.76, 152.76, 1),
(43, 104634, 4, '2018-07-27', 478, 109.94, 'Линия связи', 15, 5, 71.7, 549.7, 1),
(44, 102934, 2, '2018-09-19', 875, 192.5, 'Сварочный аппарат', 10, 5, 87.5, 962.5, 1),
(45, 106645, 6, '2018-09-02', 654, 188.02, 'Генератор', 15, 4, 98.1, 752.1, 1),
(46, 101317, 1, '2018-10-11', 54, 21.6, 'Тумбочка дб', 20, 3, 10.8, 64.8, 0),
(47, 106698, 6, '2019-03-13', 810, 230.85, 'Дробитель строительный', 14, 4, 113.4, 923.4, 1),
(48, 104698, 4, '2020-01-08', 10050, 3685, 'Теплопровод', 10, 3, 1005, 11055, 1),
(49, 101431, 1, '2020-02-02', 15000, 1916.67, 'Компьютер lenovo', 15, 9, 2250, 17250, 1),
(50, 101734, 1, '2020-05-14', 14694, 5387.8, 'Ноутбук lenovo', 10, 3, 1469.4, 16163.4, 1),
(51, 101433, 1, '2020-07-24', 320, 91.2, 'Монитор xiomi', 14, 4, 44.8, 364.8, 1),
(52, 103962, 3, '2021-02-11', 132, 37.62, 'Стол компьютерный', 14, 4, 18.48, 150.48, 1),
(53, 103687, 3, '2021-02-07', 470, 135.12, 'Уборочный агрегат', 15, 4, 70.5, 540.5, 1),
(54, 102922, 2, '2021-05-13', 1450, 551, 'Пуливизатор', 14, 3, 203, 1653, 1),
(55, 102444, 2, '2021-07-02', 1539, 423.22, 'Лакокрасочный расспылитель', 10, 4, 153.9, 1692.9, 1),
(56, 103789, 3, '2021-07-23', 312, 118.56, 'Столик для ноутбука', 14, 3, 43.68, 355.68, 1),
(57, 106745, 6, '2021-07-31', 968, 580.8, 'Стационарный телефон', 20, 2, 193.6, 1161.6, 1),
(58, 101741, 1, '2021-09-07', 364, 414.96, 'Звуковая система', 14, 1, 50.96, 414.96, 1),
(59, 103468, 3, '2021-09-10', 3156, 347.16, 'Венчурная система', 10, 10, 315.6, 3471.6, 1),
(60, 102131, 2, '2021-11-30', 1212, 460.56, 'Станок', 14, 3, 169.68, 1381.68, 1);

-- -------------------------------------------------------------------------

CREATE TABLE `eat_db`.`reasons_writeoff` (
  `id_reason_writeoff` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `name` varchar(150) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

INSERT INTO `reasons_writeoff` (`id_reason_writeoff`, `name`) VALUES
(1, 'Преждевременный износ'),
(2, 'Окончание СПИ'),
(3, 'Моральное устаревание'),
(4, 'Технологическое устаревание'),
(5, 'Передача или продажа');

-- -------------------------------------------------------------------------

CREATE TABLE `eat_db`.`writeoff_ea` (
  `id_writeoff_ea` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `id_enterprise_assets` int(11) NOT NULL,
  `id_reason_writeoff` int(11) NOT NULL,
  `writeoff_date` date NOT NULL,
  CONSTRAINT `ea_writeoff_ea` FOREIGN KEY (`id_enterprise_assets`) REFERENCES `enterprise_assets` (`id_enterprise_assets`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `reasons_writeoff_ea` FOREIGN KEY (`id_reason_writeoff`) REFERENCES `reasons_writeoff` (`id_reason_writeoff`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

INSERT INTO `writeoff_ea` (`id_writeoff_ea`, `id_enterprise_assets`, `id_reason_writeoff`, `writeoff_date`) VALUES
(1, 2, 1, '2021-11-22'),
(2, 23, 1, '2017-06-22'),
(3, 29, 3, '2017-06-03'),
(4, 19, 5, '2020-03-05'),
(5, 32, 2, '2020-05-22'),
(6, 25, 2, '2021-03-05'),
(7, 33, 1, '2021-04-23'),
(8, 22, 1, '2019-02-07'),
(9, 46, 4, '2018-10-25'),
(10, 18, 5, '2021-02-26');

-- -------------------------------------------------------------------------

CREATE TABLE `eat_db`.`types_repair` (
  `id_type_repair` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `name` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

INSERT INTO `types_repair` (`id_type_repair`, `name`) VALUES
(1, 'Устранение локальной неисправности'),
(3, 'Замена основного узла'),
(4, 'Восстановление лакокрасочного покрытия'),
(5, 'Модернизация комплектующих'),
(6, 'Технологическое улучшение'),
(7, 'Замена опорного аппарата');

-- -------------------------------------------------------------------------

CREATE TABLE `eat_db`.`repair` (
  `id_repair` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `id_enterprise_assets` int(11) NOT NULL,
  `id_type_repair` int(11) NOT NULL,
  `start_date` date NOT NULL,
  `end_date` date DEFAULT NULL,
  `amount_costs` decimal(15, 2) DEFAULT NULL,
  CONSTRAINT `ea_repair` FOREIGN KEY (`id_enterprise_assets`) REFERENCES `enterprise_assets` (`id_enterprise_assets`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `types_repair_repair` FOREIGN KEY (`id_type_repair`) REFERENCES `types_repair` (`id_type_repair`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

INSERT INTO `repair` (`id_repair`, `id_enterprise_assets`, `id_type_repair`, `start_date`, `end_date`, `amount_costs`) VALUES
(1, 1, 4, '2019-09-07', '2019-09-19', 1830.6),
(2, 2, 4, '2021-11-01', '2021-11-03', 1615.78),
(4, 1, 3, '2021-11-01', '2021-11-20', 1830.6),
(5, 20, 1, '2016-04-14', '2016-05-06', 47),
(6, 21, 4, '2018-06-06', '2018-06-08', 47),
(7, 26, 6, '2017-05-05', NULL, NULL),
(8, 28, 7, '2017-05-20', NULL, NULL),
(9, 38, 5, '2020-01-16', NULL, NULL);

-- -------------------------------------------------------------------------

CREATE TABLE `eat_db`.`positions` (
  `id_position` int(11) NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `name` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

INSERT INTO `positions` (`id_position`, `name`) VALUES
(1, 'Директор'),
(2, 'Сотрудник общего назначения'),
(3, 'Главный инженер'),
(4, 'Инженер-технолог'),
(5, 'Наладчик оборудования'),
(6, 'Аналитик'),
(7, 'Бухгалтер'),
(8, 'Экономист'),
(9, 'Уборщик');

-- -------------------------------------------------------------------------

CREATE TABLE `eat_db`.`asset_custodian` (
  `id_asset_custodian` int(11) NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `id_position` int(11) NOT NULL,
  `surname` varchar(30) NOT NULL,
  `name` varchar(30) NOT NULL,
  `father_name` varchar(30) NOT NULL,
  CONSTRAINT `positions_asset_custodian` FOREIGN KEY (`id_position`) REFERENCES `positions` (`id_position`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

INSERT INTO `asset_custodian` (`id_asset_custodian`, `id_position`, `surname`, `name`, `father_name`) VALUES
(1, 1, 'Арещенко', 'Татьяна', 'Ивановна'),
(2, 4, 'Карпако', 'Николай', 'Михайловия'),
(4, 3, 'Иванов', 'Дмитрий', 'Николаевич'),
(5, 5, 'Кирилов', 'Иван', 'Павлович');

-- -------------------------------------------------------------------------

CREATE TABLE `eat_db`.`assignment_ea` (
  `id_assignment_ea` int(11) NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `id_enterprise_assets` int(11) NOT NULL,
  `id_asset_custodian` int(11) NOT NULL,
  CONSTRAINT `assignment_ea_ea` FOREIGN KEY (`id_enterprise_assets`) REFERENCES `enterprise_assets` (`id_enterprise_assets`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `assignment_ea_asset_custodian` FOREIGN KEY (`id_asset_custodian`) REFERENCES `asset_custodian` (`id_asset_custodian`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

INSERT INTO `assignment_ea` (`id_assignment_ea`, `id_enterprise_assets`, `id_asset_custodian`) VALUES
(1, 1, 2),
(18, 17, 4),
(21, 20, 1),
(22, 21, 2),
(25, 24, 1),
(27, 26, 2),
(28, 27, 4),
(29, 28, 1),
(31, 30, 2),
(32, 31, 2),
(35, 34, 2),
(36, 35, 1),
(37, 36, 2),
(38, 37, 1),
(39, 38, 2),
(40, 39, 4),
(41, 40, 1),
(42, 41, 1),
(43, 42, 2),
(44, 43, 1),
(45, 44, 4),
(46, 45, 4),
(48, 47, 5),
(49, 48, 1),
(50, 49, 1),
(51, 50, 5),
(52, 51, 1),
(53, 52, 1),
(54, 53, 2),
(55, 54, 1),
(56, 55, 4),
(57, 56, 1),
(58, 57, 4),
(59, 58, 2),
(60, 59, 1),
(61, 60, 2);

-- -------------------------------------------------------------------------
--
-- Triggers and Procedures
--

DELIMITER $$

CREATE TRIGGER `Transfer_of_responsibility`
BEFORE DELETE ON `asset_custodian`
FOR EACH ROW
UPDATE `assignment_ea`
	SET `id_asset_custodian` = '1'
    	WHERE `assignment_ea`.`id_asset_custodian` = `OLD`.`id_asset_custodian`
$$

DELIMITER ;



DELIMITER $$

CREATE TRIGGER `Transfer_of_positions`
BEFORE DELETE ON `positions`
FOR EACH ROW
UPDATE `asset_custodian`
	SET `id_position` = '2'
    	WHERE `asset_custodian`.`id_position` = `OLD`.`id_position`
$$

DELIMITER ;



DELIMITER $$

CREATE TRIGGER `Transfer_of_reasons_writeoff`
BEFORE DELETE ON `reasons_writeoff`
FOR EACH ROW
UPDATE `writeoff_ea`
	SET `id_reason_writeoff` = '1'
    	WHERE `writeoff_ea`.`id_reason_writeoff` = `OLD`.`id_reason_writeoff`
$$

DELIMITER ;



DELIMITER $$

CREATE TRIGGER `Transfer_of_types_ea`
BEFORE DELETE ON `types_ea`
FOR EACH ROW
UPDATE `enterprise_assets`
	SET `id_type_ea` = '1'
    	WHERE `enterprise_assets`.`id_type_ea` = `OLD`.`id_type_ea`
$$

DELIMITER ;



DELIMITER $$

CREATE TRIGGER `Transfer_of_types_repair`
BEFORE DELETE ON `types_repair`
FOR EACH ROW
UPDATE `repair`
	SET `id_type_repair` = '1'
    	WHERE `repair`.`id_type_repair` = `OLD`.`id_type_repair`
$$

DELIMITER ;



DELIMITER $$

CREATE TRIGGER `after_writeoffEA`
AFTER INSERT ON `writeoff_ea`
FOR EACH ROW
BEGIN
    UPDATE `enterprise_assets`
    SET `status` = 0
    WHERE `enterprise_assets`.`id_enterprise_assets` = NEW.`id_enterprise_assets`;

    DELETE FROM `assignment_ea`
    WHERE `assignment_ea`.`id_enterprise_assets` = NEW.`id_enterprise_assets`;

    UPDATE `repair`
    SET `end_date` = NEW.`writeoff_date`, `amount_costs` = 50
    WHERE `repair`.`id_enterprise_assets` = NEW.`id_enterprise_assets` AND `repair`.`end_date` IS NULL;
END $$

DELIMITER ;



DELIMITER $$

CREATE TRIGGER `after_update_writeoffEA`
AFTER UPDATE ON `writeoff_ea`
FOR EACH ROW
BEGIN
    UPDATE `repair`
    SET `end_date` = NEW.`writeoff_date`
    WHERE `repair`.`id_enterprise_assets` = NEW.`id_enterprise_assets`
    AND (`repair`.`end_date` IS NULL OR `repair`.`end_date` > NEW.`writeoff_date`);
END $$

DELIMITER ;



DELIMITER $$

CREATE PROCEDURE `GetData_YearSaldoReport`(IN `input_year` INT)
BEGIN
    DROP TEMPORARY TABLE IF EXISTS `temp_receipt`;
    DROP TEMPORARY TABLE IF EXISTS `temp_writeoff`;
    DROP TEMPORARY TABLE IF EXISTS `temp_depreciation`;
    DROP TEMPORARY TABLE IF EXISTS `temp_repair`;
    DROP TEMPORARY TABLE IF EXISTS `temp_month_data`;


    CREATE TEMPORARY TABLE `temp_receipt` (`month` INT, `receipt_amount` DECIMAL(15, 2));
    CREATE TEMPORARY TABLE `temp_writeoff` (`month` INT, `writeoff_amount` DECIMAL(15, 2));
    CREATE TEMPORARY TABLE `temp_depreciation` (`month` INT, `depreciation_amount` DECIMAL(15, 2));
    CREATE TEMPORARY TABLE `temp_repair` (`month` INT, `repair_amount` DECIMAL(15, 2));
    CREATE TEMPORARY TABLE `temp_month_data` (`month` INT, `receipt` DECIMAL(15, 2), `writeoff` DECIMAL(15, 2), `depreciation` DECIMAL(15, 2), `repair_costs` DECIMAL(15, 2), `total` DECIMAL(15, 2));


    INSERT INTO `temp_receipt` (`month`, `receipt_amount`)
    SELECT MONTH(`receipt_date`), SUM(`total_cost`)
    FROM `enterprise_assets`
    WHERE YEAR(`receipt_date`) = `input_year`
    GROUP BY MONTH(`receipt_date`);


    INSERT INTO `temp_writeoff` (`month`, `writeoff_amount`)
    SELECT MONTH(`writeoff_date`), SUM(`total_cost`)
    FROM `writeoff_ea` 
    INNER JOIN `enterprise_assets` ON `writeoff_ea`.`id_enterprise_assets` = `enterprise_assets`.`id_enterprise_assets`
    WHERE YEAR(`writeoff_date`) = `input_year`
    GROUP BY MONTH(`writeoff_date`);


    INSERT INTO `temp_depreciation` (`month`, `depreciation_amount`)
    SELECT MONTH(`writeoff_date`),
           SUM(CASE
                   WHEN `service_life` - (YEAR(`writeoff_date`) - YEAR(`receipt_date`) + 1) > 0
                   THEN (YEAR(`writeoff_date`) - YEAR(`receipt_date`) + 1) * `annual_depreciation_amount`
                   ELSE `total_cost`
               END)
    FROM `writeoff_ea` 
    INNER JOIN `enterprise_assets` ON `writeoff_ea`.`id_enterprise_assets` = `enterprise_assets`.`id_enterprise_assets`
    WHERE YEAR(`writeoff_date`) = `input_year`
    GROUP BY MONTH(`writeoff_date`);


    INSERT INTO `temp_repair` (`month`, `repair_amount`)
    SELECT MONTH(`end_date`), SUM(`amount_costs`)
    FROM `repair`
    WHERE YEAR(`end_date`) = `input_year`
    GROUP BY MONTH(`end_date`);


    INSERT INTO `temp_month_data` (`month`, `receipt`, `writeoff`, `depreciation`, `repair_costs`, `total`)
    SELECT
        `months`.`month`,
        IFNULL(`temp_receipt`.`receipt_amount`, 0),
        IFNULL(`temp_writeoff`.`writeoff_amount`, 0),
        IFNULL(`temp_depreciation`.`depreciation_amount`, 0),
        IFNULL(`temp_repair`.`repair_amount`, 0),
        (IFNULL(`temp_receipt`.`receipt_amount`, 0) + IFNULL(`temp_depreciation`.`depreciation_amount`, 0) - IFNULL(`temp_writeoff`.`writeoff_amount`, 0) - IFNULL(`temp_repair`.`repair_amount`, 0))
    FROM
        (SELECT 1 AS `month` UNION SELECT 2 UNION SELECT 3 UNION SELECT 4 UNION SELECT 5 UNION SELECT 6 UNION SELECT 7 UNION SELECT 8 UNION SELECT 9 UNION SELECT 10 UNION SELECT 11 UNION SELECT 12) AS `months`
    LEFT JOIN `temp_receipt` ON `months`.`month` = `temp_receipt`.`month`
    LEFT JOIN `temp_writeoff` ON `months`.`month` = `temp_writeoff`.`month`
    LEFT JOIN `temp_depreciation` ON `months`.`month` = `temp_depreciation`.`month`
    LEFT JOIN `temp_repair` ON `months`.`month` = `temp_repair`.`month`
    ORDER BY `month`;


    SELECT 
        `month`,
        SUM(`receipt`) AS `total_receipt`,
        SUM(`writeoff`) AS `total_writeoff`,
        SUM(`depreciation`) AS `total_depreciation`,
        SUM(`repair_costs`) AS `total_repair_costs`,
        SUM(`total`) AS `total_total`
    FROM `temp_month_data`
    GROUP BY `month` WITH ROLLUP;

    DROP TEMPORARY TABLE IF EXISTS `temp_receipt`;
    DROP TEMPORARY TABLE IF EXISTS `temp_writeoff`;
    DROP TEMPORARY TABLE IF EXISTS `temp_depreciation`;
    DROP TEMPORARY TABLE IF EXISTS `temp_repair`;
    DROP TEMPORARY TABLE IF EXISTS `temp_month_data`;

END $$

DELIMITER ;



DELIMITER $$

CREATE PROCEDURE `GetData_AnnualDynamicsCapitalReport`(IN `startYear` INT, IN `endYear` INT)
BEGIN
    DECLARE `i` INT;
    
    DROP TEMPORARY TABLE IF EXISTS `temp_capital_data`;
    
    CREATE TEMPORARY TABLE IF NOT EXISTS `temp_capital_data` (`reportYear` INT, `total_capital` DECIMAL(15, 2));
    
    SET `i` = `startYear`;
    
    WHILE `i` <= `endYear` DO
        
        INSERT INTO `temp_capital_data` (`reportYear`, `total_capital`)
        SELECT `i`, IFNULL(SUM(`enterprise_assets`.`total_cost`), 0)
        FROM `enterprise_assets` 
        LEFT JOIN `writeoff_ea` ON `enterprise_assets`.`id_enterprise_assets` = `writeoff_ea`.`id_enterprise_assets`
        WHERE YEAR(`enterprise_assets`.`receipt_date`) <= `i` 
        AND (`enterprise_assets`.`status` = 1 OR YEAR(`writeoff_ea`.`writeoff_date`) > `i`);
        
        SET `i` = `i` + 1;
        
    END WHILE;
    
    SELECT * FROM `temp_capital_data`;
    
    DROP TEMPORARY TABLE IF EXISTS `temp_capital_data`;
END $$

DELIMITER ;