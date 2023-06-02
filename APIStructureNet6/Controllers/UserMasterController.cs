using ElectionCampaignBackEnd2_Application.ModelsDtos;
using ElectionCampaignBackEnd2_Application.Services;
using ElectionCampaignBackEnd2_Domain.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElectionCampaignBackEnd2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMasterController : ControllerBase
    {
        private readonly IUsermasterService _usermasterService;
        public UserMasterController(IUsermasterService usermasterService)
        {
            _usermasterService = usermasterService;
        }


        [HttpGet]
        public async Task<IActionResult> GetUserList()
        {
            var response = await _usermasterService.GetAllUser();
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetuserById(int userId)
        {
            var response = await _usermasterService.GetUserById(userId);

            if (response != null)
            {
                return Ok(new Response<usermasterDto>(response));
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(usermaster userDetails)
        {
            var isuserCreated = await _usermasterService.CreateUser(userDetails);

            if (isuserCreated)
            {
                return Ok(isuserCreated);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(usermaster userDetails)
        {
            if (userDetails != null)
            {
                var response = await _usermasterService.UpdateUser(userDetails);
                if (response)
                {
                    return Ok(response);
                }
                return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            var response = await _usermasterService.DeleteUser(userId);

            if (response)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest();
            }
        }


    }
}
