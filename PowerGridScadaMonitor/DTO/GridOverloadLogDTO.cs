using System;

namespace DTO
{
    public class GridOverloadLogDTO
    {
        public int LogID { get; set; }
        public string SubstationID { get; set; }
        public string SubstationName { get; set; }
        public DateTime RecordedTime { get; set; }
        public double VoltageKV { get; set; }
        public double LoadPercent { get; set; }
        public string StatusMessage { get; set; }
    }
}
