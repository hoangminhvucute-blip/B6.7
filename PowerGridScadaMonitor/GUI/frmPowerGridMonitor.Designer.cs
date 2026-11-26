using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    partial class frmPowerGridMonitor
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlHeader;
        private Label lblTitle;
        private GroupBox grpControl;
        private Label lblSelectSubstation;
        private ComboBox cboSubstation;
        private Button btnStartScada;
        private Button btnDisconnect;

        private GroupBox grpDashboard;
        private Panel pnlVoltageCard;
        private Label lblVoltageTitle;
        private Label lblVoltage;

        private Panel pnlLoadCard;
        private Label lblLoadTitle;
        private Label lblLoadPercent;
        private Label lblAlertBanner;

        private GroupBox grpLogs;
        private DataGridView dgvGridLogs;

        private StatusStrip statusStripMain;
        private ToolStripStatusLabel tsslConnectionState;
        private ToolStripStatusLabel tsslLastPacketTime;
        private ToolStripStatusLabel tsslTotalCycles;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpControl = new System.Windows.Forms.GroupBox();
            this.lblSelectSubstation = new System.Windows.Forms.Label();
            this.cboSubstation = new System.Windows.Forms.ComboBox();
            this.btnStartScada = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.grpDashboard = new System.Windows.Forms.GroupBox();
            this.pnlVoltageCard = new System.Windows.Forms.Panel();
            this.lblVoltageTitle = new System.Windows.Forms.Label();
            this.lblVoltage = new System.Windows.Forms.Label();
            this.pnlLoadCard = new System.Windows.Forms.Panel();
            this.lblAlertBanner = new System.Windows.Forms.Label();
            this.lblLoadPercent = new System.Windows.Forms.Label();
            this.lblLoadTitle = new System.Windows.Forms.Label();
            this.grpLogs = new System.Windows.Forms.GroupBox();
            this.dgvGridLogs = new System.Windows.Forms.DataGridView();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.tsslConnectionState = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslLastPacketTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslTotalCycles = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlHeader.SuspendLayout();
            this.grpControl.SuspendLayout();
            this.grpDashboard.SuspendLayout();
            this.pnlVoltageCard.SuspendLayout();
            this.pnlLoadCard.SuspendLayout();
            this.grpLogs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGridLogs)).BeginInit();
            this.statusStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(39)))), ((int)(((byte)(68)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1010, 59);
            this.pnlHeader.TabIndex = 3;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1010, 59);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "TRUNG TÂM ĐIỀU ĐỘ & GIÁM SÁT LƯỚI ĐIỆN THỜI GIAN THỰC (SCADA)";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpControl
            // 
            this.grpControl.Controls.Add(this.lblSelectSubstation);
            this.grpControl.Controls.Add(this.cboSubstation);
            this.grpControl.Controls.Add(this.btnStartScada);
            this.grpControl.Controls.Add(this.btnDisconnect);
            this.grpControl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpControl.Location = new System.Drawing.Point(17, 73);
            this.grpControl.Name = "grpControl";
            this.grpControl.Size = new System.Drawing.Size(976, 80);
            this.grpControl.TabIndex = 2;
            this.grpControl.TabStop = false;
            this.grpControl.Text = "1. Khu vực Điều khiển Kết nối SCADA";
            // 
            // lblSelectSubstation
            // 
            this.lblSelectSubstation.AutoSize = true;
            this.lblSelectSubstation.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSelectSubstation.Location = new System.Drawing.Point(21, 35);
            this.lblSelectSubstation.Name = "lblSelectSubstation";
            this.lblSelectSubstation.Size = new System.Drawing.Size(160, 23);
            this.lblSelectSubstation.TabIndex = 0;
            this.lblSelectSubstation.Text = "Chọn Trạm biến áp:";
            // 
            // cboSubstation
            // 
            this.cboSubstation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubstation.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboSubstation.Location = new System.Drawing.Point(200, 29);
            this.cboSubstation.Name = "cboSubstation";
            this.cboSubstation.Size = new System.Drawing.Size(308, 31);
            this.cboSubstation.TabIndex = 1;
            this.cboSubstation.SelectedIndexChanged += new System.EventHandler(this.cboSubstation_SelectedIndexChanged);
            // 
            // btnStartScada
            // 
            this.btnStartScada.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(130)))), ((int)(((byte)(68)))));
            this.btnStartScada.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStartScada.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartScada.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnStartScada.ForeColor = System.Drawing.Color.White;
            this.btnStartScada.Location = new System.Drawing.Point(514, 28);
            this.btnStartScada.Name = "btnStartScada";
            this.btnStartScada.Size = new System.Drawing.Size(240, 36);
            this.btnStartScada.TabIndex = 2;
            this.btnStartScada.Text = "Bắt đầu Giám sát SCADA";
            this.btnStartScada.UseVisualStyleBackColor = false;
            this.btnStartScada.Click += new System.EventHandler(this.btnStartScada_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnDisconnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDisconnect.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDisconnect.ForeColor = System.Drawing.Color.White;
            this.btnDisconnect.Location = new System.Drawing.Point(771, 28);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(183, 36);
            this.btnDisconnect.TabIndex = 3;
            this.btnDisconnect.Text = "Ngắt Kết nối";
            this.btnDisconnect.UseVisualStyleBackColor = false;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // grpDashboard
            // 
            this.grpDashboard.Controls.Add(this.pnlVoltageCard);
            this.grpDashboard.Controls.Add(this.pnlLoadCard);
            this.grpDashboard.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpDashboard.Location = new System.Drawing.Point(17, 162);
            this.grpDashboard.Name = "grpDashboard";
            this.grpDashboard.Size = new System.Drawing.Size(976, 165);
            this.grpDashboard.TabIndex = 1;
            this.grpDashboard.TabStop = false;
            this.grpDashboard.Text = "2. Bảng Thông số Trực quan Thời gian thực (Real-time Dashboard)";
            // 
            // pnlVoltageCard
            // 
            this.pnlVoltageCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(246)))), ((int)(((byte)(252)))));
            this.pnlVoltageCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlVoltageCard.Controls.Add(this.lblVoltageTitle);
            this.pnlVoltageCard.Controls.Add(this.lblVoltage);
            this.pnlVoltageCard.Location = new System.Drawing.Point(21, 32);
            this.pnlVoltageCard.Name = "pnlVoltageCard";
            this.pnlVoltageCard.Size = new System.Drawing.Size(451, 117);
            this.pnlVoltageCard.TabIndex = 0;
            // 
            // lblVoltageTitle
            // 
            this.lblVoltageTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblVoltageTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblVoltageTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblVoltageTitle.Location = new System.Drawing.Point(0, 0);
            this.lblVoltageTitle.Name = "lblVoltageTitle";
            this.lblVoltageTitle.Size = new System.Drawing.Size(449, 32);
            this.lblVoltageTitle.TabIndex = 0;
            this.lblVoltageTitle.Text = "ĐIỆN ÁP VẬN HÀNH HIỆN TẠI (kV)";
            this.lblVoltageTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVoltage
            // 
            this.lblVoltage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVoltage.Font = new System.Drawing.Font("Consolas", 28F, System.Drawing.FontStyle.Bold);
            this.lblVoltage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.lblVoltage.Location = new System.Drawing.Point(0, 0);
            this.lblVoltage.Name = "lblVoltage";
            this.lblVoltage.Size = new System.Drawing.Size(449, 115);
            this.lblVoltage.TabIndex = 1;
            this.lblVoltage.Text = "--- kV";
            this.lblVoltage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlLoadCard
            // 
            this.pnlLoadCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(246)))), ((int)(((byte)(252)))));
            this.pnlLoadCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLoadCard.Controls.Add(this.lblAlertBanner);
            this.pnlLoadCard.Controls.Add(this.lblLoadPercent);
            this.pnlLoadCard.Controls.Add(this.lblLoadTitle);
            this.pnlLoadCard.Location = new System.Drawing.Point(497, 32);
            this.pnlLoadCard.Name = "pnlLoadCard";
            this.pnlLoadCard.Size = new System.Drawing.Size(457, 117);
            this.pnlLoadCard.TabIndex = 1;
            // 
            // lblAlertBanner
            // 
            this.lblAlertBanner.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblAlertBanner.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblAlertBanner.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblAlertBanner.Location = new System.Drawing.Point(0, 89);
            this.lblAlertBanner.Name = "lblAlertBanner";
            this.lblAlertBanner.Size = new System.Drawing.Size(455, 26);
            this.lblAlertBanner.TabIndex = 0;
            this.lblAlertBanner.Text = "Trạng thái: Chờ kết nối tín hiệu...";
            this.lblAlertBanner.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLoadPercent
            // 
            this.lblLoadPercent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLoadPercent.Font = new System.Drawing.Font("Consolas", 26F, System.Drawing.FontStyle.Bold);
            this.lblLoadPercent.ForeColor = System.Drawing.Color.Green;
            this.lblLoadPercent.Location = new System.Drawing.Point(0, 30);
            this.lblLoadPercent.Name = "lblLoadPercent";
            this.lblLoadPercent.Size = new System.Drawing.Size(455, 85);
            this.lblLoadPercent.TabIndex = 1;
            this.lblLoadPercent.Text = "--- %";
            this.lblLoadPercent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLoadTitle
            // 
            this.lblLoadTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLoadTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblLoadTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblLoadTitle.Location = new System.Drawing.Point(0, 0);
            this.lblLoadTitle.Name = "lblLoadTitle";
            this.lblLoadTitle.Size = new System.Drawing.Size(455, 30);
            this.lblLoadTitle.TabIndex = 2;
            this.lblLoadTitle.Text = "MỨC MANG TẢI MÁY BIẾN ÁP (%)";
            this.lblLoadTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpLogs
            // 
            this.grpLogs.Controls.Add(this.dgvGridLogs);
            this.grpLogs.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpLogs.Location = new System.Drawing.Point(17, 337);
            this.grpLogs.Name = "grpLogs";
            this.grpLogs.Size = new System.Drawing.Size(976, 251);
            this.grpLogs.TabIndex = 0;
            this.grpLogs.TabStop = false;
            this.grpLogs.Text = "3. Nhật ký Sự cố Quá tải Lưới điện (Ngưỡng cảnh báo > 85%)";
            // 
            // dgvGridLogs
            // 
            this.dgvGridLogs.AllowUserToAddRows = false;
            this.dgvGridLogs.AllowUserToDeleteRows = false;
            this.dgvGridLogs.BackgroundColor = System.Drawing.Color.White;
            this.dgvGridLogs.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvGridLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGridLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGridLogs.Location = new System.Drawing.Point(3, 26);
            this.dgvGridLogs.Name = "dgvGridLogs";
            this.dgvGridLogs.ReadOnly = true;
            this.dgvGridLogs.RowHeadersVisible = false;
            this.dgvGridLogs.RowHeadersWidth = 51;
            this.dgvGridLogs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGridLogs.Size = new System.Drawing.Size(970, 222);
            this.dgvGridLogs.TabIndex = 0;
            // 
            // statusStripMain
            // 
            this.statusStripMain.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.statusStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslConnectionState,
            this.tsslLastPacketTime,
            this.tsslTotalCycles});
            this.statusStripMain.Location = new System.Drawing.Point(0, 596);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStripMain.Size = new System.Drawing.Size(1010, 31);
            this.statusStripMain.TabIndex = 4;
            // 
            // tsslConnectionState
            // 
            this.tsslConnectionState.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tsslConnectionState.ForeColor = System.Drawing.Color.DimGray;
            this.tsslConnectionState.Name = "tsslConnectionState";
            this.tsslConnectionState.Size = new System.Drawing.Size(187, 25);
            this.tsslConnectionState.Text = "Trạng thái: Ngắt kết nối   ";
            // 
            // tsslLastPacketTime
            // 
            this.tsslLastPacketTime.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tsslLastPacketTime.Name = "tsslLastPacketTime";
            this.tsslLastPacketTime.Size = new System.Drawing.Size(166, 25);
            this.tsslLastPacketTime.Text = "   Gói tin cuối: --:--:--   ";
            // 
            // tsslTotalCycles
            // 
            this.tsslTotalCycles.Name = "tsslTotalCycles";
            this.tsslTotalCycles.Size = new System.Drawing.Size(198, 25);
            this.tsslTotalCycles.Text = "   Tổng số chu kỳ đã quét: 0";
            // 
            // frmPowerGridMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 627);
            this.Controls.Add(this.grpLogs);
            this.Controls.Add(this.grpDashboard);
            this.Controls.Add(this.grpControl);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.statusStripMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmPowerGridMonitor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SCADA Power Grid Monitor - Cross-Thread Safety (Bài tập 6.7)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPowerGridMonitor_FormClosing);
            this.Load += new System.EventHandler(this.frmPowerGridMonitor_Load);
            this.pnlHeader.ResumeLayout(false);
            this.grpControl.ResumeLayout(false);
            this.grpControl.PerformLayout();
            this.grpDashboard.ResumeLayout(false);
            this.pnlVoltageCard.ResumeLayout(false);
            this.pnlLoadCard.ResumeLayout(false);
            this.grpLogs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGridLogs)).EndInit();
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
