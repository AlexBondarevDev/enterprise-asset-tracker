
namespace EnterpriseAssetTracker.Forms
{
    partial class UserForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            BunifuAnimatorNS.Animation animation3 = new BunifuAnimatorNS.Animation();
            BunifuAnimatorNS.Animation animation2 = new BunifuAnimatorNS.Animation();
            BunifuAnimatorNS.Animation animation1 = new BunifuAnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserForm));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.bunifuFormCloseButton = new Bunifu.Framework.UI.BunifuImageButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.bunifuAnalyticButton = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuAssignmentEAButton = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuWriteOffEAButton = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuRepairEAButton = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuReceiptEAButton = new Bunifu.Framework.UI.BunifuFlatButton();
            this.logo = new Bunifu.UI.WinForms.BunifuPictureBox();
            this.menyButton = new Bunifu.UI.WinForms.BunifuImageButton();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.workPanel = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.logoAnimator = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.panelAnimator1 = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.panelAnimator2 = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuFormCloseButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.workPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 9;
            this.bunifuElipse1.TargetControl = this;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(69)))), ((int)(((byte)(80)))));
            this.panel1.Controls.Add(this.bunifuFormCloseButton);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.bunifuCustomLabel1);
            this.logoAnimator.SetDecoration(this.panel1, BunifuAnimatorNS.DecorationType.None);
            this.panelAnimator1.SetDecoration(this.panel1, BunifuAnimatorNS.DecorationType.None);
            this.panelAnimator2.SetDecoration(this.panel1, BunifuAnimatorNS.DecorationType.None);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1200, 34);
            this.panel1.TabIndex = 0;
            // 
            // bunifuFormCloseButton
            // 
            this.bunifuFormCloseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logoAnimator.SetDecoration(this.bunifuFormCloseButton, BunifuAnimatorNS.DecorationType.None);
            this.panelAnimator1.SetDecoration(this.bunifuFormCloseButton, BunifuAnimatorNS.DecorationType.None);
            this.panelAnimator2.SetDecoration(this.bunifuFormCloseButton, BunifuAnimatorNS.DecorationType.None);
            this.bunifuFormCloseButton.Image = ((System.Drawing.Image)(resources.GetObject("bunifuFormCloseButton.Image")));
            this.bunifuFormCloseButton.ImageActive = null;
            this.bunifuFormCloseButton.Location = new System.Drawing.Point(1165, 1);
            this.bunifuFormCloseButton.Name = "bunifuFormCloseButton";
            this.bunifuFormCloseButton.Size = new System.Drawing.Size(30, 31);
            this.bunifuFormCloseButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuFormCloseButton.TabIndex = 4;
            this.bunifuFormCloseButton.TabStop = false;
            this.bunifuFormCloseButton.Zoom = 10;
            this.bunifuFormCloseButton.Click += new System.EventHandler(this.BunifuFormCloseButton_Click);
            // 
            // pictureBox1
            // 
            this.panelAnimator2.SetDecoration(this.pictureBox1, BunifuAnimatorNS.DecorationType.None);
            this.panelAnimator1.SetDecoration(this.pictureBox1, BunifuAnimatorNS.DecorationType.None);
            this.logoAnimator.SetDecoration(this.pictureBox1, BunifuAnimatorNS.DecorationType.None);
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.panelAnimator2.SetDecoration(this.bunifuCustomLabel1, BunifuAnimatorNS.DecorationType.None);
            this.panelAnimator1.SetDecoration(this.bunifuCustomLabel1, BunifuAnimatorNS.DecorationType.None);
            this.logoAnimator.SetDecoration(this.bunifuCustomLabel1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bunifuCustomLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(42, 6);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(309, 21);
            this.bunifuCustomLabel1.TabIndex = 0;
            this.bunifuCustomLabel1.Text = "Enterprise Asset Tracker - Экономист:  ";
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(90)))));
            this.menuPanel.Controls.Add(this.bunifuAnalyticButton);
            this.menuPanel.Controls.Add(this.bunifuAssignmentEAButton);
            this.menuPanel.Controls.Add(this.bunifuWriteOffEAButton);
            this.menuPanel.Controls.Add(this.bunifuRepairEAButton);
            this.menuPanel.Controls.Add(this.bunifuReceiptEAButton);
            this.menuPanel.Controls.Add(this.logo);
            this.menuPanel.Controls.Add(this.menyButton);
            this.logoAnimator.SetDecoration(this.menuPanel, BunifuAnimatorNS.DecorationType.None);
            this.panelAnimator1.SetDecoration(this.menuPanel, BunifuAnimatorNS.DecorationType.None);
            this.panelAnimator2.SetDecoration(this.menuPanel, BunifuAnimatorNS.DecorationType.None);
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuPanel.Location = new System.Drawing.Point(0, 34);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(60, 666);
            this.menuPanel.TabIndex = 1;
            // 
            // bunifuAnalyticButton
            // 
            this.bunifuAnalyticButton.Active = false;
            this.bunifuAnalyticButton.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(77)))), ((int)(((byte)(90)))));
            this.bunifuAnalyticButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(90)))));
            this.bunifuAnalyticButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuAnalyticButton.BorderRadius = 0;
            this.bunifuAnalyticButton.ButtonText = "      Аналитика";
            this.bunifuAnalyticButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelAnimator2.SetDecoration(this.bunifuAnalyticButton, BunifuAnimatorNS.DecorationType.None);
            this.panelAnimator1.SetDecoration(this.bunifuAnalyticButton, BunifuAnimatorNS.DecorationType.None);
            this.logoAnimator.SetDecoration(this.bunifuAnalyticButton, BunifuAnimatorNS.DecorationType.None);
            this.bunifuAnalyticButton.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuAnalyticButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bunifuAnalyticButton.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuAnalyticButton.Iconimage = ((System.Drawing.Image)(resources.GetObject("bunifuAnalyticButton.Iconimage")));
            this.bunifuAnalyticButton.Iconimage_right = null;
            this.bunifuAnalyticButton.Iconimage_right_Selected = null;
            this.bunifuAnalyticButton.Iconimage_Selected = null;
            this.bunifuAnalyticButton.IconMarginLeft = 10;
            this.bunifuAnalyticButton.IconMarginRight = 0;
            this.bunifuAnalyticButton.IconRightVisible = true;
            this.bunifuAnalyticButton.IconRightZoom = 0D;
            this.bunifuAnalyticButton.IconVisible = true;
            this.bunifuAnalyticButton.IconZoom = 90D;
            this.bunifuAnalyticButton.IsTab = true;
            this.bunifuAnalyticButton.Location = new System.Drawing.Point(0, 362);
            this.bunifuAnalyticButton.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.bunifuAnalyticButton.Name = "bunifuAnalyticButton";
            this.bunifuAnalyticButton.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(90)))));
            this.bunifuAnalyticButton.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(88)))), ((int)(((byte)(90)))));
            this.bunifuAnalyticButton.OnHoverTextColor = System.Drawing.Color.DarkTurquoise;
            this.bunifuAnalyticButton.selected = false;
            this.bunifuAnalyticButton.Size = new System.Drawing.Size(286, 45);
            this.bunifuAnalyticButton.TabIndex = 2;
            this.bunifuAnalyticButton.Text = "      Аналитика";
            this.bunifuAnalyticButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuAnalyticButton.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.bunifuAnalyticButton.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuAnalyticButton.Click += new System.EventHandler(this.BunifuAnalyticButton_Click);
            // 
            // bunifuAssignmentEAButton
            // 
            this.bunifuAssignmentEAButton.Active = false;
            this.bunifuAssignmentEAButton.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(77)))), ((int)(((byte)(90)))));
            this.bunifuAssignmentEAButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(90)))));
            this.bunifuAssignmentEAButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuAssignmentEAButton.BorderRadius = 0;
            this.bunifuAssignmentEAButton.ButtonText = "      Закрепление ОС";
            this.bunifuAssignmentEAButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelAnimator2.SetDecoration(this.bunifuAssignmentEAButton, BunifuAnimatorNS.DecorationType.None);
            this.panelAnimator1.SetDecoration(this.bunifuAssignmentEAButton, BunifuAnimatorNS.DecorationType.None);
            this.logoAnimator.SetDecoration(this.bunifuAssignmentEAButton, BunifuAnimatorNS.DecorationType.None);
            this.bunifuAssignmentEAButton.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuAssignmentEAButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bunifuAssignmentEAButton.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuAssignmentEAButton.Iconimage = ((System.Drawing.Image)(resources.GetObject("bunifuAssignmentEAButton.Iconimage")));
            this.bunifuAssignmentEAButton.Iconimage_right = null;
            this.bunifuAssignmentEAButton.Iconimage_right_Selected = null;
            this.bunifuAssignmentEAButton.Iconimage_Selected = null;
            this.bunifuAssignmentEAButton.IconMarginLeft = 10;
            this.bunifuAssignmentEAButton.IconMarginRight = 0;
            this.bunifuAssignmentEAButton.IconRightVisible = true;
            this.bunifuAssignmentEAButton.IconRightZoom = 0D;
            this.bunifuAssignmentEAButton.IconVisible = true;
            this.bunifuAssignmentEAButton.IconZoom = 90D;
            this.bunifuAssignmentEAButton.IsTab = true;
            this.bunifuAssignmentEAButton.Location = new System.Drawing.Point(0, 307);
            this.bunifuAssignmentEAButton.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.bunifuAssignmentEAButton.Name = "bunifuAssignmentEAButton";
            this.bunifuAssignmentEAButton.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(90)))));
            this.bunifuAssignmentEAButton.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(88)))), ((int)(((byte)(90)))));
            this.bunifuAssignmentEAButton.OnHoverTextColor = System.Drawing.Color.DarkTurquoise;
            this.bunifuAssignmentEAButton.selected = false;
            this.bunifuAssignmentEAButton.Size = new System.Drawing.Size(286, 45);
            this.bunifuAssignmentEAButton.TabIndex = 2;
            this.bunifuAssignmentEAButton.Text = "      Закрепление ОС";
            this.bunifuAssignmentEAButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuAssignmentEAButton.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.bunifuAssignmentEAButton.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuAssignmentEAButton.Click += new System.EventHandler(this.BunifuAssignmentEAButton_Click);
            // 
            // bunifuWriteOffEAButton
            // 
            this.bunifuWriteOffEAButton.Active = false;
            this.bunifuWriteOffEAButton.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(77)))), ((int)(((byte)(90)))));
            this.bunifuWriteOffEAButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(90)))));
            this.bunifuWriteOffEAButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuWriteOffEAButton.BorderRadius = 0;
            this.bunifuWriteOffEAButton.ButtonText = "      Списание ОС";
            this.bunifuWriteOffEAButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelAnimator2.SetDecoration(this.bunifuWriteOffEAButton, BunifuAnimatorNS.DecorationType.None);
            this.panelAnimator1.SetDecoration(this.bunifuWriteOffEAButton, BunifuAnimatorNS.DecorationType.None);
            this.logoAnimator.SetDecoration(this.bunifuWriteOffEAButton, BunifuAnimatorNS.DecorationType.None);
            this.bunifuWriteOffEAButton.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuWriteOffEAButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bunifuWriteOffEAButton.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuWriteOffEAButton.Iconimage = ((System.Drawing.Image)(resources.GetObject("bunifuWriteOffEAButton.Iconimage")));
            this.bunifuWriteOffEAButton.Iconimage_right = null;
            this.bunifuWriteOffEAButton.Iconimage_right_Selected = null;
            this.bunifuWriteOffEAButton.Iconimage_Selected = null;
            this.bunifuWriteOffEAButton.IconMarginLeft = 10;
            this.bunifuWriteOffEAButton.IconMarginRight = 0;
            this.bunifuWriteOffEAButton.IconRightVisible = true;
            this.bunifuWriteOffEAButton.IconRightZoom = 0D;
            this.bunifuWriteOffEAButton.IconVisible = true;
            this.bunifuWriteOffEAButton.IconZoom = 90D;
            this.bunifuWriteOffEAButton.IsTab = true;
            this.bunifuWriteOffEAButton.Location = new System.Drawing.Point(0, 252);
            this.bunifuWriteOffEAButton.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.bunifuWriteOffEAButton.Name = "bunifuWriteOffEAButton";
            this.bunifuWriteOffEAButton.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(90)))));
            this.bunifuWriteOffEAButton.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(88)))), ((int)(((byte)(90)))));
            this.bunifuWriteOffEAButton.OnHoverTextColor = System.Drawing.Color.DarkTurquoise;
            this.bunifuWriteOffEAButton.selected = false;
            this.bunifuWriteOffEAButton.Size = new System.Drawing.Size(286, 45);
            this.bunifuWriteOffEAButton.TabIndex = 2;
            this.bunifuWriteOffEAButton.TabStop = false;
            this.bunifuWriteOffEAButton.Text = "      Списание ОС";
            this.bunifuWriteOffEAButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuWriteOffEAButton.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.bunifuWriteOffEAButton.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuWriteOffEAButton.Click += new System.EventHandler(this.BunifuWriteOffEAButton_Click);
            // 
            // bunifuRepairEAButton
            // 
            this.bunifuRepairEAButton.Active = false;
            this.bunifuRepairEAButton.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(77)))), ((int)(((byte)(90)))));
            this.bunifuRepairEAButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(90)))));
            this.bunifuRepairEAButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuRepairEAButton.BorderRadius = 0;
            this.bunifuRepairEAButton.ButtonText = "      Ремонт ОС";
            this.bunifuRepairEAButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelAnimator2.SetDecoration(this.bunifuRepairEAButton, BunifuAnimatorNS.DecorationType.None);
            this.panelAnimator1.SetDecoration(this.bunifuRepairEAButton, BunifuAnimatorNS.DecorationType.None);
            this.logoAnimator.SetDecoration(this.bunifuRepairEAButton, BunifuAnimatorNS.DecorationType.None);
            this.bunifuRepairEAButton.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuRepairEAButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bunifuRepairEAButton.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuRepairEAButton.Iconimage = ((System.Drawing.Image)(resources.GetObject("bunifuRepairEAButton.Iconimage")));
            this.bunifuRepairEAButton.Iconimage_right = null;
            this.bunifuRepairEAButton.Iconimage_right_Selected = null;
            this.bunifuRepairEAButton.Iconimage_Selected = null;
            this.bunifuRepairEAButton.IconMarginLeft = 10;
            this.bunifuRepairEAButton.IconMarginRight = 0;
            this.bunifuRepairEAButton.IconRightVisible = true;
            this.bunifuRepairEAButton.IconRightZoom = 0D;
            this.bunifuRepairEAButton.IconVisible = true;
            this.bunifuRepairEAButton.IconZoom = 90D;
            this.bunifuRepairEAButton.IsTab = true;
            this.bunifuRepairEAButton.Location = new System.Drawing.Point(0, 197);
            this.bunifuRepairEAButton.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.bunifuRepairEAButton.Name = "bunifuRepairEAButton";
            this.bunifuRepairEAButton.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(90)))));
            this.bunifuRepairEAButton.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(88)))), ((int)(((byte)(90)))));
            this.bunifuRepairEAButton.OnHoverTextColor = System.Drawing.Color.DarkTurquoise;
            this.bunifuRepairEAButton.selected = false;
            this.bunifuRepairEAButton.Size = new System.Drawing.Size(286, 45);
            this.bunifuRepairEAButton.TabIndex = 2;
            this.bunifuRepairEAButton.Text = "      Ремонт ОС";
            this.bunifuRepairEAButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuRepairEAButton.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.bunifuRepairEAButton.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuRepairEAButton.Click += new System.EventHandler(this.BunifuRepairEAButton_Click);
            // 
            // bunifuReceiptEAButton
            // 
            this.bunifuReceiptEAButton.Active = false;
            this.bunifuReceiptEAButton.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(77)))), ((int)(((byte)(90)))));
            this.bunifuReceiptEAButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(90)))));
            this.bunifuReceiptEAButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuReceiptEAButton.BorderRadius = 0;
            this.bunifuReceiptEAButton.ButtonText = "      Поступление ОС";
            this.bunifuReceiptEAButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelAnimator2.SetDecoration(this.bunifuReceiptEAButton, BunifuAnimatorNS.DecorationType.None);
            this.panelAnimator1.SetDecoration(this.bunifuReceiptEAButton, BunifuAnimatorNS.DecorationType.None);
            this.logoAnimator.SetDecoration(this.bunifuReceiptEAButton, BunifuAnimatorNS.DecorationType.None);
            this.bunifuReceiptEAButton.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuReceiptEAButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bunifuReceiptEAButton.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuReceiptEAButton.Iconimage = ((System.Drawing.Image)(resources.GetObject("bunifuReceiptEAButton.Iconimage")));
            this.bunifuReceiptEAButton.Iconimage_right = null;
            this.bunifuReceiptEAButton.Iconimage_right_Selected = null;
            this.bunifuReceiptEAButton.Iconimage_Selected = null;
            this.bunifuReceiptEAButton.IconMarginLeft = 10;
            this.bunifuReceiptEAButton.IconMarginRight = 0;
            this.bunifuReceiptEAButton.IconRightVisible = true;
            this.bunifuReceiptEAButton.IconRightZoom = 0D;
            this.bunifuReceiptEAButton.IconVisible = true;
            this.bunifuReceiptEAButton.IconZoom = 90D;
            this.bunifuReceiptEAButton.IsTab = true;
            this.bunifuReceiptEAButton.Location = new System.Drawing.Point(0, 142);
            this.bunifuReceiptEAButton.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.bunifuReceiptEAButton.Name = "bunifuReceiptEAButton";
            this.bunifuReceiptEAButton.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(90)))));
            this.bunifuReceiptEAButton.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(88)))), ((int)(((byte)(90)))));
            this.bunifuReceiptEAButton.OnHoverTextColor = System.Drawing.Color.DarkTurquoise;
            this.bunifuReceiptEAButton.selected = false;
            this.bunifuReceiptEAButton.Size = new System.Drawing.Size(286, 45);
            this.bunifuReceiptEAButton.TabIndex = 2;
            this.bunifuReceiptEAButton.Text = "      Поступление ОС";
            this.bunifuReceiptEAButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuReceiptEAButton.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.bunifuReceiptEAButton.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuReceiptEAButton.Click += new System.EventHandler(this.BunifuReceiptEAButton_Click);
            // 
            // logo
            // 
            this.logo.AllowFocused = false;
            this.logo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.logo.BorderRadius = 50;
            this.logoAnimator.SetDecoration(this.logo, BunifuAnimatorNS.DecorationType.None);
            this.panelAnimator1.SetDecoration(this.logo, BunifuAnimatorNS.DecorationType.None);
            this.panelAnimator2.SetDecoration(this.logo, BunifuAnimatorNS.DecorationType.None);
            this.logo.Image = ((System.Drawing.Image)(resources.GetObject("logo.Image")));
            this.logo.IsCircle = true;
            this.logo.Location = new System.Drawing.Point(67, 20);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(112, 112);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logo.TabIndex = 1;
            this.logo.TabStop = false;
            this.logo.Type = Bunifu.UI.WinForms.BunifuPictureBox.Types.Square;
            // 
            // menyButton
            // 
            this.menyButton.ActiveImage = null;
            this.menyButton.AllowAnimations = true;
            this.menyButton.AllowBuffering = false;
            this.menyButton.AllowZooming = true;
            this.menyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.menyButton.BackColor = System.Drawing.Color.Transparent;
            this.panelAnimator2.SetDecoration(this.menyButton, BunifuAnimatorNS.DecorationType.None);
            this.logoAnimator.SetDecoration(this.menyButton, BunifuAnimatorNS.DecorationType.None);
            this.panelAnimator1.SetDecoration(this.menyButton, BunifuAnimatorNS.DecorationType.None);
            this.menyButton.ErrorImage = ((System.Drawing.Image)(resources.GetObject("menyButton.ErrorImage")));
            this.menyButton.FadeWhenInactive = false;
            this.menyButton.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.menyButton.Image = ((System.Drawing.Image)(resources.GetObject("menyButton.Image")));
            this.menyButton.ImageActive = null;
            this.menyButton.ImageLocation = null;
            this.menyButton.ImageMargin = 10;
            this.menyButton.ImageSize = new System.Drawing.Size(37, 31);
            this.menyButton.ImageZoomSize = new System.Drawing.Size(47, 41);
            this.menyButton.InitialImage = ((System.Drawing.Image)(resources.GetObject("menyButton.InitialImage")));
            this.menyButton.Location = new System.Drawing.Point(6, 6);
            this.menyButton.Name = "menyButton";
            this.menyButton.Rotation = 0;
            this.menyButton.ShowActiveImage = true;
            this.menyButton.ShowCursorChanges = true;
            this.menyButton.ShowImageBorders = false;
            this.menyButton.ShowSizeMarkers = false;
            this.menyButton.Size = new System.Drawing.Size(47, 41);
            this.menyButton.TabIndex = 0;
            this.menyButton.ToolTipText = "";
            this.menyButton.WaitOnLoad = false;
            this.menyButton.Zoom = 10;
            this.menyButton.ZoomSpeed = 10;
            this.menyButton.Click += new System.EventHandler(this.MenyButton_Click);
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = null;
            this.bunifuDragControl1.Vertical = true;
            // 
            // workPanel
            // 
            this.workPanel.Controls.Add(this.bunifuCustomLabel2);
            this.logoAnimator.SetDecoration(this.workPanel, BunifuAnimatorNS.DecorationType.None);
            this.panelAnimator1.SetDecoration(this.workPanel, BunifuAnimatorNS.DecorationType.None);
            this.panelAnimator2.SetDecoration(this.workPanel, BunifuAnimatorNS.DecorationType.None);
            this.workPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workPanel.Location = new System.Drawing.Point(60, 34);
            this.workPanel.Name = "workPanel";
            this.workPanel.Size = new System.Drawing.Size(1140, 666);
            this.workPanel.TabIndex = 2;
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelAnimator2.SetDecoration(this.bunifuCustomLabel2, BunifuAnimatorNS.DecorationType.None);
            this.panelAnimator1.SetDecoration(this.bunifuCustomLabel2, BunifuAnimatorNS.DecorationType.None);
            this.logoAnimator.SetDecoration(this.bunifuCustomLabel2, BunifuAnimatorNS.DecorationType.None);
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("Century Gothic", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bunifuCustomLabel2.ForeColor = System.Drawing.Color.White;
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(122, 101);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(892, 492);
            this.bunifuCustomLabel2.TabIndex = 1;
            this.bunifuCustomLabel2.Text = resources.GetString("bunifuCustomLabel2.Text");
            this.bunifuCustomLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // logoAnimator
            // 
            this.logoAnimator.AnimationType = BunifuAnimatorNS.AnimationType.Transparent;
            this.logoAnimator.Cursor = null;
            animation3.AnimateOnlyDifferences = true;
            animation3.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.BlindCoeff")));
            animation3.LeafCoeff = 0F;
            animation3.MaxTime = 1F;
            animation3.MinTime = 0F;
            animation3.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.MosaicCoeff")));
            animation3.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation3.MosaicShift")));
            animation3.MosaicSize = 0;
            animation3.Padding = new System.Windows.Forms.Padding(0);
            animation3.RotateCoeff = 0F;
            animation3.RotateLimit = 0F;
            animation3.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.ScaleCoeff")));
            animation3.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.SlideCoeff")));
            animation3.TimeCoeff = 0F;
            animation3.TransparencyCoeff = 1F;
            this.logoAnimator.DefaultAnimation = animation3;
            this.logoAnimator.TimeStep = 0.03F;
            // 
            // panelAnimator1
            // 
            this.panelAnimator1.AnimationType = BunifuAnimatorNS.AnimationType.HorizSlide;
            this.panelAnimator1.Cursor = null;
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
            this.panelAnimator1.DefaultAnimation = animation2;
            // 
            // panelAnimator2
            // 
            this.panelAnimator2.AnimationType = BunifuAnimatorNS.AnimationType.HorizSlide;
            this.panelAnimator2.Cursor = null;
            animation1.AnimateOnlyDifferences = true;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 0;
            animation1.Padding = new System.Windows.Forms.Padding(0);
            animation1.RotateCoeff = 0F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 0F;
            this.panelAnimator2.DefaultAnimation = animation1;
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(164)))), ((int)(((byte)(162)))));
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.workPanel);
            this.Controls.Add(this.menuPanel);
            this.Controls.Add(this.panel1);
            this.panelAnimator2.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.logoAnimator.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.panelAnimator1.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "е";
            this.Load += new System.EventHandler(this.UserForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuFormCloseButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.workPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.UI.WinForms.BunifuImageButton menyButton;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private Bunifu.UI.WinForms.BunifuPictureBox logo;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuReceiptEAButton;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuAssignmentEAButton;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuWriteOffEAButton;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuRepairEAButton;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuAnalyticButton;
        private System.Windows.Forms.Panel workPanel;
        private Bunifu.Framework.UI.BunifuImageButton bunifuFormCloseButton;
        private BunifuAnimatorNS.BunifuTransition logoAnimator;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;
        private BunifuAnimatorNS.BunifuTransition panelAnimator2;
        private BunifuAnimatorNS.BunifuTransition panelAnimator1;
    }
}

