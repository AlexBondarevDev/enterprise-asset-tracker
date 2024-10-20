using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Windows.Media;
using EnterpriseAssetTracker.Scripts;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;
using Bunifu.UI.WinForms;



namespace EnterpriseAssetTracker.Forms
{
    /// <summary>
    /// Contains key analytical reports and charts, such as annual dynamics and turnover balance statements.
    /// </summary>
    public partial class AnalyticForm : Form
    {
        #region Component initialization.

        public string userName;

        DatabaseHelper dbHelper = new DatabaseHelper();

        public AnalyticForm(string userName)
        {
            InitializeComponent();

            SetValueInDatePickers();

            string[] transformUserName = userName.Split(' ');
            this.userName = $"{transformUserName[0]} {transformUserName[1][0]}. {transformUserName[2][0]}.";
        }

        private void SetValueInDatePickers()
        {
            BunifuDatePicker[] datePickers = {
                bunifuReportStartDatePicker,
                bunifuReportEndDatePicker,
                bunifuCreateReport_YearSaldoDatePicker,
                bunifuAnnualDynamicEndDatePicker
            };

            DateTime currentDateTime = DateTime.Now;

            foreach (var datePicker in datePickers)
            {
                datePicker.Value = currentDateTime;
                datePicker.MaxDate = currentDateTime;
            }
        }

        #endregion Component initialization.



        #region Realization of report selection for creation.

        private void BunifuSelectReportDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (bunifuSelectReportDropdown.Text)
            {
                case "Список поступления/списания ОС":
                    {
                        setReportDatePanel.Visible = true;
                        createReport_YearSaldoPanel.Visible = false;
                        reportCartesianChart.Visible = false;
                        pieChartRecordPanel.Visible = false;
                        setDateForAnnualDinamicPanel.Visible = false;
                        break;
                    }
                case "Оборотное сальдо по итогам года":
                    {
                        setReportDatePanel.Visible = false;
                        createReport_YearSaldoPanel.Visible = true;
                        reportCartesianChart.Visible = false;
                        pieChartRecordPanel.Visible = false;
                        setDateForAnnualDinamicPanel.Visible = false;
                        break;
                    }
                case "Отношение ответственности МОЛ":
                    {
                        CreateReport_ResponsibilityRelationshipAC();
                        setReportDatePanel.Visible = false;
                        createReport_YearSaldoPanel.Visible = false;
                        reportCartesianChart.Visible = false;
                        pieChartRecordPanel.Visible = true;
                        setDateForAnnualDinamicPanel.Visible = false;
                        break;
                    }
                default:
                    {
                        reportCartesianChart.Series.Clear();
                        reportCartesianChart.AxisX.Clear();

                        setReportDatePanel.Visible = false;
                        createReport_YearSaldoPanel.Visible = false;
                        reportCartesianChart.Visible = true;
                        pieChartRecordPanel.Visible = false;
                        setDateForAnnualDinamicPanel.Visible = true;
                        break;
                    }
            }

            PlayAnimation();
        }

        private void PlayAnimation()
        {
            if (bunifuSelectReportDropdown.Text == "Список поступления/списания ОС")
            {
                setReportDatePanel.Visible = false;
                bunifuTransition.ShowSync(setReportDatePanel, false, BunifuAnimatorNS.Animation.Transparent);
            }
            else if (bunifuSelectReportDropdown.Text == "Оборотное сальдо по итогам года")
            {
                createReport_YearSaldoPanel.Visible = false;
                bunifuTransition.ShowSync(createReport_YearSaldoPanel, false, BunifuAnimatorNS.Animation.Transparent);
            }
            else if (bunifuSelectReportDropdown.Text != "Отношение ответственности МОЛ")
            {
                setDateForAnnualDinamicPanel.Visible = false;
                bunifuTransition.ShowSync(setDateForAnnualDinamicPanel, false, BunifuAnimatorNS.Animation.Transparent);
            }
            else
            {
                bunifuTransition.HideSync(setReportDatePanel, false, BunifuAnimatorNS.Animation.Transparent);
                setReportDatePanel.Visible = false;

                bunifuTransition.HideSync(createReport_YearSaldoPanel, false, BunifuAnimatorNS.Animation.Transparent);
                createReport_YearSaldoPanel.Visible = false;

                bunifuTransition.HideSync(setDateForAnnualDinamicPanel, false, BunifuAnimatorNS.Animation.Transparent);
                setDateForAnnualDinamicPanel.Visible = false;
            }
        }

        #endregion Realization of report selection for creation.



        #region Realization of report generation.

        private void BunifuReportStartDatePicker_ValueChanged(object sender, EventArgs e)
        {
            bunifuReportEndDatePicker.MinDate = bunifuReportStartDatePicker.Value;
        }

        private void BunifuReportEndDatePicker_ValueChanged(object sender, EventArgs e)
        {
            bunifuReportStartDatePicker.MaxDate = bunifuReportEndDatePicker.Value;
        }

        private void BunifuCreateReport_ReceiptWriteoffEAList_Button_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Вы уверены, что хотите сформировать отчёт на даты с {bunifuReportStartDatePicker.Value:dd.MM.yyyy} по {bunifuReportEndDatePicker.Value:dd.MM.yyyy}?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            MessageBox.Show("Начало процесса формирования документа!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            bunifuCreateReport_ReceiptWriteoffEAList_Button.Enabled = false;

            string newFileName = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\Отчёт о поступлении-списании ОС с {bunifuReportStartDatePicker.Value:dd.MM.yyyy} по {bunifuReportEndDatePicker.Value:dd.MM.yyyy}.docx";

            WordHelper wordHelper = new WordHelper(Application.StartupPath + @"\\document_templates\Report_ReceiptWriteoffEAList.docx");



            DateTime currentDateTime = DateTime.Now;

            var items = new Dictionary<string, string>
                    {
                        {"$docNumber$", $"№{currentDateTime.Day}-{currentDateTime.Minute}"},
                        {"$createDate$", $"{currentDateTime:dd.MM.yyyy}"},
                        {"$startDate$", $"{bunifuReportStartDatePicker.Value:dd.MM.yyyy}"},
                        {"$endDate$", $"{bunifuReportEndDatePicker.Value:dd.MM.yyyy}"},
                        {"$economistName$", userName}
                    };



            DataTable reportReceiptTable = dbHelper.GetReport_RWEAList_ReceiptEA(bunifuReportStartDatePicker.Value, bunifuReportEndDatePicker.Value);

            DataTable reportWriteoffTable = dbHelper.GetReport_RWEAList_WriteoffEA(bunifuReportStartDatePicker.Value, bunifuReportEndDatePicker.Value);

            if (reportReceiptTable == null || reportWriteoffTable == null)
            {
                return;
            }



            if (wordHelper.Process(items, newFileName))
            {
                wordHelper.InsertTable(reportReceiptTable, 2);

                wordHelper.InsertTable(reportWriteoffTable, 3);

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

            bunifuCreateReport_ReceiptWriteoffEAList_Button.Enabled = true;
        }



        private void BunifuCreateReport_YearSaldoButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Вы уверены, что хотите сформировать годовую оборотно-сальдовую ведомость на {bunifuCreateReport_YearSaldoDatePicker.Value:yyyy} год?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            MessageBox.Show("Начало процесса формирования документа!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            try
            {
                int reportYear = Convert.ToInt32(bunifuCreateReport_YearSaldoDatePicker.Value.Year);
                DataTable reportYearSaldoTable = dbHelper.GetReport_YearSaldo(reportYear);


                string reportTemplatePath = Application.StartupPath + @"\\document_templates\Report_YearSaldo.xlsx";
                string newReportPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\Оборотно-сальдовая ведомость за {reportYear} год.xlsx";

                File.Copy(reportTemplatePath, newReportPath, true);


                Microsoft.Office.Interop.Excel.Application ExcelApp = null;
                Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook = null;

                try
                {
                    ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                    ExcelWorkBook = ExcelApp.Workbooks.Open(newReportPath);
                    Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);

                    ExcelApp.Cells[4, 2].Value += $" с 01.01.{reportYear} по 31.12.{reportYear}";
                    ExcelApp.Cells[7, 2].Value += $" {DateTime.Now:dd.MM.yyyy}";

                    for (int i = 12; i < 24; i++)
                    {
                        ExcelApp.Cells[i, 2].Value += reportYear;
                    }

                    int rowsTemplateShift = 12;
                    int columnTemplateShift = 2;
                    int reportDataRowsCount = reportYearSaldoTable.Rows.Count;
                    int reportDataColumnsCount = reportYearSaldoTable.Columns.Count;

                    for (int i = 0; i < reportDataRowsCount; i++)
                    {
                        for (int j = 1; j < reportDataColumnsCount; j++)
                        {
                            ExcelApp.Cells[i + rowsTemplateShift, j + columnTemplateShift].Value = Convert.ToDecimal(reportYearSaldoTable.Rows[i][j]);
                        }
                    }

                    ExcelApp.Cells[29, 7] = userName;

                    ExcelWorkBook.Save();

                    if (MessageBox.Show("Отчёт сформирован! Хотите открыть его?", "Открыть отчёт", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(newReportPath);
                    }
                }
                catch
                {
                    MessageBox.Show("Произошла ошибка экспорта в Excel!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (ExcelWorkBook != null)
                    {
                        ExcelWorkBook.Close(false);
                    }

                    if (ExcelApp != null)
                    {
                        ExcelApp.Quit();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка при создании отчёта! Повторите попытку или перезагрузите программу!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BunifuCreateReport_YearSaldoDatePicker_ValueChanged(object sender, EventArgs e)
        {
            bunifuCreateReport_YearSaldoDatePicker.Refresh();
        }



        private void CreateReport_ResponsibilityRelationshipAC()
        {
            DataTable reportData = dbHelper.GetReport_ResponsibilityRelationshipAC();

            bunifuPieChartRecordDataGridView.DataSource = reportData.DefaultView;


            reportPieChart.Series.Clear();
            reportPieChart.InnerRadius = 130;

            foreach (DataRow reportDataRow in reportData.Rows)
            {
                if (Convert.ToInt32(reportDataRow[1]) == 0)
                {
                    return;
                }

                reportPieChart.Series.Add(
                    new PieSeries
                    {
                        Title = $"{reportDataRow[0]}",
                        Values = new ChartValues<ObservableValue> { new ObservableValue(Convert.ToInt32(reportDataRow[1])) },
                        DataLabels = true,
                    }
                );
            }
        }



        private void BunifuAnnualDynamicStartDatePicker_ValueChanged(object sender, EventArgs e)
        {
            bunifuAnnualDynamicStartDatePicker.Refresh();
            bunifuAnnualDynamicEndDatePicker.MinDate = bunifuAnnualDynamicStartDatePicker.Value;
        }

        private void BunifuAnnualDynamicEndDatePicker_ValueChanged(object sender, EventArgs e)
        {
            bunifuAnnualDynamicEndDatePicker.Refresh();
            bunifuAnnualDynamicStartDatePicker.MaxDate = bunifuAnnualDynamicEndDatePicker.Value;
        }

        private void BunifuAnnualDinamicButton_Click(object sender, EventArgs e)
        {
            switch (bunifuSelectReportDropdown.Text)
            {
                case "Годовая динамика поступления ОС":
                    {
                        DataTable reportData = dbHelper.GetReport_AnnualDynamicsReceiptEA(bunifuAnnualDynamicStartDatePicker.Value, bunifuAnnualDynamicEndDatePicker.Value);

                        LoadDataInReportCartesianChart(reportData, "Годовая динамика поступления основных средств в отражении на Уставной капитал, BYN.");
                        break;
                    }
                case "Годовая динамика списания ОС":
                    {
                        DataTable reportData = dbHelper.GetReport_AnnualDynamicsWriteoffEA(bunifuAnnualDynamicStartDatePicker.Value, bunifuAnnualDynamicEndDatePicker.Value);

                        LoadDataInReportCartesianChart(reportData, "Годовая динамика списания основных средств в отражении на Уставной капитал, BYN.");
                        break;
                    }
                case "Годовая динамика затрат на ремонтные работы":
                    {
                        DataTable reportData = dbHelper.GetReport_AnnualDynamicsRepairEA(bunifuAnnualDynamicStartDatePicker.Value, bunifuAnnualDynamicEndDatePicker.Value);

                        LoadDataInReportCartesianChart(reportData, "Годовая динамика затрат на ремонтные работы, BYN.");
                        break;
                    }
                case "Годовая динамика Уставного Капитала":
                    {
                        DataTable reportData = dbHelper.GetReport_AnnualDynamicsCapital(bunifuAnnualDynamicStartDatePicker.Value, bunifuAnnualDynamicEndDatePicker.Value);

                        LoadDataInReportCartesianChart(reportData, "Годовая динамика затрат на ремонтные работы, BYN.");
                        break;
                    }
            }
        }
        
        private void LoadDataInReportCartesianChart(DataTable reportData, string chartTitle)
        {
            List<string> yearsList = new List<string>();
            ChartValues<double> yearsSum = new ChartValues<double>();

            foreach (DataRow reportDataRow in reportData.Rows)
            {
                yearsList.Add(reportDataRow[0].ToString());

                yearsSum.Add(Convert.ToDouble(reportDataRow[1]));
            }

            reportCartesianChart.AxisX.Clear();
            reportCartesianChart.AxisX.Add(new Axis
            {
                Title = chartTitle,
                Labels = yearsList,
                FontSize = 16

            });

            BrushConverter brushConverter = new BrushConverter();

            reportCartesianChart.Series.Clear();
            reportCartesianChart.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "",
                    Values = yearsSum,
                    PointGeometrySize = 15,
                    Stroke = (Brush)brushConverter.ConvertFromString("#FFFEC007")
                }
            };
        }

        #endregion Realization of report generation.



        private void BunifuFormCloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}