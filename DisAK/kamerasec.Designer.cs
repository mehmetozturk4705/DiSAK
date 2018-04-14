namespace DisAK
{
    partial class kamerasec
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(kamerasec));
            this.kameralar = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tamam = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // kameralar
            // 
            this.kameralar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kameralar.FormattingEnabled = true;
            this.kameralar.ItemHeight = 13;
            this.kameralar.Location = new System.Drawing.Point(13, 35);
            this.kameralar.Name = "kameralar";
            this.kameralar.Size = new System.Drawing.Size(363, 21);
            this.kameralar.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Please select your camera";
            // 
            // tamam
            // 
            this.tamam.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.tamam.Location = new System.Drawing.Point(149, 94);
            this.tamam.Name = "tamam";
            this.tamam.Size = new System.Drawing.Size(75, 23);
            this.tamam.TabIndex = 2;
            this.tamam.Text = "Ok";
            this.tamam.UseVisualStyleBackColor = true;
            this.tamam.Click += new System.EventHandler(this.tamam_Click);
            // 
            // kamerasec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 129);
            this.ControlBox = false;
            this.Controls.Add(this.tamam);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.kameralar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(404, 168);
            this.MinimumSize = new System.Drawing.Size(404, 168);
            this.Name = "kamerasec";
            this.ShowInTaskbar = false;
            this.Text = "Camera Settings";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.kamerasec_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox kameralar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button tamam;
    }
}