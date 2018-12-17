using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GitHub.Service
{
    public interface IGitHubService
    {
        Task<IEnumerable<Entry>> GetFoldersAsync(string folderName);

        Task<string> ReadTextFileAsync(string path);
    }
}
