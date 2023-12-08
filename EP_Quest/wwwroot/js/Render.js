BABYLON = window.BABYLON;
DotNet = window.DotNet;

var canvas;
var engine;
var scene;
var camera;
var glitchPostProcess;
var hemisphericLight;
var pointLight;

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
    scene.clearColor = new BABYLON.Color4(0.1, 0.1, 0.1, 1);
    hemisphericLight = new BABYLON.HemisphericLight("light", new BABYLON.Vector3(0, 1, 0), scene);
    hemisphericLight.intensity = 0.8;
    pointLight = new BABYLON.PointLight("pointLight", new BABYLON.Vector3(-12, 1, 1), scene);
    pointLight.intensity = 0; // Интенсивность света (от 0 до 1)
    pointLight.diffuse = new BABYLON.Color3(1, 1, 1); // Цвет рассеянного света
    pointLight.specular = new BABYLON.Color3(1, 1, 1); // Цвет отраженного света
    pointLight.range = 120; // Максимальная дистанция, на которой свет будет воздействовать

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
    glitchPostProcess = new BABYLON.PostProcess("Glitch", "./shaders/Noise", ["time"], null, 1.0, camera);
    glitchPostProcess.onApply = function (effect) {
        effect.setFloat("time", performance.now() * 0.001);
    };
    SwitchGlitch();
}

function SwitchGlitch() {
    if (camera._postProcesses.length > 0 && camera._postProcesses.find(x => x.name === "Glitch")) {
        camera._postProcesses.length = camera._postProcesses.length === 1 ? 0 : camera._postProcesses.length;
        camera.detachPostProcess(glitchPostProcess);
        hemisphericLight.intensity = 0.8;
        pointLight.intensity = 0;
        scene.clearColor = new BABYLON.Color4(0.5, 0.5, 0.5, 1);
        return;
    }

    camera.attachPostProcess(glitchPostProcess);
    hemisphericLight.intensity = 0.025;
    pointLight.intensity = 1.0;
    scene.clearColor = new BABYLON.Color4(0.1, 0.1, 0.1, 1);
}