using BlazorAzureDoc.Client.Models;
using BlazorVis.Component;
using BlazorVis.Component.Model;
using GitHub.Service;
using Microsoft.AspNetCore.Blazor.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAzureDoc.Client.Pages
{
    public class IndexBase : BlazorComponent
    {
        [Inject]
        public IGitHubService gitHubService { get; set; }

        protected override async Task OnAfterRenderAsync()
        {
            var fileContent = await gitHubService.ReadTextFileAsync("articles/app-service/toc.yml");

            var toc = (BlazorAzureDoc.Client.Utils.Convert.FromYamlToObject(fileContent)).ToList<TocEntry>();

            var vis = BlazorAzureDoc.Client.Utils.Convert.FromTocEntryToNodesEdges(toc);


            await Javascript.LoadVis("vis-network", vis.nodes, vis.edges);
        }
    }
}
