namespace DisAK
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dosyaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yeniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yardımToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.goruntu = new Emgu.CV.UI.ImageBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.eyebox = new Emgu.CV.UI.ImageBox();
            this.console1 = new System.Windows.Forms.TextBox();
            this.facebox = new Emgu.CV.UI.ImageBox();
            this.bilgiler = new System.Windows.Forms.Label();
            this.dur = new System.Windows.Forms.Button();
            this.basla = new System.Windows.Forms.Button();
            this.labelcam = new System.Windows.Forms.Label();
            this.Caption = new System.Windows.Forms.Panel();
            this.butons = new System.Windows.Forms.Panel();
            this.minimize = new System.Windows.Forms.PictureBox();
            this.close = new System.Windows.Forms.PictureBox();
            this.fullscreen = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.notify = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.gösterGizleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.çıkışToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.mousetimer = new System.Windows.Forms.Timer(this.components);
            this.LeftEye = new Emgu.CV.UI.ImageBox();
            this.RightEye = new Emgu.CV.UI.ImageBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.goruntu)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eyebox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.facebox)).BeginInit();
            this.butons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.close)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fullscreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.notify.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LeftEye)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightEye)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Window;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dosyaToolStripMenuItem,
            this.yardımToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.menuStrip1.Location = new System.Drawing.Point(-2, 36);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(128, 22);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dosyaToolStripMenuItem
            // 
            this.dosyaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yeniToolStripMenuItem});
            this.dosyaToolStripMenuItem.Name = "dosyaToolStripMenuItem";
            this.dosyaToolStripMenuItem.Size = new System.Drawing.Size(59, 18);
            this.dosyaToolStripMenuItem.Text = "DOSYA";
            // 
            // yeniToolStripMenuItem
            // 
            this.yeniToolStripMenuItem.Name = "yeniToolStripMenuItem";
            this.yeniToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.yeniToolStripMenuItem.Text = "Yeni";
            // 
            // yardımToolStripMenuItem
            // 
            this.yardımToolStripMenuItem.Name = "yardımToolStripMenuItem";
            this.yardımToolStripMenuItem.Size = new System.Drawing.Size(63, 18);
            this.yardımToolStripMenuItem.Text = "YARDIM";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.goruntu);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.labelcam);
            this.groupBox1.Location = new System.Drawing.Point(12, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(902, 494);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // goruntu
            // 
            this.goruntu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.goruntu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.goruntu.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.goruntu.Location = new System.Drawing.Point(17, 40);
            this.goruntu.Name = "goruntu";
            this.goruntu.Size = new System.Drawing.Size(516, 437);
            this.goruntu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.goruntu.TabIndex = 2;
            this.goruntu.TabStop = false;
            this.goruntu.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.RightEye);
            this.groupBox2.Controls.Add(this.LeftEye);
            this.groupBox2.Controls.Add(this.eyebox);
            this.groupBox2.Controls.Add(this.console1);
            this.groupBox2.Controls.Add(this.facebox);
            this.groupBox2.Controls.Add(this.bilgiler);
            this.groupBox2.Controls.Add(this.dur);
            this.groupBox2.Controls.Add(this.basla);
            this.groupBox2.Location = new System.Drawing.Point(549, 40);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(347, 456);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Seçenekler";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // eyebox
            // 
            this.eyebox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.eyebox.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.eyebox.Location = new System.Drawing.Point(9, 159);
            this.eyebox.Name = "eyebox";
            this.eyebox.Size = new System.Drawing.Size(332, 128);
            this.eyebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.eyebox.TabIndex = 8;
            this.eyebox.TabStop = false;
            // 
            // console1
            // 
            this.console1.BackColor = System.Drawing.SystemColors.WindowText;
            this.console1.Font = new System.Drawing.Font("Prestige Elite Std", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.console1.ForeColor = System.Drawing.Color.Brown;
            this.console1.Location = new System.Drawing.Point(9, 48);
            this.console1.Multiline = true;
            this.console1.Name = "console1";
            this.console1.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.console1.Size = new System.Drawing.Size(195, 105);
            this.console1.TabIndex = 7;
            this.console1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // facebox
            // 
            this.facebox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.facebox.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.facebox.Location = new System.Drawing.Point(210, 19);
            this.facebox.Name = "facebox";
            this.facebox.Size = new System.Drawing.Size(131, 134);
            this.facebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.facebox.TabIndex = 2;
            this.facebox.TabStop = false;
            this.facebox.Visible = false;
            // 
            // bilgiler
            // 
            this.bilgiler.AutoSize = true;
            this.bilgiler.Location = new System.Drawing.Point(27, 140);
            this.bilgiler.Name = "bilgiler";
            this.bilgiler.Size = new System.Drawing.Size(0, 13);
            this.bilgiler.TabIndex = 6;
            // 
            // dur
            // 
            this.dur.Enabled = false;
            this.dur.Location = new System.Drawing.Point(112, 19);
            this.dur.Name = "dur";
            this.dur.Size = new System.Drawing.Size(92, 23);
            this.dur.TabIndex = 5;
            this.dur.Text = "Dur";
            this.dur.UseVisualStyleBackColor = true;
            this.dur.Click += new System.EventHandler(this.dur_Click);
            // 
            // basla
            // 
            this.basla.Location = new System.Drawing.Point(6, 19);
            this.basla.Name = "basla";
            this.basla.Size = new System.Drawing.Size(100, 23);
            this.basla.TabIndex = 2;
            this.basla.Text = "Başlat";
            this.basla.UseVisualStyleBackColor = true;
            this.basla.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelcam
            // 
            this.labelcam.AutoSize = true;
            this.labelcam.Location = new System.Drawing.Point(14, 20);
            this.labelcam.Name = "labelcam";
            this.labelcam.Size = new System.Drawing.Size(0, 13);
            this.labelcam.TabIndex = 1;
            // 
            // Caption
            // 
            this.Caption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Caption.BackColor = System.Drawing.Color.White;
            this.Caption.Location = new System.Drawing.Point(46, -4);
            this.Caption.Name = "Caption";
            this.Caption.Size = new System.Drawing.Size(763, 40);
            this.Caption.TabIndex = 3;
            this.Caption.Paint += new System.Windows.Forms.PaintEventHandler(this.Caption_Paint);
            this.Caption.DoubleClick += new System.EventHandler(this.fullscreen_Click);
            this.Caption.MouseDown += new System.Windows.Forms.MouseEventHandler(this.captionmousedown);
            this.Caption.MouseMove += new System.Windows.Forms.MouseEventHandler(this.captionmove);
            // 
            // butons
            // 
            this.butons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butons.Controls.Add(this.minimize);
            this.butons.Controls.Add(this.close);
            this.butons.Controls.Add(this.fullscreen);
            this.butons.Location = new System.Drawing.Point(815, -3);
            this.butons.Name = "butons";
            this.butons.Size = new System.Drawing.Size(108, 39);
            this.butons.TabIndex = 7;
            // 
            // minimize
            // 
            this.minimize.Location = new System.Drawing.Point(9, 8);
            this.minimize.Name = "minimize";
            this.minimize.Size = new System.Drawing.Size(26, 26);
            this.minimize.TabIndex = 4;
            this.minimize.TabStop = false;
            this.minimize.Click += new System.EventHandler(this.minimize_Click);
            this.minimize.Paint += new System.Windows.Forms.PaintEventHandler(this.minimizepaint);
            this.minimize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.butonmousedown);
            this.minimize.MouseEnter += new System.EventHandler(this.butonmouseenter);
            this.minimize.MouseLeave += new System.EventHandler(this.butonmouseleave);
            this.minimize.MouseUp += new System.Windows.Forms.MouseEventHandler(this.butonmouseup);
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(73, 8);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(26, 26);
            this.close.TabIndex = 5;
            this.close.TabStop = false;
            this.close.Click += new System.EventHandler(this.close_Click);
            this.close.Paint += new System.Windows.Forms.PaintEventHandler(this.closepaint);
            this.close.MouseDown += new System.Windows.Forms.MouseEventHandler(this.butonmousedown);
            this.close.MouseEnter += new System.EventHandler(this.butonmouseenter);
            this.close.MouseLeave += new System.EventHandler(this.butonmouseleave);
            this.close.MouseUp += new System.Windows.Forms.MouseEventHandler(this.butonmouseup);
            // 
            // fullscreen
            // 
            this.fullscreen.Location = new System.Drawing.Point(41, 8);
            this.fullscreen.Name = "fullscreen";
            this.fullscreen.Size = new System.Drawing.Size(26, 26);
            this.fullscreen.TabIndex = 6;
            this.fullscreen.TabStop = false;
            this.fullscreen.Click += new System.EventHandler(this.fullscreen_Click);
            this.fullscreen.Paint += new System.Windows.Forms.PaintEventHandler(this.maximizepaint);
            this.fullscreen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.butonmousedown);
            this.fullscreen.MouseEnter += new System.EventHandler(this.butonmouseenter);
            this.fullscreen.MouseLeave += new System.EventHandler(this.butonmouseleave);
            this.fullscreen.MouseUp += new System.Windows.Forms.MouseEventHandler(this.butonmouseup);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::DisAK.Properties.Resources.pngupt;
            this.pictureBox1.Location = new System.Drawing.Point(11, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.logopaint);
            // 
            // notify
            // 
            this.notify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gösterGizleToolStripMenuItem,
            this.çıkışToolStripMenuItem});
            this.notify.Name = "notify";
            this.notify.Size = new System.Drawing.Size(139, 48);
            // 
            // gösterGizleToolStripMenuItem
            // 
            this.gösterGizleToolStripMenuItem.Name = "gösterGizleToolStripMenuItem";
            this.gösterGizleToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.gösterGizleToolStripMenuItem.Text = "Göster/Gizle";
            this.gösterGizleToolStripMenuItem.Click += new System.EventHandler(this.gösterGizleToolStripMenuItem_Click);
            // 
            // çıkışToolStripMenuItem
            // 
            this.çıkışToolStripMenuItem.Name = "çıkışToolStripMenuItem";
            this.çıkışToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.çıkışToolStripMenuItem.Text = "Çıkış";
            this.çıkışToolStripMenuItem.Click += new System.EventHandler(this.çıkışToolStripMenuItem_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "DiSAK çalışmaya devam ediyor";
            this.notifyIcon.BalloonTipTitle = "DiSAK";
            this.notifyIcon.ContextMenuStrip = this.notify;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "DiSAK";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // mousetimer
            // 
            this.mousetimer.Enabled = true;
            this.mousetimer.Interval = 10;
            this.mousetimer.Tick += new System.EventHandler(this.MouseControl_tick);
            // 
            // LeftEye
            // 
            this.LeftEye.Location = new System.Drawing.Point(9, 293);
            this.LeftEye.Name = "LeftEye";
            this.LeftEye.Size = new System.Drawing.Size(154, 144);
            this.LeftEye.TabIndex = 2;
            this.LeftEye.TabStop = false;
            // 
            // RightEye
            // 
            this.RightEye.Location = new System.Drawing.Point(187, 293);
            this.RightEye.Name = "RightEye";
            this.RightEye.Size = new System.Drawing.Size(154, 144);
            this.RightEye.TabIndex = 9;
            this.RightEye.TabStop = false;
            // 
            // Form1
            // 
            this.AccessibleName = "DisAK (Aid Kit for New Generation)";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(920, 578);
            this.ControlBox = false;
            this.Controls.Add(this.butons);
            this.Controls.Add(this.Caption);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(920, 400);
            this.Name = "Form1";
            this.Text = "DisAK";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.onFormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.goruntu)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eyebox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.facebox)).EndInit();
            this.butons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.minimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.close)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fullscreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.notify.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LeftEye)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightEye)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dosyaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yardımToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripMenuItem yeniToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel Caption;
        private System.Windows.Forms.PictureBox minimize;
        private System.Windows.Forms.PictureBox close;
        private System.Windows.Forms.PictureBox fullscreen;
        private System.Windows.Forms.Panel butons;
        private System.Windows.Forms.Label labelcam;
        private System.Windows.Forms.Button basla;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button dur;
        private System.Windows.Forms.Label bilgiler;
        private Emgu.CV.UI.ImageBox goruntu;
        private Emgu.CV.UI.ImageBox facebox;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ContextMenuStrip notify;
        private System.Windows.Forms.ToolStripMenuItem gösterGizleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem çıkışToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox console1;
        private System.Windows.Forms.Timer mousetimer;
        private Emgu.CV.UI.ImageBox eyebox;
        private Emgu.CV.UI.ImageBox RightEye;
        private Emgu.CV.UI.ImageBox LeftEye;

    }
}

