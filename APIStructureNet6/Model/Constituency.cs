using System;
using System.Collections.Generic;

namespace ElectionCampaignBackEnd2.Model
{
    public partial class Constituency
    {
        public Constituency()
        {
            UserDetails = new HashSet<UserDetail>();
            Villages = new HashSet<Village>();
            VoterDetails = new HashSet<VoterDetail>();
        }

        public int ConstituencyId { get; set; }
        public string ConstituencyName { get; set; } = null!;
        public int StateId { get; set; }
        public bool? IsDelete { get; set; }
        public string? CreatedBy { get; set; }
        public string? CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public string? UpdatedDate { get; set; }

        public virtual State State { get; set; } = null!;
        public virtual ICollection<UserDetail> UserDetails { get; set; }
        public virtual ICollection<Village> Villages { get; set; }
        public virtual ICollection<VoterDetail> VoterDetails { get; set; }
    }
}
