using ElectionCampaignBackEnd2_Application.ModelsDtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectionCampaignBackEnd2_Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<usermaster> usermasters { get; }

    }
}
