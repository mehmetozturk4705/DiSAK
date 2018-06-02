namespace DisAK
{
    partial class FareMenu
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
            this.clickTimer = new System.Windows.Forms.Timer(this.components);
            this.mouseMoveBox = new System.Windows.Forms.PictureBox();
            this.doubleClickBox = new System.Windows.Forms.PictureBox();
            this.rightClickBox = new System.Windows.Forms.PictureBox();
            this.leftClickBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.mouseMoveBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleClickBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightClickBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftClickBox)).BeginInit();
            this.SuspendLayout();
            // 
            // clickTimer
            // 
            this.clickTimer.Enabled = true;
            this.clickTimer.Interval = 50;
            this.clickTimer.Tick += new System.EventHandler(this.clickTimer_Tick);
            // 
            // mouseMoveBox
            // 
            this.mouseMoveBox.BackColor = System.Drawing.Color.DarkGray;
            this.mouseMoveBox.BackgroundImage = global::DisAK.Properties.Resources.mousemove;
            this.mouseMoveBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mouseMoveBox.Location = new System.Drawing.Point(319, 13);
            this.mouseMoveBox.Name = "mouseMoveBox";
            this.mouseMoveBox.Size = new System.Drawing.Size(96, 96);
            this.mouseMoveBox.TabIndex = 3;
            this.mouseMoveBox.TabStop = false;
            this.mouseMoveBox.MouseEnter += new System.EventHandler(this.ButtonsMouseEnter);
            this.mouseMoveBox.MouseLeave += new System.EventHandler(this.ButtonsMouseLeave);
            // 
            // doubleClickBox
            // 
            this.doubleClickBox.BackColor = System.Drawing.Color.DarkGray;
            this.doubleClickBox.BackgroundImage = global::DisAK.Properties.Resources.doubleclick;
            this.doubleClickBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.doubleClickBox.Location = new System.Drawing.Point(217, 13);
            this.doubleClickBox.Name = "doubleClickBox";
            this.doubleClickBox.Size = new System.Drawing.Size(96, 96);
            this.doubleClickBox.TabIndex = 2;
            this.doubleClickBox.TabStop = false;
            this.doubleClickBox.Click += new System.EventHandler(this.doubleClickBox_Click);
            this.doubleClickBox.MouseEnter += new System.EventHandler(this.ButtonsMouseEnter);
            this.doubleClickBox.MouseLeave += new System.EventHandler(this.ButtonsMouseLeave);
            // 
            // rightClickBox
            // 
            this.rightClickBox.BackColor = System.Drawing.Color.DarkGray;
            this.rightClickBox.BackgroundImage = global::DisAK.Properties.Resources.rightclick;
            this.rightClickBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rightClickBox.Location = new System.Drawing.Point(115, 13);
            this.rightClickBox.Name = "rightClickBox";
            this.rightClickBox.Size = new System.Drawing.Size(96, 96);
            this.rightClickBox.TabIndex = 1;
            this.rightClickBox.TabStop = false;
            this.rightClickBox.Click += new System.EventHandler(this.rightClickBox_Click);
            this.rightClickBox.MouseEnter += new System.EventHandler(this.ButtonsMouseEnter);
            this.rightClickBox.MouseLeave += new System.EventHandler(this.ButtonsMouseLeave);
            // 
            // leftClickBox
            // 
            this.leftClickBox.BackColor = System.Drawing.Color.DarkGray;
            this.leftClickBox.BackgroundImage = global::DisAK.Properties.Resources.leftclick;
            this.leftClickBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.leftClickBox.Location = new System.Drawing.Point(13, 13);
            this.leftClickBox.Name = "leftClickBox";
            this.leftClickBox.Size = new System.Drawing.Size(96, 96);
            this.leftClickBox.TabIndex = 0;
            this.leftClickBox.TabStop = false;
            this.leftClickBox.Click += new System.EventHandler(this.leftClickBox_Click);
            this.leftClickBox.MouseEnter += new System.EventHandler(this.ButtonsMouseEnter);
            this.leftClickBox.MouseLeave += new System.EventHandler(this.ButtonsMouseLeave);
            // 
            // FareMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 117);
            this.ControlBox = false;
            this.Controls.Add(this.mouseMoveBox);
            this.Controls.Add(this.doubleClickBox);
            this.Controls.Add(this.rightClickBox);
            this.Controls.Add(this.leftClickBox);
            this.MaximumSize = new System.Drawing.Size(444, 156);
            this.MinimumSize = new System.Drawing.Size(444, 156);
            this.Name = "FareMenu";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Fare Menü";
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.FareMenu_Activated);
            this.Deactivate += new System.EventHandler(this.FareMenu_Deactivate);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FareMenu_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.mouseMoveBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleClickBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightClickBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftClickBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox leftClickBox;
        private System.Windows.Forms.PictureBox rightClickBox;
        private System.Windows.Forms.PictureBox doubleClickBox;
        private System.Windows.Forms.PictureBox mouseMoveBox;
        private System.Windows.Forms.Timer clickTimer;
    }
}