using System;
using System.Drawing;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class frmPowerGridMonitor : Form
    {
        private readonly ScadaBUS _scadaBUS;

        public frmPowerGridMonitor()
        {
            InitializeComponent();
            _scadaBUS = new ScadaBUS();
            _scadaBUS.OnTelemetryReceived += UpdateDashboardSafely;
        }

        private void frmPowerGridMonitor_Load(object sender, EventArgs e)
        {
            ConfigureGridLogsManually();
            LoadSubstations();
        }

        /// <summary>
        /// Cấu hình cột thủ công bằng code cho dgvGridLogs
        /// </summary>
        private void ConfigureGridLogsManually()
        {
            dgvGridLogs.Columns.Clear();
            dgvGridLogs.AutoGenerateColumns = false;

            dgvGridLogs.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCycle",
                HeaderText = "Chu kỳ #",
                Width = 80
            });

            dgvGridLogs.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTime",
                HeaderText = "Thời điểm Sự cố",
                Width = 140
            });

            dgvGridLogs.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colSubstation",
                HeaderText = "Trạm Biến Áp",
                Width = 190
            });

            dgvGridLogs.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colVoltage",
                HeaderText = "Điện áp (kV)",
                Width = 110
            });

            dgvGridLogs.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colLoad",
                HeaderText = "Mức tải (%)",
                Width = 110
            });

            dgvGridLogs.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colStatus",
                HeaderText = "Cảnh báo Hệ thống",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvGridLogs.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvGridLogs.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(230, 236, 245);
            dgvGridLogs.EnableHeadersVisualStyles = false;
            dgvGridLogs.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
        }

        private void LoadSubstations()
        {
            var substations = _scadaBUS.GetSubstations();
            cboSubstation.DataSource = substations;
            cboSubstation.DisplayMember = "SubstationName";
            cboSubstation.ValueMember = "SubstationID";
        }

        private void btnStartScada_Click(object sender, EventArgs e)
        {
            if (cboSubstation.SelectedItem is SubstationDTO selectedSubstation)
            {
                btnStartScada.Enabled = false;
                cboSubstation.Enabled = false;
                btnDisconnect.Enabled = true;

                tsslConnectionState.Text = $"Trạng thái: Đang giám sát [{selectedSubstation.SubstationName}]   ";
                tsslConnectionState.ForeColor = Color.DarkGreen;

                _scadaBUS.StartMonitoring(selectedSubstation);
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            _scadaBUS.StopMonitoring();

            btnStartScada.Enabled = true;
            cboSubstation.Enabled = true;
            btnDisconnect.Enabled = false;

            tsslConnectionState.Text = "Trạng thái: Đã ngắt kết nối SCADA   ";
            tsslConnectionState.ForeColor = Color.Firebrick;
            lblAlertBanner.Text = "Trạng thái: Đã dừng thu thập dữ liệu";
            lblAlertBanner.ForeColor = Color.DimGray;
        }

        /// <summary>
        /// Mọi cập nhật lên lblVoltage, lblLoadPercent, StatusStrip và dgvGridLogs
        /// đều đi qua UpdateDashboardSafely(...) kiểm tra if (this.InvokeRequired)
        /// rồi gọi this.Invoke(new Action(() => { ... })), tránh lỗi InvalidOperationException
        /// </summary>
        private void UpdateDashboardSafely(ScadaTelemetryDTO data)
        {
            if (this.IsDisposed) return;

            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    UpdateDashboardSafely(data);
                }));
                return;
            }

            // 1. Cập nhật Điện áp (108.0 - 115.0 kV)
            lblVoltage.Text = $"{data.VoltageKV:F2} kV";

            // 2. Cập nhật Mức tải (50.0 - 98.0 %) — Đỏ nếu > 85%, Xanh lá nếu ổn định
            lblLoadPercent.Text = $"{data.LoadPercent:F1} %";

            if (data.IsOverloaded)
            {
                lblLoadPercent.ForeColor = Color.Red;
                pnlLoadCard.BackColor = Color.FromArgb(255, 235, 238);
                lblAlertBanner.Text = $"CẢNH BÁO QUÁ TẢI! Tải đạt {data.LoadPercent:F1}% (Vượt ngưỡng 85%)";
                lblAlertBanner.ForeColor = Color.Red;

                dgvGridLogs.Rows.Insert(0,
                    data.CycleCount,
                    data.Timestamp.ToString("HH:mm:ss dd/MM/yyyy"),
                    data.SubstationName,
                    $"{data.VoltageKV:F2} kV",
                    $"{data.LoadPercent:F1} %",
                    data.StatusMessage
                );

                dgvGridLogs.Rows[0].DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 238);
                dgvGridLogs.Rows[0].DefaultCellStyle.ForeColor = Color.DarkRed;
            }
            else
            {
                lblLoadPercent.ForeColor = Color.Green;
                pnlLoadCard.BackColor = Color.FromArgb(232, 245, 233);
                lblAlertBanner.Text = "Hệ thống vận hành ổn định (≤ 85%)";
                lblAlertBanner.ForeColor = Color.DarkGreen;
            }

            // 3. Cập nhật StatusStrip (HH:mm:ss & Tổng số chu kỳ đã quét)
            tsslLastPacketTime.Text = $"   Gói tin cuối: {data.Timestamp:HH:mm:ss}   ";
            tsslTotalCycles.Text = $"   Tổng số chu kỳ đã quét: {data.CycleCount}";
        }

        private void frmPowerGridMonitor_FormClosing(object sender, FormClosingEventArgs e)
        {
            _scadaBUS.StopMonitoring();
        }

        private void cboSubstation_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
