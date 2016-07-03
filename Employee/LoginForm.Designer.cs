namespace BIG.Present
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.gb_logon = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblpassword = new System.Windows.Forms.Label();
            this.lblusername = new System.Windows.Forms.Label();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.txtusername = new System.Windows.Forms.TextBox();
            this.bt_logon = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_home = new System.Windows.Forms.PictureBox();
            this.btn_close = new System.Windows.Forms.PictureBox();
            this.gb_logon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_home)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_close)).BeginInit();
            this.SuspendLayout();
            // 
            // gb_logon
            // 
            this.gb_logon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_logon.Controls.Add(this.pictureBox2);
            this.gb_logon.Controls.Add(this.lblpassword);
            this.gb_logon.Controls.Add(this.lblusername);
            this.gb_logon.Controls.Add(this.txtpassword);
            this.gb_logon.Controls.Add(this.txtusername);
            this.gb_logon.Controls.Add(this.bt_logon);
            this.gb_logon.Location = new System.Drawing.Point(4, 26);
            this.gb_logon.Name = "gb_logon";
            this.gb_logon.Padding = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.gb_logon.Size = new System.Drawing.Size(463, 240);
            this.gb_logon.TabIndex = 0;
            this.gb_logon.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::BIG.Present.Properties.Resources.login_icon_png;
            this.pictureBox2.Location = new System.Drawing.Point(58, 53);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(105, 133);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // lblpassword
            // 
            this.lblpassword.AutoSize = true;
            this.lblpassword.Location = new System.Drawing.Point(172, 109);
            this.lblpassword.Name = "lblpassword";
            this.lblpassword.Size = new System.Drawing.Size(46, 13);
            this.lblpassword.TabIndex = 4;
            this.lblpassword.Text = "รหัสผ่าน";
            // 
            // lblusername
            // 
            this.lblusername.AutoSize = true;
            this.lblusername.Location = new System.Drawing.Point(171, 70);
            this.lblusername.Name = "lblusername";
            this.lblusername.Size = new System.Drawing.Size(58, 13);
            this.lblusername.TabIndex = 3;
            this.lblusername.Text = "ชื่อผู้ใช้งาน";
            // 
            // txtpassword
            // 
            this.txtpassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtpassword.Location = new System.Drawing.Point(235, 108);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.Size = new System.Drawing.Size(140, 20);
            this.txtpassword.TabIndex = 2;
            this.txtpassword.Text = "1234";
            this.txtpassword.UseSystemPasswordChar = true;
            // 
            // txtusername
            // 
            this.txtusername.Location = new System.Drawing.Point(235, 69);
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(140, 20);
            this.txtusername.TabIndex = 1;
            this.txtusername.Text = "admin";
            // 
            // bt_logon
            // 
            this.bt_logon.Location = new System.Drawing.Point(235, 150);
            this.bt_logon.Name = "bt_logon";
            this.bt_logon.Size = new System.Drawing.Size(83, 36);
            this.bt_logon.TabIndex = 0;
            this.bt_logon.Text = "เข้าสู่ระบบ";
            this.bt_logon.UseVisualStyleBackColor = true;
            this.bt_logon.Click += new System.EventHandler(this.bt_logon_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Menu;
            this.panel1.Controls.Add(this.btn_home);
            this.panel1.Controls.Add(this.btn_close);
            this.panel1.Location = new System.Drawing.Point(-3, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(479, 28);
            this.panel1.TabIndex = 23;
            // 
            // btn_home
            // 
            this.btn_home.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_home.Image = global::BIG.Present.Properties.Resources.Lock;
            this.btn_home.Location = new System.Drawing.Point(3, 0);
            this.btn_home.Name = "btn_home";
            this.btn_home.Size = new System.Drawing.Size(25, 25);
            this.btn_home.TabIndex = 22;
            this.btn_home.TabStop = false;
            // 
            // btn_close
            // 
            this.btn_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_close.Image = global::BIG.Present.Properties.Resources.Close1;
            this.btn_close.Location = new System.Drawing.Point(451, 1);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(25, 25);
            this.btn_close.TabIndex = 21;
            this.btn_close.TabStop = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(472, 270);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gb_logon);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.gb_logon.ResumeLayout(false);
            this.gb_logon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btn_home)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_close)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_logon;
        private System.Windows.Forms.Button bt_logon;
        private System.Windows.Forms.TextBox txtusername;
        private System.Windows.Forms.Label lblpassword;
        private System.Windows.Forms.Label lblusername;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.PictureBox btn_close;
        private System.Windows.Forms.PictureBox btn_home;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel1;

    }
}