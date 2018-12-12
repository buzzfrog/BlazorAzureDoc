using BlazorAzureDoc.Client.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace BlazorAzureDoc.Client.Utils
{
    public class Convert
    {
        public static IEnumerable<TocEntry> FromYamlToObject(string yamlContent)
        {
            var yaml = new YamlStream();
            var reader = new StringReader(yamlContent);

            var deserializer = new DeserializerBuilder()
            .WithNamingConvention(new CamelCaseNamingConvention())
            .Build();

            return deserializer.Deserialize<List<TocEntry>>(reader);
        }
    }
}
