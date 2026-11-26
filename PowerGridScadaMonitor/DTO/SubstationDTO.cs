using System;

namespace DTO
{
    public class SubstationDTO
    {
        public string SubstationID { get; set; }
        public string SubstationName { get; set; }
        public double NominalVoltageKV { get; set; }
        public double SafeLoadThreshold { get; set; }
        public string Location { get; set; }

        public override string ToString() => SubstationName;
    }
}
