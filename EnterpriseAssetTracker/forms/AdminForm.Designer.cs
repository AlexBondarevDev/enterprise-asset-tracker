
namespace EnterpriseAssetTracker.Forms
{
    partial class AdminForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.bunifuFormCloseButton = new Bunifu.Framework.UI.BunifuImageButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.panelAnimator1 = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.menuPanel = new System.Windows.Forms.Panel();
            this.bunifuEditingLoginButton = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuAssetCustodianButton = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuDirectoriesButton = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuDeletingDataEAButton = new Bunifu.Framework.UI.BunifuFlatButton();
            this.logo = new Bunifu.UI.WinForms.BunifuPictureBox();
            this.menyButton = new Bunifu.UI.WinForms.BunifuImageButton();
            this.workPanel = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.panelAnimator2 = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.logoAnimator = new BunifuAnimatorNS.BunifuTransition(this.components);
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
            this.panelAnimator1.SetDecoration(this.panel1, BunifuAnimatorNS.DecorationType.None);
            this.panelAnimator2.SetDecoration(this.panel1, BunifuAnimatorNS.DecorationType.None);
            this.logoAnimator.SetDecoration(this.panel1, BunifuAnimatorNS.DecorationType.None);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1200, 34);
            this.panel1.TabIndex = 0;
            // 
            // bunifuFormCloseButton
            // 
            this.bunifuFormCloseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelAnimator1.SetDecoration(this.bunifuFormCloseButton, BunifuAnimatorNS.DecorationType.None);
            this.panelAnimator2.SetDecoration(this.bunifuFormCloseButton, BunifuAnimatorNS.DecorationType.None);
            this.logoAnimator.SetDecoration(this.bunifuFormCloseButton, BunifuAnimatorNS.DecorationType.None);
            this.bunifuFormCloseButton.Image = ((System.Drawing.Image)(resources.GetObject("bunifuFormCloseButton.Image")));
            this.bunifuFormCloseButton.ImageActive = null;
            this.bunifuFormCloseButton.Location = new System.Drawing.Point(1168, 1);
            this.bunifuFormCloseButton.Name = "bunifuFormCloseButton";
            this.bunifuFormCloseButton.Size = new System.Drawing.Size(30, 31);
            this.bunifuFormCloseButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuFormCloseButton.TabIndex = 5;
            this.bunifuFormCloseButton.TabStop = false;
            this.bunifuFormCloseButton.Zoom = 10;
            this.bunifuFormCloseButton.Click += new System.EventHandler(this.BunifuFormCloseButton_Click);
            // 
            // pictureBox1
            // 
            this.logoAnimator.SetDecoration(this.pictureBox1, BunifuAnimatorNS.DecorationType.None);
            this.panelAnimator2.SetDecoration(this.pictureBox1, BunifuAnimatorNS.DecorationType.None);
            this.panelAnimator1.SetDecoration(this.pictureBox1, BunifuAnimatorNS.DecorationType.None);
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
            this.logoAnimator.SetDecoration(this.bunifuCustomLabel1, BunifuAnimatorNS.DecorationType.None);
            this.panelAnimator2.SetDecoration(this.bunifuCustomLabel1, BunifuAnimatorNS.DecorationType.None);
            this.panelAnimator1.SetDecoration(this.bunifuCustomLabel1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bunifuCustomLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(42, 6);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(349, 21);
            this.bunifuCustomLabel1.TabIndex = 0;
            this.bunifuCustomLabel1.Text = "Enterprise Asset Tracker - Администратор:  ";
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = null;
            this.bunifuDragControl1.Vertical = true;
            // 
            // panelAnimator1
            // 
            this.panelAnimator1.AnimationType = BunifuAnimatorNS.AnimationType.HorizSlide;
            this.panelAnimator1.Cursor = null;
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
            animation3.TransparencyCoeff = 0F;
            this.panelAnimator1.DefaultAnimation = animation3;
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(90)))));
            this.menuPanel.Controls.Add(this.bunifuEditingLoginButton);
            this.menuPanel.Controls.Add(this.bunifuAssetCustodianButton);
            this.menuPanel.Controls.Add(this.bunifuDirectoriesButton);
            this.menuPanel.Controls.Add(this.bunifuDeletingDataEAButton);
            this.menuPanel.Controls.Add(this.logo);
            this.menuPanel.Controls.Add(this.menyButton);
            this.panelAnimator1.SetDecoration(this.menuPanel, BunifuAnimatorNS.DecorationType.None);
            this.panelAnimator2.SetDecoration(this.menuPanel, BunifuAnimatorNS.DecorationType.None);
            this.logoAnimator.SetDecoration(this.menuPanel, BunifuAnimatorNS.DecorationType.None);
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuPanel.Location = new System.Drawing.Point(0, 34);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(60, 666);
            this.menuPanel.TabIndex = 2;
            // 
            // bunifuEditingLoginButton
            // 
            this.bunifuEditingLoginButton.Active = false;
            this.bunifuEditingLoginButton.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(77)))), ((int)(((byte)(90)))));
            this.bunifuEditingLoginButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(90)))));
            this.bunifuEditingLoginButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuEditingLoginButton.BorderRadius = 0;
            this.bunifuEditingLoginButton.ButtonText = "      Авторизация";
            this.bunifuEditingLoginButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logoAnimator.SetDecoration(this.bunifuEditingLoginButton, BunifuAnimatorNS.DecorationType.None);
            this.panelAnimator2.SetDecoration(this.bunifuEditingLoginButton, BunifuAnimatorNS.DecorationType.None);
            this.panelAnimator1.SetDecoration(this.bunifuEditingLoginButton, BunifuAnimatorNS.DecorationType.None);
            this.bunifuEditingLoginButton.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuEditingLoginButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bunifuEditingLoginButton.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuEditingLoginButton.Iconimage = ((System.Drawing.Image)(resources.GetObject("bunifuEditingLoginButton.Iconimage")));
            this.bunifuEditingLoginButton.Iconimage_right = null;
            this.bunifuEditingLoginButton.Iconimage_right_Selected = null;
            this.bunifuEditingLoginButton.Iconimage_Selected = null;
            this.bunifuEditingLoginButton.IconMarginLeft = 10;
            this.bunifuEditingLoginButton.IconMarginRight = 0;
            this.bunifuEditingLoginButton.IconRightVisible = true;
            this.bunifuEditingLoginButton.IconRightZoom = 0D;
            this.bunifuEditingLoginButton.IconVisible = true;
            this.bunifuEditingLoginButton.IconZoom = 90D;
            this.bunifuEditingLoginButton.IsTab = true;
            this.bunifuEditingLoginButton.Location = new System.Drawing.Point(0, 307);
            this.bunifuEditingLoginButton.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.bunifuEditingLoginButton.Name = "bunifuEditingLoginButton";
            this.bunifuEditingLoginButton.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(90)))));
            this.bunifuEditingLoginButton.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(88)))), ((int)(((byte)(90)))));
            this.bunifuEditingLoginButton.OnHoverTextColor = System.Drawing.Color.DarkTurquoise;
            this.bunifuEditingLoginButton.selected = false;
            this.bunifuEditingLoginButton.Size = new System.Drawing.Size(286, 45);
            this.bunifuEditingLoginButton.TabIndex = 2;
            this.bunifuEditingLoginButton.Text = "      Авторизация";
            this.bunifuEditingLoginButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuEditingLoginButton.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.bunifuEditingLoginButton.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuEditingLoginButton.Click += new System.EventHandler(this.BunifuEditingLoginButton_Click);
            // 
            // bunifuAssetCustodianButton
            // 
            this.bunifuAssetCustodianButton.Active = false;
            this.bunifuAssetCustodianButton.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(77)))), ((int)(((byte)(90)))));
            this.bunifuAssetCustodianButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(90)))));
            this.bunifuAssetCustodianButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuAssetCustodianButton.BorderRadius = 0;
            this.bunifuAssetCustodianButton.ButtonText = "      МОЛ";
            this.bunifuAssetCustodianButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logoAnimator.SetDecoration(this.bunifuAssetCustodianButton, BunifuAnimatorNS.DecorationType.None);
            this.panelAnimator2.SetDecoration(this.bunifuAssetCustodianButton, BunifuAnimatorNS.DecorationType.None);
            this.panelAnimator1.SetDecoration(this.bunifuAssetCustodianButton, BunifuAnimatorNS.DecorationType.None);
            this.bunifuAssetCustodianButton.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuAssetCustodianButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bunifuAssetCustodianButton.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuAssetCustodianButton.Iconimage = ((System.Drawing.Image)(resources.GetObject("bunifuAssetCustodianButton.Iconimage")));
            this.bunifuAssetCustodianButton.Iconimage_right = null;
            this.bunifuAssetCustodianButton.Iconimage_right_Selected = null;
            this.bunifuAssetCustodianButton.Iconimage_Selected = null;
            this.bunifuAssetCustodianButton.IconMarginLeft = 10;
            this.bunifuAssetCustodianButton.IconMarginRight = 0;
            this.bunifuAssetCustodianButton.IconRightVisible = true;
            this.bunifuAssetCustodianButton.IconRightZoom = 0D;
            this.bunifuAssetCustodianButton.IconVisible = true;
            this.bunifuAssetCustodianButton.IconZoom = 90D;
            this.bunifuAssetCustodianButton.IsTab = true;
            this.bunifuAssetCustodianButton.Location = new System.Drawing.Point(0, 252);
            this.bunifuAssetCustodianButton.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.bunifuAssetCustodianButton.Name = "bunifuAssetCustodianButton";
            this.bunifuAssetCustodianButton.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(90)))));
            this.bunifuAssetCustodianButton.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(88)))), ((int)(((byte)(90)))));
            this.bunifuAssetCustodianButton.OnHoverTextColor = System.Drawing.Color.DarkTurquoise;
            this.bunifuAssetCustodianButton.selected = false;
            this.bunifuAssetCustodianButton.Size = new System.Drawing.Size(286, 45);
            this.bunifuAssetCustodianButton.TabIndex = 2;
            this.bunifuAssetCustodianButton.TabStop = false;
            this.bunifuAssetCustodianButton.Text = "      МОЛ";
            this.bunifuAssetCustodianButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuAssetCustodianButton.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.bunifuAssetCustodianButton.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuAssetCustodianButton.Click += new System.EventHandler(this.BunifuAssetCustodianButton_Click);
            // 
            // bunifuDirectoriesButton
            // 
            this.bunifuDirectoriesButton.Active = false;
            this.bunifuDirectoriesButton.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(77)))), ((int)(((byte)(90)))));
            this.bunifuDirectoriesButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(90)))));
            this.bunifuDirectoriesButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuDirectoriesButton.BorderRadius = 0;
            this.bunifuDirectoriesButton.ButtonText = "      Справочники";
            this.bunifuDirectoriesButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logoAnimator.SetDecoration(this.bunifuDirectoriesButton, BunifuAnimatorNS.DecorationType.None);
            this.panelAnimator2.SetDecoration(this.bunifuDirectoriesButton, BunifuAnimatorNS.DecorationType.None);
            this.panelAnimator1.SetDecoration(this.bunifuDirectoriesButton, BunifuAnimatorNS.DecorationType.None);
            this.bunifuDirectoriesButton.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuDirectoriesButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bunifuDirectoriesButton.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuDirectoriesButton.Iconimage = ((System.Drawing.Image)(resources.GetObject("bunifuDirectoriesButton.Iconimage")));
            this.bunifuDirectoriesButton.Iconimage_right = null;
            this.bunifuDirectoriesButton.Iconimage_right_Selected = null;
            this.bunifuDirectoriesButton.Iconimage_Selected = null;
            this.bunifuDirectoriesButton.IconMarginLeft = 10;
            this.bunifuDirectoriesButton.IconMarginRight = 0;
            this.bunifuDirectoriesButton.IconRightVisible = true;
            this.bunifuDirectoriesButton.IconRightZoom = 0D;
            this.bunifuDirectoriesButton.IconVisible = true;
            this.bunifuDirectoriesButton.IconZoom = 90D;
            this.bunifuDirectoriesButton.IsTab = true;
            this.bunifuDirectoriesButton.Location = new System.Drawing.Point(0, 197);
            this.bunifuDirectoriesButton.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.bunifuDirectoriesButton.Name = "bunifuDirectoriesButton";
            this.bunifuDirectoriesButton.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(90)))));
            this.bunifuDirectoriesButton.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(88)))), ((int)(((byte)(90)))));
            this.bunifuDirectoriesButton.OnHoverTextColor = System.Drawing.Color.DarkTurquoise;
            this.bunifuDirectoriesButton.selected = false;
            this.bunifuDirectoriesButton.Size = new System.Drawing.Size(286, 45);
            this.bunifuDirectoriesButton.TabIndex = 2;
            this.bunifuDirectoriesButton.Text = "      Справочники";
            this.bunifuDirectoriesButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuDirectoriesButton.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.bunifuDirectoriesButton.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuDirectoriesButton.Click += new System.EventHandler(this.BunifuDirectoriesButton_Click);
            // 
            // bunifuDeletingDataEAButton
            // 
            this.bunifuDeletingDataEAButton.Active = false;
            this.bunifuDeletingDataEAButton.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(77)))), ((int)(((byte)(90)))));
            this.bunifuDeletingDataEAButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(90)))));
            this.bunifuDeletingDataEAButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuDeletingDataEAButton.BorderRadius = 0;
            this.bunifuDeletingDataEAButton.ButtonText = "      Удаление данных";
            this.bunifuDeletingDataEAButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logoAnimator.SetDecoration(this.bunifuDeletingDataEAButton, BunifuAnimatorNS.DecorationType.None);
            this.panelAnimator2.SetDecoration(this.bunifuDeletingDataEAButton, BunifuAnimatorNS.DecorationType.None);
            this.panelAnimator1.SetDecoration(this.bunifuDeletingDataEAButton, BunifuAnimatorNS.DecorationType.None);
            this.bunifuDeletingDataEAButton.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuDeletingDataEAButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bunifuDeletingDataEAButton.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuDeletingDataEAButton.Iconimage = ((System.Drawing.Image)(resources.GetObject("bunifuDeletingDataEAButton.Iconimage")));
            this.bunifuDeletingDataEAButton.Iconimage_right = null;
            this.bunifuDeletingDataEAButton.Iconimage_right_Selected = null;
            this.bunifuDeletingDataEAButton.Iconimage_Selected = null;
            this.bunifuDeletingDataEAButton.IconMarginLeft = 10;
            this.bunifuDeletingDataEAButton.IconMarginRight = 0;
            this.bunifuDeletingDataEAButton.IconRightVisible = true;
            this.bunifuDeletingDataEAButton.IconRightZoom = 0D;
            this.bunifuDeletingDataEAButton.IconVisible = true;
            this.bunifuDeletingDataEAButton.IconZoom = 90D;
            this.bunifuDeletingDataEAButton.IsTab = true;
            this.bunifuDeletingDataEAButton.Location = new System.Drawing.Point(0, 142);
            this.bunifuDeletingDataEAButton.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.bunifuDeletingDataEAButton.Name = "bunifuDeletingDataEAButton";
            this.bunifuDeletingDataEAButton.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(90)))));
            this.bunifuDeletingDataEAButton.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(88)))), ((int)(((byte)(90)))));
            this.bunifuDeletingDataEAButton.OnHoverTextColor = System.Drawing.Color.DarkTurquoise;
            this.bunifuDeletingDataEAButton.selected = false;
            this.bunifuDeletingDataEAButton.Size = new System.Drawing.Size(286, 45);
            this.bunifuDeletingDataEAButton.TabIndex = 2;
            this.bunifuDeletingDataEAButton.Text = "      Удаление данных";
            this.bunifuDeletingDataEAButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuDeletingDataEAButton.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.bunifuDeletingDataEAButton.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuDeletingDataEAButton.Click += new System.EventHandler(this.BunifuDeletingDataEAButton_Click);
            // 
            // logo
            // 
            this.logo.AllowFocused = false;
            this.logo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.logo.BorderRadius = 50;
            this.panelAnimator1.SetDecoration(this.logo, BunifuAnimatorNS.DecorationType.None);
            this.panelAnimator2.SetDecoration(this.logo, BunifuAnimatorNS.DecorationType.None);
            this.logoAnimator.SetDecoration(this.logo, BunifuAnimatorNS.DecorationType.None);
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
            this.logoAnimator.SetDecoration(this.menyButton, BunifuAnimatorNS.DecorationType.None);
            this.panelAnimator1.SetDecoration(this.menyButton, BunifuAnimatorNS.DecorationType.None);
            this.panelAnimator2.SetDecoration(this.menyButton, BunifuAnimatorNS.DecorationType.None);
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
            // workPanel
            // 
            this.workPanel.Controls.Add(this.bunifuCustomLabel2);
            this.panelAnimator1.SetDecoration(this.workPanel, BunifuAnimatorNS.DecorationType.None);
            this.panelAnimator2.SetDecoration(this.workPanel, BunifuAnimatorNS.DecorationType.None);
            this.logoAnimator.SetDecoration(this.workPanel, BunifuAnimatorNS.DecorationType.None);
            this.workPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workPanel.Location = new System.Drawing.Point(60, 34);
            this.workPanel.Name = "workPanel";
            this.workPanel.Size = new System.Drawing.Size(1140, 666);
            this.workPanel.TabIndex = 36;
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.logoAnimator.SetDecoration(this.bunifuCustomLabel2, BunifuAnimatorNS.DecorationType.None);
            this.panelAnimator2.SetDecoration(this.bunifuCustomLabel2, BunifuAnimatorNS.DecorationType.None);
            this.panelAnimator1.SetDecoration(this.bunifuCustomLabel2, BunifuAnimatorNS.DecorationType.None);
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("Century Gothic", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bunifuCustomLabel2.ForeColor = System.Drawing.Color.White;
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(125, 83);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(892, 508);
            this.bunifuCustomLabel2.TabIndex = 1;
            this.bunifuCustomLabel2.Text = resources.GetString("bunifuCustomLabel2.Text");
            this.bunifuCustomLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelAnimator2
            // 
            this.panelAnimator2.AnimationType = BunifuAnimatorNS.AnimationType.HorizSlide;
            this.panelAnimator2.Cursor = null;
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
            this.panelAnimator2.DefaultAnimation = animation2;
            // 
            // logoAnimator
            // 
            this.logoAnimator.AnimationType = BunifuAnimatorNS.AnimationType.Transparent;
            this.logoAnimator.Cursor = null;
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
            animation1.TransparencyCoeff = 1F;
            this.logoAnimator.DefaultAnimation = animation1;
            this.logoAnimator.TimeStep = 0.03F;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(164)))), ((int)(((byte)(162)))));
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.workPanel);
            this.Controls.Add(this.menuPanel);
            this.Controls.Add(this.panel1);
            this.logoAnimator.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.panelAnimator1.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.panelAnimator2.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "е";
            this.Load += new System.EventHandler(this.AdminForm_Load);
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
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private BunifuAnimatorNS.BunifuTransition panelAnimator1;
        private BunifuAnimatorNS.BunifuTransition panelAnimator2;
        private BunifuAnimatorNS.BunifuTransition logoAnimator;
        private Bunifu.Framework.UI.BunifuImageButton bunifuFormCloseButton;
        private System.Windows.Forms.Panel menuPanel;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuEditingLoginButton;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuAssetCustodianButton;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuDirectoriesButton;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuDeletingDataEAButton;
        private Bunifu.UI.WinForms.BunifuPictureBox logo;
        private Bunifu.UI.WinForms.BunifuImageButton menyButton;
        private System.Windows.Forms.Panel workPanel;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;
    }
}

