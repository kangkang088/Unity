Shader "TeachShader/Lesson75_ReflectBase"
{
    Properties
    {
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

            #include "UnityCG.cginc"
            #include "Lighting.cginc"

            samplerCUBE _Cubemap;
            float _Reflectivity;

            struct v2f
            {
                float4 pos : SV_POSITION;
                float3 worldReflect : TEXCOORD0;
            };

            v2f vert(appdata_base v)
            {
                v2f data;
                data.pos = UnityObjectToClipPos(v.vertex);
                fixed3 worldNormal = normalize(UnityObjectToWorldNormal(v.normal));
                float3 worldVertex = mul(UNITY_MATRIX_M, v.vertex).xyz;
                fixed3 viewDir = UnityWorldSpaceViewDir(worldVertex);
                data.worldReflect = reflect(-viewDir, worldNormal);
                return data;
            }

            fixed4 frag(v2f data) : SV_Target
            {
                fixed4 cubemapColor = texCUBE(_Cubemap, data.worldReflect);
                cubemapColor *= _Reflectivity;
                return cubemapColor;
            }
            ENDCG
        }
    }
}