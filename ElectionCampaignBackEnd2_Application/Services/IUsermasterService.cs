using ElectionCampaignBackEnd2_Application.ModelsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectionCampaignBackEnd2_Application.Services
{
    public interface IUsermasterService
    {
        Task<bool> CreateUser(usermaster UserDetails);

        Task<IEnumerable<usermaster>> GetAllUser();

        Task<usermasterDto> GetUserById(int UserId);

        Task<bool> UpdateUser(usermaster UserDetails);

        Task<bool> DeleteUser(int UserId);
    }
}
