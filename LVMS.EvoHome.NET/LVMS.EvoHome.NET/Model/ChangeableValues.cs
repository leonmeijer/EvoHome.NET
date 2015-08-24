using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVMS.EvoHome.Model
{
    public class ChangeableValues
    {
        public string Mode { get; set; }
        public HeatSetpoint HeatSetpoint { get; set; }
        public int VacationHoldDays { get; set; }
    }

}
