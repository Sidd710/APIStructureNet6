using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ElectionCampaignBackEnd2.Model;
using ElectionCampaignBackEnd2.JwtHelpers;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly JwtSettings jwtSettings;
        ElectionCampaignContext electionCampaignContext = new();
        //  private readonly ElectionCampaignContext _context;
        public TokenController(JwtSettings jwtSettings)
        {
            //this._context = context;
            this.jwtSettings = jwtSettings;
        }

        [HttpPost]
        [AllowAnonymous] 
        public IActionResult GetToken(UserLogin _userData)
        {
            try
            {
                var Token = new UserTokens();
                if (_userData != null && _userData.Mobile != null && _userData.Password != null)
                {
                    var user = GetUser(_userData.Mobile.ToString(), _userData.Password);

                    if (user != null)
                    {
                        Token = JWTHelper.GenTokenkey(new UserTokens()
                        {
                            EmailId = user.AadharCard,
                            GuidId = Guid.NewGuid(),
                            UserName = user.Name,
                            Id = Guid.NewGuid()
                        }, jwtSettings);
                        return Ok(Token);
                    }
                    else
                    {
                        return BadRequest("Invalid credentials");
                    }
                }
                else
                {
                    return BadRequest("wrong password");
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
                throw;
            }
           
        }
        private UserDetail GetUser(string mobile, string password)
        {
            
            UserDetail userDetail = new UserDetail();
            if(!string.IsNullOrEmpty(mobile) && !string.IsNullOrEmpty(password))
            {
                userDetail = electionCampaignContext.UserDetails.FirstOrDefault(u => u.Mobile == mobile && u.Password == password);
                if (userDetail != null)
                {
                    return userDetail;
                }
                else
                {
                    return new UserDetail();
                }
            }
            else
            {
                return new UserDetail();
            }
            
           
        }


        [HttpGet]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult GetList()
        {

            return Ok(electionCampaignContext.UserDetails.ToList());
            
        }
    }
}