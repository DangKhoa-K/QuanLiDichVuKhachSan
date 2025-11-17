namespace QuanLiDichVuKhachSan
{
    partial class frmMain
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuCatalog = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrice = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUsage = new System.Windows.Forms.ToolStripMenuItem();

            this.scMain = new System.Windows.Forms.SplitContainer();

            // Sidebar
            this.panelNav = new System.Windows.Forms.FlowLayoutPanel();
            this.btnNavRooms = new System.Windows.Forms.Button();
            this.btnNavCatalog = new System.Windows.Forms.Button();
            this.btnNavPrice = new System.Windows.Forms.Button();
            this.btnNavUsage = new System.Windows.Forms.Button();

            // Toolbar + Room board + Legend
            this.rbToolbar = new System.Windows.Forms.Panel();
            this.rbLblStatus = new System.Windows.Forms.Label();
            this.rbCboStatus = new System.Windows.Forms.ComboBox();
            this.rbLblSearch = new System.Windows.Forms.Label();
            this.rbTxtSearch = new System.Windows.Forms.TextBox();
            this.rbBtnReload = new System.Windows.Forms.Button();

            this.rbFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.rbLegend = new System.Windows.Forms.Panel();
            this.rbLgVacant = new System.Windows.Forms.Label();
            this.rbLgOcc = new System.Windows.Forms.Label();
            this.rbLgDirty = new System.Windows.Forms.Label();
            this.rbLgRepair = new System.Windows.Forms.Label();

            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.rbLegend.SuspendLayout();

            // ===== MENU =====
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.mnuCatalog, this.mnuPrice, this.mnuUsage
            });
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1200, 28);
            this.menuStrip1.TabIndex = 0;

            this.mnuCatalog.Name = "mnuCatalog";
            this.mnuCatalog.Size = new System.Drawing.Size(85, 24);
            this.mnuCatalog.Text = "Danh mục";

            this.mnuPrice.Name = "mnuPrice";
            this.mnuPrice.Size = new System.Drawing.Size(78, 24);
            this.mnuPrice.Text = "Bảng giá";

            this.mnuUsage.Name = "mnuUsage";
            this.mnuUsage.Size = new System.Drawing.Size(120, 24);
            this.mnuUsage.Text = "Sử dụng dịch vụ";

            // ===== SPLIT =====
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.Location = new System.Drawing.Point(0, 28);
            this.scMain.Name = "scMain";
            this.scMain.Orientation = System.Windows.Forms.Orientation.Vertical;

            // Đừng set SplitterDistance ở Designer để tránh lỗi
            this.scMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scMain.Panel1MinSize = 0;
            this.scMain.Panel2MinSize = 0;
            this.scMain.SplitterWidth = 6;

            // ===== SIDEBAR (Panel1) =====
            this.scMain.Panel1.Controls.Add(this.panelNav);
            this.panelNav.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelNav.Padding = new System.Windows.Forms.Padding(12);
            this.panelNav.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panelNav.WrapContents = false;
            this.panelNav.AutoScroll = true;

            this.btnNavRooms.Text = "Sơ đồ phòng";
            this.btnNavRooms.Height = 36;
            this.btnNavRooms.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.panelNav.Controls.Add(this.btnNavRooms);

            this.btnNavCatalog.Text = "Danh mục";
            this.btnNavCatalog.Height = 36;
            this.btnNavCatalog.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.panelNav.Controls.Add(this.btnNavCatalog);

            this.btnNavPrice.Text = "Bảng giá";
            this.btnNavPrice.Height = 36;
            this.btnNavPrice.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.panelNav.Controls.Add(this.btnNavPrice);

            this.btnNavUsage.Text = "Sử dụng dịch vụ";
            this.btnNavUsage.Height = 36;
            this.btnNavUsage.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.panelNav.Controls.Add(this.btnNavUsage);

            // ===== PANEL2 (Content) =====
            this.scMain.Panel2.Controls.Add(this.rbFlow);
            this.scMain.Panel2.Controls.Add(this.rbLegend);
            this.scMain.Panel2.Controls.Add(this.rbToolbar);

            // Toolbar
            this.rbToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbToolbar.Height = 50;
            this.rbToolbar.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);

            this.rbLblStatus.AutoSize = true;
            this.rbLblStatus.Location = new System.Drawing.Point(18, 15);
            this.rbLblStatus.Text = "Trạng thái:";

            this.rbCboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rbCboStatus.Location = new System.Drawing.Point(88, 11);
            this.rbCboStatus.Size = new System.Drawing.Size(170, 23);

            this.rbLblSearch.AutoSize = true;
            this.rbLblSearch.Location = new System.Drawing.Point(274, 15);
            this.rbLblSearch.Text = "Tìm số phòng:";

            this.rbTxtSearch.Location = new System.Drawing.Point(358, 11);
            this.rbTxtSearch.Size = new System.Drawing.Size(160, 23);

            this.rbBtnReload.Location = new System.Drawing.Point(528, 9);
            this.rbBtnReload.Size = new System.Drawing.Size(90, 26);
            this.rbBtnReload.Text = "Làm mới";

            this.rbToolbar.Controls.Add(this.rbBtnReload);
            this.rbToolbar.Controls.Add(this.rbTxtSearch);
            this.rbToolbar.Controls.Add(this.rbLblSearch);
            this.rbToolbar.Controls.Add(this.rbCboStatus);
            this.rbToolbar.Controls.Add(this.rbLblStatus);

            // Board
            this.rbFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbFlow.AutoScroll = true;
            this.rbFlow.WrapContents = true;
            this.rbFlow.Padding = new System.Windows.Forms.Padding(10);

            // Legend
            this.rbLegend.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rbLegend.Height = 36;
            this.rbLegend.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);

            this.rbLgVacant.Text = "Trống";
            this.rbLgVacant.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbLgVacant.AutoSize = false; this.rbLgVacant.Width = 110; this.rbLgVacant.Height = 20;
            this.rbLgVacant.BackColor = System.Drawing.Color.FromArgb(232, 245, 233);
            this.rbLgVacant.Location = new System.Drawing.Point(12, 8);

            this.rbLgOcc.Text = "Đang ở";
            this.rbLgOcc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbLgOcc.AutoSize = false; this.rbLgOcc.Width = 110; this.rbLgOcc.Height = 20;
            this.rbLgOcc.BackColor = System.Drawing.Color.FromArgb(187, 222, 251);
            this.rbLgOcc.Location = new System.Drawing.Point(132, 8);

            this.rbLgDirty.Text = "Phòng bẩn";
            this.rbLgDirty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbLgDirty.AutoSize = false; this.rbLgDirty.Width = 110; this.rbLgDirty.Height = 20;
            this.rbLgDirty.BackColor = System.Drawing.Color.FromArgb(243, 229, 245);
            this.rbLgDirty.Location = new System.Drawing.Point(252, 8);

            this.rbLgRepair.Text = "Đang sửa";
            this.rbLgRepair.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbLgRepair.AutoSize = false; this.rbLgRepair.Width = 110; this.rbLgRepair.Height = 20;
            this.rbLgRepair.BackColor = System.Drawing.Color.FromArgb(239, 235, 233);
            this.rbLgRepair.Location = new System.Drawing.Point(372, 8);

            this.rbLegend.Controls.Add(this.rbLgVacant);
            this.rbLegend.Controls.Add(this.rbLgOcc);
            this.rbLegend.Controls.Add(this.rbLgDirty);
            this.rbLegend.Controls.Add(this.rbLgRepair);

            // FORM
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.scMain);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đề tài 5 – Quản lý dịch vụ khách sạn";
            this.Load += new System.EventHandler(this.frmMain_Load);

            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.rbLegend.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuCatalog;
        private System.Windows.Forms.ToolStripMenuItem mnuPrice;
        private System.Windows.Forms.ToolStripMenuItem mnuUsage;

        private System.Windows.Forms.SplitContainer scMain;

        private System.Windows.Forms.FlowLayoutPanel panelNav;
        private System.Windows.Forms.Button btnNavRooms;
        private System.Windows.Forms.Button btnNavCatalog;
        private System.Windows.Forms.Button btnNavPrice;
        private System.Windows.Forms.Button btnNavUsage;

        private System.Windows.Forms.Panel rbToolbar;
        private System.Windows.Forms.Label rbLblStatus;
        private System.Windows.Forms.ComboBox rbCboStatus;
        private System.Windows.Forms.Label rbLblSearch;
        private System.Windows.Forms.TextBox rbTxtSearch;
        private System.Windows.Forms.Button rbBtnReload;

        private System.Windows.Forms.FlowLayoutPanel rbFlow;
        private System.Windows.Forms.Panel rbLegend;
        private System.Windows.Forms.Label rbLgVacant;
        private System.Windows.Forms.Label rbLgOcc;
        private System.Windows.Forms.Label rbLgDirty;
        private System.Windows.Forms.Label rbLgRepair;
    }
}
