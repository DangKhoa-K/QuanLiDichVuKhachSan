using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QuanLiDichVuKhachSan.Data;
using QuanLiDichVuKhachSan.Controls;

namespace QuanLiDichVuKhachSan
{
    public partial class frmMain : Form
    {
        public frmMain() { InitializeComponent(); }

        // ========= Sidebar an toàn (không lỗi SplitterDistance) =========
        private void ApplySplitterForSidebar()
        {
            int desiredLeft = 220;                    // rộng sidebar mong muốn
            int minLeft = 200;                        // để panel1 không quá nhỏ
            int minRight = 300;                       // để khu vực phòng không quá nhỏ

            scMain.Panel1MinSize = minLeft;
            scMain.Panel2MinSize = minRight;

            int w = scMain.ClientSize.Width;
            int maxLeft = w - scMain.Panel2MinSize - scMain.SplitterWidth;
            if (maxLeft < minLeft) maxLeft = minLeft;

            int left = desiredLeft;
            if (left < minLeft) left = minLeft;
            if (left > maxLeft) left = maxLeft;

            scMain.SplitterDistance = left;
        }
        private void ResizeNavButtons()
        {
            int w = panelNav.ClientSize.Width - panelNav.Padding.Left - panelNav.Padding.Right;
            foreach (Control c in panelNav.Controls)
                if (c is Button) ((Button)c).Width = w;
        }

        private void frmMain_Load(object s, EventArgs e)
        {
            // Enable DoubleBuffered for FlowLayoutPanel to reduce flicker
            typeof(Control).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty,
                null, rbFlow, new object[] { true });

            // Sidebar: đặt khoảng chia + fit nút sau khi form đo xong
            this.BeginInvoke(new Action(() => { ApplySplitterForSidebar(); ResizeNavButtons(); }));
            this.Resize += (sender, e2) => { ApplySplitterForSidebar(); ResizeNavButtons(); };

            // Menu mở form
            this.mnuCatalog.Click += (sender, e2) => { using (var f = new frmCatalog()) f.ShowDialog(this); };
            this.mnuPrice.Click += (sender, e2) => { using (var f = new frmPrice()) f.ShowDialog(this); };
            this.mnuUsage.Click += (sender, e2) => { using (var f = new frmUsage()) f.ShowDialog(this); };

            // Sidebar mở form
            this.btnNavRooms.Click += (sender, e2) => { /* chỉ là sơ đồ phòng - không cần làm gì */ };
            this.btnNavCatalog.Click += (sender, e2) => { using (var f = new frmCatalog()) f.ShowDialog(this); };
            this.btnNavPrice.Click += (sender, e2) => { using (var f = new frmPrice()) f.ShowDialog(this); };
            this.btnNavUsage.Click += (sender, e2) => { using (var f = new frmUsage()) f.ShowDialog(this); };

            // Khởi tạo room board
            InitRoomBoard();
            LoadRoomBoard();
        }

        // ========= Room board =========
        private DataTable _rbRooms;

        private void InitRoomBoard()
        {
            rbCboStatus.Items.Clear();
            rbCboStatus.Items.Add("Tất cả");
            // Populate from RoomRepo constant
            foreach (string status in RoomRepo.ROOM_STATUSES)
                rbCboStatus.Items.Add(status);
            rbCboStatus.SelectedIndex = 0;

            rbBtnReload.Click += delegate { LoadRoomBoard(); };
            rbTxtSearch.TextChanged += delegate { ApplyRoomBoardFilter(); };
            rbCboStatus.SelectedIndexChanged += delegate { ApplyRoomBoardFilter(); };
        }

        private void LoadRoomBoard()
        {
            // Lấy danh sách phòng với trạng thái thực từ database
            _rbRooms = RoomRepo.List();
            if (_rbRooms == null) return;

            // Nếu chưa có cột TrangThaiText -> thêm để map từ numeric sang text
            if (!_rbRooms.Columns.Contains("TrangThaiText"))
                _rbRooms.Columns.Add("TrangThaiText", typeof(string));

            // Map trạng thái từ numeric sang text
            for (int i = 0; i < _rbRooms.Rows.Count; i++)
            {
                object statusObj = _rbRooms.Rows[i]["TrangThai"];
                int statusIndex = 0;
                if (statusObj != null && int.TryParse(statusObj.ToString(), out int st))
                    statusIndex = st;
                
                // Map to status text
                if (statusIndex >= 0 && statusIndex < RoomRepo.ROOM_STATUSES.Length)
                    _rbRooms.Rows[i]["TrangThaiText"] = RoomRepo.ROOM_STATUSES[statusIndex];
                else
                    _rbRooms.Rows[i]["TrangThaiText"] = RoomRepo.ROOM_STATUSES[0]; // Default: Trống
            }
            RenderRoomTiles(_rbRooms);
        }

        // Public method to refresh room board from external forms (e.g., frmCatalog)
        public void RefreshRoomBoard()
        {
            LoadRoomBoard();
        }

        private void RenderRoomTiles(DataTable dt)
        {
            const int TILE_W = 150;
            const int TILE_H = 110;

            rbFlow.SuspendLayout();
            rbFlow.Controls.Clear();

            foreach (DataRow r in dt.Rows)
            {
                var tile = new RoomTile();
                tile.Margin = new Padding(6);
                tile.Size = new Size(TILE_W, TILE_H);

                tile.RoomId = Convert.ToInt32(r["PhongId"]);
                tile.RoomNumber = Convert.ToString(r["SoPhong"]);
                string st = Convert.ToString(r["TrangThaiText"]);
                tile.Status = MapStatus(st);
                tile.StatusText = st;

                tile.Click += delegate
                {
                    MessageBox.Show("Phòng " + tile.RoomNumber + " - " + tile.StatusText, "Thông tin");
                };

                rbFlow.Controls.Add(tile);
            }
            rbFlow.ResumeLayout();
        }

        private void ApplyRoomBoardFilter()
        {
            if (_rbRooms == null) return;
            string kw = (rbTxtSearch.Text ?? "").Trim();
            string st = rbCboStatus.SelectedIndex <= 0 ? "" : Convert.ToString(rbCboStatus.SelectedItem);

            DataTable view = _rbRooms.Clone();
            foreach (DataRow r in _rbRooms.Rows)
            {
                bool ok = true;
                if (kw.Length > 0 && !Convert.ToString(r["SoPhong"]).Contains(kw)) ok = false;
                if (st.Length > 0 && !string.Equals(Convert.ToString(r["TrangThaiText"]), st, StringComparison.Ordinal)) ok = false;
                if (ok) view.ImportRow(r);
            }
            RenderRoomTiles(view);
        }

        private RoomStatus MapStatus(string s)
        {
            s = (s ?? "").Trim();
            if (s == "Trống") return RoomStatus.Vacant;
            if (s == "Đang ở") return RoomStatus.Occupied;
            if (s == "Giữ chỗ") return RoomStatus.Reserved;
            if (s == "Sắp trả") return RoomStatus.CheckoutSoon;
            if (s == "Phòng sạch") return RoomStatus.Clean;
            if (s == "Phòng bẩn") return RoomStatus.Dirty;
            if (s == "Đang sửa") return RoomStatus.Repair;
            return RoomStatus.Vacant;
        }
    }
}
