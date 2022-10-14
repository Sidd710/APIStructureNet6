using System;
using System.Collections.Generic;

namespace ElectionCampaignBackEnd2.Model
{
    public partial class UserDetail
    {
        public UserDetail()
        {
            AssignEmployeeAllocatedEmployees = new HashSet<AssignEmployee>();
            AssignEmployeeManagers = new HashSet<AssignEmployee>();
            Attendances = new HashSet<Attendance>();
            EmployeeVillageMappings = new HashSet<EmployeeVillageMapping>();
            LeadDetailEmployees = new HashSet<LeadDetail>();
            LeadDetailManagers = new HashSet<LeadDetail>();
            VoterDetails = new HashSet<VoterDetail>();
        }

        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Mobile { get; set; }
        public string? Pan { get; set; }
        public string? AadharCard { get; set; }
        public int? MangerId { get; set; }
        public bool? IsManager { get; set; }
        public int ConstitutionId { get; set; }
        public int VillageId { get; set; }
        public bool? IsActive { get; set; }
        public bool? CanChangePassword { get; set; }
        public string? Password { get; set; }
        public bool? IsDelete { get; set; }
        public string? CreatedBy { get; set; }
        public string? CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public string? UpdatedDate { get; set; }
        public bool? IsLogin { get; set; }
        public string? IsLoginCurrentDate { get; set; }

        public virtual Constituency Constitution { get; set; } = null!;
        public virtual ICollection<AssignEmployee> AssignEmployeeAllocatedEmployees { get; set; }
        public virtual ICollection<AssignEmployee> AssignEmployeeManagers { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<EmployeeVillageMapping> EmployeeVillageMappings { get; set; }
        public virtual ICollection<LeadDetail> LeadDetailEmployees { get; set; }
        public virtual ICollection<LeadDetail> LeadDetailManagers { get; set; }
        public virtual ICollection<VoterDetail> VoterDetails { get; set; }
    }
}
