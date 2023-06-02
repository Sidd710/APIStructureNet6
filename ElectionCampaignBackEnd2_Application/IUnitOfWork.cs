using ElectionCampaignBackEnd2_Application.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectionCampaignBackEnd2_Application
{
    public interface IUnitOfWork : IDisposable
    {
        IUserMasterRepository userMasterRepository { get; }
        int Save();
    }
}
