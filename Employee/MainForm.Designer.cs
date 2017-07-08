namespace BIG.Present
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btn_employee = new System.Windows.Forms.PictureBox();
            this.lnk_employee = new System.Windows.Forms.LinkLabel();
            this.btn_setting = new System.Windows.Forms.PictureBox();
            this.lnk_setting = new System.Windows.Forms.LinkLabel();
            this.btn_report = new System.Windows.Forms.PictureBox();
            this.lnk_report = new System.Windows.Forms.LinkLabel();
            this.btn_company = new System.Windows.Forms.PictureBox();
            this.lnk_company = new System.Windows.Forms.LinkLabel();
            this.btn_close = new System.Windows.Forms.PictureBox();
            this.btn_home = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btn_employee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_setting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_report)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_company)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_close)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_home)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_employee
            // 
            this.btn_employee.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_employee.Image = global::BIG.Present.Properties.Resources.personal;
            this.btn_employee.Location = new System.Drawing.Point(267, 218);
            this.btn_employee.Margin = new System.Windows.Forms.Padding(4);
            this.btn_employee.Name = "btn_employee";
            this.btn_employee.Size = new System.Drawing.Size(100, 92);
            this.btn_employee.TabIndex = 7;
            this.btn_employee.TabStop = false;
            this.btn_employee.Click += new System.EventHandler(this.btn_employee_Click);
            // 
            // lnk_employee
            // 
            this.lnk_employee.AutoSize = true;
            this.lnk_employee.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lnk_employee.Location = new System.Drawing.Point(247, 314);
            this.lnk_employee.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnk_employee.Name = "lnk_employee";
            this.lnk_employee.Size = new System.Drawing.Size(120, 24);
            this.lnk_employee.TabIndex = 8;
            this.lnk_employee.TabStop = true;
            this.lnk_employee.Text = "ประวัติพนักงาน";
            this.lnk_employee.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_employee_LinkClicked);
            // 
            // btn_setting
            // 
            this.btn_setting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_setting.Image = global::BIG.Present.Properties.Resources.setting;
            this.btn_setting.Location = new System.Drawing.Point(802, 220);
            this.btn_setting.Margin = new System.Windows.Forms.Padding(4);
            this.btn_setting.Name = "btn_setting";
            this.btn_setting.Size = new System.Drawing.Size(100, 92);
            this.btn_setting.TabIndex = 9;
            this.btn_setting.TabStop = false;
            this.btn_setting.Click += new System.EventHandler(this.btn_setting_Click);
            // 
            // lnk_setting
            // 
            this.lnk_setting.AutoSize = true;
            this.lnk_setting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnk_setting.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lnk_setting.Location = new System.Drawing.Point(799, 314);
            this.lnk_setting.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnk_setting.Name = "lnk_setting";
            this.lnk_setting.Size = new System.Drawing.Size(90, 24);
            this.lnk_setting.TabIndex = 10;
            this.lnk_setting.TabStop = true;
            this.lnk_setting.Text = "ตั้งค่าบริษัท";
            this.lnk_setting.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_setting_LinkClicked);
            // 
            // btn_report
            // 
            this.btn_report.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_report.Image = global::BIG.Present.Properties.Resources.skill;
            this.btn_report.Location = new System.Drawing.Point(652, 531);
            this.btn_report.Margin = new System.Windows.Forms.Padding(4);
            this.btn_report.Name = "btn_report";
            this.btn_report.Size = new System.Drawing.Size(97, 84);
            this.btn_report.TabIndex = 11;
            this.btn_report.TabStop = false;
            this.btn_report.Click += new System.EventHandler(this.btn_report_Click);
            // 
            // lnk_report
            // 
            this.lnk_report.AutoSize = true;
            this.lnk_report.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnk_report.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lnk_report.Location = new System.Drawing.Point(648, 619);
            this.lnk_report.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnk_report.Name = "lnk_report";
            this.lnk_report.Size = new System.Drawing.Size(64, 24);
            this.lnk_report.TabIndex = 12;
            this.lnk_report.TabStop = true;
            this.lnk_report.Text = "รายงาน";
            this.lnk_report.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // btn_company
            // 
            this.btn_company.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_company.Image = global::BIG.Present.Properties.Resources.network;
            this.btn_company.Location = new System.Drawing.Point(312, 531);
            this.btn_company.Margin = new System.Windows.Forms.Padding(4);
            this.btn_company.Name = "btn_company";
            this.btn_company.Size = new System.Drawing.Size(100, 92);
            this.btn_company.TabIndex = 17;
            this.btn_company.TabStop = false;
            this.btn_company.Click += new System.EventHandler(this.btn_company_Click);
            // 
            // lnk_company
            // 
            this.lnk_company.AutoSize = true;
            this.lnk_company.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnk_company.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lnk_company.Location = new System.Drawing.Point(307, 627);
            this.lnk_company.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnk_company.Name = "lnk_company";
            this.lnk_company.Size = new System.Drawing.Size(92, 24);
            this.lnk_company.TabIndex = 18;
            this.lnk_company.TabStop = true;
            this.lnk_company.Text = "ข้อมูลบริษัท";
            this.lnk_company.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_company_LinkClicked);
            // 
            // btn_close
            // 
            this.btn_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_close.Image = global::BIG.Present.Properties.Resources.Close2;
            this.btn_close.Location = new System.Drawing.Point(1087, 1);
            this.btn_close.Margin = new System.Windows.Forms.Padding(4);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(32, 30);
            this.btn_close.TabIndex = 20;
            this.btn_close.TabStop = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_home
            // 
            this.btn_home.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_home.Image = global::BIG.Present.Properties.Resources.Home1;
            this.btn_home.Location = new System.Drawing.Point(1, 1);
            this.btn_home.Margin = new System.Windows.Forms.Padding(4);
            this.btn_home.Name = "btn_home";
            this.btn_home.Size = new System.Drawing.Size(32, 30);
            this.btn_home.TabIndex = 23;
            this.btn_home.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImage = global::BIG.Present.Properties.Resources.big_bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1121, 742);
            this.ControlBox = false;
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_home);
            this.Controls.Add(this.lnk_company);
            this.Controls.Add(this.btn_company);
            this.Controls.Add(this.lnk_report);
            this.Controls.Add(this.btn_report);
            this.Controls.Add(this.lnk_setting);
            this.Controls.Add(this.btn_setting);
            this.Controls.Add(this.lnk_employee);
            this.Controls.Add(this.btn_employee);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "โปรแกรมจัดการข้อมูลพนักงาน V1.4 (9 July 2017)";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btn_employee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_setting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_report)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_company)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_close)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_home)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox btn_employee;
        private System.Windows.Forms.LinkLabel lnk_employee;
        private System.Windows.Forms.PictureBox btn_setting;
        private System.Windows.Forms.LinkLabel lnk_setting;
        private System.Windows.Forms.PictureBox btn_report;
        private System.Windows.Forms.LinkLabel lnk_report;
        private System.Windows.Forms.PictureBox btn_company;
        private System.Windows.Forms.LinkLabel lnk_company;
        private System.Windows.Forms.PictureBox btn_close;
        private System.Windows.Forms.PictureBox btn_home;




    }
}