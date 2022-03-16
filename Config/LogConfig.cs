using KissLog;
using KissLog.AspNetCore;
using KissLog.CloudListeners.Auth;
using KissLog.CloudListeners.RequestLogsListener;
using Microsoft.Extensions.Configuration;

namespace ASP.NET_Identity.Config
{
    public class LogConfig
    {
        public static void ConfigureKissLog(IOptionsBuilder options, IConfiguration configuration)
        {
            KissLogConfiguration.Listeners.Add(new RequestLogsApiListener(new Application(
                configuration["KissLog.OrganizationId"],    //  "eaa1a7a1-6aeb-471e-9c02-4cc35b8fcc26"
                configuration["KissLog.ApplicationId"])     //  "0dc12745-8838-4478-b697-3eb8c314cfc8"
            )
            {
                ApiUrl = configuration["KissLog.ApiUrl"]    //  "https://api.kisslog.net"
            });
        }
    }
}
