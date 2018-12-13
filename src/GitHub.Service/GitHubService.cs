using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Text;

namespace GitHub.Service
{
    public class GitHubService
    {
        private IGitHubApiFacade gitHubApiFacade;

        public GitHubService(IGitHubApiFacade gitHubApiFacade)
        {
            this.gitHubApiFacade = gitHubApiFacade;
        }

        public async Task<IEnumerable<Entry>> GetFoldersAsync(string folderName)
        {
           
            return Microsoft.JSInterop.Json.Deserialize<List<Entry>>(await gitHubApiFacade.GetContentsAsync("MicrosoftDocs", "azure-docs", folderName))
                .Where(x => x.type == "dir");     
        }

        public async Task<string> ReadTextFileAsync(string path)
        {
            var entry = Microsoft.JSInterop.Json.Deserialize<Entry>(await gitHubApiFacade.GetContentsAsync("MicrosoftDocs", "azure-docs", path));

            return Encoding.UTF8.GetString(Convert.FromBase64String(entry.content));
        }
    }
}
