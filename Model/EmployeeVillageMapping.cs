using System;
using System.Collections.Generic;

namespace ElectionCampaignBackEnd2.Model
{
    public partial class EmployeeVillageMapping
    {
        public int EmployeeVillageMappingId { get; set; }
        public int EmployeeId { get; set; }
        public int VillageId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual UserDetail Employee { get; set; } = null!;
        public virtual Village Village { get; set; } = null!;
    }
}
