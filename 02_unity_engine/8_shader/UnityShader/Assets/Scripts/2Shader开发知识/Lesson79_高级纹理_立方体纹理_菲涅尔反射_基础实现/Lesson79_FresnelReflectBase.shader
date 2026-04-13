Shader "TeachShader/Lesson79_FresnelReflectBase"
{
    Properties
    {
        _Cubemap("Cubemap",Cube) = "" {}
        _FresnelScale("FresnelScale",Range(0,1)) = 1
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
            #include "Lighting.cginc"

            samplerCUBE _Cubemap;
            float _FresnelScale;

            struct v2f
            {
                float4 pos : SV_POSITION;
                float3 worldReflect : TEXCOORD0;
                float3 worldNormal : NORMAL;
                float3 worldViewDir : TEXCOORD1;
            };

            v2f vert(appdata_base v)
            {
                v2f data;
                data.pos = UnityObjectToClipPos(v.vertex);
                data.worldNormal = normalize(UnityObjectToWorldNormal(v.normal));
                float3 worldVertex = mul(UNITY_MATRIX_M, v.vertex).xyz;
                data.worldViewDir = normalize(UnityWorldSpaceViewDir(worldVertex));
                data.worldReflect = reflect(-data.worldViewDir, data.worldNormal);
                return data;
            }

            fixed4 frag(v2f data) : SV_Target
            {
                fixed4 cubemapColor = texCUBE(_Cubemap, data.worldReflect);

                float fresnelRate = _FresnelScale + (1 - _FresnelScale) * pow(
                    1 - dot(data.worldViewDir, data.worldNormal), 5);

                cubemapColor *= fresnelRate;
                return cubemapColor;
            }
            ENDCG
        }
    }
}