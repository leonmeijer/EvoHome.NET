namespace LVMS.EvoHome.Model
{
    public class Device
    {
        public int DeviceId { get; set; }
        public string ThermostatModelType { get; set; }
        public string Name { get; set; }
        public bool ScheduleCapable { get; set; }
        public bool HoldUntilCapable { get; set; }
        public Thermostat Thermostat { get; set; }
        public AlertSettings AlertSettings { get; set; }
        public bool IsUpgrading { get; set; }
        public bool IsAlive { get; set; }
        public string ThermostatVersion { get; set; }
        public string MacId { get; set; }
        public int LocationId { get; set; }
    }
}