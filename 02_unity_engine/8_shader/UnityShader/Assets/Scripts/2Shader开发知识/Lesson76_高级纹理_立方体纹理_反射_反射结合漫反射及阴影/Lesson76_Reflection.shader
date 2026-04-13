Shader "TeachShader/Lesson76_Reflection"
{
    Properties
    {
        _Color("MainColor",Color) = (1,1,1,1)
        _ReflectColor("ReflectColor",Color) = (1,1,1,1)
        _Cubemap("Cubemap",Cube) = "" {}
        _Reflectivity("Reflectivity",Range(0,1)) = 1
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

            fixed4 _Color;
            fixed4 _ReflectColor;
            samplerCUBE _Cubemap;
            float _Reflectivity;

            struct v2f
            {
                float4 pos : SV_POSITION;
                float3 worldReflect : TEXCOORD0;
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
                fixed3 viewDir = UnityWorldSpaceViewDir(data.worldVertex);
                data.worldReflect = reflect(-viewDir, data.worldNormal);
                TRANSFER_SHADOW(data);
                return data;
            }

            fixed4 frag(v2f data) : SV_Target
            {
                UNITY_LIGHT_ATTENUATION(atten, data, data.worldVertex);

                fixed4 cubemapColor = texCUBE(_Cubemap, data.worldReflect) * _ReflectColor;

                fixed3 diffuse = _LightColor0.rgb * _Color.rgb * max(
                    0, dot(data.worldNormal, normalize(UnityWorldSpaceLightDir(data.worldVertex))));

                // diffuse *= atten;

                fixed3 rateColor = lerp(diffuse, cubemapColor.rgb, _Reflectivity);

                // fixed3 color = UNITY_LIGHTMODEL_AMBIENT.rgb + rateColor;
                fixed3 color = UNITY_LIGHTMODEL_AMBIENT.rgb + rateColor * atten;

                return fixed4(color, 1);
            }
            ENDCG
        }
    }

    Fallback "Legacy Shaders/Reflective/VertexLit"
}