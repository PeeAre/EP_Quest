BABYLON = window.BABYLON;
DotNet = window.DotNet;

var canvas1;
var engine;
var scene;

function RenderOnCanvasAsync(canvasId, sceneUrl) {
    InitScene(canvasId);

    window.addEventListener("resize", function () {
        engine.resize();
    });

    LoadScene(scene, sceneUrl);
}
function InitScene(canvasId) {
    try {
        canvas1 = document.getElementById(canvasId);
        engine = new BABYLON.Engine(canvas1, true);
        scene = new BABYLON.Scene(engine);
        scene.clearColor = new BABYLON.Color4(0.8, 0.8, 0.8, 1);
        var light = new BABYLON.HemisphericLight("light", new BABYLON.Vector3(0, 1, 0), scene);
        light.intensity = 0.7;
    } catch (error) {
        console.log(error);
    }
}
async function LoadScene(scene, sceneUrl) {
    await BABYLON.SceneLoader.ImportMeshAsync("", "", sceneUrl, scene)
        .then(() => {
            scene.activeCamera = scene.cameras[0];
            scene.animationGroups.forEach(x => x.stop());
            scene.animationGroups.forEach(x => x.start());
            engine.runRenderLoop(() => {
                scene.render();
            });
        });
    await DotNet.invokeMethodAsync('EP_Quest', 'OnSceneReady');
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