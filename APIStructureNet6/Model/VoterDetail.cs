using System;
using System.Collections.Generic;

namespace ElectionCampaignBackEnd2.Model
{
    public partial class VoterDetail
    {
        public int VoterId { get; set; }
        public int? ManagerId { get; set; }
        public int EmployeeId { get; set; }
        public string? Gpslocation { get; set; }
        public string? DateTime { get; set; }
        public int ConstituencyId { get; set; }
        public int? VillageId { get; set; }
        public string VoterName { get; set; } = null!;
        public int PhoneNumber { get; set; }
        public int? WhatsappNo { get; set; }
        public bool? HeadofFamily { get; set; }
        public string? NameofHeadofFamily { get; set; }
        public int? WhatsappNoofHof { get; set; }
        public string? NoofVotersInHh { get; set; }
        public string? LastVoted { get; set; }
        public string? ProxyQuestions { get; set; }
        public string? NegNeuPositive { get; set; }
        public string? Influencer { get; set; }
        public string? WhoisanInfluencer { get; set; }
        public string? SubscribetoWhatsappGroup { get; set; }
        public string? VoterIdGenerator { get; set; }
        public bool? IsDelete { get; set; }
        public string? CreatedBy { get; set; }
        public string? CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public string? UpdatedDate { get; set; }

        public virtual Constituency Constituency { get; set; } = null!;
        public virtual UserDetail Employee { get; set; } = null!;
        public virtual Village Voter { get; set; } = null!;
    }
}
