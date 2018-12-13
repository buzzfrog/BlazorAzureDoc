using GitHub.Service;
using Moq;
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

            var gitHubApiFacade = Mock.Of<IGitHubApiFacade>();
            Mock.Get(gitHubApiFacade).Setup(m => m.GetContentsAsync(It.IsAny<string>(), It.IsAny<string>(), folderName))
                .ReturnsAsync(jsonResponse1);

            var service = new GitHubService(gitHubApiFacade);
            var folders = await service.GetFoldersAsync(folderName);

            Mock.Get(gitHubApiFacade).Verify(m => m.GetContentsAsync(It.IsAny<string>(), It.IsAny<string>(), folderName));
            Assert.Equal(2, folders.Count());
        }

        [Fact]
        public async Task ReadFile_should_return_one_file_with_content()
        {
            var path = "README.md";

            var gitHubApiFacade = Mock.Of<IGitHubApiFacade>();
            Mock.Get(gitHubApiFacade).Setup(m => m.GetContentsAsync(It.IsAny<string>(), It.IsAny<string>(), path))
                .ReturnsAsync(jsonResponse2);

            var service = new GitHubService(gitHubApiFacade);
            var result = await service.ReadTextFileAsync(path);

            Mock.Get(gitHubApiFacade).Verify(m => m.GetContentsAsync(It.IsAny<string>(), It.IsAny<string>(), path));
            Assert.Contains("Test", result);

        }

        private const string jsonResponse1 = @"[
    {
        ""name"": ""active-directory-b2c"",
        ""path"": ""articles//active-directory-b2c"",
        ""sha"": ""bae8832a536eeb72987f9a570bfc749da70ac78f"",
        ""size"": 0,
        ""url"": ""https:////api.github.com//repos//MicrosoftDocs//azure-docs//contents//articles//active-directory-b2c?ref=master"",
        ""html_url"": ""https:////github.com//MicrosoftDocs//azure-docs//tree//master//articles//active-directory-b2c"",
        ""git_url"": ""https:////api.github.com//repos//MicrosoftDocs//azure-docs//git//trees//bae8832a536eeb72987f9a570bfc749da70ac78f"",
        ""download_url"": null,
        ""type"": ""dir"",
        ""_links"": {
            ""self"": ""https:////api.github.com//repos//MicrosoftDocs//azure-docs//contents//articles//active-directory-b2c?ref=master"",
            ""git"": ""https:////api.github.com//repos//MicrosoftDocs//azure-docs//git//trees//bae8832a536eeb72987f9a570bfc749da70ac78f"",
            ""html"": ""https:////github.com//MicrosoftDocs//azure-docs//tree//master//articles//active-directory-b2c""
        }
    },
    {
        ""name"": ""active-directory-domain-services"",
        ""path"": ""articles//active-directory-domain-services"",
        ""sha"": ""1fb24b4ab630dff1ece22b0ea15294071d36c436"",
        ""size"": 0,
        ""url"": ""https:////api.github.com//repos//MicrosoftDocs//azure-docs//contents//articles//active-directory-domain-services?ref=master"",
        ""html_url"": ""https:////github.com//MicrosoftDocs//azure-docs//tree//master//articles//active-directory-domain-services"",
        ""git_url"": ""https:////api.github.com//repos//MicrosoftDocs//azure-docs//git//trees//1fb24b4ab630dff1ece22b0ea15294071d36c436"",
        ""download_url"": null,
        ""type"": ""dir"",
        ""_links"": {
            ""self"": ""https:////api.github.com//repos//MicrosoftDocs//azure-docs//contents//articles//active-directory-domain-services?ref=master"",
            ""git"": ""https:////api.github.com//repos//MicrosoftDocs//azure-docs//git//trees//1fb24b4ab630dff1ece22b0ea15294071d36c436"",
            ""html"": ""https:////github.com//MicrosoftDocs//azure-docs//tree//master//articles//active-directory-domain-services""
        }
    }
]";

        private const string jsonResponse2 = @"{
    ""name"": ""README.md"",
    ""path"": ""README.md"",
    ""sha"": ""90b5dbdef09cc3746df3ef02f5216cdfe8f77a08"",
    ""size"": 12,
    ""url"": ""https:////api.github.com//repos//buzzfrog//ap-1//contents//README.md?ref=master"",
    ""html_url"": ""https:////github.com//buzzfrog//ap-1//blob//master//README.md"",
    ""git_url"": ""https:////api.github.com//repos//buzzfrog//ap-1//git//blobs//90b5dbdef09cc3746df3ef02f5216cdfe8f77a08"",
    ""download_url"": ""https:////raw.githubusercontent.com//buzzfrog//ap-1//master//README.md"",
    ""type"": ""file"",
    ""content"": ""IyBhcC0xClRlc3QK\n"",
    ""encoding"": ""base64"",
    ""_links"": {
        ""self"": ""https:////api.github.com//repos//buzzfrog//ap-1//contents//README.md?ref=master"",
        ""git"": ""https:////api.github.com//repos//buzzfrog//ap-1//git//blobs//90b5dbdef09cc3746df3ef02f5216cdfe8f77a08"",
        ""html"": ""https:////github.com//buzzfrog//ap-1//blob//master//README.md""
    }
}";
    }
}
