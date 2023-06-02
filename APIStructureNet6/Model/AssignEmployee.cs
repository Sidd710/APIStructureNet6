using System;
using System.Collections.Generic;

namespace ElectionCampaignBackEnd2.Model
{
    public partial class AssignEmployee
    {
        public int EmployeeAssignId { get; set; }
        public int ManagerId { get; set; }
        public int AllocatedEmployeeId { get; set; }

        public virtual UserDetail AllocatedEmployee { get; set; } = null!;
        public virtual UserDetail Manager { get; set; } = null!;
    }
}
