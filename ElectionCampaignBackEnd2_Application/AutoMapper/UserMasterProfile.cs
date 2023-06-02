using AutoMapper;
using ElectionCampaignBackEnd2_Application.ModelsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectionCampaignBackEnd2_Application.AutoMapper
{
    public class UserMasterProfile : Profile
    {
        public UserMasterProfile()
        {   
            CreateMap<usermaster, usermasterDto>().ReverseMap();
        }
    }
}
