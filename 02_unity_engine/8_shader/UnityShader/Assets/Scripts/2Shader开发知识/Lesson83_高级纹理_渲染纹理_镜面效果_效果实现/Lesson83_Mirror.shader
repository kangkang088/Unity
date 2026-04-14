Shader "TeachShader/Lesson83_Mirror"
{
    Properties
    {
        _MainTex("MainTex",2D) = "white" {}

    }

    SubShader
    {
        Tags
        {
            "RenderType"="Opaque"
            "Queue"="Geometry"
        }

        Pass
        {
            Tags
            {
                "LightMode"="ForwardBase"
            }

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float4 _MainTex_ST;

            struct v2f
            {
                float4 pos : SV_POSITION;
                fixed2 uv : TEXCOORD0;
            };

            v2f vert(appdata_base v)
            {
                v2f data;
                data.pos = UnityObjectToClipPos(v.vertex);
                data.uv = v.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw;
                data.uv.x = 1 - data.uv.x;
                return data;
            }

            fixed4 frag(v2f data) : SV_Target
            {
                float4 mainColor = tex2D(_MainTex, data.uv);
                return mainColor;
            }
            ENDCG
        }
    }

    Fallback "Legacy Shaders/Diffuse"
}