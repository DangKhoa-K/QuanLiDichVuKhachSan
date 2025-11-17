namespace QuanLiDichVuKhachSan
{
    partial class frmUsage
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblRoom = new System.Windows.Forms.Label();
            this.cboRoom = new System.Windows.Forms.ComboBox();
            this.lblService = new System.Windows.Forms.Label();
            this.cboService = new System.Windows.Forms.ComboBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            this.lblQty = new System.Windows.Forms.Label();
            this.nudQty = new System.Windows.Forms.NumericUpDown();
            this.lblAt = new System.Windows.Forms.Label();
            this.dtpUsedAt = new System.Windows.Forms.DateTimePicker();
            this.lblNote = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panelFilter = new System.Windows.Forms.Panel();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtpFromF = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpToF = new System.Windows.Forms.DateTimePicker();
            this.btnFilter = new System.Windows.Forms.Button();
            this.dgvUsage = new System.Windows.Forms.DataGridView();
            this.statusPanel = new System.Windows.Forms.Panel();
            this.lblSum = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQty)).BeginInit();
            this.panelFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsage)).BeginInit();
            this.statusPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.btnAdd);
            this.panelTop.Controls.Add(this.txtNote);
            this.panelTop.Controls.Add(this.lblNote);
            this.panelTop.Controls.Add(this.dtpUsedAt);
            this.panelTop.Controls.Add(this.lblAt);
            this.panelTop.Controls.Add(this.nudQty);
            this.panelTop.Controls.Add(this.lblQty);
            this.panelTop.Controls.Add(this.cboCustomer);
            this.panelTop.Controls.Add(this.lblCustomer);
            this.panelTop.Controls.Add(this.cboService);
            this.panelTop.Controls.Add(this.lblService);
            this.panelTop.Controls.Add(this.cboRoom);
            this.panelTop.Controls.Add(this.lblRoom);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Padding = new System.Windows.Forms.Padding(10);
            this.panelTop.Size = new System.Drawing.Size(1000, 90);
            this.panelTop.TabIndex = 0;
            // 
            // lblRoom
            // 
            this.lblRoom.AutoSize = true;
            this.lblRoom.Location = new System.Drawing.Point(13, 16);
            this.lblRoom.Name = "lblRoom";
            this.lblRoom.Size = new System.Drawing.Size(57, 20);
            this.lblRoom.TabIndex = 0;
            this.lblRoom.Text = "Phòng:";
            // 
            // cboRoom
            // 
            this.cboRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRoom.FormattingEnabled = true;
            this.cboRoom.Location = new System.Drawing.Point(72, 12);
            this.cboRoom.Name = "cboRoom";
            this.cboRoom.Size = new System.Drawing.Size(100, 28);
            this.cboRoom.TabIndex = 1;
            // 
            // lblService
            // 
            this.lblService.AutoSize = true;
            this.lblService.Location = new System.Drawing.Point(182, 16);
            this.lblService.Name = "lblService";
            this.lblService.Size = new System.Drawing.Size(65, 20);
            this.lblService.TabIndex = 2;
            this.lblService.Text = "Dịch vụ:";
            // 
            // cboService
            // 
            this.cboService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboService.FormattingEnabled = true;
            this.cboService.Location = new System.Drawing.Point(247, 12);
            this.cboService.Name = "cboService";
            this.cboService.Size = new System.Drawing.Size(160, 28);
            this.cboService.TabIndex = 3;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(417, 16);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(87, 20);
            this.lblCustomer.TabIndex = 4;
            this.lblCustomer.Text = "Khách hàng:";
            // 
            // cboCustomer
            // 
            this.cboCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCustomer.FormattingEnabled = true;
            this.cboCustomer.Location = new System.Drawing.Point(506, 12);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(170, 28);
            this.cboCustomer.TabIndex = 5;
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Location = new System.Drawing.Point(686, 16);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(71, 20);
            this.lblQty.TabIndex = 6;
            this.lblQty.Text = "Số lượng:";
            // 
            // nudQty
            // 
            this.nudQty.Location = new System.Drawing.Point(758, 12);
            this.nudQty.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudQty.Name = "nudQty";
            this.nudQty.Size = new System.Drawing.Size(80, 27);
            this.nudQty.TabIndex = 7;
            this.nudQty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblAt
            // 
            this.lblAt.AutoSize = true;
            this.lblAt.Location = new System.Drawing.Point(13, 54);
            this.lblAt.Name = "lblAt";
            this.lblAt.Size = new System.Drawing.Size(70, 20);
            this.lblAt.TabIndex = 8;
            this.lblAt.Text = "Thời điểm:";
            // 
            // dtpUsedAt
            // 
            this.dtpUsedAt.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpUsedAt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpUsedAt.Location = new System.Drawing.Point(89, 50);
            this.dtpUsedAt.Name = "dtpUsedAt";
            this.dtpUsedAt.ShowUpDown = true;
            this.dtpUsedAt.Size = new System.Drawing.Size(160, 27);
            this.dtpUsedAt.TabIndex = 9;
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Location = new System.Drawing.Point(260, 54);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(58, 20);
            this.lblNote.TabIndex = 10;
            this.lblNote.Text = "Ghi chú:";
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(324, 50);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(356, 27);
            this.txtNote.TabIndex = 11;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(694, 48);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(144, 30);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "Thêm phát sinh";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panelFilter
            // 
            this.panelFilter.Controls.Add(this.btnFilter);
            this.panelFilter.Controls.Add(this.dtpToF);
            this.panelFilter.Controls.Add(this.lblTo);
            this.panelFilter.Controls.Add(this.dtpFromF);
            this.panelFilter.Controls.Add(this.lblFrom);
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilter.Location = new System.Drawing.Point(0, 90);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.panelFilter.Size = new System.Drawing.Size(1000, 45);
            this.panelFilter.TabIndex = 1;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(13, 13);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(69, 20);
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Text = "Từ ngày:";
            // 
            // dtpFromF
            // 
            this.dtpFromF.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromF.Location = new System.Drawing.Point(88, 9);
            this.dtpFromF.Name = "dtpFromF";
            this.dtpFromF.Size = new System.Drawing.Size(120, 27);
            this.dtpFromF.TabIndex = 1;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(218, 13);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(76, 20);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "Đến ngày:";
            // 
            // dtpToF
            // 
            this.dtpToF.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToF.Location = new System.Drawing.Point(300, 9);
            this.dtpToF.Name = "dtpToF";
            this.dtpToF.Size = new System.Drawing.Size(120, 27);
            this.dtpToF.TabIndex = 3;
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(426, 8);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(90, 29);
            this.btnFilter.TabIndex = 4;
            this.btnFilter.Text = "Lọc";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // dgvUsage
            // 
            this.dgvUsage.AllowUserToAddRows = false;
            this.dgvUsage.AllowUserToDeleteRows = false;
            this.dgvUsage.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsage.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvUsage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsage.Location = new System.Drawing.Point(0, 135);
            this.dgvUsage.MultiSelect = false;
            this.dgvUsage.Name = "dgvUsage";
            this.dgvUsage.ReadOnly = true;
            this.dgvUsage.RowHeadersVisible = false;
            this.dgvUsage.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsage.Size = new System.Drawing.Size(1000, 455);
            this.dgvUsage.TabIndex = 2;
            // 
            // statusPanel
            // 
            this.statusPanel.Controls.Add(this.lblSum);
            this.statusPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusPanel.Location = new System.Drawing.Point(0, 590);
            this.statusPanel.Name = "statusPanel";
            this.statusPanel.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.statusPanel.Size = new System.Drawing.Size(1000, 40);
            this.statusPanel.TabIndex = 3;
            // 
            // lblSum
            // 
            this.lblSum.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblSum.Location = new System.Drawing.Point(726, 5);
            this.lblSum.Name = "lblSum";
            this.lblSum.Size = new System.Drawing.Size(264, 30);
            this.lblSum.TabIndex = 0;
            this.lblSum.Text = "Tổng: 0 đ";
            this.lblSum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmUsage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 630);
            this.Controls.Add(this.dgvUsage);
            this.Controls.Add(this.panelFilter);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.statusPanel);
            this.Name = "frmUsage";
            this.Text = "Sử dụng dịch vụ theo phòng";
            this.Load += new System.EventHandler(this.frmUsage_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQty)).EndInit();
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsage)).EndInit();
            this.statusPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.ComboBox cboRoom;
        private System.Windows.Forms.Label lblService;
        private System.Windows.Forms.ComboBox cboService;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.ComboBox cboCustomer;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.NumericUpDown nudQty;
        private System.Windows.Forms.Label lblAt;
        private System.Windows.Forms.DateTimePicker dtpUsedAt;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtpFromF;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpToF;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.DataGridView dgvUsage;
        private System.Windows.Forms.Panel statusPanel;
        private System.Windows.Forms.Label lblSum;
    }
}
