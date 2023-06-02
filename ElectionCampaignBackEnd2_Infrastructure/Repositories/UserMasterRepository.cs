using ElectionCampaignBackEnd2_Application.Interfaces;
using ElectionCampaignBackEnd2_Application.ModelsDtos;
using ElectionCampaignBackEnd2_Application.Repository;
using ElectionCampaignBackEnd2_Infrastructure.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectionCampaignBackEnd2_Infrastructure.Repositories
{
    public class UserMasterRepository : GenericRepository<usermaster>, IUserMasterRepository
    {
        public UserMasterRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
