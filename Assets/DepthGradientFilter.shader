Shader "Hidden/DepthGradientFilter"
{
    Properties
    {
        _MainTex("", 2D) = "white" {}
    }

    CGINCLUDE

#include "UnityCG.cginc"

sampler2D _MainTex;
float _Threshold;

void Vertex(float4 vertex : POSITION,
            float2 uv : TEXCOORD0,
            out float4 outVertex : SV_Position,
            out float2 outUV : TEXCOORD0)
{
    outVertex = UnityObjectToClipPos(vertex);
    outUV = uv;
}

float4 Fragment(float4 vertex : SV_Position,
                float2 uv : TEXCOORD0) : SV_Target
{
    return fwidth(tex2D(_MainTex, uv).r) < _Threshold;
}

    ENDCG

    SubShader
    {
        Cull Off ZWrite Off ZTest Always
        Pass
        {
            CGPROGRAM
            #pragma vertex Vertex
            #pragma fragment Fragment
            ENDCG
        }
    }
}
