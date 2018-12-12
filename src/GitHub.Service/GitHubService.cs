using Octokit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace GitHub.Service
{
    public class GitHubService
    {
        private IGitHubClient gitHubClient;

        public GitHubService(IGitHubClient gitHubClient)
        {
            this.gitHubClient = gitHubClient;
        }

        public async Task<IEnumerable<RepositoryContent>> GetFoldersAsync(string folderName)
        {
         return (await gitHubClient.Repository.Content.GetAllContents("MicrosoftDocs", "azure-docs", folderName))
                .Where(c => c.Type == ContentType.Dir);
        }

        public async Task<string> ReadTextFileAsync(string path)
        {
            return (await gitHubClient.Repository.Content.GetAllContents("MicrosoftDocs", "azure-docs", path)).First().Content;
        }
    }
}
