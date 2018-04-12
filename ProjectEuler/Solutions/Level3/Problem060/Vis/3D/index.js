const Graph = ForceGraph3D()
    (document.getElementById("3d-graph"));

const stepper = new Stepper();

Graph
    //.cooldownTicks(200)
    //.nodeLabel('id')
    //.nodeAutoColorBy('group')
    //.forceEngine('ngraph')
    .graphData({
        links: [],
        nodes: []
    }).nodeAutoColorBy('id')
    .nodeThreeObject(node => {
        const sprite = new SpriteText(node.id);
        sprite.color = node.color;
        sprite.textHeight = 8;
        return sprite;
    });

var timer = {};
timer.interval = setInterval((timer) => {
    const { nodes, links } = Graph.graphData();
    while (!stepper.step(nodes, links));
    Graph.graphData({ nodes, links });

    if (nodes.length > 30) clearInterval(timer.interval);
}, 1000, timer);