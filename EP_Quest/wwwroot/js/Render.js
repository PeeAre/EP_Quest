BABYLON = window.BABYLON;
DotNet = window.DotNet;

var canvas;
var engine;
var scene;
var camera;
var light;

async function RenderOnCanvasAsync(canvasId, sceneUrl) {
    InitScene(canvasId);
    var loadMeshTask = LoadMesh(scene, sceneUrl);
    

    return await loadMeshTask;
}
function InitScene(canvasId) {
    canvas = document.getElementById(canvasId);
    engine = new BABYLON.Engine(canvas, true);
    scene = new BABYLON.Scene(engine);
    
    light = new BABYLON.HemisphericLight("light", new BABYLON.Vector3(0, 1, 0), scene);
    light.intensity = 0.7;
}
async function LoadMesh(scene, sceneUrl) {
    return await BABYLON.SceneLoader.ImportMeshAsync("", "", sceneUrl, scene)
        .then(() => {
            camera = scene.getCameraByName("Camera");
            camera.attachControl(canvas, true);
            scene.activeCamera = camera;
            AddPostProcess();
            await DotNet.invokeMethodAsync('EP_Quest', 'OnSceneReady');

            engine.runRenderLoop(() => {
                scene.render();
            });
            window.addEventListener("resize", function () {
                engine.resize();
            });
        });
}
function AddPostProcess() {
    var postProcess = new BABYLON.PostProcess("Glitch", "./shaders/Noise", ["time"], null, 1.0, camera);
    postProcess.onApply = function (effect) {
        effect.setFloat("time", performance.now() * 0.001);
    };
    var pipeline = new BABYLON.DefaultRenderingPipeline("glitchPipeline", true, scene, [camera]);
    pipeline.imageProcessingEnabled = false;
    postProcess.onError = function (effect, errors) {
        console.error("Shader compilation errors: ", errors);
    };
    scene.postProcessRenderPipelineManager.attachCamerasToRenderPipeline("glitchPipeline", camera);
}