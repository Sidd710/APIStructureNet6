using System;
using System.Collections.Generic;

namespace ElectionCampaignBackEnd2.Model
{
    public partial class LeadDetail
    {
        public int LeadId { get; set; }
        public int EmployeeId { get; set; }
        public int ManagerId { get; set; }
        public int TotalLead { get; set; }
        public int PendingLead { get; set; }
        public string Date { get; set; } = null!;
        public string? CreatedBy { get; set; }
        public string? CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public string? UpdatedDate { get; set; }
        public bool? IsDelete { get; set; }

        public virtual UserDetail Employee { get; set; } = null!;
        public virtual UserDetail Manager { get; set; } = null!;
    }
}
