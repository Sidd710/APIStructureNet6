using ElectionCampaignBackEnd2_Application.AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ElectionCampaignBackEnd2
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddWebApiServices(this IServiceCollection services)
        {
            //services.AddAutoMapper(typeof(UserMasterProfile));
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }
    }
}
