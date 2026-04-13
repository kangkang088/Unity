Shader "TeachShader/Lesson78_Refraction"
{
    Properties
    {
        _Cubemap("Cubemap",Cube) = "" {}
        _Color("Color",Color) = (1,1,1,1)
        _RefractColor("RefractColor",Color) = (1,1,1,1)
        _RefractiveRate("RefractiveRateA",Range(0,1)) = 0.5
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
            #pragma multi_compile_fwdbase

            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "AutoLight.cginc"

            samplerCUBE _Cubemap;
            float _Refraction;
            float _RefractiveRate;
            fixed4 _Color;
            fixed4 _RefractColor;

            struct v2f
            {
                float4 pos : SV_POSITION;
                float3 worldRefract : TEXCOORD0;
                float3 worldVertex : TEXCOORD1;
                float3 worldNormal : NORMAL;
                SHADOW_COORDS(2)
            };

            v2f vert(appdata_base v)
            {
                v2f data;
                data.pos = UnityObjectToClipPos(v.vertex);
                data.worldNormal = normalize(UnityObjectToWorldNormal(v.normal));
                data.worldVertex = mul(UNITY_MATRIX_M, v.vertex).xyz;
                fixed3 viewDir = normalize(UnityWorldSpaceViewDir(data.worldVertex));
                data.worldRefract = refract(-viewDir, data.worldNormal, _RefractiveRate);
                TRANSFER_SHADOW(data);
                return data;
            }

            fixed4 frag(v2f data) : SV_Target
            {
                fixed4 cubemapColor = texCUBE(_Cubemap, data.worldRefract) * _RefractColor;
                fixed3 diffuse = _LightColor0.rgb * _Color.rgb * max(
                    0, dot(data.worldNormal, normalize(UnityWorldSpaceLightDir(data.worldVertex))));

                fixed3 rateColor = lerp(diffuse, cubemapColor.rgb, _Refraction);

                UNITY_LIGHT_ATTENUATION(atten, data, data.worldVertex);

                fixed3 color = UNITY_LIGHTMODEL_AMBIENT.rgb + rateColor * atten;

                return fixed4(color, 1);
            }
            ENDCG
        }
    }

    Fallback "Legacy Shaders/Reflective/VertexLit"
}