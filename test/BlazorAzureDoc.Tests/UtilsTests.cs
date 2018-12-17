using BlazorAzureDoc.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BlazorAzureDoc.Tests
{
    public class UtilsTests
    {
        [Fact]
        public void Deserialize_yaml_to_object_graph()
        {
            var result = (BlazorAzureDoc.Client.Utils.Convert.FromYamlToObject(yamlContent1)).ToList<TocEntry>();

            Assert.Equal(2, result.Count());
            Assert.Equal(4, result[1].items.Count);
        }

        [Fact]
        public void Create_nodes_and_edges()
        {
            List<TocEntry> entries = new List<TocEntry>()
            {
                new TocEntry()
                {
                    Name = "1",
                    items = new List<TocEntry>()
                    {
                        new TocEntry() { Name = "11" },
                        new TocEntry() { Name = "12" }
                    }
                },
                new TocEntry()
                {
                    Name = "2",
                    items = new List<TocEntry>()
                    {
                        new TocEntry() { Name = "21" },
                        new TocEntry() { Name = "22" },
                        new TocEntry() { Name = "23", items = new List<TocEntry>() {
                            new TocEntry() { Name = "231" }
                            }
                        },
                        new TocEntry() { Name = "24" }
                    }
                },
                new TocEntry()
                {
                    Name = "3",
                    items = new List<TocEntry>()
                    {
                        new TocEntry() { Name = "31" },
                        new TocEntry() { Name = "32" }
                    }
                }
            };

            var result = BlazorAzureDoc.Client.Utils.Convert.FromTocEntryToNodesEdges(entries);

            Assert.Equal(12, result.nodes.Count);
            Assert.Equal(9, result.edges.Count);
        }

        private const string yamlContent1 = @"---
            - name: App Service Documentation
              href: index.yml
            - name: Overview
              items:
                  - name: About Web Apps
                    href: app-service-web-overview.md
                  - name: About App Service on Linux
                    href: containers/app-service-linux-intro.md
                  - name: About App Service Environments
                    href: environment/intro.md
                  - name: Compare hosting options
                    href: choose-web-site-cloud-service-vm.md
...";
    }
}
