using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using StoreExample.Interfaces;

namespace StoreExample.Repositories
{
    public class AppServices : IAppServices
    {
    public AppServices(IHostingEnvironment environment, IConfiguration configuration)
    {
        Environment = environment ?? throw new ArgumentNullException(nameof(environment), "Invalid Entry Environment");
        Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration), "Invalid Entry Configuration");
   
    }
    public IHostingEnvironment Environment { get; set; }
    public IConfiguration Configuration { get; set; }
    }
}