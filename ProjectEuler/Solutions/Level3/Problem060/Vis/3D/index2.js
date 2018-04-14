const Graph = ForceGraph3D()
    (document.getElementById("3d-graph"));

const stepper = new Stepper();
const graph = {
    links: [],
    nodes: []
};

while (graph.nodes.length < 100) {
    stepper.step(graph.nodes, graph.links);
}

console.log(graph);

Graph
    .graphData(graph)
    .nodeAutoColorBy('id')
    .nodeThreeObject(node => {
        const sprite = new SpriteText(node.id);
        sprite.color = node.color;
        sprite.textHeight = 8;
        return sprite;
    })
    .linkColor('#fff')
    .linkOpacity(1);

Graph.d3Force('charge').strength(-50);