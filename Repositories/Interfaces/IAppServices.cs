using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace StoreExample.Interfaces
{
    public class IAppServices
    {
        IHostingEnvironment Environment { get; set; }
        IConfiguration Configuration { get; set; }
    }
}