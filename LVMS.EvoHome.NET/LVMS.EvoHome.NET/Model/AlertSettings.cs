namespace LVMS.EvoHome.Model
{
    public class AlertSettings
    {
        public int DeviceId { get; set; }
        public bool TempHigherThanActive { get; set; }
        public double TempHigherThan { get; set; }
        public int TempHigherThanMinutes { get; set; }
        public bool TempLowerThanActive { get; set; }
        public double TempLowerThan { get; set; }
        public int TempLowerThanMinutes { get; set; }
        public bool FaultConditionExistsActive { get; set; }
        public int FaultConditionExistsHours { get; set; }
        public bool NormalConditionsActive { get; set; }
        public bool CommunicationLostActive { get; set; }
        public int CommunicationLostHours { get; set; }
        public bool CommunicationFailureActive { get; set; }
        public int CommunicationFailureMinutes { get; set; }
        public bool DeviceLostActive { get; set; }
        public int DeviceLostHours { get; set; }
    }
}