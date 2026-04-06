Shader "TeachShader/Lesson45_BlinnPhongFragment"
{
    Properties
    {
        _MainColor("MainColor",Color) = (1,1,1,1)
        _SpecularColor("SpecularColor",Color) = (1,1,1,1)
        _SpecularPower("SpecularPower",Range(1,100)) = 15
    }
    SubShader
    {
        Tags
        {
            "LightMode"="ForwardBase"
        }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #include "Lighting.cginc"

            fixed4 _MainColor;
            fixed4 _SpecularColor;
            float _SpecularPower;

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float3 normal : NORMAL;
                float3 worldVertex : TEXCOORD0;
            };

            fixed3 getLambertDiffuseColor(in float3 normal)
            {
                fixed3 color = _LightColor0.rgb * _MainColor.rgb * max(
                    0, dot(UnityObjectToWorldNormal(normal), normalize(_WorldSpaceLightPos0)));
                return color;
            }

            fixed3 getBlinnPhongSpecularColor(in float3 vertex, in float3 normal)
            {
                float3 halfDir = normalize(
                    normalize(_WorldSpaceLightPos0) + normalize(_WorldSpaceCameraPos - vertex));

                fixed3 color = _LightColor0.rgb * _SpecularColor.rgb * pow(
                    max(0, dot(halfDir, UnityObjectToWorldNormal(normal))), _SpecularPower);
                return color;
            }

            v2f vert(appdata_base v)
            {
                v2f data;
                data.vertex = UnityObjectToClipPos(v.vertex);
                data.normal = UnityObjectToWorldNormal(v.normal);
                data.worldVertex = mul(UNITY_MATRIX_M, v.vertex).xyz;

                return data;
            }

            fixed4 frag(v2f data) : SV_Target
            {
                fixed3 lambertDiffuseColor = getLambertDiffuseColor(data.normal);
                fixed3 phongSpecularColor = getBlinnPhongSpecularColor(data.worldVertex, data.normal);

                fixed3 color = UNITY_LIGHTMODEL_AMBIENT + lambertDiffuseColor + phongSpecularColor;
                return fixed4(color, 1);
            }
            ENDCG
        }
    }
}