Shader "TeachShader/Lesson77_RefractBase"
{
    Properties
    {
        _Cubemap("Cubemap",Cube) = "" {}
        _RefractiveRateA("RefractiveRateA",Range(1,2)) = 1
        _RefractiveRateB("RefractiveRateB",Range(1,2)) = 1.3
        _Refraction("Refraction",Range(0,1)) = 1
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
            float _Refraction;
            float _RefractiveRateA;
            float _RefractiveRateB;

            struct v2f
            {
                float4 pos : SV_POSITION;
                float3 worldRefract : TEXCOORD0;
            };

            v2f vert(appdata_base v)
            {
                v2f data;
                data.pos = UnityObjectToClipPos(v.vertex);
                fixed3 worldNormal = normalize(UnityObjectToWorldNormal(v.normal));
                float3 worldVertex = mul(UNITY_MATRIX_M, v.vertex).xyz;
                fixed3 viewDir = UnityWorldSpaceViewDir(worldVertex);
                data.worldRefract = refract(-viewDir, worldNormal, _RefractiveRateA / _RefractiveRateB);
                return data;
            }

            fixed4 frag(v2f data) : SV_Target
            {
                fixed4 cubemapColor = texCUBE(_Cubemap, data.worldRefract);
                cubemapColor *= _Refraction;
                return cubemapColor;
            }
            ENDCG
        }
    }
}