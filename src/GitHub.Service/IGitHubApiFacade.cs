using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GitHub.Service
{
    public interface IGitHubApiFacade
    {
        Task<string> GetContentsAsync(string owner, string repository, string path);
    }
}
