﻿#if HAS_URP
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace ImGuiNET.Unity
{
    public class RenderImGuiFeature : ScriptableRendererFeature
    {
        class ExecuteCommandBufferPass : ScriptableRenderPass
        {
            public CommandBuffer cmd;

            public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
            {
                context.ExecuteCommandBuffer(cmd);
            }
        }

        ExecuteCommandBufferPass _executeCommandBufferPass;

        public CommandBuffer commandBuffer;
        public RenderPassEvent renderPassEvent = RenderPassEvent.AfterRenderingPostProcessing;

        public override void Create()
        {
            _executeCommandBufferPass = new ExecuteCommandBufferPass()
            {
                cmd = commandBuffer,
                renderPassEvent = renderPassEvent,
            };
        }

        public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
        {
            if (commandBuffer == null) return;
            _executeCommandBufferPass.renderPassEvent = renderPassEvent;
            _executeCommandBufferPass.cmd = commandBuffer;
            renderer.EnqueuePass(_executeCommandBufferPass);
        }
    }
}

#endif
