BABYLON = window.BABYLON;
DotNet = window.DotNet;

var canvas;
var engine;
var scene;
var camera;
var glitchPostProcess;

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
}
async function LoadScene(scenePath) {
    await BABYLON.SceneLoader.ImportMeshAsync("", "", scenePath, scene)
        .then(() => {
            camera = scene.activeCamera = scene.cameras[0];
            camera.minZ = 0.01;
            //scene.animationGroups.forEach(x => x.stop());
            //scene.animationGroups.forEach(x => x.start());
        });
    await DotNet.invokeMethodAsync('EP_Quest', 'OnSceneReady');
}
function AddPostProcess() {
    glitchPostProcess = new BABYLON.PostProcess("Glitch", "./shaders/Noise", ["time"], null, 1.0, camera);
    glitchPostProcess.onApply = function (effect) {
        effect.setFloat("time", performance.now() * 0.001);
    };
    SwitchGlitch();
}

function SwitchGlitch() {
    if (camera._postProcesses.find(x => x.name === "Glitch")) {
        camera._postProcesses.length = camera._postProcesses.length === 1 ? 0 : camera._postProcesses.length;
        camera.detachPostProcess(glitchPostProcess);
        scene.lights.forEach(x => x.intensity = 0.4);
        return;
    }

    //scene.lights.forEach(x => x.intensity = 1.0);
    //scene.lights.find(x => x.name === "Point").range = 3.0;
    //scene.lights.find(x => x.name === "Point.001").range = 4.0;
    //scene.lights.find(x => x.name === 'Sun').intensity = 0;
    camera.attachPostProcess(glitchPostProcess);
}