using AutoMapper;
using ElectionCampaignBackEnd2_Application;
using ElectionCampaignBackEnd2_Application.ModelsDtos;
using ElectionCampaignBackEnd2_Application.Services;
using ElectionCampaignBackEnd2_Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectionCampaignBackEnd2_Infrastructure.Services
{
    public class UsermasterService : IUsermasterService
    {
        #nullable disable

        public IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UsermasterService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<bool> CreateUser(usermaster UserDetails)
        {
            if (UserDetails != null)
            {
                await _unitOfWork.userMasterRepository.Add(UserDetails);

                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteUser(int UserId)
        {
            if (UserId > 0)
            {
                var UserDetails = await _unitOfWork.userMasterRepository.GetById(UserId);
                if (UserDetails != null)
                {
                    _unitOfWork.userMasterRepository.Delete(UserDetails);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<usermaster>> GetAllUser()
        {
            var userDetailsList = await _unitOfWork.userMasterRepository.GetAll();
            return userDetailsList;
        }

        public async Task<usermasterDto> GetUserById(int UserId)
        {
            if (UserId > 0)
            {
                var userDetails = await _unitOfWork.userMasterRepository.GetById(UserId);


                if (userDetails != null)
                {
                    #region comment code
                    //DateTime dateNoe = ConvertExtensions.GetTimeInEasternStandardTime((DateTime)userDetails.DateCreated);
                    //// DateTime modifyDate = ConvertExtensions.GetTimeInEasternStandardTime((DateTime)userDetails.DateModified);
                    //var respone = new usermaster
                    //{
                    //    name = userDetails.name,
                    //    email = userDetails.email,
                    //    password = userDetails.password,
                    //    phone = userDetails.phone,
                    //    city = userDetails.city,
                    //    state = userDetails.state,
                    //    zipcode = userDetails.zipcode,
                    //    country = userDetails.country,
                    //    citycode = userDetails.citycode,
                    //    countrycode = userDetails.countrycode,
                    //    phonecode = userDetails.phonecode,
                    //    CreatedBy = userDetails.CreatedBy,
                    //    DateCreated = dateNoe
                    //};
                    #endregion

                    return this._mapper.Map<usermasterDto>(userDetails);

                    //return userDetails;
                }
            }
            return null;
        }

        public async Task<bool> UpdateUser(usermaster UserDetails)
        {
            if (UserDetails != null)
            {
                var usermaster = await _unitOfWork.userMasterRepository.GetById(UserDetails.id);
                if (usermaster != null)
                {
                    usermaster.name = UserDetails.name;
                    usermaster.email = UserDetails.email;
                    usermaster.password = UserDetails.password;
                    usermaster.phone = UserDetails.phone;
                    usermaster.city = UserDetails.city;
                    usermaster.state = UserDetails.state;
                    usermaster.zipcode = UserDetails.zipcode;
                    usermaster.country = UserDetails.country;
                    usermaster.citycode = UserDetails.citycode;
                    usermaster.countrycode = UserDetails.countrycode;
                    usermaster.phonecode = UserDetails.phonecode;

                    _unitOfWork.userMasterRepository.Update(usermaster);

                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }
    }

}
