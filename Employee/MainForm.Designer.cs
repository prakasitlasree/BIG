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
            this.detail = new MakarovDev.ExpandCollapsePanel.ExpandCollapsePanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.expandCollapsePanel1 = new MakarovDev.ExpandCollapsePanel.ExpandCollapsePanel();
            this.advancedFlowLayoutPanel1 = new MakarovDev.ExpandCollapsePanel.AdvancedFlowLayoutPanel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // detail
            // 
            this.detail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.detail.ButtonSize = MakarovDev.ExpandCollapsePanel.ExpandCollapseButton.ExpandButtonSize.Normal;
            this.detail.ButtonStyle = MakarovDev.ExpandCollapsePanel.ExpandCollapseButton.ExpandButtonStyle.Circle;
            this.detail.ExpandedHeight = 0;
            this.detail.IsExpanded = true;
            this.detail.Location = new System.Drawing.Point(17, 19);
            this.detail.Name = "detail";
            this.detail.Size = new System.Drawing.Size(219, 319);
            this.detail.TabIndex = 1;
            this.detail.Text = "ข้อมูลทั่วไป";
            this.detail.UseAnimation = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.expandCollapsePanel1);
            this.groupBox1.Controls.Add(this.detail);
            this.groupBox1.Controls.Add(this.advancedFlowLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(11, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(256, 557);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Menu";
            // 
            // expandCollapsePanel1
            // 
            this.expandCollapsePanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.expandCollapsePanel1.ButtonSize = MakarovDev.ExpandCollapsePanel.ExpandCollapseButton.ExpandButtonSize.Normal;
            this.expandCollapsePanel1.ButtonStyle = MakarovDev.ExpandCollapsePanel.ExpandCollapseButton.ExpandButtonStyle.Circle;
            this.expandCollapsePanel1.ExpandedHeight = 0;
            this.expandCollapsePanel1.IsExpanded = true;
            this.expandCollapsePanel1.Location = new System.Drawing.Point(17, 344);
            this.expandCollapsePanel1.Name = "expandCollapsePanel1";
            this.expandCollapsePanel1.Size = new System.Drawing.Size(219, 195);
            this.expandCollapsePanel1.TabIndex = 3;
            this.expandCollapsePanel1.Text = "ข้อมูลการจ้างงาน";
            this.expandCollapsePanel1.UseAnimation = true;
            // 
            // advancedFlowLayoutPanel1
            // 
            this.advancedFlowLayoutPanel1.Location = new System.Drawing.Point(7, 9);
            this.advancedFlowLayoutPanel1.Name = "advancedFlowLayoutPanel1";
            this.advancedFlowLayoutPanel1.Size = new System.Drawing.Size(243, 542);
            this.advancedFlowLayoutPanel1.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 603);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MakarovDev.ExpandCollapsePanel.ExpandCollapsePanel detail;
        private System.Windows.Forms.GroupBox groupBox1;
        private MakarovDev.ExpandCollapsePanel.ExpandCollapsePanel expandCollapsePanel1;
        private MakarovDev.ExpandCollapsePanel.AdvancedFlowLayoutPanel advancedFlowLayoutPanel1;

    }
}