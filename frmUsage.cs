using System;
using System.Windows.Forms;
using QuanLiDichVuKhachSan.Data;

namespace QuanLiDichVuKhachSan
{
    public partial class frmUsage : Form
    {
        public frmUsage() { InitializeComponent(); }
        private void frmUsage_Load(object s, EventArgs e)
        {
            cboRoom.DataSource = RoomRepo.List(); cboRoom.DisplayMember = "SoPhong"; cboRoom.ValueMember = "PhongId";
            cboService.DataSource = ServiceRepo.List(); cboService.DisplayMember = "TenDichVu"; cboService.ValueMember = "DichVuId";
            cboCustomer.DataSource = CustomerRepo.List(); cboCustomer.DisplayMember = "HoTen"; cboCustomer.ValueMember = "KhachHangId";
            dtpUsedAt.Value = DateTime.Now; nudQty.Value = 1;
            dtpFromF.Value = DateTime.Today; dtpToF.Value = DateTime.Today.AddDays(1).AddSeconds(-1);
            LoadList();
        }
        void LoadList() { dgvUsage.DataSource = UsageRepo.List(dtpFromF.Value, dtpToF.Value, null, null); CalcSum(); }
        void CalcSum() { decimal s = 0; foreach (DataGridViewRow r in dgvUsage.Rows) if (r.Cells["ThanhTien"].Value != null && r.Cells["ThanhTien"].Value != DBNull.Value) s += Convert.ToDecimal(r.Cells["ThanhTien"].Value); lblSum.Text = $"Tổng: {s:n0} đ"; }

        private void btnAdd_Click(object s, EventArgs e)
        {
            try
            {
                int? kh = (cboCustomer.SelectedValue is int v) ? v : (int?)null;
                UsageRepo.Add((int)cboRoom.SelectedValue, (int)cboService.SelectedValue, nudQty.Value, dtpUsedAt.Value, kh, txtNote.Text.Trim());
                LoadList();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Lỗi"); }
        }
        private void btnFilter_Click(object s, EventArgs e) => LoadList();
    }
}
