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
            this.btn_search = new System.Windows.Forms.PictureBox();
            this.lnk_search = new System.Windows.Forms.LinkLabel();
            this.btn_secure = new System.Windows.Forms.PictureBox();
            this.btn_company = new System.Windows.Forms.PictureBox();
            this.lnk_company = new System.Windows.Forms.LinkLabel();
            this.lnk_secure = new System.Windows.Forms.LinkLabel();
            this.btn_close = new System.Windows.Forms.PictureBox();
            this.btn_eval = new System.Windows.Forms.PictureBox();
            this.lnk_eval = new System.Windows.Forms.LinkLabel();
            this.btn_home = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btn_employee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_setting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_report)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_search)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_secure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_company)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_close)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_eval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_home)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_employee
            // 
            this.btn_employee.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_employee.Image = global::BIG.Present.Properties.Resources.personal;
            this.btn_employee.Location = new System.Drawing.Point(161, 276);
            this.btn_employee.Name = "btn_employee";
            this.btn_employee.Size = new System.Drawing.Size(75, 75);
            this.btn_employee.TabIndex = 7;
            this.btn_employee.TabStop = false;
            this.btn_employee.Click += new System.EventHandler(this.btn_employee_Click);
            // 
            // lnk_employee
            // 
            this.lnk_employee.AutoSize = true;
            this.lnk_employee.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lnk_employee.Location = new System.Drawing.Point(157, 354);
            this.lnk_employee.Name = "lnk_employee";
            this.lnk_employee.Size = new System.Drawing.Size(85, 21);
            this.lnk_employee.TabIndex = 8;
            this.lnk_employee.TabStop = true;
            this.lnk_employee.Text = "ประวัติพนักงาน";
            this.lnk_employee.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_employee_LinkClicked);
            // 
            // btn_setting
            // 
            this.btn_setting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_setting.Image = global::BIG.Present.Properties.Resources.setting;
            this.btn_setting.Location = new System.Drawing.Point(607, 276);
            this.btn_setting.Name = "btn_setting";
            this.btn_setting.Size = new System.Drawing.Size(75, 75);
            this.btn_setting.TabIndex = 9;
            this.btn_setting.TabStop = false;
            this.btn_setting.Click += new System.EventHandler(this.btn_setting_Click);
            // 
            // lnk_setting
            // 
            this.lnk_setting.AutoSize = true;
            this.lnk_setting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnk_setting.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lnk_setting.Location = new System.Drawing.Point(612, 354);
            this.lnk_setting.Name = "lnk_setting";
            this.lnk_setting.Size = new System.Drawing.Size(65, 21);
            this.lnk_setting.TabIndex = 10;
            this.lnk_setting.TabStop = true;
            this.lnk_setting.Text = "ตั้งค่าบริษัท";
            this.lnk_setting.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_setting_LinkClicked);
            // 
            // btn_report
            // 
            this.btn_report.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_report.Image = global::BIG.Present.Properties.Resources.skill;
            this.btn_report.Location = new System.Drawing.Point(481, 425);
            this.btn_report.Name = "btn_report";
            this.btn_report.Size = new System.Drawing.Size(73, 68);
            this.btn_report.TabIndex = 11;
            this.btn_report.TabStop = false;
            this.btn_report.Click += new System.EventHandler(this.btn_report_Click);
            // 
            // lnk_report
            // 
            this.lnk_report.AutoSize = true;
            this.lnk_report.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnk_report.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lnk_report.Location = new System.Drawing.Point(496, 496);
            this.lnk_report.Name = "lnk_report";
            this.lnk_report.Size = new System.Drawing.Size(48, 21);
            this.lnk_report.TabIndex = 12;
            this.lnk_report.TabStop = true;
            this.lnk_report.Text = "รายงาน";
            this.lnk_report.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // btn_search
            // 
            this.btn_search.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_search.Image = global::BIG.Present.Properties.Resources.search_;
            this.btn_search.Location = new System.Drawing.Point(244, 425);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(73, 68);
            this.btn_search.TabIndex = 13;
            this.btn_search.TabStop = false;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // lnk_search
            // 
            this.lnk_search.AutoSize = true;
            this.lnk_search.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnk_search.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lnk_search.Location = new System.Drawing.Point(262, 496);
            this.lnk_search.Name = "lnk_search";
            this.lnk_search.Size = new System.Drawing.Size(39, 21);
            this.lnk_search.TabIndex = 15;
            this.lnk_search.TabStop = true;
            this.lnk_search.Text = "ค้นหา";
            this.lnk_search.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_search_LinkClicked);
            // 
            // btn_secure
            // 
            this.btn_secure.Image = global::BIG.Present.Properties.Resources.lock_3;
            this.btn_secure.Location = new System.Drawing.Point(577, 114);
            this.btn_secure.Name = "btn_secure";
            this.btn_secure.Size = new System.Drawing.Size(75, 75);
            this.btn_secure.TabIndex = 16;
            this.btn_secure.TabStop = false;
            // 
            // btn_company
            // 
            this.btn_company.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_company.Image = global::BIG.Present.Properties.Resources.network;
            this.btn_company.Location = new System.Drawing.Point(255, 114);
            this.btn_company.Name = "btn_company";
            this.btn_company.Size = new System.Drawing.Size(75, 75);
            this.btn_company.TabIndex = 17;
            this.btn_company.TabStop = false;
            this.btn_company.Click += new System.EventHandler(this.btn_company_Click);
            // 
            // lnk_company
            // 
            this.lnk_company.AutoSize = true;
            this.lnk_company.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnk_company.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lnk_company.Location = new System.Drawing.Point(251, 192);
            this.lnk_company.Name = "lnk_company";
            this.lnk_company.Size = new System.Drawing.Size(68, 21);
            this.lnk_company.TabIndex = 18;
            this.lnk_company.TabStop = true;
            this.lnk_company.Text = "ข้อมูลบริษัท";
            this.lnk_company.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_company_LinkClicked);
            // 
            // lnk_secure
            // 
            this.lnk_secure.AutoSize = true;
            this.lnk_secure.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lnk_secure.Location = new System.Drawing.Point(573, 192);
            this.lnk_secure.Name = "lnk_secure";
            this.lnk_secure.Size = new System.Drawing.Size(80, 21);
            this.lnk_secure.TabIndex = 19;
            this.lnk_secure.TabStop = true;
            this.lnk_secure.Text = "ความปลอดภัย";
            // 
            // btn_close
            // 
            this.btn_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_close.Image = global::BIG.Present.Properties.Resources.Close2;
            this.btn_close.Location = new System.Drawing.Point(815, 1);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(24, 24);
            this.btn_close.TabIndex = 20;
            this.btn_close.TabStop = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_eval
            // 
            this.btn_eval.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_eval.Image = global::BIG.Present.Properties.Resources.eval;
            this.btn_eval.Location = new System.Drawing.Point(428, 57);
            this.btn_eval.Name = "btn_eval";
            this.btn_eval.Size = new System.Drawing.Size(75, 75);
            this.btn_eval.TabIndex = 21;
            this.btn_eval.TabStop = false;
            // 
            // lnk_eval
            // 
            this.lnk_eval.AutoSize = true;
            this.lnk_eval.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnk_eval.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lnk_eval.Location = new System.Drawing.Point(443, 135);
            this.lnk_eval.Name = "lnk_eval";
            this.lnk_eval.Size = new System.Drawing.Size(49, 21);
            this.lnk_eval.TabIndex = 22;
            this.lnk_eval.TabStop = true;
            this.lnk_eval.Text = "ประเมิน";
            // 
            // btn_home
            // 
            this.btn_home.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_home.Image = global::BIG.Present.Properties.Resources.Home1;
            this.btn_home.Location = new System.Drawing.Point(1, 1);
            this.btn_home.Name = "btn_home";
            this.btn_home.Size = new System.Drawing.Size(24, 24);
            this.btn_home.TabIndex = 23;
            this.btn_home.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImage = global::BIG.Present.Properties.Resources.big_bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(841, 603);
            this.ControlBox = false;
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_home);
            this.Controls.Add(this.lnk_eval);
            this.Controls.Add(this.btn_eval);
            this.Controls.Add(this.lnk_secure);
            this.Controls.Add(this.lnk_company);
            this.Controls.Add(this.btn_company);
            this.Controls.Add(this.btn_secure);
            this.Controls.Add(this.lnk_search);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.lnk_report);
            this.Controls.Add(this.btn_report);
            this.Controls.Add(this.lnk_setting);
            this.Controls.Add(this.btn_setting);
            this.Controls.Add(this.lnk_employee);
            this.Controls.Add(this.btn_employee);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "โปรแกรมจัดการข้อมูลพนักงาน";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btn_employee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_setting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_report)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_search)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_secure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_company)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_close)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_eval)).EndInit();
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
        private System.Windows.Forms.PictureBox btn_search;
        private System.Windows.Forms.LinkLabel lnk_search;
        private System.Windows.Forms.PictureBox btn_secure;
        private System.Windows.Forms.PictureBox btn_company;
        private System.Windows.Forms.LinkLabel lnk_company;
        private System.Windows.Forms.LinkLabel lnk_secure;
        private System.Windows.Forms.PictureBox btn_close;
        private System.Windows.Forms.PictureBox btn_eval;
        private System.Windows.Forms.LinkLabel lnk_eval;
        private System.Windows.Forms.PictureBox btn_home;




    }
}