using System.Windows.Forms;
using System.Drawing;

namespace QuanLiDichVuKhachSan.Controls
{
    partial class RoomTile
    {
        private System.ComponentModel.IContainer components = null;
        private Panel card;
        private Label lblRoom;
        private Label lblSub;
        private Label lblStatus;

        protected override void Dispose(bool disposing)
        { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.card = new System.Windows.Forms.Panel();
            this.lblSub = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblRoom = new System.Windows.Forms.Label();
            this.card.SuspendLayout();
            this.SuspendLayout();
            // card
            this.card.BackColor = System.Drawing.Color.White;
            this.card.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.card.Controls.Add(this.lblSub);
            this.card.Controls.Add(this.lblStatus);
            this.card.Controls.Add(this.lblRoom);
            this.card.Dock = System.Windows.Forms.DockStyle.Fill;
            this.card.Location = new System.Drawing.Point(0, 0);
            this.card.Name = "card";
            this.card.Padding = new System.Windows.Forms.Padding(8);
            this.card.Size = new System.Drawing.Size(160, 110);
            this.card.TabIndex = 0;
            // lblRoom
            this.lblRoom.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRoom.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblRoom.ForeColor = System.Drawing.Color.DimGray;
            this.lblRoom.Location = new System.Drawing.Point(8, 8);
            this.lblRoom.Name = "lblRoom";
            this.lblRoom.Size = new System.Drawing.Size(142, 32);
            this.lblRoom.Text = "101";
            // lblSub
            this.lblSub.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSub.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSub.Location = new System.Drawing.Point(8, 40);
            this.lblSub.Name = "lblSub";
            this.lblSub.Size = new System.Drawing.Size(142, 38);
            this.lblSub.Text = "";
            // lblStatus
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Location = new System.Drawing.Point(8, 78);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(142, 30);
            this.lblStatus.Text = "Trống";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // RoomTile
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.card);
            this.Cursor = Cursors.Hand;
            this.Name = "RoomTile";
            this.Size = new System.Drawing.Size(160, 110);
            this.card.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
