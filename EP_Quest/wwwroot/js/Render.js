function loadBabylon(canvasId) {
    var canvas = document.getElementById(canvasId);
    var engine = new BABYLON.Engine(canvas, true);
    var scene = new BABYLON.Scene(engine);

    var camera = new BABYLON.FreeCamera('camera', new BABYLON.Vector3(-0.068, 6.1, 5), scene);
    camera.rotation.y = Math.PI / 3.96 * 4;
    camera.attachControl(canvas, true);
    var light = new BABYLON.HemisphericLight("light", new BABYLON.Vector3(0, 1, 0), scene);
    light.intensity = 0.7;

    BABYLON.SceneLoader.ImportMesh("", "", "https://dl.dropboxusercontent.com/scl/fi/b6b4fdcegimce2z4qb4cf/head.glb?rlkey=4y6ackt4qwd0xzttclmu43t8e&dl=0", scene);
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
    engine.runRenderLoop(() => {
        scene.render();
        console.log(camera.position);
    });

    window.addEventListener("resize", function () {
        engine.resize();
    });
}