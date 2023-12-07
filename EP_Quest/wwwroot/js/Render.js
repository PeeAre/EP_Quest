BABYLON = window.BABYLON;
DotNet = window.DotNet;

var canvas;
var engine;
var scene;
var camera;

async function RenderOnCanvasAsync(canvasId, scenePath) {
    InitScene(canvasId);
    await LoadScene(scenePath);
    AddPostProcess();

    engine.runRenderLoop(function () {
        scene.render();
    });
    window.addEventListener("resize", function () {
        engine.resize();
    });
}

function InitScene(canvasId) {
    canvas = document.getElementById(canvasId);
    engine = new BABYLON.Engine(canvas, true);
    scene = new BABYLON.Scene(engine);
    var light = new BABYLON.HemisphericLight("light", new BABYLON.Vector3(0, 1, 0), scene);
    light.intensity = 0.7;
}
async function LoadScene(scenePath) {
    await BABYLON.SceneLoader.ImportMeshAsync("", "", scenePath, scene)
        .then(() => {
            camera = scene.activeCamera = scene.cameras[0];
            camera.minZ = 0.01;
            scene.animationGroups.forEach(x => x.stop());
            scene.animationGroups.forEach(x => x.start());
        });
    await DotNet.invokeMethodAsync('EP_Quest', 'OnSceneReady');
}
function AddPostProcess() {
    var glitchMesh = scene.meshes.find(x => x.name === "handLOW");
    console.log(glitchMesh);
}