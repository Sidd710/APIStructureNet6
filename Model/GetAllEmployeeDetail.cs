using System;
using System.Collections.Generic;

namespace ElectionCampaignBackEnd2.Model
{
    public partial class GetAllEmployeeDetail
    {
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Mobile { get; set; }
        public string? Pan { get; set; }
        public string? AadharCard { get; set; }
        public bool? IsManager { get; set; }
        public int ConstitutionId { get; set; }
        public string ConstituencyName { get; set; } = null!;
        public bool? IsDelete { get; set; }
        public int? MangerId { get; set; }
        public string? VillageName { get; set; }
        public string? VillageId { get; set; }
        public bool? IsActive { get; set; }
        public string? Password { get; set; }
    }
}
