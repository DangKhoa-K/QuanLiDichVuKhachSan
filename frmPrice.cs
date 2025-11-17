using System;
using System.Windows.Forms;
using QuanLiDichVuKhachSan.Data;

namespace QuanLiDichVuKhachSan
{
    public partial class frmPrice : Form
    {
        public frmPrice() { InitializeComponent(); }
        private void frmPrice_Load(object s, EventArgs e)
        {
            cboService.DataSource = ServiceRepo.List();
            cboService.DisplayMember = "TenDichVu"; cboService.ValueMember = "DichVuId";
            LoadPrices();
        }
        void LoadPrices() { if (cboService.SelectedValue is int id) dgvPrices.DataSource = PriceRepo.ListByService(id); }
        private void cboService_SelectedIndexChanged(object s, EventArgs e) => LoadPrices();

        private void btnAdd_Click(object s, EventArgs e)
        {
            try
            {
                PriceRepo.Insert((int)cboService.SelectedValue, decimal.Parse(txtPrice.Text), dtpFrom.Value,
                                 dtpTo.Checked ? dtpTo.Value : (DateTime?)null);
                LoadPrices();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Lỗi"); }
        }
        private void btnUpdate_Click(object s, EventArgs e)
        {
            if (dgvPrices.CurrentRow == null) return;
            try
            {
                PriceRepo.Update((int)dgvPrices.CurrentRow.Cells["BangGiaId"].Value,
                                 decimal.Parse(txtPrice.Text), dtpFrom.Value,
                                 dtpTo.Checked ? dtpTo.Value : (DateTime?)null);
                LoadPrices();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Lỗi"); }
        }
        private void btnDelete_Click(object s, EventArgs e)
        {
            if (dgvPrices.CurrentRow == null) return;
            if (MessageBox.Show("Xóa giá?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                PriceRepo.Delete((int)dgvPrices.CurrentRow.Cells["BangGiaId"].Value);
                LoadPrices();
            }
        }
        private void dgvPrices_SelectionChanged(object s, EventArgs e)
        {
            if (dgvPrices.CurrentRow == null) return;
            txtPrice.Text = dgvPrices.CurrentRow.Cells["DonGia"].Value.ToString();
            dtpFrom.Value = (DateTime)dgvPrices.CurrentRow.Cells["HieuLucTu"].Value;
            var v = dgvPrices.CurrentRow.Cells["HieuLucDen"].Value;
            if (v == DBNull.Value) { dtpTo.Checked = false; } else { dtpTo.Checked = true; dtpTo.Value = (DateTime)v; }
        }
        private void btnRefresh_Click(object s, EventArgs e) => LoadPrices();
    }
}
