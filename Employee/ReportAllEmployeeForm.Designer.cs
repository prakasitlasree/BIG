namespace BIG.Present
{
    partial class ReportAllEmployeeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportAllEmployeeForm));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.employeeReportBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.AllEmployeeDS = new BIG.Present.AllEmployeeDS();
            this.ribbonPanel6 = new System.Windows.Forms.RibbonPanel();
            this.ribbonSearchbyPID = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel8 = new System.Windows.Forms.RibbonPanel();
            this.ribbonSearchbyName = new System.Windows.Forms.RibbonButton();
            this.ribbonTab5 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel7 = new System.Windows.Forms.RibbonPanel();
            this.ribbonAllReport = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel9 = new System.Windows.Forms.RibbonPanel();
            this.ribbon_Employee = new System.Windows.Forms.RibbonButton();
            this.ribbonTab6 = new System.Windows.Forms.RibbonTab();
            this.ribbonTab7 = new System.Windows.Forms.RibbonTab();
            this.ribbonSeparator4 = new System.Windows.Forms.RibbonSeparator();
            this.ribbonTab4 = new System.Windows.Forms.RibbonTab();
            this.ribbonTab1 = new System.Windows.Forms.RibbonTab();
            this.main = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.ribbonPanel4 = new System.Windows.Forms.RibbonPanel();
            this.rb_main = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel2 = new System.Windows.Forms.RibbonPanel();
            this.rb_home = new System.Windows.Forms.RibbonButton();
            this.rb_new = new System.Windows.Forms.RibbonButton();
            this.rb_load_pid = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel3 = new System.Windows.Forms.RibbonPanel();
            this.rb_save = new System.Windows.Forms.RibbonButton();
            this.rb_print = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel5 = new System.Windows.Forms.RibbonPanel();
            this.rb_logout = new System.Windows.Forms.RibbonButton();
            this.rb_exit = new System.Windows.Forms.RibbonButton();
            this.ribbonTab2 = new System.Windows.Forms.RibbonTab();
            this.ribbonTab3 = new System.Windows.Forms.RibbonTab();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.ribbonOrbMenuItem1 = new System.Windows.Forms.RibbonOrbMenuItem();
            this.ribbonSeparator1 = new System.Windows.Forms.RibbonSeparator();
            this.ribbonSeparator2 = new System.Windows.Forms.RibbonSeparator();
            this.ribbonSeparator3 = new System.Windows.Forms.RibbonSeparator();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lb_search1 = new System.Windows.Forms.Label();
            this.start_date = new System.Windows.Forms.DateTimePicker();
            this.Btn_Search = new System.Windows.Forms.Button();
            this.end_date = new System.Windows.Forms.DateTimePicker();
            this.lb_search2 = new System.Windows.Forms.Label();
            this.Btn_ShowAll = new System.Windows.Forms.Button();
            this.allEmployeeDSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.EmployeeReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.EmployeeReportTableAdapter = new BIG.Present.AllEmployeeDSTableAdapters.EmployeeReportTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.employeeReportBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AllEmployeeDS)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.allEmployeeDSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeReportBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // employeeReportBindingSource1
            // 
            this.employeeReportBindingSource1.DataMember = "EmployeeReport";
            this.employeeReportBindingSource1.DataSource = this.AllEmployeeDS;
            // 
            // AllEmployeeDS
            // 
            this.AllEmployeeDS.DataSetName = "AllEmployeeDS";
            this.AllEmployeeDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ribbonPanel6
            // 
            this.ribbonPanel6.Items.Add(this.ribbonSearchbyPID);
            this.ribbonPanel6.Text = "";
            // 
            // ribbonSearchbyPID
            // 
            this.ribbonSearchbyPID.Image = global::BIG.Present.Properties.Resources.Toolbox2;
            this.ribbonSearchbyPID.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonSearchbyPID.SmallImage")));
            this.ribbonSearchbyPID.Text = "ค้นหาบัตรประชาชน";
            this.ribbonSearchbyPID.Click += new System.EventHandler(this.ribbonSearchbyPID_Click);
            // 
            // ribbonPanel8
            // 
            this.ribbonPanel8.Items.Add(this.ribbonSearchbyName);
            this.ribbonPanel8.Text = "";
            // 
            // ribbonSearchbyName
            // 
            this.ribbonSearchbyName.Image = global::BIG.Present.Properties.Resources.People1;
            this.ribbonSearchbyName.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonSearchbyName.SmallImage")));
            this.ribbonSearchbyName.Text = "ค้นหาตามชื่อ-สกุล";
            this.ribbonSearchbyName.Click += new System.EventHandler(this.ribbonSearchbyName_Click);
            // 
            // ribbonTab5
            // 
            this.ribbonTab5.Panels.Add(this.ribbonPanel7);
            this.ribbonTab5.Panels.Add(this.ribbonPanel9);
            this.ribbonTab5.Text = "รายงาน";
            // 
            // ribbonPanel7
            // 
            this.ribbonPanel7.Items.Add(this.ribbonAllReport);
            this.ribbonPanel7.Text = "...";
            // 
            // ribbonAllReport
            // 
            this.ribbonAllReport.Image = global::BIG.Present.Properties.Resources.Stock_graph;
            this.ribbonAllReport.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonAllReport.SmallImage")));
            this.ribbonAllReport.Text = "รายชื่อพนักงานทั้งหมด";
            this.ribbonAllReport.Click += new System.EventHandler(this.ribbonAllReport_Click);
            // 
            // ribbonPanel9
            // 
            this.ribbonPanel9.Items.Add(this.ribbon_Employee);
            this.ribbonPanel9.Text = "";
            // 
            // ribbon_Employee
            // 
            this.ribbon_Employee.Image = global::BIG.Present.Properties.Resources.Boss;
            this.ribbon_Employee.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbon_Employee.SmallImage")));
            this.ribbon_Employee.Text = "รายงานประวัติบุคคล";
            this.ribbon_Employee.Click += new System.EventHandler(this.ribbon_personale_detail_Click);
            // 
            // ribbonTab6
            // 
            this.ribbonTab6.Text = "ข้อมูลบริษัท";
            // 
            // ribbonTab7
            // 
            this.ribbonTab7.Text = "";
            // 
            // ribbonTab4
            // 
            this.ribbonTab4.Text = "ข้อมูลโปรแกรม";
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Panels.Add(this.ribbonPanel6);
            this.ribbonTab1.Panels.Add(this.ribbonPanel8);
            this.ribbonTab1.Text = "ค้นหา";
            // 
            // main
            // 
            this.main.Panels.Add(this.ribbonPanel1);
            this.main.Panels.Add(this.ribbonPanel4);
            this.main.Text = "รายการหลัก";
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.Text = "main menu";
            // 
            // ribbonPanel4
            // 
            this.ribbonPanel4.Text = "ribbonPanel4";
            // 
            // rb_main
            // 
            this.rb_main.Panels.Add(this.ribbonPanel2);
            this.rb_main.Panels.Add(this.ribbonPanel3);
            this.rb_main.Panels.Add(this.ribbonPanel5);
            this.rb_main.Text = "รายการหลัก";
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.Items.Add(this.rb_home);
            this.ribbonPanel2.Items.Add(this.rb_new);
            this.ribbonPanel2.Items.Add(this.rb_load_pid);
            this.ribbonPanel2.Text = "";
            // 
            // rb_home
            // 
            this.rb_home.Image = global::BIG.Present.Properties.Resources.Home;
            this.rb_home.SmallImage = ((System.Drawing.Image)(resources.GetObject("rb_home.SmallImage")));
            this.rb_home.Text = "หน้าหลัก";
            this.rb_home.TextAlignment = System.Windows.Forms.RibbonItem.RibbonItemTextAlignment.Center;
            this.rb_home.Click += new System.EventHandler(this.rb_home_Click);
            // 
            // rb_new
            // 
            this.rb_new.Image = global::BIG.Present.Properties.Resources.User_group;
            this.rb_new.SmallImage = ((System.Drawing.Image)(resources.GetObject("rb_new.SmallImage")));
            this.rb_new.Text = "เพิ่มพนักงาน";
            this.rb_new.Click += new System.EventHandler(this.rb_new_Click);
            // 
            // rb_load_pid
            // 
            this.rb_load_pid.Enabled = false;
            this.rb_load_pid.Image = global::BIG.Present.Properties.Resources.Sync;
            this.rb_load_pid.SmallImage = ((System.Drawing.Image)(resources.GetObject("rb_load_pid.SmallImage")));
            this.rb_load_pid.Text = "โหลดบัตรประชาชน";
            // 
            // ribbonPanel3
            // 
            this.ribbonPanel3.Items.Add(this.rb_save);
            this.ribbonPanel3.Items.Add(this.rb_print);
            this.ribbonPanel3.Text = "";
            // 
            // rb_save
            // 
            this.rb_save.Enabled = false;
            this.rb_save.Image = global::BIG.Present.Properties.Resources.Save;
            this.rb_save.SmallImage = ((System.Drawing.Image)(resources.GetObject("rb_save.SmallImage")));
            this.rb_save.Text = "บันทึกข้อมูล";
            this.rb_save.TextAlignment = System.Windows.Forms.RibbonItem.RibbonItemTextAlignment.Center;
            // 
            // rb_print
            // 
            this.rb_print.Image = global::BIG.Present.Properties.Resources.Print;
            this.rb_print.SmallImage = ((System.Drawing.Image)(resources.GetObject("rb_print.SmallImage")));
            this.rb_print.Text = "พิมพ์รายงาน";
            this.rb_print.TextAlignment = System.Windows.Forms.RibbonItem.RibbonItemTextAlignment.Center;
            this.rb_print.Click += new System.EventHandler(this.rb_print_Click);
            // 
            // ribbonPanel5
            // 
            this.ribbonPanel5.Items.Add(this.rb_logout);
            this.ribbonPanel5.Items.Add(this.rb_exit);
            this.ribbonPanel5.Text = "";
            // 
            // rb_logout
            // 
            this.rb_logout.Image = global::BIG.Present.Properties.Resources.Unlock;
            this.rb_logout.SmallImage = ((System.Drawing.Image)(resources.GetObject("rb_logout.SmallImage")));
            this.rb_logout.Text = "ออกจากระบบ";
            this.rb_logout.TextAlignment = System.Windows.Forms.RibbonItem.RibbonItemTextAlignment.Center;
            this.rb_logout.Click += new System.EventHandler(this.rb_logout_Click);
            // 
            // rb_exit
            // 
            this.rb_exit.Image = global::BIG.Present.Properties.Resources.Turn_off;
            this.rb_exit.SmallImage = ((System.Drawing.Image)(resources.GetObject("rb_exit.SmallImage")));
            this.rb_exit.Text = "ปิดโปรแกรม";
            this.rb_exit.TextAlignment = System.Windows.Forms.RibbonItem.RibbonItemTextAlignment.Center;
            this.rb_exit.Click += new System.EventHandler(this.rb_exit_Click);
            // 
            // ribbonTab2
            // 
            this.ribbonTab2.Text = "ตั้งค่าระบบ";
            // 
            // ribbonTab3
            // 
            this.ribbonTab3.Text = "ribbonTab3";
            // 
            // ribbon1
            // 
            this.ribbon1.CaptionBarVisible = false;
            this.ribbon1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Margin = new System.Windows.Forms.Padding(4);
            this.ribbon1.Minimized = false;
            this.ribbon1.Name = "ribbon1";
            // 
            // 
            // 
            this.ribbon1.OrbDropDown.BorderRoundness = 8;
            this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.ribbonOrbMenuItem1);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.ribbonSeparator1);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.ribbonSeparator2);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.ribbonSeparator3);
            this.ribbon1.OrbDropDown.Name = "";
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 125);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.OrbImage = null;
            this.ribbon1.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2013;
            // 
            // 
            // 
            this.ribbon1.QuickAcessToolbar.Visible = false;
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("Viner Hand ITC", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribbon1.Size = new System.Drawing.Size(1344, 118);
            this.ribbon1.TabIndex = 3;
            this.ribbon1.Tabs.Add(this.rb_main);
            this.ribbon1.Tabs.Add(this.ribbonTab1);
            this.ribbon1.Tabs.Add(this.ribbonTab5);
            this.ribbon1.Tabs.Add(this.ribbonTab6);
            this.ribbon1.Tabs.Add(this.ribbonTab7);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 2, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // ribbonOrbMenuItem1
            // 
            this.ribbonOrbMenuItem1.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.ribbonOrbMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonOrbMenuItem1.Image")));
            this.ribbonOrbMenuItem1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonOrbMenuItem1.SmallImage")));
            this.ribbonOrbMenuItem1.Text = "ribbonOrbMenuItem1";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.employeeReportBindingSource1;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "BIG.Present.AllEmployeeReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 63);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1314, 536);
            this.reportViewer1.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.reportViewer1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 125);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1320, 602);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.Controls.Add(this.lb_search1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.start_date, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.Btn_Search, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.end_date, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.lb_search2, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.Btn_ShowAll, 5, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1314, 47);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // lb_search1
            // 
            this.lb_search1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lb_search1.AutoSize = true;
            this.lb_search1.Location = new System.Drawing.Point(43, 15);
            this.lb_search1.Name = "lb_search1";
            this.lb_search1.Size = new System.Drawing.Size(85, 17);
            this.lb_search1.TabIndex = 0;
            this.lb_search1.Text = "ค้นหาจากวันที่";
            // 
            // start_date
            // 
            this.start_date.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.start_date.Location = new System.Drawing.Point(134, 12);
            this.start_date.Name = "start_date";
            this.start_date.Size = new System.Drawing.Size(191, 22);
            this.start_date.TabIndex = 2;
            // 
            // Btn_Search
            // 
            this.Btn_Search.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Btn_Search.Location = new System.Drawing.Point(674, 8);
            this.Btn_Search.Name = "Btn_Search";
            this.Btn_Search.Size = new System.Drawing.Size(110, 30);
            this.Btn_Search.TabIndex = 1;
            this.Btn_Search.Text = "ค้นหา";
            this.Btn_Search.UseVisualStyleBackColor = true;
            this.Btn_Search.Click += new System.EventHandler(this.Btn_Search_Click);
            // 
            // end_date
            // 
            this.end_date.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.end_date.Location = new System.Drawing.Point(462, 12);
            this.end_date.Name = "end_date";
            this.end_date.Size = new System.Drawing.Size(191, 22);
            this.end_date.TabIndex = 3;
            // 
            // lb_search2
            // 
            this.lb_search2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lb_search2.AutoSize = true;
            this.lb_search2.Location = new System.Drawing.Point(410, 15);
            this.lb_search2.Name = "lb_search2";
            this.lb_search2.Size = new System.Drawing.Size(46, 17);
            this.lb_search2.TabIndex = 5;
            this.lb_search2.Text = "ถึงวันที่";
            // 
            // Btn_ShowAll
            // 
            this.Btn_ShowAll.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Btn_ShowAll.Location = new System.Drawing.Point(790, 8);
            this.Btn_ShowAll.Name = "Btn_ShowAll";
            this.Btn_ShowAll.Size = new System.Drawing.Size(110, 30);
            this.Btn_ShowAll.TabIndex = 4;
            this.Btn_ShowAll.Text = "แสดงทั้งหมด";
            this.Btn_ShowAll.UseVisualStyleBackColor = true;
            this.Btn_ShowAll.Click += new System.EventHandler(this.Btn_ShowAll_Click);
            // 
            // allEmployeeDSBindingSource
            // 
            this.allEmployeeDSBindingSource.DataSource = this.AllEmployeeDS;
            this.allEmployeeDSBindingSource.Position = 0;
            // 
            // EmployeeReportBindingSource
            // 
            this.EmployeeReportBindingSource.DataMember = "EmployeeReport";
            this.EmployeeReportBindingSource.DataSource = this.AllEmployeeDS;
            // 
            // EmployeeReportTableAdapter
            // 
            this.EmployeeReportTableAdapter.ClearBeforeFill = true;
            // 
            // ReportAllEmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 739);
            this.Controls.Add(this.ribbon1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ReportAllEmployeeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportAllEmployeeForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ReportAllEmployeeForm_FormClosed);
            this.Load += new System.EventHandler(this.ReportAllEmployeeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.employeeReportBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AllEmployeeDS)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.allEmployeeDSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeReportBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RibbonPanel ribbonPanel6;
        private System.Windows.Forms.RibbonButton ribbonSearchbyPID;
        private System.Windows.Forms.RibbonPanel ribbonPanel8;
        private System.Windows.Forms.RibbonButton ribbonSearchbyName;
        private System.Windows.Forms.RibbonTab ribbonTab5;
        private System.Windows.Forms.RibbonPanel ribbonPanel7;
        private System.Windows.Forms.RibbonButton ribbonAllReport;
        private System.Windows.Forms.RibbonPanel ribbonPanel9;
        private System.Windows.Forms.RibbonButton ribbon_Employee;
        private System.Windows.Forms.RibbonTab ribbonTab6;
        private System.Windows.Forms.RibbonTab ribbonTab7;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator4;
        private System.Windows.Forms.RibbonTab ribbonTab4;
        private System.Windows.Forms.RibbonTab ribbonTab1;
        private System.Windows.Forms.RibbonTab main;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonPanel ribbonPanel4;
        private System.Windows.Forms.RibbonTab rb_main;
        private System.Windows.Forms.RibbonPanel ribbonPanel2;
        private System.Windows.Forms.RibbonButton rb_home;
        private System.Windows.Forms.RibbonButton rb_new;
        private System.Windows.Forms.RibbonButton rb_load_pid;
        private System.Windows.Forms.RibbonPanel ribbonPanel3;
        private System.Windows.Forms.RibbonButton rb_save;
        private System.Windows.Forms.RibbonButton rb_print;
        private System.Windows.Forms.RibbonPanel ribbonPanel5;
        private System.Windows.Forms.RibbonButton rb_logout;
        private System.Windows.Forms.RibbonButton rb_exit;
        private System.Windows.Forms.RibbonTab ribbonTab2;
        private System.Windows.Forms.RibbonTab ribbonTab3;
        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonOrbMenuItem ribbonOrbMenuItem1;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator1;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator2;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator3;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource EmployeeReportBindingSource;
        private AllEmployeeDS AllEmployeeDS;
        private AllEmployeeDSTableAdapters.EmployeeReportTableAdapter EmployeeReportTableAdapter;
        private System.Windows.Forms.BindingSource allEmployeeDSBindingSource;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lb_search1;
        private System.Windows.Forms.Button Btn_Search;
        private System.Windows.Forms.DateTimePicker start_date;
        private System.Windows.Forms.DateTimePicker end_date;
        private System.Windows.Forms.BindingSource employeeReportBindingSource1;
        private System.Windows.Forms.Button Btn_ShowAll;
        private System.Windows.Forms.Label lb_search2;
    }
}