Shader "TeachShader/Lesson85_GlassBase"
{
    Properties
    {
        _MainTex("MainTex",2D) = "" {}
        _Cubemap("Cubemap",Cube) = "" {}
        _Refraction("Refraction",Range(0,1)) = 1
    }
    SubShader
    {
        Tags
        {
            "RenderType"="Opaque"
            "Queue"="Transparent"
        }

        GrabPass {}

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
            #include "Lighting.cginc"

            sampler2D _MainTex;
            float4 _MainTex_ST;
            samplerCUBE _Cubemap;
            float _Refraction;
            sampler2D _GrabTexture;

            struct v2f
            {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
                float3 worldReflect : TEXCOORD1;
                float4 grabPos : TEXCOORD2;
            };

            v2f vert(appdata_base v)
            {
                v2f data;
                data.pos = UnityObjectToClipPos(v.vertex);
                data.uv = v.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw;
                fixed3 worldNormal = normalize(UnityObjectToWorldNormal(v.normal));
                float3 worldVertex = mul(UNITY_MATRIX_M, v.vertex).xyz;
                fixed3 viewDir = UnityWorldSpaceViewDir(worldVertex);
                data.worldReflect = reflect(-viewDir, worldNormal);
                data.grabPos = ComputeGrabScreenPos(data.pos);
                return data;
            }

            fixed4 frag(v2f data) : SV_Target
            {
                fixed4 reflectColor = texCUBE(_Cubemap, data.worldReflect) * tex2D(_MainTex, data.uv);
                float2 offset = 1 - _Refraction;
                data.grabPos.xy -= offset / 10;
                fixed2 screenUV = data.grabPos.xy / data.grabPos.w;
                fixed4 grabColor = tex2D(_GrabTexture, screenUV);
                fixed4 rateColor = lerp(reflectColor, grabColor, _Refraction);
                return rateColor;
            }
            ENDCG
        }
    }
}