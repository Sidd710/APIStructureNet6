using System;
using System.Collections.Generic;

namespace ElectionCampaignBackEnd2.Model
{
    public partial class GetAssignedEmployeeList
    {
        public int? ManagerId { get; set; }
        public string? ManagerName { get; set; }
        public string? Name { get; set; }
        public int? UserId { get; set; }
    }
}
