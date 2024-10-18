
namespace EnterpriseAssetTracker.Forms
{
    partial class AnalyticForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges4 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            BunifuAnimatorNS.Animation animation2 = new BunifuAnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnalyticForm));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges5 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges6 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            this.reportCartesianChart = new LiveCharts.WinForms.CartesianChart();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuLabel1 = new Bunifu.UI.WinForms.BunifuLabel();
            this.selectReportPanel = new System.Windows.Forms.Panel();
            this.createReport_YearSaldoPanel = new System.Windows.Forms.Panel();
            this.bunifuCreateReport_YearSaldoButton = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.bunifuCreateReport_YearSaldoDatePicker = new Bunifu.UI.WinForms.BunifuDatePicker();
            this.bunifuSelectReportDropdown = new Bunifu.UI.WinForms.BunifuDropdown();
            this.bunifuLabel6 = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuTransition = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.bunifuCloseButton = new Bunifu.Framework.UI.BunifuImageButton();
            this.setReportDatePanel = new System.Windows.Forms.Panel();
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.bunifuLabel9 = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuLabel8 = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuReportEndDatePicker = new Bunifu.UI.WinForms.BunifuDatePicker();
            this.bunifuReportStartDatePicker = new Bunifu.UI.WinForms.BunifuDatePicker();
            this.bunifuLabel7 = new Bunifu.UI.WinForms.BunifuLabel();
            this.reportPieChart = new LiveCharts.WinForms.PieChart();
            this.bunifuPieChartRecordDataGridView = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.pieChartRecordPanel = new System.Windows.Forms.Panel();
            this.setDateForAnnualDinamicPanel = new System.Windows.Forms.Panel();
            this.bunifuAnnualDynamicEndDatePicker = new Bunifu.UI.WinForms.BunifuDatePicker();
            this.bunifuLabel2 = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuLabel3 = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuLabel4 = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuAnnualDinamicButton = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.bunifuAnnualDynamicStartDatePicker = new Bunifu.UI.WinForms.BunifuDatePicker();
            this.selectReportPanel.SuspendLayout();
            this.createReport_YearSaldoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuCloseButton)).BeginInit();
            this.setReportDatePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuPieChartRecordDataGridView)).BeginInit();
            this.pieChartRecordPanel.SuspendLayout();
            this.setDateForAnnualDinamicPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // reportCartesianChart
            // 
            this.bunifuTransition.SetDecoration(this.reportCartesianChart, BunifuAnimatorNS.DecorationType.None);
            this.reportCartesianChart.ForeColor = System.Drawing.Color.White;
            this.reportCartesianChart.Location = new System.Drawing.Point(84, 248);
            this.reportCartesianChart.Name = "reportCartesianChart";
            this.reportCartesianChart.Size = new System.Drawing.Size(1016, 423);
            this.reportCartesianChart.TabIndex = 0;
            this.reportCartesianChart.Visible = false;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // bunifuLabel1
            // 
            this.bunifuLabel1.AutoEllipsis = false;
            this.bunifuLabel1.AutoSize = false;
            this.bunifuLabel1.AutoSizeHeightOnly = true;
            this.bunifuLabel1.CursorType = null;
            this.bunifuTransition.SetDecoration(this.bunifuLabel1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bunifuLabel1.Font = new System.Drawing.Font("Century Gothic", 20.25F);
            this.bunifuLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.bunifuLabel1.Location = new System.Drawing.Point(0, 0);
            this.bunifuLabel1.Name = "bunifuLabel1";
            this.bunifuLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel1.Size = new System.Drawing.Size(1200, 42);
            this.bunifuLabel1.TabIndex = 1;
            this.bunifuLabel1.Text = "Аналитика";
            this.bunifuLabel1.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.bunifuLabel1.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // selectReportPanel
            // 
            this.selectReportPanel.Controls.Add(this.createReport_YearSaldoPanel);
            this.selectReportPanel.Controls.Add(this.bunifuSelectReportDropdown);
            this.selectReportPanel.Controls.Add(this.bunifuLabel6);
            this.bunifuTransition.SetDecoration(this.selectReportPanel, BunifuAnimatorNS.DecorationType.None);
            this.selectReportPanel.Location = new System.Drawing.Point(81, 48);
            this.selectReportPanel.Name = "selectReportPanel";
            this.selectReportPanel.Size = new System.Drawing.Size(523, 161);
            this.selectReportPanel.TabIndex = 65;
            // 
            // createReport_YearSaldoPanel
            // 
            this.createReport_YearSaldoPanel.Controls.Add(this.bunifuCreateReport_YearSaldoButton);
            this.createReport_YearSaldoPanel.Controls.Add(this.bunifuCreateReport_YearSaldoDatePicker);
            this.bunifuTransition.SetDecoration(this.createReport_YearSaldoPanel, BunifuAnimatorNS.DecorationType.None);
            this.createReport_YearSaldoPanel.Location = new System.Drawing.Point(85, 93);
            this.createReport_YearSaldoPanel.Name = "createReport_YearSaldoPanel";
            this.createReport_YearSaldoPanel.Size = new System.Drawing.Size(349, 56);
            this.createReport_YearSaldoPanel.TabIndex = 69;
            this.createReport_YearSaldoPanel.Visible = false;
            // 
            // bunifuCreateReport_YearSaldoButton
            // 
            this.bunifuCreateReport_YearSaldoButton.AllowToggling = false;
            this.bunifuCreateReport_YearSaldoButton.AnimationSpeed = 200;
            this.bunifuCreateReport_YearSaldoButton.AutoGenerateColors = false;
            this.bunifuCreateReport_YearSaldoButton.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCreateReport_YearSaldoButton.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(90)))));
            this.bunifuCreateReport_YearSaldoButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuCreateReport_YearSaldoButton.BackgroundImage")));
            this.bunifuCreateReport_YearSaldoButton.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuCreateReport_YearSaldoButton.ButtonText = "Сформировать";
            this.bunifuCreateReport_YearSaldoButton.ButtonTextMarginLeft = 0;
            this.bunifuCreateReport_YearSaldoButton.ColorContrastOnClick = 45;
            this.bunifuCreateReport_YearSaldoButton.ColorContrastOnHover = 45;
            this.bunifuCreateReport_YearSaldoButton.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges4.BottomLeft = true;
            borderEdges4.BottomRight = true;
            borderEdges4.TopLeft = true;
            borderEdges4.TopRight = true;
            this.bunifuCreateReport_YearSaldoButton.CustomizableEdges = borderEdges4;
            this.bunifuTransition.SetDecoration(this.bunifuCreateReport_YearSaldoButton, BunifuAnimatorNS.DecorationType.None);
            this.bunifuCreateReport_YearSaldoButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.bunifuCreateReport_YearSaldoButton.DisabledBorderColor = System.Drawing.Color.Empty;
            this.bunifuCreateReport_YearSaldoButton.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.bunifuCreateReport_YearSaldoButton.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.bunifuCreateReport_YearSaldoButton.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.bunifuCreateReport_YearSaldoButton.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.bunifuCreateReport_YearSaldoButton.ForeColor = System.Drawing.Color.White;
            this.bunifuCreateReport_YearSaldoButton.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuCreateReport_YearSaldoButton.IconMarginLeft = 11;
            this.bunifuCreateReport_YearSaldoButton.IconPadding = 10;
            this.bunifuCreateReport_YearSaldoButton.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuCreateReport_YearSaldoButton.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(90)))));
            this.bunifuCreateReport_YearSaldoButton.IdleBorderRadius = 3;
            this.bunifuCreateReport_YearSaldoButton.IdleBorderThickness = 1;
            this.bunifuCreateReport_YearSaldoButton.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(90)))));
            this.bunifuCreateReport_YearSaldoButton.IdleIconLeftImage = null;
            this.bunifuCreateReport_YearSaldoButton.IdleIconRightImage = null;
            this.bunifuCreateReport_YearSaldoButton.IndicateFocus = false;
            this.bunifuCreateReport_YearSaldoButton.Location = new System.Drawing.Point(133, 10);
            this.bunifuCreateReport_YearSaldoButton.Name = "bunifuCreateReport_YearSaldoButton";
            this.bunifuCreateReport_YearSaldoButton.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.bunifuCreateReport_YearSaldoButton.onHoverState.BorderRadius = 3;
            this.bunifuCreateReport_YearSaldoButton.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuCreateReport_YearSaldoButton.onHoverState.BorderThickness = 1;
            this.bunifuCreateReport_YearSaldoButton.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.bunifuCreateReport_YearSaldoButton.onHoverState.ForeColor = System.Drawing.Color.White;
            this.bunifuCreateReport_YearSaldoButton.onHoverState.IconLeftImage = null;
            this.bunifuCreateReport_YearSaldoButton.onHoverState.IconRightImage = null;
            this.bunifuCreateReport_YearSaldoButton.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(90)))));
            this.bunifuCreateReport_YearSaldoButton.OnIdleState.BorderRadius = 3;
            this.bunifuCreateReport_YearSaldoButton.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuCreateReport_YearSaldoButton.OnIdleState.BorderThickness = 1;
            this.bunifuCreateReport_YearSaldoButton.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(90)))));
            this.bunifuCreateReport_YearSaldoButton.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.bunifuCreateReport_YearSaldoButton.OnIdleState.IconLeftImage = null;
            this.bunifuCreateReport_YearSaldoButton.OnIdleState.IconRightImage = null;
            this.bunifuCreateReport_YearSaldoButton.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.bunifuCreateReport_YearSaldoButton.OnPressedState.BorderRadius = 3;
            this.bunifuCreateReport_YearSaldoButton.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuCreateReport_YearSaldoButton.OnPressedState.BorderThickness = 1;
            this.bunifuCreateReport_YearSaldoButton.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.bunifuCreateReport_YearSaldoButton.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.bunifuCreateReport_YearSaldoButton.OnPressedState.IconLeftImage = null;
            this.bunifuCreateReport_YearSaldoButton.OnPressedState.IconRightImage = null;
            this.bunifuCreateReport_YearSaldoButton.Size = new System.Drawing.Size(216, 35);
            this.bunifuCreateReport_YearSaldoButton.TabIndex = 70;
            this.bunifuCreateReport_YearSaldoButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuCreateReport_YearSaldoButton.TextMarginLeft = 0;
            this.bunifuCreateReport_YearSaldoButton.UseDefaultRadiusAndThickness = true;
            this.bunifuCreateReport_YearSaldoButton.Click += new System.EventHandler(this.BunifuCreateReport_YearSaldoButton_Click);
            // 
            // bunifuCreateReport_YearSaldoDatePicker
            // 
            this.bunifuCreateReport_YearSaldoDatePicker.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bunifuCreateReport_YearSaldoDatePicker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(69)))), ((int)(((byte)(80)))));
            this.bunifuCreateReport_YearSaldoDatePicker.BorderRadius = 1;
            this.bunifuCreateReport_YearSaldoDatePicker.Color = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.bunifuCreateReport_YearSaldoDatePicker.CustomFormat = "yyyy";
            this.bunifuCreateReport_YearSaldoDatePicker.DateBorderThickness = Bunifu.UI.WinForms.BunifuDatePicker.BorderThickness.Thick;
            this.bunifuCreateReport_YearSaldoDatePicker.DateTextAlign = Bunifu.UI.WinForms.BunifuDatePicker.TextAlign.Left;
            this.bunifuTransition.SetDecoration(this.bunifuCreateReport_YearSaldoDatePicker, BunifuAnimatorNS.DecorationType.None);
            this.bunifuCreateReport_YearSaldoDatePicker.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuCreateReport_YearSaldoDatePicker.DisplayWeekNumbers = false;
            this.bunifuCreateReport_YearSaldoDatePicker.DPHeight = 0;
            this.bunifuCreateReport_YearSaldoDatePicker.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.bunifuCreateReport_YearSaldoDatePicker.FillDatePicker = false;
            this.bunifuCreateReport_YearSaldoDatePicker.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bunifuCreateReport_YearSaldoDatePicker.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.bunifuCreateReport_YearSaldoDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.bunifuCreateReport_YearSaldoDatePicker.Icon = ((System.Drawing.Image)(resources.GetObject("bunifuCreateReport_YearSaldoDatePicker.Icon")));
            this.bunifuCreateReport_YearSaldoDatePicker.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.bunifuCreateReport_YearSaldoDatePicker.IconLocation = Bunifu.UI.WinForms.BunifuDatePicker.Indicator.Right;
            this.bunifuCreateReport_YearSaldoDatePicker.Location = new System.Drawing.Point(13, 11);
            this.bunifuCreateReport_YearSaldoDatePicker.MaxDate = new System.DateTime(2100, 1, 1, 0, 0, 0, 0);
            this.bunifuCreateReport_YearSaldoDatePicker.MinDate = new System.DateTime(1995, 1, 1, 0, 0, 0, 0);
            this.bunifuCreateReport_YearSaldoDatePicker.MinimumSize = new System.Drawing.Size(100, 32);
            this.bunifuCreateReport_YearSaldoDatePicker.Name = "bunifuCreateReport_YearSaldoDatePicker";
            this.bunifuCreateReport_YearSaldoDatePicker.Size = new System.Drawing.Size(100, 32);
            this.bunifuCreateReport_YearSaldoDatePicker.TabIndex = 61;
            this.bunifuCreateReport_YearSaldoDatePicker.Value = new System.DateTime(2024, 10, 16, 0, 0, 0, 0);
            this.bunifuCreateReport_YearSaldoDatePicker.ValueChanged += new System.EventHandler(this.BunifuCreateReport_YearSaldoDatePicker_ValueChanged);
            // 
            // bunifuSelectReportDropdown
            // 
            this.bunifuSelectReportDropdown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(69)))), ((int)(((byte)(80)))));
            this.bunifuSelectReportDropdown.BorderRadius = 1;
            this.bunifuSelectReportDropdown.Color = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.bunifuSelectReportDropdown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTransition.SetDecoration(this.bunifuSelectReportDropdown, BunifuAnimatorNS.DecorationType.None);
            this.bunifuSelectReportDropdown.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
            this.bunifuSelectReportDropdown.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuSelectReportDropdown.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.bunifuSelectReportDropdown.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thick;
            this.bunifuSelectReportDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bunifuSelectReportDropdown.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.bunifuSelectReportDropdown.FillDropDown = false;
            this.bunifuSelectReportDropdown.FillIndicator = false;
            this.bunifuSelectReportDropdown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bunifuSelectReportDropdown.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bunifuSelectReportDropdown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.bunifuSelectReportDropdown.FormattingEnabled = true;
            this.bunifuSelectReportDropdown.Icon = null;
            this.bunifuSelectReportDropdown.IndicatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.bunifuSelectReportDropdown.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.bunifuSelectReportDropdown.ItemBackColor = System.Drawing.Color.White;
            this.bunifuSelectReportDropdown.ItemBorderColor = System.Drawing.Color.White;
            this.bunifuSelectReportDropdown.ItemForeColor = System.Drawing.Color.DarkSlateGray;
            this.bunifuSelectReportDropdown.ItemHeight = 26;
            this.bunifuSelectReportDropdown.ItemHighLightColor = System.Drawing.Color.PowderBlue;
            this.bunifuSelectReportDropdown.Items.AddRange(new object[] {
            "Список поступления/списания ОС",
            "Оборотное сальдо по итогам года",
            "Отношение ответственности МОЛ",
            "Годовая динамика поступления ОС",
            "Годовая динамика списания ОС",
            "Годовая динамика затрат на ремонтные работы",
            "Годовая динамика Уставного Капитала"});
            this.bunifuSelectReportDropdown.Location = new System.Drawing.Point(3, 55);
            this.bunifuSelectReportDropdown.Name = "bunifuSelectReportDropdown";
            this.bunifuSelectReportDropdown.Size = new System.Drawing.Size(517, 32);
            this.bunifuSelectReportDropdown.TabIndex = 9;
            this.bunifuSelectReportDropdown.Text = null;
            this.bunifuSelectReportDropdown.SelectedIndexChanged += new System.EventHandler(this.BunifuSelectReportDropdown_SelectedIndexChanged);
            // 
            // bunifuLabel6
            // 
            this.bunifuLabel6.AutoEllipsis = false;
            this.bunifuLabel6.AutoSize = false;
            this.bunifuLabel6.AutoSizeHeightOnly = true;
            this.bunifuLabel6.CursorType = null;
            this.bunifuTransition.SetDecoration(this.bunifuLabel6, BunifuAnimatorNS.DecorationType.None);
            this.bunifuLabel6.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.bunifuLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.bunifuLabel6.Location = new System.Drawing.Point(0, 21);
            this.bunifuLabel6.Name = "bunifuLabel6";
            this.bunifuLabel6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel6.Size = new System.Drawing.Size(523, 23);
            this.bunifuLabel6.TabIndex = 1;
            this.bunifuLabel6.Text = "Выберите аналитическую операцию для формирования:";
            this.bunifuLabel6.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel6.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bunifuTransition
            // 
            this.bunifuTransition.AnimationType = BunifuAnimatorNS.AnimationType.VertSlide;
            this.bunifuTransition.Cursor = null;
            animation2.AnimateOnlyDifferences = true;
            animation2.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.BlindCoeff")));
            animation2.LeafCoeff = 0F;
            animation2.MaxTime = 1F;
            animation2.MinTime = 0F;
            animation2.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicCoeff")));
            animation2.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicShift")));
            animation2.MosaicSize = 0;
            animation2.Padding = new System.Windows.Forms.Padding(0);
            animation2.RotateCoeff = 0F;
            animation2.RotateLimit = 0F;
            animation2.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.ScaleCoeff")));
            animation2.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.SlideCoeff")));
            animation2.TimeCoeff = 0F;
            animation2.TransparencyCoeff = 0F;
            this.bunifuTransition.DefaultAnimation = animation2;
            // 
            // bunifuCloseButton
            // 
            this.bunifuCloseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTransition.SetDecoration(this.bunifuCloseButton, BunifuAnimatorNS.DecorationType.None);
            this.bunifuCloseButton.Image = ((System.Drawing.Image)(resources.GetObject("bunifuCloseButton.Image")));
            this.bunifuCloseButton.ImageActive = null;
            this.bunifuCloseButton.Location = new System.Drawing.Point(1153, 6);
            this.bunifuCloseButton.Name = "bunifuCloseButton";
            this.bunifuCloseButton.Size = new System.Drawing.Size(35, 39);
            this.bunifuCloseButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuCloseButton.TabIndex = 66;
            this.bunifuCloseButton.TabStop = false;
            this.bunifuCloseButton.Zoom = 10;
            this.bunifuCloseButton.Click += new System.EventHandler(this.BunifuCloseButton_Click);
            // 
            // setReportDatePanel
            // 
            this.setReportDatePanel.Controls.Add(this.bunifuCreateReport_ReceiptWriteoffEAList_Button);
            this.setReportDatePanel.Controls.Add(this.bunifuLabel9);
            this.setReportDatePanel.Controls.Add(this.bunifuLabel8);
            this.setReportDatePanel.Controls.Add(this.bunifuReportEndDatePicker);
            this.setReportDatePanel.Controls.Add(this.bunifuReportStartDatePicker);
            this.setReportDatePanel.Controls.Add(this.bunifuLabel7);
            this.bunifuTransition.SetDecoration(this.setReportDatePanel, BunifuAnimatorNS.DecorationType.None);
            this.setReportDatePanel.Location = new System.Drawing.Point(651, 60);
            this.setReportDatePanel.Name = "setReportDatePanel";
            this.setReportDatePanel.Size = new System.Drawing.Size(449, 161);
            this.setReportDatePanel.TabIndex = 68;
            this.setReportDatePanel.Visible = false;
            // 
            // bunifuCreateReport_ReceiptWriteoffEAList_Button
            // 
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.AllowToggling = false;
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.AnimationSpeed = 200;
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.AutoGenerateColors = false;
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(90)))));
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuCreateReport_ReceiptWriteoffEAList_Button.BackgroundImage")));
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.ButtonText = "Сформировать";
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.ButtonTextMarginLeft = 0;
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.ColorContrastOnClick = 45;
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.ColorContrastOnHover = 45;
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges5.BottomLeft = true;
            borderEdges5.BottomRight = true;
            borderEdges5.TopLeft = true;
            borderEdges5.TopRight = true;
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.CustomizableEdges = borderEdges5;
            this.bunifuTransition.SetDecoration(this.bunifuCreateReport_ReceiptWriteoffEAList_Button, BunifuAnimatorNS.DecorationType.None);
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.DialogResult = System.Windows.Forms.DialogResult.None;
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.DisabledBorderColor = System.Drawing.Color.Empty;
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.ForeColor = System.Drawing.Color.White;
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.IconMarginLeft = 11;
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.IconPadding = 10;
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(90)))));
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.IdleBorderRadius = 3;
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.IdleBorderThickness = 1;
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(90)))));
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.IdleIconLeftImage = null;
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.IdleIconRightImage = null;
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.IndicateFocus = false;
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.Location = new System.Drawing.Point(134, 119);
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.Name = "bunifuCreateReport_ReceiptWriteoffEAList_Button";
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.onHoverState.BorderRadius = 3;
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.onHoverState.BorderThickness = 1;
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.onHoverState.ForeColor = System.Drawing.Color.White;
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.onHoverState.IconLeftImage = null;
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.onHoverState.IconRightImage = null;
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(90)))));
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.OnIdleState.BorderRadius = 3;
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.OnIdleState.BorderThickness = 1;
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(90)))));
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.OnIdleState.IconLeftImage = null;
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.OnIdleState.IconRightImage = null;
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.OnPressedState.BorderRadius = 3;
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.OnPressedState.BorderThickness = 1;
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.OnPressedState.IconLeftImage = null;
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.OnPressedState.IconRightImage = null;
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.Size = new System.Drawing.Size(216, 35);
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.TabIndex = 63;
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.TextMarginLeft = 0;
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.UseDefaultRadiusAndThickness = true;
            this.bunifuCreateReport_ReceiptWriteoffEAList_Button.Click += new System.EventHandler(this.BunifuCreateReport_ReceiptWriteoffEAList_Button_Click);
            // 
            // bunifuLabel9
            // 
            this.bunifuLabel9.AutoEllipsis = false;
            this.bunifuLabel9.AutoSize = false;
            this.bunifuLabel9.CursorType = null;
            this.bunifuTransition.SetDecoration(this.bunifuLabel9, BunifuAnimatorNS.DecorationType.None);
            this.bunifuLabel9.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.bunifuLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.bunifuLabel9.Location = new System.Drawing.Point(45, 90);
            this.bunifuLabel9.Name = "bunifuLabel9";
            this.bunifuLabel9.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel9.Size = new System.Drawing.Size(40, 23);
            this.bunifuLabel9.TabIndex = 62;
            this.bunifuLabel9.Text = "ПО";
            this.bunifuLabel9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuLabel9.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bunifuLabel8
            // 
            this.bunifuLabel8.AutoEllipsis = false;
            this.bunifuLabel8.AutoSize = false;
            this.bunifuLabel8.CursorType = null;
            this.bunifuTransition.SetDecoration(this.bunifuLabel8, BunifuAnimatorNS.DecorationType.None);
            this.bunifuLabel8.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.bunifuLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.bunifuLabel8.Location = new System.Drawing.Point(45, 51);
            this.bunifuLabel8.Name = "bunifuLabel8";
            this.bunifuLabel8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel8.Size = new System.Drawing.Size(40, 23);
            this.bunifuLabel8.TabIndex = 62;
            this.bunifuLabel8.Text = "С";
            this.bunifuLabel8.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuLabel8.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bunifuReportEndDatePicker
            // 
            this.bunifuReportEndDatePicker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(69)))), ((int)(((byte)(80)))));
            this.bunifuReportEndDatePicker.BorderRadius = 1;
            this.bunifuReportEndDatePicker.Color = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.bunifuReportEndDatePicker.Cursor = System.Windows.Forms.Cursors.Default;
            this.bunifuReportEndDatePicker.CustomFormat = "dd.MM.yyyy";
            this.bunifuReportEndDatePicker.DateBorderThickness = Bunifu.UI.WinForms.BunifuDatePicker.BorderThickness.Thick;
            this.bunifuReportEndDatePicker.DateTextAlign = Bunifu.UI.WinForms.BunifuDatePicker.TextAlign.Left;
            this.bunifuTransition.SetDecoration(this.bunifuReportEndDatePicker, BunifuAnimatorNS.DecorationType.None);
            this.bunifuReportEndDatePicker.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuReportEndDatePicker.DisplayWeekNumbers = false;
            this.bunifuReportEndDatePicker.DPHeight = 0;
            this.bunifuReportEndDatePicker.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.bunifuReportEndDatePicker.FillDatePicker = false;
            this.bunifuReportEndDatePicker.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bunifuReportEndDatePicker.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.bunifuReportEndDatePicker.Icon = ((System.Drawing.Image)(resources.GetObject("bunifuReportEndDatePicker.Icon")));
            this.bunifuReportEndDatePicker.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.bunifuReportEndDatePicker.IconLocation = Bunifu.UI.WinForms.BunifuDatePicker.Indicator.Right;
            this.bunifuReportEndDatePicker.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bunifuReportEndDatePicker.Location = new System.Drawing.Point(91, 81);
            this.bunifuReportEndDatePicker.MaxDate = new System.DateTime(2100, 1, 1, 0, 0, 0, 0);
            this.bunifuReportEndDatePicker.MinDate = new System.DateTime(1995, 1, 1, 0, 0, 0, 0);
            this.bunifuReportEndDatePicker.MinimumSize = new System.Drawing.Size(311, 32);
            this.bunifuReportEndDatePicker.Name = "bunifuReportEndDatePicker";
            this.bunifuReportEndDatePicker.Size = new System.Drawing.Size(311, 32);
            this.bunifuReportEndDatePicker.TabIndex = 61;
            this.bunifuReportEndDatePicker.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.bunifuReportEndDatePicker.ValueChanged += new System.EventHandler(this.BunifuReportEndDatePicker_ValueChanged);
            // 
            // bunifuReportStartDatePicker
            // 
            this.bunifuReportStartDatePicker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(69)))), ((int)(((byte)(80)))));
            this.bunifuReportStartDatePicker.BorderRadius = 1;
            this.bunifuReportStartDatePicker.Color = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.bunifuReportStartDatePicker.CustomFormat = "dd.MM.yyyy";
            this.bunifuReportStartDatePicker.DateBorderThickness = Bunifu.UI.WinForms.BunifuDatePicker.BorderThickness.Thick;
            this.bunifuReportStartDatePicker.DateTextAlign = Bunifu.UI.WinForms.BunifuDatePicker.TextAlign.Left;
            this.bunifuTransition.SetDecoration(this.bunifuReportStartDatePicker, BunifuAnimatorNS.DecorationType.None);
            this.bunifuReportStartDatePicker.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuReportStartDatePicker.DisplayWeekNumbers = false;
            this.bunifuReportStartDatePicker.DPHeight = 0;
            this.bunifuReportStartDatePicker.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.bunifuReportStartDatePicker.FillDatePicker = false;
            this.bunifuReportStartDatePicker.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bunifuReportStartDatePicker.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.bunifuReportStartDatePicker.Icon = ((System.Drawing.Image)(resources.GetObject("bunifuReportStartDatePicker.Icon")));
            this.bunifuReportStartDatePicker.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.bunifuReportStartDatePicker.IconLocation = Bunifu.UI.WinForms.BunifuDatePicker.Indicator.Right;
            this.bunifuReportStartDatePicker.Location = new System.Drawing.Point(91, 42);
            this.bunifuReportStartDatePicker.MaxDate = new System.DateTime(2100, 1, 1, 0, 0, 0, 0);
            this.bunifuReportStartDatePicker.MinDate = new System.DateTime(1995, 1, 1, 0, 0, 0, 0);
            this.bunifuReportStartDatePicker.MinimumSize = new System.Drawing.Size(311, 32);
            this.bunifuReportStartDatePicker.Name = "bunifuReportStartDatePicker";
            this.bunifuReportStartDatePicker.Size = new System.Drawing.Size(311, 32);
            this.bunifuReportStartDatePicker.TabIndex = 61;
            this.bunifuReportStartDatePicker.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.bunifuReportStartDatePicker.ValueChanged += new System.EventHandler(this.BunifuReportStartDatePicker_ValueChanged);
            // 
            // bunifuLabel7
            // 
            this.bunifuLabel7.AutoEllipsis = false;
            this.bunifuLabel7.AutoSize = false;
            this.bunifuLabel7.CursorType = null;
            this.bunifuTransition.SetDecoration(this.bunifuLabel7, BunifuAnimatorNS.DecorationType.None);
            this.bunifuLabel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.bunifuLabel7.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.bunifuLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.bunifuLabel7.Location = new System.Drawing.Point(0, 0);
            this.bunifuLabel7.Name = "bunifuLabel7";
            this.bunifuLabel7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel7.Size = new System.Drawing.Size(449, 40);
            this.bunifuLabel7.TabIndex = 1;
            this.bunifuLabel7.Text = "Промежуток времени для поступления/списания ОС";
            this.bunifuLabel7.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuLabel7.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // reportPieChart
            // 
            this.bunifuTransition.SetDecoration(this.reportPieChart, BunifuAnimatorNS.DecorationType.None);
            this.reportPieChart.Location = new System.Drawing.Point(586, 19);
            this.reportPieChart.Name = "reportPieChart";
            this.reportPieChart.Size = new System.Drawing.Size(412, 388);
            this.reportPieChart.TabIndex = 69;
            this.reportPieChart.Text = "pieChart1";
            // 
            // bunifuPieChartRecordDataGridView
            // 
            this.bunifuPieChartRecordDataGridView.AllowCustomTheming = false;
            this.bunifuPieChartRecordDataGridView.AllowUserToAddRows = false;
            this.bunifuPieChartRecordDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.bunifuPieChartRecordDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.bunifuPieChartRecordDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuPieChartRecordDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.bunifuPieChartRecordDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(69)))), ((int)(((byte)(80)))));
            this.bunifuPieChartRecordDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bunifuPieChartRecordDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.bunifuPieChartRecordDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.bunifuPieChartRecordDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.bunifuPieChartRecordDataGridView.ColumnHeadersHeight = 40;
            this.bunifuPieChartRecordDataGridView.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.bunifuPieChartRecordDataGridView.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.bunifuPieChartRecordDataGridView.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.bunifuPieChartRecordDataGridView.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(178)))), ((int)(((byte)(178)))));
            this.bunifuPieChartRecordDataGridView.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.White;
            this.bunifuPieChartRecordDataGridView.CurrentTheme.BackColor = System.Drawing.Color.Teal;
            this.bunifuPieChartRecordDataGridView.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(216)))), ((int)(((byte)(216)))));
            this.bunifuPieChartRecordDataGridView.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.Teal;
            this.bunifuPieChartRecordDataGridView.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.bunifuPieChartRecordDataGridView.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.bunifuPieChartRecordDataGridView.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.bunifuPieChartRecordDataGridView.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.bunifuPieChartRecordDataGridView.CurrentTheme.Name = null;
            this.bunifuPieChartRecordDataGridView.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.bunifuPieChartRecordDataGridView.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.bunifuPieChartRecordDataGridView.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.bunifuPieChartRecordDataGridView.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(178)))), ((int)(((byte)(178)))));
            this.bunifuPieChartRecordDataGridView.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
            this.bunifuTransition.SetDecoration(this.bunifuPieChartRecordDataGridView, BunifuAnimatorNS.DecorationType.None);
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(178)))), ((int)(((byte)(178)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.bunifuPieChartRecordDataGridView.DefaultCellStyle = dataGridViewCellStyle6;
            this.bunifuPieChartRecordDataGridView.EnableHeadersVisualStyles = false;
            this.bunifuPieChartRecordDataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(216)))), ((int)(((byte)(216)))));
            this.bunifuPieChartRecordDataGridView.HeaderBackColor = System.Drawing.Color.Teal;
            this.bunifuPieChartRecordDataGridView.HeaderBgColor = System.Drawing.Color.Empty;
            this.bunifuPieChartRecordDataGridView.HeaderForeColor = System.Drawing.Color.White;
            this.bunifuPieChartRecordDataGridView.Location = new System.Drawing.Point(3, 3);
            this.bunifuPieChartRecordDataGridView.Name = "bunifuPieChartRecordDataGridView";
            this.bunifuPieChartRecordDataGridView.ReadOnly = true;
            this.bunifuPieChartRecordDataGridView.RowHeadersVisible = false;
            this.bunifuPieChartRecordDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.bunifuPieChartRecordDataGridView.RowTemplate.Height = 40;
            this.bunifuPieChartRecordDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.bunifuPieChartRecordDataGridView.Size = new System.Drawing.Size(565, 404);
            this.bunifuPieChartRecordDataGridView.TabIndex = 70;
            this.bunifuPieChartRecordDataGridView.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Teal;
            // 
            // pieChartRecordPanel
            // 
            this.pieChartRecordPanel.Controls.Add(this.bunifuPieChartRecordDataGridView);
            this.pieChartRecordPanel.Controls.Add(this.reportPieChart);
            this.bunifuTransition.SetDecoration(this.pieChartRecordPanel, BunifuAnimatorNS.DecorationType.None);
            this.pieChartRecordPanel.Location = new System.Drawing.Point(84, 248);
            this.pieChartRecordPanel.Name = "pieChartRecordPanel";
            this.pieChartRecordPanel.Size = new System.Drawing.Size(1016, 423);
            this.pieChartRecordPanel.TabIndex = 71;
            this.pieChartRecordPanel.Visible = false;
            // 
            // setDateForAnnualDinamicPanel
            // 
            this.setDateForAnnualDinamicPanel.Controls.Add(this.bunifuAnnualDynamicEndDatePicker);
            this.setDateForAnnualDinamicPanel.Controls.Add(this.bunifuLabel2);
            this.setDateForAnnualDinamicPanel.Controls.Add(this.bunifuLabel3);
            this.setDateForAnnualDinamicPanel.Controls.Add(this.bunifuLabel4);
            this.setDateForAnnualDinamicPanel.Controls.Add(this.bunifuAnnualDinamicButton);
            this.setDateForAnnualDinamicPanel.Controls.Add(this.bunifuAnnualDynamicStartDatePicker);
            this.bunifuTransition.SetDecoration(this.setDateForAnnualDinamicPanel, BunifuAnimatorNS.DecorationType.None);
            this.setDateForAnnualDinamicPanel.Location = new System.Drawing.Point(652, 48);
            this.setDateForAnnualDinamicPanel.Name = "setDateForAnnualDinamicPanel";
            this.setDateForAnnualDinamicPanel.Size = new System.Drawing.Size(448, 173);
            this.setDateForAnnualDinamicPanel.TabIndex = 71;
            this.setDateForAnnualDinamicPanel.Visible = false;
            // 
            // bunifuAnnualDynamicEndDatePicker
            // 
            this.bunifuAnnualDynamicEndDatePicker.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bunifuAnnualDynamicEndDatePicker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(69)))), ((int)(((byte)(80)))));
            this.bunifuAnnualDynamicEndDatePicker.BorderRadius = 1;
            this.bunifuAnnualDynamicEndDatePicker.Color = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.bunifuAnnualDynamicEndDatePicker.CustomFormat = "yyyy";
            this.bunifuAnnualDynamicEndDatePicker.DateBorderThickness = Bunifu.UI.WinForms.BunifuDatePicker.BorderThickness.Thick;
            this.bunifuAnnualDynamicEndDatePicker.DateTextAlign = Bunifu.UI.WinForms.BunifuDatePicker.TextAlign.Left;
            this.bunifuTransition.SetDecoration(this.bunifuAnnualDynamicEndDatePicker, BunifuAnimatorNS.DecorationType.None);
            this.bunifuAnnualDynamicEndDatePicker.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuAnnualDynamicEndDatePicker.DisplayWeekNumbers = false;
            this.bunifuAnnualDynamicEndDatePicker.DPHeight = 0;
            this.bunifuAnnualDynamicEndDatePicker.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.bunifuAnnualDynamicEndDatePicker.FillDatePicker = false;
            this.bunifuAnnualDynamicEndDatePicker.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bunifuAnnualDynamicEndDatePicker.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.bunifuAnnualDynamicEndDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.bunifuAnnualDynamicEndDatePicker.Icon = ((System.Drawing.Image)(resources.GetObject("bunifuAnnualDynamicEndDatePicker.Icon")));
            this.bunifuAnnualDynamicEndDatePicker.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.bunifuAnnualDynamicEndDatePicker.IconLocation = Bunifu.UI.WinForms.BunifuDatePicker.Indicator.Right;
            this.bunifuAnnualDynamicEndDatePicker.Location = new System.Drawing.Point(302, 79);
            this.bunifuAnnualDynamicEndDatePicker.MaxDate = new System.DateTime(2100, 1, 1, 0, 0, 0, 0);
            this.bunifuAnnualDynamicEndDatePicker.MinDate = new System.DateTime(1995, 1, 1, 0, 0, 0, 0);
            this.bunifuAnnualDynamicEndDatePicker.MinimumSize = new System.Drawing.Size(100, 32);
            this.bunifuAnnualDynamicEndDatePicker.Name = "bunifuAnnualDynamicEndDatePicker";
            this.bunifuAnnualDynamicEndDatePicker.Size = new System.Drawing.Size(100, 32);
            this.bunifuAnnualDynamicEndDatePicker.TabIndex = 74;
            this.bunifuAnnualDynamicEndDatePicker.Value = new System.DateTime(2024, 10, 16, 0, 0, 0, 0);
            this.bunifuAnnualDynamicEndDatePicker.ValueChanged += new System.EventHandler(this.BunifuAnnualDynamicEndDatePicker_ValueChanged);
            // 
            // bunifuLabel2
            // 
            this.bunifuLabel2.AutoEllipsis = false;
            this.bunifuLabel2.AutoSize = false;
            this.bunifuLabel2.CursorType = null;
            this.bunifuTransition.SetDecoration(this.bunifuLabel2, BunifuAnimatorNS.DecorationType.None);
            this.bunifuLabel2.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.bunifuLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.bunifuLabel2.Location = new System.Drawing.Point(247, 83);
            this.bunifuLabel2.Name = "bunifuLabel2";
            this.bunifuLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel2.Size = new System.Drawing.Size(40, 23);
            this.bunifuLabel2.TabIndex = 73;
            this.bunifuLabel2.Text = "ПО";
            this.bunifuLabel2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuLabel2.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bunifuLabel3
            // 
            this.bunifuLabel3.AutoEllipsis = false;
            this.bunifuLabel3.AutoSize = false;
            this.bunifuLabel3.CursorType = null;
            this.bunifuTransition.SetDecoration(this.bunifuLabel3, BunifuAnimatorNS.DecorationType.None);
            this.bunifuLabel3.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.bunifuLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.bunifuLabel3.Location = new System.Drawing.Point(52, 88);
            this.bunifuLabel3.Name = "bunifuLabel3";
            this.bunifuLabel3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel3.Size = new System.Drawing.Size(32, 23);
            this.bunifuLabel3.TabIndex = 72;
            this.bunifuLabel3.Text = "С";
            this.bunifuLabel3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuLabel3.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bunifuLabel4
            // 
            this.bunifuLabel4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bunifuLabel4.AutoEllipsis = false;
            this.bunifuLabel4.AutoSize = false;
            this.bunifuLabel4.CursorType = null;
            this.bunifuTransition.SetDecoration(this.bunifuLabel4, BunifuAnimatorNS.DecorationType.None);
            this.bunifuLabel4.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.bunifuLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.bunifuLabel4.Location = new System.Drawing.Point(-1, 22);
            this.bunifuLabel4.Name = "bunifuLabel4";
            this.bunifuLabel4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel4.Size = new System.Drawing.Size(449, 40);
            this.bunifuLabel4.TabIndex = 71;
            this.bunifuLabel4.Text = "Промежуток времени для формирования годовой динамики";
            this.bunifuLabel4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuLabel4.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bunifuAnnualDinamicButton
            // 
            this.bunifuAnnualDinamicButton.AllowToggling = false;
            this.bunifuAnnualDinamicButton.AnimationSpeed = 200;
            this.bunifuAnnualDinamicButton.AutoGenerateColors = false;
            this.bunifuAnnualDinamicButton.BackColor = System.Drawing.Color.Transparent;
            this.bunifuAnnualDinamicButton.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(90)))));
            this.bunifuAnnualDinamicButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuAnnualDinamicButton.BackgroundImage")));
            this.bunifuAnnualDinamicButton.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuAnnualDinamicButton.ButtonText = "Сформировать";
            this.bunifuAnnualDinamicButton.ButtonTextMarginLeft = 0;
            this.bunifuAnnualDinamicButton.ColorContrastOnClick = 45;
            this.bunifuAnnualDinamicButton.ColorContrastOnHover = 45;
            this.bunifuAnnualDinamicButton.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges6.BottomLeft = true;
            borderEdges6.BottomRight = true;
            borderEdges6.TopLeft = true;
            borderEdges6.TopRight = true;
            this.bunifuAnnualDinamicButton.CustomizableEdges = borderEdges6;
            this.bunifuTransition.SetDecoration(this.bunifuAnnualDinamicButton, BunifuAnimatorNS.DecorationType.None);
            this.bunifuAnnualDinamicButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.bunifuAnnualDinamicButton.DisabledBorderColor = System.Drawing.Color.Empty;
            this.bunifuAnnualDinamicButton.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.bunifuAnnualDinamicButton.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.bunifuAnnualDinamicButton.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.bunifuAnnualDinamicButton.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.bunifuAnnualDinamicButton.ForeColor = System.Drawing.Color.White;
            this.bunifuAnnualDinamicButton.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuAnnualDinamicButton.IconMarginLeft = 11;
            this.bunifuAnnualDinamicButton.IconPadding = 10;
            this.bunifuAnnualDinamicButton.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuAnnualDinamicButton.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(90)))));
            this.bunifuAnnualDinamicButton.IdleBorderRadius = 3;
            this.bunifuAnnualDinamicButton.IdleBorderThickness = 1;
            this.bunifuAnnualDinamicButton.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(90)))));
            this.bunifuAnnualDinamicButton.IdleIconLeftImage = null;
            this.bunifuAnnualDinamicButton.IdleIconRightImage = null;
            this.bunifuAnnualDinamicButton.IndicateFocus = false;
            this.bunifuAnnualDinamicButton.Location = new System.Drawing.Point(124, 128);
            this.bunifuAnnualDinamicButton.Name = "bunifuAnnualDinamicButton";
            this.bunifuAnnualDinamicButton.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.bunifuAnnualDinamicButton.onHoverState.BorderRadius = 3;
            this.bunifuAnnualDinamicButton.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuAnnualDinamicButton.onHoverState.BorderThickness = 1;
            this.bunifuAnnualDinamicButton.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.bunifuAnnualDinamicButton.onHoverState.ForeColor = System.Drawing.Color.White;
            this.bunifuAnnualDinamicButton.onHoverState.IconLeftImage = null;
            this.bunifuAnnualDinamicButton.onHoverState.IconRightImage = null;
            this.bunifuAnnualDinamicButton.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(90)))));
            this.bunifuAnnualDinamicButton.OnIdleState.BorderRadius = 3;
            this.bunifuAnnualDinamicButton.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuAnnualDinamicButton.OnIdleState.BorderThickness = 1;
            this.bunifuAnnualDinamicButton.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(90)))));
            this.bunifuAnnualDinamicButton.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.bunifuAnnualDinamicButton.OnIdleState.IconLeftImage = null;
            this.bunifuAnnualDinamicButton.OnIdleState.IconRightImage = null;
            this.bunifuAnnualDinamicButton.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.bunifuAnnualDinamicButton.OnPressedState.BorderRadius = 3;
            this.bunifuAnnualDinamicButton.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuAnnualDinamicButton.OnPressedState.BorderThickness = 1;
            this.bunifuAnnualDinamicButton.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.bunifuAnnualDinamicButton.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.bunifuAnnualDinamicButton.OnPressedState.IconLeftImage = null;
            this.bunifuAnnualDinamicButton.OnPressedState.IconRightImage = null;
            this.bunifuAnnualDinamicButton.Size = new System.Drawing.Size(216, 35);
            this.bunifuAnnualDinamicButton.TabIndex = 70;
            this.bunifuAnnualDinamicButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuAnnualDinamicButton.TextMarginLeft = 0;
            this.bunifuAnnualDinamicButton.UseDefaultRadiusAndThickness = true;
            this.bunifuAnnualDinamicButton.Click += new System.EventHandler(this.BunifuAnnualDinamicButton_Click);
            // 
            // bunifuAnnualDynamicStartDatePicker
            // 
            this.bunifuAnnualDynamicStartDatePicker.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bunifuAnnualDynamicStartDatePicker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(69)))), ((int)(((byte)(80)))));
            this.bunifuAnnualDynamicStartDatePicker.BorderRadius = 1;
            this.bunifuAnnualDynamicStartDatePicker.Color = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.bunifuAnnualDynamicStartDatePicker.CustomFormat = "yyyy";
            this.bunifuAnnualDynamicStartDatePicker.DateBorderThickness = Bunifu.UI.WinForms.BunifuDatePicker.BorderThickness.Thick;
            this.bunifuAnnualDynamicStartDatePicker.DateTextAlign = Bunifu.UI.WinForms.BunifuDatePicker.TextAlign.Left;
            this.bunifuTransition.SetDecoration(this.bunifuAnnualDynamicStartDatePicker, BunifuAnimatorNS.DecorationType.None);
            this.bunifuAnnualDynamicStartDatePicker.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuAnnualDynamicStartDatePicker.DisplayWeekNumbers = false;
            this.bunifuAnnualDynamicStartDatePicker.DPHeight = 0;
            this.bunifuAnnualDynamicStartDatePicker.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.bunifuAnnualDynamicStartDatePicker.FillDatePicker = false;
            this.bunifuAnnualDynamicStartDatePicker.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bunifuAnnualDynamicStartDatePicker.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.bunifuAnnualDynamicStartDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.bunifuAnnualDynamicStartDatePicker.Icon = ((System.Drawing.Image)(resources.GetObject("bunifuAnnualDynamicStartDatePicker.Icon")));
            this.bunifuAnnualDynamicStartDatePicker.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.bunifuAnnualDynamicStartDatePicker.IconLocation = Bunifu.UI.WinForms.BunifuDatePicker.Indicator.Right;
            this.bunifuAnnualDynamicStartDatePicker.Location = new System.Drawing.Point(106, 79);
            this.bunifuAnnualDynamicStartDatePicker.MaxDate = new System.DateTime(2100, 1, 1, 0, 0, 0, 0);
            this.bunifuAnnualDynamicStartDatePicker.MinDate = new System.DateTime(1995, 1, 1, 0, 0, 0, 0);
            this.bunifuAnnualDynamicStartDatePicker.MinimumSize = new System.Drawing.Size(100, 32);
            this.bunifuAnnualDynamicStartDatePicker.Name = "bunifuAnnualDynamicStartDatePicker";
            this.bunifuAnnualDynamicStartDatePicker.Size = new System.Drawing.Size(100, 32);
            this.bunifuAnnualDynamicStartDatePicker.TabIndex = 61;
            this.bunifuAnnualDynamicStartDatePicker.Value = new System.DateTime(2024, 10, 16, 0, 0, 0, 0);
            this.bunifuAnnualDynamicStartDatePicker.ValueChanged += new System.EventHandler(this.BunifuAnnualDynamicStartDatePicker_ValueChanged);
            // 
            // AnalyticForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(69)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.reportCartesianChart);
            this.Controls.Add(this.pieChartRecordPanel);
            this.Controls.Add(this.bunifuCloseButton);
            this.Controls.Add(this.selectReportPanel);
            this.Controls.Add(this.bunifuLabel1);
            this.Controls.Add(this.setDateForAnnualDinamicPanel);
            this.Controls.Add(this.setReportDatePanel);
            this.bunifuTransition.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AnalyticForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.selectReportPanel.ResumeLayout(false);
            this.createReport_YearSaldoPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuCloseButton)).EndInit();
            this.setReportDatePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuPieChartRecordDataGridView)).EndInit();
            this.pieChartRecordPanel.ResumeLayout(false);
            this.setDateForAnnualDinamicPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private LiveCharts.WinForms.CartesianChart reportCartesianChart;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel1;
        private System.Windows.Forms.Panel selectReportPanel;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel6;
        public Bunifu.UI.WinForms.BunifuDropdown bunifuSelectReportDropdown;
        private BunifuAnimatorNS.BunifuTransition bunifuTransition;
        private Bunifu.Framework.UI.BunifuImageButton bunifuCloseButton;
        private System.Windows.Forms.Panel setReportDatePanel;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel7;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel9;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel8;
        private Bunifu.UI.WinForms.BunifuDatePicker bunifuReportEndDatePicker;
        private Bunifu.UI.WinForms.BunifuDatePicker bunifuReportStartDatePicker;
        private LiveCharts.WinForms.PieChart reportPieChart;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton bunifuCreateReport_YearSaldoButton;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton bunifuCreateReport_ReceiptWriteoffEAList_Button;
        private System.Windows.Forms.Panel createReport_YearSaldoPanel;
        private Bunifu.UI.WinForms.BunifuDatePicker bunifuCreateReport_YearSaldoDatePicker;
        private System.Windows.Forms.Panel pieChartRecordPanel;
        private Bunifu.UI.WinForms.BunifuDataGridView bunifuPieChartRecordDataGridView;
        private System.Windows.Forms.Panel setDateForAnnualDinamicPanel;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton bunifuAnnualDinamicButton;
        private Bunifu.UI.WinForms.BunifuDatePicker bunifuAnnualDynamicStartDatePicker;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel2;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel3;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel4;
        private Bunifu.UI.WinForms.BunifuDatePicker bunifuAnnualDynamicEndDatePicker;
    }
}