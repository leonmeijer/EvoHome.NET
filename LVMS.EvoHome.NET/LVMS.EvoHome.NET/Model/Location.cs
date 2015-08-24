using System.Collections.Generic;

namespace LVMS.EvoHome.Model
{
    public class Location
    {
        public int LocationId { get; set; }
        public string Name { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Zipcode { get; set; }
        public string Type { get; set; }
        public bool HasStation { get; set; }
        public List<Device> Devices { get; set; }
        public List<object> OneTouchButtons { get; set; }
        public bool DaylightSavingTimeEnabled { get; set; }
        public TimeZone TimeZone { get; set; }
        public bool OneTouchActionsSuspended { get; set; }
        public List<EvoTouchSystemsStatus> EvoTouchSystemsStatus { get; set; }
        public bool IsLocationOwner { get; set; }
        public int LocationOwnerId { get; set; }
        public string LocationOwnerName { get; set; }
        public string LocationOwnerUserName { get; set; }
        public bool CanSearchForContractors { get; set; }
    }
}