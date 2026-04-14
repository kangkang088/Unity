Shader "TeachShader/Lesson86_GlassRefraction"
{
    Properties
    {
        _MainTex("MainTex",2D) = "" {}
        _BumpMap("BumpMap",2D) = "" {}
        _Cubemap("Cubemap",Cube) = "" {}
        _Refraction("Refraction",Range(0,1)) = 1
        _Distortion("Distortion",Range(0,10)) = 0
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
            sampler2D _BumpMap;
            float4 _BumpMap_ST;
            samplerCUBE _Cubemap;
            float _Refraction;
            sampler2D _GrabTexture;
            float _Distortion;

            struct v2f
            {
                float4 pos : SV_POSITION;
                float4 uv : TEXCOORD0;
                float4 grabPos : TEXCOORD1;
                float4 t2w0 : TEXCOORD2;
                float4 t2w1 : TEXCOORD3;
                float4 t2w2 : TEXCOORD4;
            };

            v2f vert(appdata_full v)
            {
                v2f data;
                data.pos = UnityObjectToClipPos(v.vertex);
                data.uv.xy = v.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw;
                data.uv.zw = v.texcoord.xy * _BumpMap_ST.xy + _BumpMap_ST.zw;
                fixed3 worldNormal = normalize(UnityObjectToWorldNormal(v.normal));
                float3 worldVertex = mul(UNITY_MATRIX_M, v.vertex).xyz;
                // fixed3 viewDir = UnityWorldSpaceViewDir(worldVertex);
                // data.worldReflect = reflect(-viewDir, worldNormal);
                data.grabPos = ComputeGrabScreenPos(data.pos);

                float3 worldTangent = UnityObjectToWorldDir(v.tangent);
                float3 worldBinormal = cross(worldNormal, worldTangent) * v.tangent.w;

                data.t2w0.w = worldVertex.x;
                data.t2w1.w = worldVertex.y;
                data.t2w2.w = worldVertex.z;
                data.t2w0.xyz = float3(worldTangent.x, worldBinormal.x, worldNormal.x);
                data.t2w1.xyz = float3(worldTangent.y, worldBinormal.y, worldNormal.y);
                data.t2w2.xyz = float3(worldTangent.z, worldBinormal.z, worldNormal.z);

                return data;
            }

            fixed4 frag(v2f data) : SV_Target
            {
                float4 packedNormal = tex2D(_BumpMap, data.uv.zw);
                float3 tangentNormal = UnpackNormal(packedNormal);
                float3 worldNormal = float3(dot(data.t2w0.xyz, tangentNormal), dot(data.t2w1.xyz, tangentNormal),
                                            dot(data.t2w2.xyz, tangentNormal));

                fixed3 viewDir = normalize(UnityWorldSpaceViewDir(float3(data.t2w0.w, data.t2w1.w, data.t2w2.w)));
                fixed3 worldReflect = reflect(-viewDir, worldNormal);
                fixed4 reflectColor = texCUBE(_Cubemap, worldReflect) * tex2D(_MainTex, data.uv.xy);

                float2 offset = tangentNormal.xy * _Distortion;
                data.grabPos.xy = offset * data.grabPos.z + data.grabPos.xy;

                fixed2 screenUV = data.grabPos.xy / data.grabPos.w;
                fixed4 grabColor = tex2D(_GrabTexture, screenUV);
                fixed4 rateColor = lerp(reflectColor, grabColor, _Refraction);
                return rateColor;
            }
            ENDCG
        }
    }
}