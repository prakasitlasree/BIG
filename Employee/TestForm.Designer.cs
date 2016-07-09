namespace BIG.Present
{
    partial class TestForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestForm));
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
            this.ribbonTab3 = new System.Windows.Forms.RibbonTab();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.ribbonOrbMenuItem1 = new System.Windows.Forms.RibbonOrbMenuItem();
            this.ribbonSeparator1 = new System.Windows.Forms.RibbonSeparator();
            this.ribbonSeparator2 = new System.Windows.Forms.RibbonSeparator();
            this.ribbonSeparator3 = new System.Windows.Forms.RibbonSeparator();
            this.ribbonTab1 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel6 = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton12 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton13 = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel8 = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton14 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton15 = new System.Windows.Forms.RibbonButton();
            this.ribbonTab5 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel7 = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton9 = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel9 = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton10 = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel10 = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton11 = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel11 = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton16 = new System.Windows.Forms.RibbonButton();
            this.ribbonTab6 = new System.Windows.Forms.RibbonTab();
            this.ribbonTab7 = new System.Windows.Forms.RibbonTab();
            this.ribbonTab8 = new System.Windows.Forms.RibbonTab();
            this.ribbonSeparator4 = new System.Windows.Forms.RibbonSeparator();
            this.ribbonTab2 = new System.Windows.Forms.RibbonTab();
            this.ribbonTab4 = new System.Windows.Forms.RibbonTab();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
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
            // 
            // rb_new
            // 
            this.rb_new.Image = global::BIG.Present.Properties.Resources.User_group;
            this.rb_new.SmallImage = ((System.Drawing.Image)(resources.GetObject("rb_new.SmallImage")));
            this.rb_new.Text = "เพิ่มพนักงาน";
            // 
            // rb_load_pid
            // 
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
            // 
            // rb_exit
            // 
            this.rb_exit.Image = global::BIG.Present.Properties.Resources.Turn_off;
            this.rb_exit.SmallImage = ((System.Drawing.Image)(resources.GetObject("rb_exit.SmallImage")));
            this.rb_exit.Text = "ปิดโปรแกรม";
            this.rb_exit.TextAlignment = System.Windows.Forms.RibbonItem.RibbonItemTextAlignment.Center;
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
            this.ribbon1.Size = new System.Drawing.Size(818, 96);
            this.ribbon1.TabIndex = 2;
            this.ribbon1.Tabs.Add(this.rb_main);
            this.ribbon1.Tabs.Add(this.ribbonTab1);
            this.ribbon1.Tabs.Add(this.ribbonTab5);
            this.ribbon1.Tabs.Add(this.ribbonTab6);
            this.ribbon1.Tabs.Add(this.ribbonTab7);
            this.ribbon1.Tabs.Add(this.ribbonTab8);
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
            // ribbonTab1
            // 
            this.ribbonTab1.Panels.Add(this.ribbonPanel6);
            this.ribbonTab1.Panels.Add(this.ribbonPanel8);
            this.ribbonTab1.Text = "ค้นหา";
            // 
            // ribbonPanel6
            // 
            this.ribbonPanel6.Items.Add(this.ribbonButton12);
            this.ribbonPanel6.Items.Add(this.ribbonButton13);
            this.ribbonPanel6.Text = "";
            // 
            // ribbonButton12
            // 
            this.ribbonButton12.Image = global::BIG.Present.Properties.Resources.Toolbox2;
            this.ribbonButton12.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton12.SmallImage")));
            this.ribbonButton12.Text = "ค้นหาตามไซต์งาน";
            // 
            // ribbonButton13
            // 
            this.ribbonButton13.Image = global::BIG.Present.Properties.Resources.Blue_pin;
            this.ribbonButton13.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton13.SmallImage")));
            this.ribbonButton13.Text = "ค้นหาตามเขต";
            // 
            // ribbonPanel8
            // 
            this.ribbonPanel8.Items.Add(this.ribbonButton14);
            this.ribbonPanel8.Items.Add(this.ribbonButton15);
            this.ribbonPanel8.Text = "";
            // 
            // ribbonButton14
            // 
            this.ribbonButton14.Image = global::BIG.Present.Properties.Resources.People1;
            this.ribbonButton14.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton14.SmallImage")));
            this.ribbonButton14.Text = "ค้นหาตามชื่อ-สกุล";
            // 
            // ribbonButton15
            // 
            this.ribbonButton15.Image = global::BIG.Present.Properties.Resources.Calendar;
            this.ribbonButton15.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton15.SmallImage")));
            this.ribbonButton15.Text = "ค้นหาตามวันเริ่มงาน";
            // 
            // ribbonTab5
            // 
            this.ribbonTab5.Panels.Add(this.ribbonPanel7);
            this.ribbonTab5.Panels.Add(this.ribbonPanel9);
            this.ribbonTab5.Panels.Add(this.ribbonPanel10);
            this.ribbonTab5.Panels.Add(this.ribbonPanel11);
            this.ribbonTab5.Text = "รายงาน";
            // 
            // ribbonPanel7
            // 
            this.ribbonPanel7.Items.Add(this.ribbonButton9);
            this.ribbonPanel7.Text = "...";
            // 
            // ribbonButton9
            // 
            this.ribbonButton9.Image = global::BIG.Present.Properties.Resources.Stock_graph;
            this.ribbonButton9.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton9.SmallImage")));
            this.ribbonButton9.Text = "รายงานทั้งหมด";
            // 
            // ribbonPanel9
            // 
            this.ribbonPanel9.Items.Add(this.ribbonButton10);
            this.ribbonPanel9.Text = "";
            // 
            // ribbonButton10
            // 
            this.ribbonButton10.Image = global::BIG.Present.Properties.Resources.Boss;
            this.ribbonButton10.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton10.SmallImage")));
            this.ribbonButton10.Text = "ตามชื่อพนักงาน";
            // 
            // ribbonPanel10
            // 
            this.ribbonPanel10.Items.Add(this.ribbonButton11);
            this.ribbonPanel10.Text = "";
            // 
            // ribbonButton11
            // 
            this.ribbonButton11.Image = global::BIG.Present.Properties.Resources.Find;
            this.ribbonButton11.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton11.SmallImage")));
            this.ribbonButton11.Text = "ตามรหัสพนักงาน";
            // 
            // ribbonPanel11
            // 
            this.ribbonPanel11.Items.Add(this.ribbonButton16);
            this.ribbonPanel11.Text = "";
            // 
            // ribbonButton16
            // 
            this.ribbonButton16.Image = global::BIG.Present.Properties.Resources.Upload;
            this.ribbonButton16.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton16.SmallImage")));
            this.ribbonButton16.Text = "ตามบัตรประชาชน";
            // 
            // ribbonTab6
            // 
            this.ribbonTab6.Text = "ข้อมูลบริษัท";
            // 
            // ribbonTab7
            // 
            this.ribbonTab7.Text = "";
            // 
            // ribbonTab8
            // 
            this.ribbonTab8.Text = "ตั้งค่าโปรแกรม";
            // 
            // ribbonTab2
            // 
            this.ribbonTab2.Text = "ตั้งค่าระบบ";
            // 
            // ribbonTab4
            // 
            this.ribbonTab4.Text = "ข้อมูลโปรแกรม";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(109, 175);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "ทดสอบ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(87, 219);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(130, 152);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 583);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ribbon1);
            this.Name = "TestForm";
            this.Text = "TestForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RibbonTab main;
        private System.Windows.Forms.RibbonTab rb_main;
        private System.Windows.Forms.RibbonTab ribbonTab3;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonPanel ribbonPanel2;
        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonButton rb_home;
        private System.Windows.Forms.RibbonButton rb_new;
        private System.Windows.Forms.RibbonButton rb_load_pid;
        private System.Windows.Forms.RibbonPanel ribbonPanel3;
        private System.Windows.Forms.RibbonButton rb_save;
        private System.Windows.Forms.RibbonButton rb_print;
        private System.Windows.Forms.RibbonPanel ribbonPanel4;
        private System.Windows.Forms.RibbonTab ribbonTab1;
        private System.Windows.Forms.RibbonPanel ribbonPanel5;
        private System.Windows.Forms.RibbonButton rb_logout;
        private System.Windows.Forms.RibbonButton rb_exit;
        private System.Windows.Forms.RibbonPanel ribbonPanel6;
        private System.Windows.Forms.RibbonOrbMenuItem ribbonOrbMenuItem1;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator1;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator2;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator3;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator4;
        private System.Windows.Forms.RibbonTab ribbonTab2;
        private System.Windows.Forms.RibbonTab ribbonTab4;
        private System.Windows.Forms.RibbonTab ribbonTab5;
        private System.Windows.Forms.RibbonTab ribbonTab6;
        private System.Windows.Forms.RibbonTab ribbonTab7;
        private System.Windows.Forms.RibbonTab ribbonTab8;
        private System.Windows.Forms.RibbonPanel ribbonPanel7;
        private System.Windows.Forms.RibbonButton ribbonButton9;
        private System.Windows.Forms.RibbonButton ribbonButton12;
        private System.Windows.Forms.RibbonButton ribbonButton13;
        private System.Windows.Forms.RibbonPanel ribbonPanel8;
        private System.Windows.Forms.RibbonButton ribbonButton14;
        private System.Windows.Forms.RibbonButton ribbonButton15;
        private System.Windows.Forms.RibbonPanel ribbonPanel9;
        private System.Windows.Forms.RibbonButton ribbonButton10;
        private System.Windows.Forms.RibbonPanel ribbonPanel10;
        private System.Windows.Forms.RibbonButton ribbonButton11;
        private System.Windows.Forms.RibbonPanel ribbonPanel11;
        private System.Windows.Forms.RibbonButton ribbonButton16;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;




    }
}