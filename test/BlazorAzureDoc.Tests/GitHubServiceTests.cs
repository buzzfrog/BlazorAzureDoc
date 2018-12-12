using GitHub.Service;
using Moq;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BlazorAzureDoc.Tests
{
    public class GitHubServiceTests
    {
        [Fact]
        public async Task Getting_folder_should_return_two_items()
        {
            var folderName = "folder";

            var gitHubClient = Mock.Of<IGitHubClient>();
            Mock.Get(gitHubClient).Setup(c =>
                c.Repository.Content.GetAllContents(It.IsAny<string>(), It.IsAny<string>(), folderName)).ReturnsAsync(new List<RepositoryContent>()
                {
                    Mock.Of<RepositoryContent>(r => r.Type == ContentType.Dir),
                    Mock.Of<RepositoryContent>(r => r.Type == ContentType.Dir),
                    Mock.Of<RepositoryContent>(r => r.Type == ContentType.File)
                });

            var service = new GitHubService(gitHubClient);
            var folders = await service.GetFoldersAsync(folderName);

            Mock.Get(gitHubClient).Verify(m => m.Repository.Content.GetAllContents(It.IsAny<string>(), It.IsAny<string>(), folderName));
            Assert.Equal(2, folders.Count());
        }

        [Fact]
        public async Task ReadFile_should_return_one_file_with_content()
        {
            var path = "";
            var fileContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit";
            var fileContentBase64 = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(fileContent));

            var gitHubClient = Mock.Of<IGitHubClient>();
            Mock.Get(gitHubClient).Setup(c =>
                c.Repository.Content.GetAllContents(It.IsAny<string>(), It.IsAny<string>(), path)).ReturnsAsync(new List<RepositoryContent>()
                {
                    new RepositoryContent("", "", "", 100, ContentType.File, "", "", "", "", "", fileContentBase64, "", "")
                });

            var service = new GitHubService(gitHubClient);
            var result = await service.ReadTextFileAsync(path);

            Assert.Equal(fileContent, result);
        }
    }
}
