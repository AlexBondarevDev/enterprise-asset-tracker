
namespace EnterpriseAssetTracker.Forms
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges3 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties5 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties6 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties7 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties8 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.bunifuRegisteredButton = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.bunifuLoginButton = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.bunifuUserDropdown = new Bunifu.UI.WinForms.BunifuDropdown();
            this.bunifuPasswordTextBox = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox();
            this.bunifuCloseButton = new Bunifu.Framework.UI.BunifuImageButton();
            this.bunifuLabel2 = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuLabel3 = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuLabel1 = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuImageButton2 = new Bunifu.Framework.UI.BunifuImageButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuCloseButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.panel1.Controls.Add(this.bunifuRegisteredButton);
            this.panel1.Controls.Add(this.bunifuLoginButton);
            this.panel1.Controls.Add(this.bunifuUserDropdown);
            this.panel1.Controls.Add(this.bunifuPasswordTextBox);
            this.panel1.Controls.Add(this.bunifuCloseButton);
            this.panel1.Controls.Add(this.bunifuLabel2);
            this.panel1.Controls.Add(this.bunifuLabel3);
            this.panel1.Controls.Add(this.bunifuLabel1);
            this.panel1.Controls.Add(this.bunifuImageButton2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.bunifuCustomLabel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 600);
            this.panel1.TabIndex = 1;
            // 
            // bunifuRegisteredButton
            // 
            this.bunifuRegisteredButton.AllowToggling = false;
            this.bunifuRegisteredButton.AnimationSpeed = 200;
            this.bunifuRegisteredButton.AutoGenerateColors = false;
            this.bunifuRegisteredButton.BackColor = System.Drawing.Color.Transparent;
            this.bunifuRegisteredButton.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(90)))));
            this.bunifuRegisteredButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuRegisteredButton.BackgroundImage")));
            this.bunifuRegisteredButton.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuRegisteredButton.ButtonText = "Зарегистрироваться";
            this.bunifuRegisteredButton.ButtonTextMarginLeft = 0;
            this.bunifuRegisteredButton.ColorContrastOnClick = 45;
            this.bunifuRegisteredButton.ColorContrastOnHover = 45;
            this.bunifuRegisteredButton.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges4.BottomLeft = true;
            borderEdges4.BottomRight = true;
            borderEdges4.TopLeft = true;
            borderEdges4.TopRight = true;
            this.bunifuRegisteredButton.CustomizableEdges = borderEdges4;
            this.bunifuRegisteredButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bunifuRegisteredButton.DisabledBorderColor = System.Drawing.Color.Empty;
            this.bunifuRegisteredButton.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.bunifuRegisteredButton.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.bunifuRegisteredButton.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.bunifuRegisteredButton.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.bunifuRegisteredButton.ForeColor = System.Drawing.Color.White;
            this.bunifuRegisteredButton.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuRegisteredButton.IconMarginLeft = 11;
            this.bunifuRegisteredButton.IconPadding = 10;
            this.bunifuRegisteredButton.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuRegisteredButton.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(90)))));
            this.bunifuRegisteredButton.IdleBorderRadius = 3;
            this.bunifuRegisteredButton.IdleBorderThickness = 1;
            this.bunifuRegisteredButton.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(90)))));
            this.bunifuRegisteredButton.IdleIconLeftImage = null;
            this.bunifuRegisteredButton.IdleIconRightImage = null;
            this.bunifuRegisteredButton.IndicateFocus = false;
            this.bunifuRegisteredButton.Location = new System.Drawing.Point(312, 528);
            this.bunifuRegisteredButton.Name = "bunifuRegisteredButton";
            this.bunifuRegisteredButton.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(129)))), ((int)(((byte)(90)))));
            this.bunifuRegisteredButton.onHoverState.BorderRadius = 3;
            this.bunifuRegisteredButton.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuRegisteredButton.onHoverState.BorderThickness = 1;
            this.bunifuRegisteredButton.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(129)))), ((int)(((byte)(90)))));
            this.bunifuRegisteredButton.onHoverState.ForeColor = System.Drawing.Color.White;
            this.bunifuRegisteredButton.onHoverState.IconLeftImage = null;
            this.bunifuRegisteredButton.onHoverState.IconRightImage = null;
            this.bunifuRegisteredButton.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(90)))));
            this.bunifuRegisteredButton.OnIdleState.BorderRadius = 3;
            this.bunifuRegisteredButton.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuRegisteredButton.OnIdleState.BorderThickness = 1;
            this.bunifuRegisteredButton.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(90)))));
            this.bunifuRegisteredButton.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.bunifuRegisteredButton.OnIdleState.IconLeftImage = null;
            this.bunifuRegisteredButton.OnIdleState.IconRightImage = null;
            this.bunifuRegisteredButton.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(90)))));
            this.bunifuRegisteredButton.OnPressedState.BorderRadius = 3;
            this.bunifuRegisteredButton.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuRegisteredButton.OnPressedState.BorderThickness = 1;
            this.bunifuRegisteredButton.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(90)))));
            this.bunifuRegisteredButton.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.bunifuRegisteredButton.OnPressedState.IconLeftImage = null;
            this.bunifuRegisteredButton.OnPressedState.IconRightImage = null;
            this.bunifuRegisteredButton.Size = new System.Drawing.Size(197, 41);
            this.bunifuRegisteredButton.TabIndex = 10;
            this.bunifuRegisteredButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuRegisteredButton.TextMarginLeft = 0;
            this.bunifuRegisteredButton.UseDefaultRadiusAndThickness = true;
            this.bunifuRegisteredButton.Click += new System.EventHandler(this.BunifuRegisteredButton_Click);
            // 
            // bunifuLoginButton
            // 
            this.bunifuLoginButton.AllowToggling = false;
            this.bunifuLoginButton.AnimationSpeed = 200;
            this.bunifuLoginButton.AutoGenerateColors = false;
            this.bunifuLoginButton.BackColor = System.Drawing.Color.Transparent;
            this.bunifuLoginButton.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(90)))));
            this.bunifuLoginButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuLoginButton.BackgroundImage")));
            this.bunifuLoginButton.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuLoginButton.ButtonText = "Войти";
            this.bunifuLoginButton.ButtonTextMarginLeft = 0;
            this.bunifuLoginButton.ColorContrastOnClick = 45;
            this.bunifuLoginButton.ColorContrastOnHover = 45;
            this.bunifuLoginButton.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges3.BottomLeft = true;
            borderEdges3.BottomRight = true;
            borderEdges3.TopLeft = true;
            borderEdges3.TopRight = true;
            this.bunifuLoginButton.CustomizableEdges = borderEdges3;
            this.bunifuLoginButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bunifuLoginButton.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.bunifuLoginButton.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.bunifuLoginButton.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.bunifuLoginButton.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.bunifuLoginButton.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.bunifuLoginButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bunifuLoginButton.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuLoginButton.IconMarginLeft = 11;
            this.bunifuLoginButton.IconPadding = 10;
            this.bunifuLoginButton.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuLoginButton.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(90)))));
            this.bunifuLoginButton.IdleBorderRadius = 3;
            this.bunifuLoginButton.IdleBorderThickness = 1;
            this.bunifuLoginButton.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(90)))));
            this.bunifuLoginButton.IdleIconLeftImage = null;
            this.bunifuLoginButton.IdleIconRightImage = null;
            this.bunifuLoginButton.IndicateFocus = false;
            this.bunifuLoginButton.Location = new System.Drawing.Point(280, 374);
            this.bunifuLoginButton.Name = "bunifuLoginButton";
            this.bunifuLoginButton.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(129)))), ((int)(((byte)(90)))));
            this.bunifuLoginButton.onHoverState.BorderRadius = 3;
            this.bunifuLoginButton.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuLoginButton.onHoverState.BorderThickness = 1;
            this.bunifuLoginButton.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(129)))), ((int)(((byte)(90)))));
            this.bunifuLoginButton.onHoverState.ForeColor = System.Drawing.Color.White;
            this.bunifuLoginButton.onHoverState.IconLeftImage = null;
            this.bunifuLoginButton.onHoverState.IconRightImage = null;
            this.bunifuLoginButton.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(90)))));
            this.bunifuLoginButton.OnIdleState.BorderRadius = 3;
            this.bunifuLoginButton.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuLoginButton.OnIdleState.BorderThickness = 1;
            this.bunifuLoginButton.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(90)))));
            this.bunifuLoginButton.OnIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bunifuLoginButton.OnIdleState.IconLeftImage = null;
            this.bunifuLoginButton.OnIdleState.IconRightImage = null;
            this.bunifuLoginButton.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(90)))));
            this.bunifuLoginButton.OnPressedState.BorderRadius = 3;
            this.bunifuLoginButton.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuLoginButton.OnPressedState.BorderThickness = 1;
            this.bunifuLoginButton.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(90)))));
            this.bunifuLoginButton.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.bunifuLoginButton.OnPressedState.IconLeftImage = null;
            this.bunifuLoginButton.OnPressedState.IconRightImage = null;
            this.bunifuLoginButton.Size = new System.Drawing.Size(263, 45);
            this.bunifuLoginButton.TabIndex = 10;
            this.bunifuLoginButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuLoginButton.TextMarginLeft = 0;
            this.bunifuLoginButton.UseDefaultRadiusAndThickness = true;
            this.bunifuLoginButton.Click += new System.EventHandler(this.BunifuLoginButton_Click);
            // 
            // bunifuUserDropdown
            // 
            this.bunifuUserDropdown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(69)))), ((int)(((byte)(80)))));
            this.bunifuUserDropdown.BorderRadius = 1;
            this.bunifuUserDropdown.Color = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.bunifuUserDropdown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuUserDropdown.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
            this.bunifuUserDropdown.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuUserDropdown.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.bunifuUserDropdown.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thick;
            this.bunifuUserDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bunifuUserDropdown.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.bunifuUserDropdown.FillDropDown = false;
            this.bunifuUserDropdown.FillIndicator = false;
            this.bunifuUserDropdown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bunifuUserDropdown.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bunifuUserDropdown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.bunifuUserDropdown.FormattingEnabled = true;
            this.bunifuUserDropdown.Icon = null;
            this.bunifuUserDropdown.IndicatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.bunifuUserDropdown.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.bunifuUserDropdown.ItemBackColor = System.Drawing.Color.White;
            this.bunifuUserDropdown.ItemBorderColor = System.Drawing.Color.White;
            this.bunifuUserDropdown.ItemForeColor = System.Drawing.Color.DarkSlateGray;
            this.bunifuUserDropdown.ItemHeight = 26;
            this.bunifuUserDropdown.ItemHighLightColor = System.Drawing.Color.PowderBlue;
            this.bunifuUserDropdown.Location = new System.Drawing.Point(280, 253);
            this.bunifuUserDropdown.Name = "bunifuUserDropdown";
            this.bunifuUserDropdown.Size = new System.Drawing.Size(404, 32);
            this.bunifuUserDropdown.TabIndex = 8;
            this.bunifuUserDropdown.Text = null;
            this.bunifuUserDropdown.SelectedIndexChanged += new System.EventHandler(this.BunifuUserDropdown_SelectedIndexChanged);
            // 
            // bunifuPasswordTextBox
            // 
            this.bunifuPasswordTextBox.AcceptsReturn = false;
            this.bunifuPasswordTextBox.AcceptsTab = false;
            this.bunifuPasswordTextBox.AnimationSpeed = 200;
            this.bunifuPasswordTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.bunifuPasswordTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.bunifuPasswordTextBox.BackColor = System.Drawing.Color.White;
            this.bunifuPasswordTextBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuPasswordTextBox.BackgroundImage")));
            this.bunifuPasswordTextBox.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.bunifuPasswordTextBox.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.bunifuPasswordTextBox.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.bunifuPasswordTextBox.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.bunifuPasswordTextBox.BorderRadius = 1;
            this.bunifuPasswordTextBox.BorderThickness = 1;
            this.bunifuPasswordTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.bunifuPasswordTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.bunifuPasswordTextBox.DefaultFont = new System.Drawing.Font("Century Gothic", 14.25F);
            this.bunifuPasswordTextBox.DefaultText = "";
            this.bunifuPasswordTextBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(69)))), ((int)(((byte)(80)))));
            this.bunifuPasswordTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.bunifuPasswordTextBox.HideSelection = true;
            this.bunifuPasswordTextBox.IconLeft = null;
            this.bunifuPasswordTextBox.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.bunifuPasswordTextBox.IconPadding = 10;
            this.bunifuPasswordTextBox.IconRight = null;
            this.bunifuPasswordTextBox.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.bunifuPasswordTextBox.Lines = new string[0];
            this.bunifuPasswordTextBox.Location = new System.Drawing.Point(280, 309);
            this.bunifuPasswordTextBox.MaxLength = 32767;
            this.bunifuPasswordTextBox.MinimumSize = new System.Drawing.Size(100, 35);
            this.bunifuPasswordTextBox.Modified = false;
            this.bunifuPasswordTextBox.Multiline = false;
            this.bunifuPasswordTextBox.Name = "bunifuPasswordTextBox";
            stateProperties5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            stateProperties5.FillColor = System.Drawing.Color.Empty;
            stateProperties5.ForeColor = System.Drawing.Color.Empty;
            stateProperties5.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.bunifuPasswordTextBox.OnActiveState = stateProperties5;
            stateProperties6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            stateProperties6.FillColor = System.Drawing.Color.White;
            stateProperties6.ForeColor = System.Drawing.Color.Empty;
            stateProperties6.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.bunifuPasswordTextBox.OnDisabledState = stateProperties6;
            stateProperties7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            stateProperties7.FillColor = System.Drawing.Color.Empty;
            stateProperties7.ForeColor = System.Drawing.Color.Empty;
            stateProperties7.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.bunifuPasswordTextBox.OnHoverState = stateProperties7;
            stateProperties8.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            stateProperties8.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(69)))), ((int)(((byte)(80)))));
            stateProperties8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            stateProperties8.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.bunifuPasswordTextBox.OnIdleState = stateProperties8;
            this.bunifuPasswordTextBox.PasswordChar = '\0';
            this.bunifuPasswordTextBox.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.bunifuPasswordTextBox.PlaceholderText = "";
            this.bunifuPasswordTextBox.ReadOnly = false;
            this.bunifuPasswordTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.bunifuPasswordTextBox.SelectedText = "";
            this.bunifuPasswordTextBox.SelectionLength = 0;
            this.bunifuPasswordTextBox.SelectionStart = 0;
            this.bunifuPasswordTextBox.ShortcutsEnabled = true;
            this.bunifuPasswordTextBox.Size = new System.Drawing.Size(404, 35);
            this.bunifuPasswordTextBox.Style = Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox._Style.Bunifu;
            this.bunifuPasswordTextBox.TabIndex = 7;
            this.bunifuPasswordTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.bunifuPasswordTextBox.TextMarginBottom = 0;
            this.bunifuPasswordTextBox.TextMarginLeft = 5;
            this.bunifuPasswordTextBox.TextMarginTop = 0;
            this.bunifuPasswordTextBox.TextPlaceholder = "";
            this.bunifuPasswordTextBox.UseSystemPasswordChar = false;
            this.bunifuPasswordTextBox.WordWrap = true;
            // 
            // bunifuCloseButton
            // 
            this.bunifuCloseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuCloseButton.Image = ((System.Drawing.Image)(resources.GetObject("bunifuCloseButton.Image")));
            this.bunifuCloseButton.ImageActive = null;
            this.bunifuCloseButton.Location = new System.Drawing.Point(753, 12);
            this.bunifuCloseButton.Name = "bunifuCloseButton";
            this.bunifuCloseButton.Size = new System.Drawing.Size(35, 39);
            this.bunifuCloseButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuCloseButton.TabIndex = 6;
            this.bunifuCloseButton.TabStop = false;
            this.bunifuCloseButton.Zoom = 10;
            this.bunifuCloseButton.Click += new System.EventHandler(this.BunifuCloseButton_Click);
            // 
            // bunifuLabel2
            // 
            this.bunifuLabel2.AutoEllipsis = false;
            this.bunifuLabel2.BackColor = System.Drawing.Color.Empty;
            this.bunifuLabel2.CursorType = null;
            this.bunifuLabel2.EllipsisFormat = Bunifu.UI.WinForms.Ellipsis.EllipsisFormat.Start;
            this.bunifuLabel2.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bunifuLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.bunifuLabel2.Location = new System.Drawing.Point(92, 309);
            this.bunifuLabel2.Name = "bunifuLabel2";
            this.bunifuLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel2.Size = new System.Drawing.Size(128, 42);
            this.bunifuLabel2.TabIndex = 5;
            this.bunifuLabel2.Text = "Пароль";
            this.bunifuLabel2.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel2.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bunifuLabel3
            // 
            this.bunifuLabel3.AutoEllipsis = false;
            this.bunifuLabel3.BackColor = System.Drawing.Color.Empty;
            this.bunifuLabel3.CursorType = null;
            this.bunifuLabel3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bunifuLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.bunifuLabel3.Location = new System.Drawing.Point(149, 499);
            this.bunifuLabel3.Name = "bunifuLabel3";
            this.bunifuLabel3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel3.Size = new System.Drawing.Size(533, 23);
            this.bunifuLabel3.TabIndex = 5;
            this.bunifuLabel3.Text = "Если Вы работаете в первый раз, пожалуйста, зарегистрируйтесь.";
            this.bunifuLabel3.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel3.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bunifuLabel1
            // 
            this.bunifuLabel1.AutoEllipsis = false;
            this.bunifuLabel1.BackColor = System.Drawing.Color.Empty;
            this.bunifuLabel1.CursorType = null;
            this.bunifuLabel1.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bunifuLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.bunifuLabel1.Location = new System.Drawing.Point(92, 245);
            this.bunifuLabel1.Name = "bunifuLabel1";
            this.bunifuLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel1.Size = new System.Drawing.Size(85, 42);
            this.bunifuLabel1.TabIndex = 5;
            this.bunifuLabel1.Text = "ФИО";
            this.bunifuLabel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel1.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bunifuImageButton2
            // 
            this.bunifuImageButton2.Image = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton2.Image")));
            this.bunifuImageButton2.ImageActive = null;
            this.bunifuImageButton2.Location = new System.Drawing.Point(1068, 1);
            this.bunifuImageButton2.Name = "bunifuImageButton2";
            this.bunifuImageButton2.Size = new System.Drawing.Size(29, 31);
            this.bunifuImageButton2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton2.TabIndex = 4;
            this.bunifuImageButton2.TabStop = false;
            this.bunifuImageButton2.Zoom = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 93);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 85);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bunifuCustomLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(800, 100);
            this.bunifuCustomLabel1.TabIndex = 0;
            this.bunifuCustomLabel1.Text = "Enterprise Asset Tracker\r\nАвторизация";
            this.bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = null;
            this.bunifuDragControl1.Vertical = true;
            // 
            // LoginForm
            // 
            this.AcceptButton = this.bunifuLoginButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuCloseButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel2;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel1;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private Bunifu.Framework.UI.BunifuImageButton bunifuCloseButton;
        private Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox bunifuPasswordTextBox;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel3;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton bunifuRegisteredButton;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton bunifuLoginButton;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        public Bunifu.UI.WinForms.BunifuDropdown bunifuUserDropdown;
    }
}