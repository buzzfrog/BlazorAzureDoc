using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GitHub.Service
{
    public class GitHubApiFacade : IGitHubApiFacade
    {
        private HttpClient httpClient;

        public GitHubApiFacade(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<string> GetContentsAsync(string owner, string repository, string path)
        {
            Console.WriteLine("Start - getting content from github");

            try
            {
                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri($"https://api.github.com/repos/{owner}/{repository}/contents/{path}"),
                    Method = HttpMethod.Get,

                };
                request.Headers.Add("user-agent", "BlazorToDoc");

                var response = await httpClient.SendAsync(request);

                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}
