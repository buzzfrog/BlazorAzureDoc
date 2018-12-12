using System;
using System.Linq;
using Xunit;

namespace BlazorAzureDoc.Tests
{
    public class UtilsTests
    {
        [Fact]
        public void Deserialize_yaml_to_object_graph()
        {
            var result = BlazorAzureDoc.Client.Utils.Convert.FromYamlToObject(yamlContent1);

            Assert.Equal(2, result.Count());
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
