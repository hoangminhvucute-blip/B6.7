using System;

namespace DTO
{
    public class ScadaTelemetryDTO
    {
        public string SubstationID { get; set; }
        public string SubstationName { get; set; }
        public DateTime Timestamp { get; set; }
        public double VoltageKV { get; set; }
        public double LoadPercent { get; set; }
        public int CycleCount { get; set; }
        public bool IsOverloaded => LoadPercent > 85.0;
        public string StatusMessage => IsOverloaded
            ? $"CẢNH BÁO QUÁ TẢI ({LoadPercent:F1}% > 85%)"
            : "Vận hành ổn định";
    }
}
