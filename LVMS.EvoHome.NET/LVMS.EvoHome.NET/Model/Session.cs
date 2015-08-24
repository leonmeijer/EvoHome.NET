using System;

namespace LVMS.EvoHome.Model
{
    public class Session
    {
        public Guid SessionId { get; set; }
        public UserInfo UserInfo { get; set; }
        public bool LatestEulaAccepted { get; set; }
    }
}