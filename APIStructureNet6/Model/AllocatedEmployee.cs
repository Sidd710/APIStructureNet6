using System;
using System.Collections.Generic;

namespace ElectionCampaignBackEnd2.Model
{
    public partial class AllocatedEmployee
    {
        public int? UserId { get; set; }
        public string? Name { get; set; }
        public string? Mobile { get; set; }
        public string? Pan { get; set; }
        public string? AadharCard { get; set; }
        public bool? IsManager { get; set; }
        public int? ConstitutionId { get; set; }
        public int? VillageId { get; set; }
        public int? BoothId { get; set; }
        public bool? IsActive { get; set; }
        public bool? CanChangePassword { get; set; }
        public string? Password { get; set; }
        public bool? IsDelete { get; set; }
        public string? CreatedBy { get; set; }
        public string? CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public string? UpdatedDate { get; set; }
        public int ManagerId { get; set; }
    }
}
