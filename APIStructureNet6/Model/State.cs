using System;
using System.Collections.Generic;

namespace ElectionCampaignBackEnd2.Model
{
    public partial class State
    {
        public State()
        {
            Constituencies = new HashSet<Constituency>();
        }

        public int StateId { get; set; }
        public string StateName { get; set; } = null!;

        public virtual ICollection<Constituency> Constituencies { get; set; }
    }
}
