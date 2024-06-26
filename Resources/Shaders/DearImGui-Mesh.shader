Shader "DearImGui/Mesh"
{
    //Shader for Universal render pipeline
    SubShader
    {
        Tags { "RenderType" = "Transparent" "RenderPipeline" = "UniversalPipeline" "PreviewType" = "Plane" }
        LOD 100

        Lighting Off
        Cull Off ZWrite On ZTest Always
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            Name "DEARIMGUI URP"

            HLSLPROGRAM
            #pragma vertex ImGuiPassVertex
            #pragma fragment ImGuiPassFrag
            #include "Packages/com.devhrytsan.dear-imgui-unity-continued/Resources/Shaders/PassesUniversal.hlsl"
            ENDHLSL
        }
    }

    //Shader for HD render pipeline
	SubShader
	{
		Tags { "RenderType" = "Transparent" "RenderPipeline" = "HDRenderPipeline" "PreviewType" = "Plane" }

        LOD 100

		Lighting Off
		Cull Off ZWrite On ZTest Always
		Blend SrcAlpha OneMinusSrcAlpha

		Pass
		{
			Name "DEARIMGUI HDRP"

			HLSLPROGRAM
			#pragma vertex ImGuiPassVertex
			#pragma fragment ImGuiPassFrag
			#include "Packages/com.devhrytsan.dear-imgui-unity-continued/Resources/Shaders/PassesHD.hlsl"
			ENDHLSL
		}
	}

    //Shader for Built-In rendering
    SubShader
    {
        Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" "PreviewType"="Plane" }
        LOD 100

        Lighting Off
        Cull Off ZWrite On ZTest Always
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            Name "DEARIMGUI BUILTIN"

            CGPROGRAM
            #pragma vertex ImGuiPassVertex
            #pragma fragment ImGuiPassFrag
            #include "Packages/com.devhrytsan.dear-imgui-unity-continued/Resources/Shaders/PassesBuiltin.hlsl"
            ENDCG
        }
    }
}
