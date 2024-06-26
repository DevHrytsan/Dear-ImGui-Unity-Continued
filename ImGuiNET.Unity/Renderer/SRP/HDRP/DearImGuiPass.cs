#if HAS_HDRP
using UnityEngine;
using UnityEngine.Rendering;
using ImGuiNET.Unity;
using UnityEngine.Rendering.HighDefinition;

public class DearImGuiPass : CustomPass
{
    DearImGui[] _dearImGuis;

    // It can be used to configure render targets and their clear state. Also to create temporary render target textures.
    // When empty this render pass will render to the active camera render target.
    // You should never call CommandBuffer.SetRenderTarget. Instead call <c>ConfigureTarget</c> and <c>ConfigureClear</c>.
    // The render pipeline will ensure target setup and clearing happens in an performance manner.
    protected override void Setup(ScriptableRenderContext renderContext, CommandBuffer cmd)
    {
        base.Setup(renderContext, cmd);
        _dearImGuis = GameObject.FindObjectsOfType<DearImGui>();
    }

    protected override void Execute(CustomPassContext ctx)
    {
        // Executed every frame for all the camera inside the pass volume
        if (ctx.hdCamera.camera.cameraType == CameraType.SceneView)
            return;

        foreach (DearImGui dearImGui in _dearImGuis)
        {
            CommandBuffer cb = dearImGui.GetCommandBuffer();

            if (cb == null) return;

            RTHandle colorBuffer = ctx.cameraColorBuffer;

            CoreUtils.SetRenderTarget(cb, colorBuffer, ClearFlag.None);

            ctx.renderContext.ExecuteCommandBuffer(cb);
        }
    }

    protected override void Cleanup()
    {
        
    }
}
#endif