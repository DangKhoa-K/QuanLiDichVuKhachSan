using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QuanLiDichVuKhachSan.Data;

namespace QuanLiDichVuKhachSan
{
    public partial class frmCatalog : Form
    {
        public frmCatalog()
        {
            InitializeComponent();
            this.Load += frmCatalog_Load;

            // hook events (Rooms)
            dgvRooms.SelectionChanged += dgvRooms_SelectionChanged;
            btnRoomNew.Click += (s, e) => ClearRoomInputs();
            btnRoomAdd.Click += btnRoomAdd_Click;
            btnRoomUpdate.Click += btnRoomUpdate_Click;
            btnRoomDelete.Click += btnRoomDelete_Click;

            // Customers
            dgvCustomers.SelectionChanged += dgvCustomers_SelectionChanged;
            btnCusNew.Click += (s, e) => ClearCustomerInputs();
            btnCusAdd.Click += btnCusAdd_Click;
            btnCusUpdate.Click += btnCusUpdate_Click;
            btnCusDelete.Click += btnCusDelete_Click;

            // Services
            dgvServices.SelectionChanged += dgvServices_SelectionChanged;
            btnSvNew.Click += (s, e) => ClearServiceInputs();
            btnSvAdd.Click += btnSvAdd_Click;
            btnSvUpdate.Click += btnSvUpdate_Click;
            btnSvDelete.Click += btnSvDelete_Click;
        }

        private void frmCatalog_Load(object sender, EventArgs e)
        {
            StyleGrid(dgvRooms);
            StyleGrid(dgvCustomers);
            StyleGrid(dgvServices);

            ReloadRooms();
            ReloadCustomers();
            ReloadServices();
        }

        private void StyleGrid(DataGridView g)
        {
            g.ReadOnly = true;
            g.MultiSelect = false;
            g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            g.AllowUserToAddRows = false;
            g.AllowUserToDeleteRows = false;
            g.RowHeadersVisible = false;
            g.AutoGenerateColumns = true;
            g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            g.EnableHeadersVisualStyles = false;

            g.Font = new Font("Segoe UI", 10f);
            g.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            g.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(243, 247, 255);
            g.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 252, 255);
            g.DefaultCellStyle.SelectionBackColor = Color.FromArgb(13, 110, 253);
            g.DefaultCellStyle.SelectionForeColor = Color.White;
            g.RowTemplate.Height = 28;
        }

        private object Cell(DataGridView grid, DataGridViewRow row, string col)
        {
            if (grid.Columns[col] == null || row == null) return null;
            return row.Cells[grid.Columns[col].Index].Value;
        }
        private static int ToInt(object v)
        {
            int x; return (v != null && int.TryParse(Convert.ToString(v), out x)) ? x : 0;
        }

        // ---------------- ROOMS ----------------
        private void ReloadRooms()
        {
            dgvRooms.DataSource = RoomRepo.List();
            if (dgvRooms.Columns["PhongId"] != null) dgvRooms.Columns["PhongId"].HeaderText = "ID";
            if (dgvRooms.Columns["SoPhong"] != null) dgvRooms.Columns["SoPhong"].HeaderText = "Số phòng";
            if (dgvRooms.Columns["GhiChu"] != null) dgvRooms.Columns["GhiChu"].HeaderText = "Ghi chú";
            ClearRoomInputs();
        }
        private void ClearRoomInputs()
        {
            txtRoomId.Text = "";
            txtRoomNumber.Text = "";
            txtRoomNote.Text = "";
            if (dgvRooms.Rows.Count > 0) dgvRooms.ClearSelection();
            txtRoomNumber.Focus();
        }
        private void dgvRooms_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRooms.CurrentRow == null) return;
            txtRoomId.Text = Convert.ToString(Cell(dgvRooms, dgvRooms.CurrentRow, "PhongId"));
            txtRoomNumber.Text = Convert.ToString(Cell(dgvRooms, dgvRooms.CurrentRow, "SoPhong"));
            txtRoomNote.Text = Convert.ToString(Cell(dgvRooms, dgvRooms.CurrentRow, "GhiChu"));
        }
        private void btnRoomAdd_Click(object sender, EventArgs e)
        {
            string so = (txtRoomNumber.Text ?? "").Trim();
            if (so.Length == 0) { MessageBox.Show("Nhập số phòng."); txtRoomNumber.Focus(); return; }
            RoomRepo.Add(so, (txtRoomNote.Text ?? "").Trim());
            ReloadRooms();
            if (dgvRooms.Rows.Count > 0)
            {
                var r = dgvRooms.Rows[dgvRooms.Rows.Count - 1];
                r.Selected = true; dgvRooms.CurrentCell = r.Cells[0];
            }
        }
        private void btnRoomUpdate_Click(object sender, EventArgs e)
        {
            int id = ToInt(txtRoomId.Text); if (id <= 0) { MessageBox.Show("Chưa chọn phòng."); return; }
            string so = (txtRoomNumber.Text ?? "").Trim();
            if (so.Length == 0) { MessageBox.Show("Nhập số phòng."); txtRoomNumber.Focus(); return; }
            RoomRepo.Update(id, so, (txtRoomNote.Text ?? "").Trim());
            ReloadRooms();
        }
        private void btnRoomDelete_Click(object sender, EventArgs e)
        {
            int id = ToInt(txtRoomId.Text); if (id <= 0) { MessageBox.Show("Chưa chọn phòng."); return; }
            if (MessageBox.Show("Xóa phòng đã chọn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                RoomRepo.Delete(id);
                ReloadRooms();
            }
        }

        // ---------------- CUSTOMERS ----------------
        private void ReloadCustomers()
        {
            dgvCustomers.DataSource = CustomerRepo.List();
            if (dgvCustomers.Columns["KhachHangId"] != null) dgvCustomers.Columns["KhachHangId"].HeaderText = "ID";
            if (dgvCustomers.Columns["HoTen"] != null) dgvCustomers.Columns["HoTen"].HeaderText = "Họ tên";
            if (dgvCustomers.Columns["DienThoai"] != null) dgvCustomers.Columns["DienThoai"].HeaderText = "Điện thoại";
            if (dgvCustomers.Columns["Email"] != null) dgvCustomers.Columns["Email"].HeaderText = "Email";
            if (dgvCustomers.Columns["CCCD"] != null) dgvCustomers.Columns["CCCD"].HeaderText = "CCCD";
            if (dgvCustomers.Columns["DiaChi"] != null) dgvCustomers.Columns["DiaChi"].HeaderText = "Địa chỉ";
            ClearCustomerInputs();
        }
        private void ClearCustomerInputs()
        {
            txtCusId.Text = ""; txtCusName.Text = ""; txtCusTel.Text = "";
            txtCusEmail.Text = ""; txtCusCCCD.Text = ""; txtCusAddr.Text = "";
            if (dgvCustomers.Rows.Count > 0) dgvCustomers.ClearSelection();
            txtCusName.Focus();
        }
        private void dgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow == null) return;
            txtCusId.Text = Convert.ToString(Cell(dgvCustomers, dgvCustomers.CurrentRow, "KhachHangId"));
            txtCusName.Text = Convert.ToString(Cell(dgvCustomers, dgvCustomers.CurrentRow, "HoTen"));
            txtCusTel.Text = Convert.ToString(Cell(dgvCustomers, dgvCustomers.CurrentRow, "DienThoai"));
            txtCusEmail.Text = Convert.ToString(Cell(dgvCustomers, dgvCustomers.CurrentRow, "Email"));
            txtCusCCCD.Text = Convert.ToString(Cell(dgvCustomers, dgvCustomers.CurrentRow, "CCCD"));
            txtCusAddr.Text = Convert.ToString(Cell(dgvCustomers, dgvCustomers.CurrentRow, "DiaChi"));
        }
        private void btnCusAdd_Click(object sender, EventArgs e)
        {
            string hoten = (txtCusName.Text ?? "").Trim();
            if (hoten.Length == 0) { MessageBox.Show("Nhập họ tên."); txtCusName.Focus(); return; }
            CustomerRepo.Add(hoten, (txtCusTel.Text ?? "").Trim(), (txtCusEmail.Text ?? "").Trim(),
                             (txtCusCCCD.Text ?? "").Trim(), (txtCusAddr.Text ?? "").Trim());
            ReloadCustomers();
            if (dgvCustomers.Rows.Count > 0)
            {
                var r = dgvCustomers.Rows[dgvCustomers.Rows.Count - 1];
                r.Selected = true; dgvCustomers.CurrentCell = r.Cells[0];
            }
        }
        private void btnCusUpdate_Click(object sender, EventArgs e)
        {
            int id = ToInt(txtCusId.Text); if (id <= 0) { MessageBox.Show("Chưa chọn khách."); return; }
            string hoten = (txtCusName.Text ?? "").Trim();
            if (hoten.Length == 0) { MessageBox.Show("Nhập họ tên."); txtCusName.Focus(); return; }
            CustomerRepo.Update(id, hoten, (txtCusTel.Text ?? "").Trim(), (txtCusEmail.Text ?? "").Trim(),
                                (txtCusCCCD.Text ?? "").Trim(), (txtCusAddr.Text ?? "").Trim());
            ReloadCustomers();
        }
        private void btnCusDelete_Click(object sender, EventArgs e)
        {
            int id = ToInt(txtCusId.Text); if (id <= 0) { MessageBox.Show("Chưa chọn khách."); return; }
            if (MessageBox.Show("Xóa khách hàng đã chọn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CustomerRepo.Delete(id);
                ReloadCustomers();
            }
        }

        // ---------------- SERVICES ----------------
        private void ReloadServices()
        {
            dgvServices.DataSource = ServiceRepo.List();
            if (dgvServices.Columns["DichVuId"] != null) dgvServices.Columns["DichVuId"].HeaderText = "ID";
            if (dgvServices.Columns["TenDichVu"] != null) dgvServices.Columns["TenDichVu"].HeaderText = "Tên dịch vụ";
            if (dgvServices.Columns["DonVi"] != null) dgvServices.Columns["DonVi"].HeaderText = "Đơn vị";
            if (dgvServices.Columns["MoTa"] != null) dgvServices.Columns["MoTa"].HeaderText = "Mô tả";
            ClearServiceInputs();
        }
        private void ClearServiceInputs()
        {
            txtSvId.Text = ""; txtSvName.Text = ""; txtSvUnit.Text = ""; txtSvNote.Text = "";
            if (dgvServices.Rows.Count > 0) dgvServices.ClearSelection();
            txtSvName.Focus();
        }
        private void dgvServices_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvServices.CurrentRow == null) return;
            txtSvId.Text = Convert.ToString(Cell(dgvServices, dgvServices.CurrentRow, "DichVuId"));
            txtSvName.Text = Convert.ToString(Cell(dgvServices, dgvServices.CurrentRow, "TenDichVu"));
            txtSvUnit.Text = Convert.ToString(Cell(dgvServices, dgvServices.CurrentRow, "DonVi"));
            txtSvNote.Text = Convert.ToString(Cell(dgvServices, dgvServices.CurrentRow, "MoTa"));
        }
        private void btnSvAdd_Click(object sender, EventArgs e)
        {
            string ten = (txtSvName.Text ?? "").Trim();
            if (ten.Length == 0) { MessageBox.Show("Nhập tên dịch vụ."); txtSvName.Focus(); return; }
            ServiceRepo.Add(ten, (txtSvUnit.Text ?? "").Trim(), (txtSvNote.Text ?? "").Trim());
            ReloadServices();
            if (dgvServices.Rows.Count > 0)
            {
                var r = dgvServices.Rows[dgvServices.Rows.Count - 1];
                r.Selected = true; dgvServices.CurrentCell = r.Cells[0];
            }
        }
        private void btnSvUpdate_Click(object sender, EventArgs e)
        {
            int id = ToInt(txtSvId.Text); if (id <= 0) { MessageBox.Show("Chưa chọn dịch vụ."); return; }
            string ten = (txtSvName.Text ?? "").Trim();
            if (ten.Length == 0) { MessageBox.Show("Nhập tên dịch vụ."); txtSvName.Focus(); return; }
            ServiceRepo.Update(id, ten, (txtSvUnit.Text ?? "").Trim(), (txtSvNote.Text ?? "").Trim());
            ReloadServices();
        }
        private void btnSvDelete_Click(object sender, EventArgs e)
        {
            int id = ToInt(txtSvId.Text); if (id <= 0) { MessageBox.Show("Chưa chọn dịch vụ."); return; }
            if (MessageBox.Show("Xóa dịch vụ đã chọn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ServiceRepo.Delete(id);
                ReloadServices();
            }
        }
    }
}
