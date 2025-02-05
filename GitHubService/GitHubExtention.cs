using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubService
{
    public static class GitHubExtention
    {
        public static void AddGitHubIntegration(this IServiceCollection services, Action<GitHubCredentials> configurations)
        {
            services.Configure(configurations);
            services.AddScoped<IGitHubService, GitHubService>();
        }
    }
}
