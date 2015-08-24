namespace LVMS.EvoHome.Model
{
    public class TimeZone
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public int OffsetMinutes { get; set; }
        public int CurrentOffsetMinutes { get; set; }
        public bool UsingDaylightSavingTime { get; set; }
    }
}