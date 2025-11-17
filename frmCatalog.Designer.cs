using System.Windows.Forms;

namespace QuanLiDichVuKhachSan
{
    partial class frmCatalog
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
            this.tabMain = new System.Windows.Forms.TabControl();

            // ====== ROOMS ======
            this.tabRooms = new System.Windows.Forms.TabPage();
            this.tblRooms = new System.Windows.Forms.TableLayoutPanel();
            this.dgvRooms = new System.Windows.Forms.DataGridView();
            this.grpRoom = new System.Windows.Forms.GroupBox();
            this.tlpRoom = new System.Windows.Forms.TableLayoutPanel();
            this.lblRoomId = new System.Windows.Forms.Label();
            this.txtRoomId = new System.Windows.Forms.TextBox();
            this.lblRoomNumber = new System.Windows.Forms.Label();
            this.txtRoomNumber = new System.Windows.Forms.TextBox();
            this.lblRoomNote = new System.Windows.Forms.Label();
            this.txtRoomNote = new System.Windows.Forms.TextBox();
            this.flowRoomButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRoomDelete = new System.Windows.Forms.Button();
            this.btnRoomUpdate = new System.Windows.Forms.Button();
            this.btnRoomAdd = new System.Windows.Forms.Button();
            this.btnRoomNew = new System.Windows.Forms.Button();

            // ====== CUSTOMERS ======
            this.tabCustomers = new System.Windows.Forms.TabPage();
            this.tblCustomers = new System.Windows.Forms.TableLayoutPanel();
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.grpCus = new System.Windows.Forms.GroupBox();
            this.tlpCus = new System.Windows.Forms.TableLayoutPanel();
            this.lblCusId = new System.Windows.Forms.Label();
            this.txtCusId = new System.Windows.Forms.TextBox();
            this.lblCusName = new System.Windows.Forms.Label();
            this.txtCusName = new System.Windows.Forms.TextBox();
            this.lblCusTel = new System.Windows.Forms.Label();
            this.txtCusTel = new System.Windows.Forms.TextBox();
            this.lblCusEmail = new System.Windows.Forms.Label();
            this.txtCusEmail = new System.Windows.Forms.TextBox();
            this.lblCusCCCD = new System.Windows.Forms.Label();
            this.txtCusCCCD = new System.Windows.Forms.TextBox();
            this.lblCusAddr = new System.Windows.Forms.Label();
            this.txtCusAddr = new System.Windows.Forms.TextBox();
            this.flowCusButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCusDelete = new System.Windows.Forms.Button();
            this.btnCusUpdate = new System.Windows.Forms.Button();
            this.btnCusAdd = new System.Windows.Forms.Button();
            this.btnCusNew = new System.Windows.Forms.Button();

            // ====== SERVICES ======
            this.tabServices = new System.Windows.Forms.TabPage();
            this.tblServices = new System.Windows.Forms.TableLayoutPanel();
            this.dgvServices = new System.Windows.Forms.DataGridView();
            this.grpSv = new System.Windows.Forms.GroupBox();
            this.tlpSv = new System.Windows.Forms.TableLayoutPanel();
            this.lblSvId = new System.Windows.Forms.Label();
            this.txtSvId = new System.Windows.Forms.TextBox();
            this.lblSvName = new System.Windows.Forms.Label();
            this.txtSvName = new System.Windows.Forms.TextBox();
            this.lblSvUnit = new System.Windows.Forms.Label();
            this.txtSvUnit = new System.Windows.Forms.TextBox();
            this.lblSvNote = new System.Windows.Forms.Label();
            this.txtSvNote = new System.Windows.Forms.TextBox();
            this.flowSvButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSvDelete = new System.Windows.Forms.Button();
            this.btnSvUpdate = new System.Windows.Forms.Button();
            this.btnSvAdd = new System.Windows.Forms.Button();
            this.btnSvNew = new System.Windows.Forms.Button();

            // ====== form ======
            this.SuspendLayout();
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "Danh mục";
            this.ClientSize = new System.Drawing.Size(1100, 640);
            this.Controls.Add(this.tabMain);

            // ====== tabMain ======
            this.tabMain.Dock = DockStyle.Fill;
            this.tabMain.Controls.Add(this.tabRooms);
            this.tabMain.Controls.Add(this.tabCustomers);
            this.tabMain.Controls.Add(this.tabServices);

            // ---------------- ROOMS LAYOUT ----------------
            this.tabRooms.Text = "Phòng";
            this.tabRooms.Padding = new Padding(6);
            this.tabRooms.UseVisualStyleBackColor = true;
            this.tabRooms.Controls.Add(this.tblRooms);

            this.tblRooms.Dock = DockStyle.Fill;
            this.tblRooms.ColumnCount = 2;
            this.tblRooms.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            this.tblRooms.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            this.tblRooms.RowCount = 1;
            this.tblRooms.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.tblRooms.Controls.Add(this.dgvRooms, 0, 0);
            this.tblRooms.Controls.Add(this.grpRoom, 1, 0);

            this.dgvRooms.Dock = DockStyle.Fill;
            this.dgvRooms.Name = "dgvRooms";

            this.grpRoom.Dock = DockStyle.Fill;
            this.grpRoom.Text = "Thông tin phòng";
            this.grpRoom.Padding = new Padding(12);
            this.grpRoom.Controls.Add(this.tlpRoom);

            this.tlpRoom.Dock = DockStyle.Fill;
            this.tlpRoom.ColumnCount = 2;
            this.tlpRoom.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            this.tlpRoom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.tlpRoom.RowCount = 4;
            this.tlpRoom.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            this.tlpRoom.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            this.tlpRoom.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.tlpRoom.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));

            this.lblRoomId.Text = "ID:"; this.lblRoomId.Dock = DockStyle.Fill; this.lblRoomId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtRoomId.ReadOnly = true; this.txtRoomId.Dock = DockStyle.Fill;
            this.lblRoomNumber.Text = "Số phòng:"; this.lblRoomNumber.Dock = DockStyle.Fill; this.lblRoomNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtRoomNumber.Dock = DockStyle.Fill;
            this.lblRoomNote.Text = "Ghi chú:"; this.lblRoomNote.Dock = DockStyle.Fill; this.lblRoomNote.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.txtRoomNote.Multiline = true; this.txtRoomNote.Dock = DockStyle.Fill;

            this.flowRoomButtons.Dock = DockStyle.Fill;
            this.flowRoomButtons.FlowDirection = FlowDirection.RightToLeft;
            this.btnRoomDelete.Text = "Xóa"; this.btnRoomDelete.Width = 96;
            this.btnRoomUpdate.Text = "Cập nhật"; this.btnRoomUpdate.Width = 96;
            this.btnRoomAdd.Text = "Thêm"; this.btnRoomAdd.Width = 96;
            this.btnRoomNew.Text = "Làm mới"; this.btnRoomNew.Width = 96;
            this.flowRoomButtons.Controls.Add(this.btnRoomDelete);
            this.flowRoomButtons.Controls.Add(this.btnRoomUpdate);
            this.flowRoomButtons.Controls.Add(this.btnRoomAdd);
            this.flowRoomButtons.Controls.Add(this.btnRoomNew);

            this.tlpRoom.Controls.Add(this.lblRoomId, 0, 0);
            this.tlpRoom.Controls.Add(this.txtRoomId, 1, 0);
            this.tlpRoom.Controls.Add(this.lblRoomNumber, 0, 1);
            this.tlpRoom.Controls.Add(this.txtRoomNumber, 1, 1);
            this.tlpRoom.Controls.Add(this.lblRoomNote, 0, 2);
            this.tlpRoom.Controls.Add(this.txtRoomNote, 1, 2);
            this.tlpRoom.Controls.Add(this.flowRoomButtons, 1, 3);

            // ---------------- CUSTOMERS LAYOUT ----------------
            this.tabCustomers.Text = "Khách hàng";
            this.tabCustomers.Padding = new Padding(6);
            this.tabCustomers.UseVisualStyleBackColor = true;
            this.tabCustomers.Controls.Add(this.tblCustomers);

            this.tblCustomers.Dock = DockStyle.Fill;
            this.tblCustomers.ColumnCount = 2;
            this.tblCustomers.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            this.tblCustomers.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            this.tblCustomers.RowCount = 1;
            this.tblCustomers.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.tblCustomers.Controls.Add(this.dgvCustomers, 0, 0);
            this.tblCustomers.Controls.Add(this.grpCus, 1, 0);

            this.dgvCustomers.Dock = DockStyle.Fill;
            this.dgvCustomers.Name = "dgvCustomers";

            this.grpCus.Dock = DockStyle.Fill;
            this.grpCus.Text = "Thông tin khách hàng";
            this.grpCus.Padding = new Padding(12);
            this.grpCus.Controls.Add(this.tlpCus);

            this.tlpCus.Dock = DockStyle.Fill;
            this.tlpCus.ColumnCount = 2;
            this.tlpCus.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            this.tlpCus.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.tlpCus.RowCount = 7;
            this.tlpCus.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            this.tlpCus.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            this.tlpCus.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            this.tlpCus.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            this.tlpCus.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            this.tlpCus.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.tlpCus.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));

            this.lblCusId.Text = "ID:"; this.lblCusId.Dock = DockStyle.Fill; this.lblCusId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtCusId.ReadOnly = true; this.txtCusId.Dock = DockStyle.Fill;
            this.lblCusName.Text = "Họ tên:"; this.lblCusName.Dock = DockStyle.Fill; this.lblCusName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtCusName.Dock = DockStyle.Fill;
            this.lblCusTel.Text = "Điện thoại:"; this.lblCusTel.Dock = DockStyle.Fill; this.lblCusTel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtCusTel.Dock = DockStyle.Fill;
            this.lblCusEmail.Text = "Email:"; this.lblCusEmail.Dock = DockStyle.Fill; this.lblCusEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtCusEmail.Dock = DockStyle.Fill;
            this.lblCusCCCD.Text = "CCCD:"; this.lblCusCCCD.Dock = DockStyle.Fill; this.lblCusCCCD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtCusCCCD.Dock = DockStyle.Fill;
            this.lblCusAddr.Text = "Địa chỉ:"; this.lblCusAddr.Dock = DockStyle.Fill; this.lblCusAddr.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.txtCusAddr.Multiline = true; this.txtCusAddr.Dock = DockStyle.Fill;

            this.flowCusButtons.Dock = DockStyle.Fill;
            this.flowCusButtons.FlowDirection = FlowDirection.RightToLeft;
            this.btnCusDelete.Text = "Xóa"; this.btnCusDelete.Width = 96;
            this.btnCusUpdate.Text = "Cập nhật"; this.btnCusUpdate.Width = 96;
            this.btnCusAdd.Text = "Thêm"; this.btnCusAdd.Width = 96;
            this.btnCusNew.Text = "Làm mới"; this.btnCusNew.Width = 96;
            this.flowCusButtons.Controls.Add(this.btnCusDelete);
            this.flowCusButtons.Controls.Add(this.btnCusUpdate);
            this.flowCusButtons.Controls.Add(this.btnCusAdd);
            this.flowCusButtons.Controls.Add(this.btnCusNew);

            this.tlpCus.Controls.Add(this.lblCusId, 0, 0);
            this.tlpCus.Controls.Add(this.txtCusId, 1, 0);
            this.tlpCus.Controls.Add(this.lblCusName, 0, 1);
            this.tlpCus.Controls.Add(this.txtCusName, 1, 1);
            this.tlpCus.Controls.Add(this.lblCusTel, 0, 2);
            this.tlpCus.Controls.Add(this.txtCusTel, 1, 2);
            this.tlpCus.Controls.Add(this.lblCusEmail, 0, 3);
            this.tlpCus.Controls.Add(this.txtCusEmail, 1, 3);
            this.tlpCus.Controls.Add(this.lblCusCCCD, 0, 4);
            this.tlpCus.Controls.Add(this.txtCusCCCD, 1, 4);
            this.tlpCus.Controls.Add(this.lblCusAddr, 0, 5);
            this.tlpCus.Controls.Add(this.txtCusAddr, 1, 5);
            this.tlpCus.Controls.Add(this.flowCusButtons, 1, 6);

            // ---------------- SERVICES LAYOUT ----------------
            this.tabServices.Text = "Dịch vụ";
            this.tabServices.Padding = new Padding(6);
            this.tabServices.UseVisualStyleBackColor = true;
            this.tabServices.Controls.Add(this.tblServices);

            this.tblServices.Dock = DockStyle.Fill;
            this.tblServices.ColumnCount = 2;
            this.tblServices.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            this.tblServices.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            this.tblServices.RowCount = 1;
            this.tblServices.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.tblServices.Controls.Add(this.dgvServices, 0, 0);
            this.tblServices.Controls.Add(this.grpSv, 1, 0);

            this.dgvServices.Dock = DockStyle.Fill;
            this.dgvServices.Name = "dgvServices";

            this.grpSv.Dock = DockStyle.Fill;
            this.grpSv.Text = "Thông tin dịch vụ";
            this.grpSv.Padding = new Padding(12);
            this.grpSv.Controls.Add(this.tlpSv);

            this.tlpSv.Dock = DockStyle.Fill;
            this.tlpSv.ColumnCount = 2;
            this.tlpSv.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            this.tlpSv.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.tlpSv.RowCount = 5;
            this.tlpSv.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            this.tlpSv.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            this.tlpSv.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            this.tlpSv.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.tlpSv.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));

            this.lblSvId.Text = "ID:"; this.lblSvId.Dock = DockStyle.Fill; this.lblSvId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtSvId.ReadOnly = true; this.txtSvId.Dock = DockStyle.Fill;
            this.lblSvName.Text = "Tên DV:"; this.lblSvName.Dock = DockStyle.Fill; this.lblSvName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtSvName.Dock = DockStyle.Fill;
            this.lblSvUnit.Text = "Đơn vị:"; this.lblSvUnit.Dock = DockStyle.Fill; this.lblSvUnit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtSvUnit.Dock = DockStyle.Fill;
            this.lblSvNote.Text = "Mô tả:"; this.lblSvNote.Dock = DockStyle.Fill; this.lblSvNote.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.txtSvNote.Multiline = true; this.txtSvNote.Dock = DockStyle.Fill;

            this.flowSvButtons.Dock = DockStyle.Fill;
            this.flowSvButtons.FlowDirection = FlowDirection.RightToLeft;
            this.btnSvDelete.Text = "Xóa"; this.btnSvDelete.Width = 96;
            this.btnSvUpdate.Text = "Cập nhật"; this.btnSvUpdate.Width = 96;
            this.btnSvAdd.Text = "Thêm"; this.btnSvAdd.Width = 96;
            this.btnSvNew.Text = "Làm mới"; this.btnSvNew.Width = 96;
            this.flowSvButtons.Controls.Add(this.btnSvDelete);
            this.flowSvButtons.Controls.Add(this.btnSvUpdate);
            this.flowSvButtons.Controls.Add(this.btnSvAdd);
            this.flowSvButtons.Controls.Add(this.btnSvNew);

            this.tlpSv.Controls.Add(this.lblSvId, 0, 0);
            this.tlpSv.Controls.Add(this.txtSvId, 1, 0);
            this.tlpSv.Controls.Add(this.lblSvName, 0, 1);
            this.tlpSv.Controls.Add(this.txtSvName, 1, 1);
            this.tlpSv.Controls.Add(this.lblSvUnit, 0, 2);
            this.tlpSv.Controls.Add(this.txtSvUnit, 1, 2);
            this.tlpSv.Controls.Add(this.lblSvNote, 0, 3);
            this.tlpSv.Controls.Add(this.txtSvNote, 1, 3);
            this.tlpSv.Controls.Add(this.flowSvButtons, 1, 4);

            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.TabControl tabMain;

        private System.Windows.Forms.TabPage tabRooms;
        private System.Windows.Forms.TableLayoutPanel tblRooms;
        private System.Windows.Forms.DataGridView dgvRooms;
        private System.Windows.Forms.GroupBox grpRoom;
        private System.Windows.Forms.TableLayoutPanel tlpRoom;
        private System.Windows.Forms.Label lblRoomId;
        private System.Windows.Forms.TextBox txtRoomId;
        private System.Windows.Forms.Label lblRoomNumber;
        private System.Windows.Forms.TextBox txtRoomNumber;
        private System.Windows.Forms.Label lblRoomNote;
        private System.Windows.Forms.TextBox txtRoomNote;
        private System.Windows.Forms.FlowLayoutPanel flowRoomButtons;
        private System.Windows.Forms.Button btnRoomDelete;
        private System.Windows.Forms.Button btnRoomUpdate;
        private System.Windows.Forms.Button btnRoomAdd;
        private System.Windows.Forms.Button btnRoomNew;

        private System.Windows.Forms.TabPage tabCustomers;
        private System.Windows.Forms.TableLayoutPanel tblCustomers;
        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.GroupBox grpCus;
        private System.Windows.Forms.TableLayoutPanel tlpCus;
        private System.Windows.Forms.Label lblCusId;
        private System.Windows.Forms.TextBox txtCusId;
        private System.Windows.Forms.Label lblCusName;
        private System.Windows.Forms.TextBox txtCusName;
        private System.Windows.Forms.Label lblCusTel;
        private System.Windows.Forms.TextBox txtCusTel;
        private System.Windows.Forms.Label lblCusEmail;
        private System.Windows.Forms.TextBox txtCusEmail;
        private System.Windows.Forms.Label lblCusCCCD;
        private System.Windows.Forms.TextBox txtCusCCCD;
        private System.Windows.Forms.Label lblCusAddr;
        private System.Windows.Forms.TextBox txtCusAddr;
        private System.Windows.Forms.FlowLayoutPanel flowCusButtons;
        private System.Windows.Forms.Button btnCusDelete;
        private System.Windows.Forms.Button btnCusUpdate;
        private System.Windows.Forms.Button btnCusAdd;
        private System.Windows.Forms.Button btnCusNew;

        private System.Windows.Forms.TabPage tabServices;
        private System.Windows.Forms.TableLayoutPanel tblServices;
        private System.Windows.Forms.DataGridView dgvServices;
        private System.Windows.Forms.GroupBox grpSv;
        private System.Windows.Forms.TableLayoutPanel tlpSv;
        private System.Windows.Forms.Label lblSvId;
        private System.Windows.Forms.TextBox txtSvId;
        private System.Windows.Forms.Label lblSvName;
        private System.Windows.Forms.TextBox txtSvName;
        private System.Windows.Forms.Label lblSvUnit;
        private System.Windows.Forms.TextBox txtSvUnit;
        private System.Windows.Forms.Label lblSvNote;
        private System.Windows.Forms.TextBox txtSvNote;
        private System.Windows.Forms.FlowLayoutPanel flowSvButtons;
        private System.Windows.Forms.Button btnSvDelete;
        private System.Windows.Forms.Button btnSvUpdate;
        private System.Windows.Forms.Button btnSvAdd;
        private System.Windows.Forms.Button btnSvNew;
    }
}
