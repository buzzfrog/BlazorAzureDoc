using BlazorAzureDoc.Client.Models;
using BlazorVis.Component.Model;
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

        public static (List<Node> nodes, List<Edge> edges) FromTocEntryToNodesEdges(List<TocEntry> entries)
        {
            List<Node> nodes = new List<Node>();
            List<Edge> edges = new List<Edge>();

            foreach (var entry in entries)
            {
                entry._id = getId();
                nodes.Add(new Node() { id = entry._id, label = entry.Name });
                processNode(entry, nodes, edges);
            }

            return (nodes, edges);
        }

        private static void processNode(TocEntry entry, List<Node> nodes, List<Edge> edges)
        {
            if (entry.items == null) return;

            foreach (var e in entry.items)
            {
                e._id = getId();
                nodes.Add(new Node() { id = e._id, label = e.Name });
                edges.Add(new Edge() { from = entry._id, to = e._id });
                processNode(e, nodes, edges);
            }
        }

        private static int getId()
        {
            return BitConverter.ToInt32(Guid.NewGuid().ToByteArray(), 0);
        }

    }
}
