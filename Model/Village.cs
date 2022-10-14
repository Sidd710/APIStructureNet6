using System;
using System.Collections.Generic;

namespace ElectionCampaignBackEnd2.Model
{
    public partial class Village
    {
        public Village()
        {
            EmployeeVillageMappings = new HashSet<EmployeeVillageMapping>();
        }

        public int VillageId { get; set; }
        public string VillageName { get; set; } = null!;
        public int? ConstituencyId { get; set; }
        public bool? IsDelete { get; set; }
        public string? CreatedBy { get; set; }
        public string? CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public string? UpdatedDate { get; set; }

        public virtual Constituency? Constituency { get; set; }
        public virtual VoterDetail? VoterDetail { get; set; }
        public virtual ICollection<EmployeeVillageMapping> EmployeeVillageMappings { get; set; }
    }
}
