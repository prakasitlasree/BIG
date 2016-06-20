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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btn_employee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_setting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_report)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_search)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_secure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_company)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_close)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_eval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(841, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btn_employee
            // 
            this.btn_employee.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_employee.Image = global::BIG.Present.Properties.Resources.personal;
            this.btn_employee.Location = new System.Drawing.Point(120, 287);
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
            this.lnk_employee.Location = new System.Drawing.Point(129, 365);
            this.lnk_employee.Name = "lnk_employee";
            this.lnk_employee.Size = new System.Drawing.Size(56, 21);
            this.lnk_employee.TabIndex = 8;
            this.lnk_employee.TabStop = true;
            this.lnk_employee.Text = "สมัครงาน";
            this.lnk_employee.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_employee_LinkClicked);
            // 
            // btn_setting
            // 
            this.btn_setting.Image = global::BIG.Present.Properties.Resources.setting;
            this.btn_setting.Location = new System.Drawing.Point(660, 287);
            this.btn_setting.Name = "btn_setting";
            this.btn_setting.Size = new System.Drawing.Size(75, 75);
            this.btn_setting.TabIndex = 9;
            this.btn_setting.TabStop = false;
            this.btn_setting.Click += new System.EventHandler(this.btn_setting_Click);
            // 
            // lnk_setting
            // 
            this.lnk_setting.AutoSize = true;
            this.lnk_setting.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lnk_setting.Location = new System.Drawing.Point(656, 365);
            this.lnk_setting.Name = "lnk_setting";
            this.lnk_setting.Size = new System.Drawing.Size(63, 21);
            this.lnk_setting.TabIndex = 10;
            this.lnk_setting.TabStop = true;
            this.lnk_setting.Text = "ตั้งค่าระบบ";
            this.lnk_setting.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_setting_LinkClicked);
            // 
            // btn_report
            // 
            this.btn_report.Image = global::BIG.Present.Properties.Resources.skill;
            this.btn_report.Location = new System.Drawing.Point(484, 487);
            this.btn_report.Name = "btn_report";
            this.btn_report.Size = new System.Drawing.Size(73, 68);
            this.btn_report.TabIndex = 11;
            this.btn_report.TabStop = false;
            // 
            // lnk_report
            // 
            this.lnk_report.AutoSize = true;
            this.lnk_report.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lnk_report.Location = new System.Drawing.Point(494, 558);
            this.lnk_report.Name = "lnk_report";
            this.lnk_report.Size = new System.Drawing.Size(48, 21);
            this.lnk_report.TabIndex = 12;
            this.lnk_report.TabStop = true;
            this.lnk_report.Text = "รายงาน";
            this.lnk_report.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // btn_search
            // 
            this.btn_search.Image = global::BIG.Present.Properties.Resources.search_;
            this.btn_search.Location = new System.Drawing.Point(221, 487);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(73, 68);
            this.btn_search.TabIndex = 13;
            this.btn_search.TabStop = false;
            // 
            // lnk_search
            // 
            this.lnk_search.AutoSize = true;
            this.lnk_search.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lnk_search.Location = new System.Drawing.Point(240, 558);
            this.lnk_search.Name = "lnk_search";
            this.lnk_search.Size = new System.Drawing.Size(39, 21);
            this.lnk_search.TabIndex = 15;
            this.lnk_search.TabStop = true;
            this.lnk_search.Text = "ค้นหา";
            // 
            // btn_secure
            // 
            this.btn_secure.Image = global::BIG.Present.Properties.Resources.lock_3;
            this.btn_secure.Location = new System.Drawing.Point(625, 114);
            this.btn_secure.Name = "btn_secure";
            this.btn_secure.Size = new System.Drawing.Size(75, 75);
            this.btn_secure.TabIndex = 16;
            this.btn_secure.TabStop = false;
            // 
            // btn_company
            // 
            this.btn_company.Image = global::BIG.Present.Properties.Resources.network;
            this.btn_company.Location = new System.Drawing.Point(228, 114);
            this.btn_company.Name = "btn_company";
            this.btn_company.Size = new System.Drawing.Size(75, 75);
            this.btn_company.TabIndex = 17;
            this.btn_company.TabStop = false;
            // 
            // lnk_company
            // 
            this.lnk_company.AutoSize = true;
            this.lnk_company.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lnk_company.Location = new System.Drawing.Point(233, 192);
            this.lnk_company.Name = "lnk_company";
            this.lnk_company.Size = new System.Drawing.Size(68, 21);
            this.lnk_company.TabIndex = 18;
            this.lnk_company.TabStop = true;
            this.lnk_company.Text = "ข้อมูลบริษัท";
            // 
            // lnk_secure
            // 
            this.lnk_secure.AutoSize = true;
            this.lnk_secure.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lnk_secure.Location = new System.Drawing.Point(626, 192);
            this.lnk_secure.Name = "lnk_secure";
            this.lnk_secure.Size = new System.Drawing.Size(80, 21);
            this.lnk_secure.TabIndex = 19;
            this.lnk_secure.TabStop = true;
            this.lnk_secure.Text = "ความปลอดภัย";
            // 
            // btn_close
            // 
            this.btn_close.Image = global::BIG.Present.Properties.Resources.exit1;
            this.btn_close.Location = new System.Drawing.Point(810, -3);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(30, 30);
            this.btn_close.TabIndex = 20;
            this.btn_close.TabStop = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_eval
            // 
            this.btn_eval.Image = global::BIG.Present.Properties.Resources.eval;
            this.btn_eval.Location = new System.Drawing.Point(430, 45);
            this.btn_eval.Name = "btn_eval";
            this.btn_eval.Size = new System.Drawing.Size(75, 75);
            this.btn_eval.TabIndex = 21;
            this.btn_eval.TabStop = false;
            // 
            // lnk_eval
            // 
            this.lnk_eval.AutoSize = true;
            this.lnk_eval.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lnk_eval.Location = new System.Drawing.Point(443, 123);
            this.lnk_eval.Name = "lnk_eval";
            this.lnk_eval.Size = new System.Drawing.Size(49, 21);
            this.lnk_eval.TabIndex = 22;
            this.lnk_eval.TabStop = true;
            this.lnk_eval.Text = "ประเมิน";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BIG.Present.Properties.Resources.Home1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
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
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lnk_eval);
            this.Controls.Add(this.btn_eval);
            this.Controls.Add(this.btn_close);
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
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btn_employee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_setting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_report)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_search)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_secure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_company)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_close)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_eval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
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
        private System.Windows.Forms.PictureBox pictureBox1;




    }
}