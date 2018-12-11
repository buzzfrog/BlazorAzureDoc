window.vis4blazor = {
    loadVis: function (elementId, nodes, edges) {
        var visNodes = new vis.DataSet();
        var visEdges = new vis.DataSet();

        nodes.forEach(function (node) {
            visNodes.add({id:node.id, label:node.label})
        });

        edges.forEach(function (edge) {
            visEdges.add({ from: edge.from, to: edge.to })
        });

        var nodes = new vis.DataSet([
            { id: 1, label: 'Node 1' },
            { id: 2, label: 'Node 2' },
            { id: 3, label: 'Node 3' },
            { id: 4, label: 'Node 4' },
            { id: 5, label: 'Node 5' }
        ]);

        // create an array with edges
        var edges = new vis.DataSet([
            { from: 1, to: 3 },
            { from: 1, to: 2 },
            { from: 2, to: 4 },
            { from: 2, to: 5 },
            { from: 3, to: 3 }
        ]);

        // create a network
        var container = document.getElementById(elementId);
        var data = {
            nodes: visNodes,
            edges: visEdges
        };
        var options = {};
        var network = new vis.Network(container, data, options);
    }
}