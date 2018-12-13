using GitHub.Service;
using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorAzureDoc.Client
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            //services.Configure<ProgramOptions>(Configuration);
            services.AddTransient<IGitHubApiFacade, GitHubApiFacade>();
            services.AddSingleton<GitHubService>();
        }

        public void Configure(IBlazorApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
