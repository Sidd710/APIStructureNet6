using System.ComponentModel.DataAnnotations;

namespace ElectionCampaignBackEnd2.Model
{
    public class UserLogin
    {
        [Required]
        public string? Mobile { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
