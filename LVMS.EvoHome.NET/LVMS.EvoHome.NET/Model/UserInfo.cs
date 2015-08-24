namespace LVMS.EvoHome.Model
{
    public class UserInfo
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string Country { get; set; }
        public string Telephone { get; set; }
        public string UserLanguage { get; set; }
        public bool IsActivated { get; set; }
        public int DeviceCount { get; set; }
        public int TenantId { get; set; }
        public string SecurityQuestion1 { get; set; }
        public string SecurityAnswer1 { get; set; }
        public string SecurityQuestion2 { get; set; }
        public string SecurityAnswer2 { get; set; }
        public string SecurityQuestion3 { get; set; }
        public string SecurityAnswer3 { get; set; }
        public bool LatestEulaAccepted { get; set; }
    }
}