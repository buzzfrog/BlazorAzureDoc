using BlazorVis.Component.Model;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorVis.Component
{
    public static class Javascript
    {
        public static Task LoadVis(string elementId, IEnumerable<Node> nodes, IEnumerable<Edge> edges)
        {
            return JSRuntime.Current.InvokeAsync<object>("vis4blazor.loadVis", elementId, nodes, edges);
        }
    }
}
