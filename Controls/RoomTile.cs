using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLiDichVuKhachSan.Controls
{
    public enum RoomStatus { Vacant, Occupied, Reserved, CheckoutSoon, Clean, Dirty, Repair }

    public partial class RoomTile : UserControl
    {
        public int RoomId { get; set; }
        private RoomStatus _status;
        private Color _borderColor = Color.Silver;

        public RoomTile()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint, true);
            this.UpdateStyles();

            // Hook Paint event once
            this.card.Paint += Card_Paint;

            this.card.Click += Bubble; this.lblRoom.Click += Bubble;
            this.lblSub.Click += Bubble; this.lblStatus.Click += Bubble;
        }
        
        private void Card_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.card.ClientRectangle,
                _borderColor, 1, ButtonBorderStyle.Solid,
                _borderColor, 1, ButtonBorderStyle.Solid,
                _borderColor, 1, ButtonBorderStyle.Solid,
                _borderColor, 1, ButtonBorderStyle.Solid);
        }

        private void Bubble(object s, EventArgs e) { this.OnClick(e); }

        public string RoomNumber { get { return lblRoom.Text; } set { lblRoom.Text = value; } }
        public string Subtitle { get { return lblSub.Text; } set { lblSub.Text = value; } }
        public string StatusText { get { return lblStatus.Text; } set { lblStatus.Text = value; } }

        public RoomStatus Status
        {
            get { return _status; }
            set { _status = value; ApplyStatus(); }
        }

        private void ApplyStatus()
        {
            Color bg, border; string txt;
            switch (_status)
            {
                case RoomStatus.Vacant: bg = Color.FromArgb(232, 245, 233); txt = "Trống"; border = Color.FromArgb(160, 200, 160); break;
                case RoomStatus.Occupied: bg = Color.FromArgb(187, 222, 251); txt = "Đang ở"; border = Color.FromArgb(120, 170, 210); break;
                case RoomStatus.Reserved: bg = Color.FromArgb(255, 243, 224); txt = "Giữ chỗ"; border = Color.FromArgb(210, 180, 120); break;
                case RoomStatus.CheckoutSoon: bg = Color.FromArgb(255, 235, 238); txt = "Sắp trả"; border = Color.FromArgb(210, 140, 140); break;
                case RoomStatus.Clean: bg = Color.FromArgb(224, 242, 241); txt = "Phòng sạch"; border = Color.FromArgb(120, 170, 170); break;
                case RoomStatus.Dirty: bg = Color.FromArgb(243, 229, 245); txt = "Phòng bẩn"; border = Color.FromArgb(170, 130, 180); break;
                case RoomStatus.Repair: bg = Color.FromArgb(239, 235, 233); txt = "Đang sửa"; border = Color.FromArgb(170, 160, 150); break;
                default: bg = Color.WhiteSmoke; txt = ""; border = Color.Silver; break;
            }
            this.card.BackColor = bg;
            this.lblStatus.Text = txt;
            _borderColor = border;
            this.card.Invalidate(); // Trigger repaint
        }
    }
}
