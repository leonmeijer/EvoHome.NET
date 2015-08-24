using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVMS.EvoHome.Model
{
    public class Thermostat
    {
        public string Units { get; set; }
        public double IndoorTemperature { get; set; }
        public double OutdoorTemperature { get; set; }
        public bool OutdoorTemperatureAvailable { get; set; }
        public double OutdoorHumidity { get; set; }
        public bool OutdootHumidityAvailable { get; set; }
        public double IndoorHumidity { get; set; }
        public string IndoorTemperatureStatus { get; set; }
        public string IndoorHumidityStatus { get; set; }
        public string OutdoorTemperatureStatus { get; set; }
        public string OutdoorHumidityStatus { get; set; }
        public bool IsCommercial { get; set; }
        public List<string> AllowedModes { get; set; }
        public double Deadband { get; set; }
        public double MinHeatSetpoint { get; set; }
        public double MaxHeatSetpoint { get; set; }
        public double MinCoolSetpoint { get; set; }
        public double MaxCoolSetpoint { get; set; }
        public ChangeableValues ChangeableValues { get; set; }
        public bool ScheduleCapable { get; set; }
        public bool VacationHoldChangeable { get; set; }
        public bool VacationHoldCancelable { get; set; }
        public double ScheduleHeatSp { get; set; }
        public double ScheduleCoolSp { get; set; }
    }
}
