using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nop.Core.Infrastructure;
using Nop.Web.Framework.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Web.Framework.Infrastructure
{
    public class NopMvcStartup : INopStartup
    {
        public int Order => 1000;

        /// <summary>
        ///  Add and configure  Service
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddNopMvc();
        }
        /// <summary>
        /// Configure the using of added middleware
        /// </summary>
        /// <param name="application"></param>
        public void Configure(IApplicationBuilder application)
        {
            application.UseNopMvc();
        }


    }
}
