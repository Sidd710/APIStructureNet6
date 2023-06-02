using System;
using System.Collections.Generic;

namespace ElectionCampaignBackEnd2.Model
{
    public partial class GetAssignedEmployeeDetail
    {
        public string? EmployeeName { get; set; }
        public int? EmpployeeId { get; set; }
        public string? ManagerName { get; set; }
        public int? ManagerId { get; set; }
    }
}
