Shader "TeachShader/Lesson42_SpecularBlinnPhongFragment"
{
    Properties
    {
        _SpecularColor("SpecularColor",Color) = (1,1,1,1)
        _SpecularPower("SpecularPower",Range(1,100)) = 10
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

            fixed4 _SpecularColor;
            float _SpecularPower;

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float3 normal : NORMAL;
                float3 worldVertex : TEXCOORD0;
            };

            v2f vert(appdata_base v)
            {
                v2f data;
                data.vertex = UnityObjectToClipPos(v.vertex);
                data.normal = UnityObjectToWorldNormal(v.normal);
                data.worldVertex = mul(UNITY_MATRIX_M, v.vertex);
                return data;
            }

            fixed4 frag(v2f data) : SV_Target
            {
                float3 halfDir = normalize(
                    normalize(_WorldSpaceLightPos0) + normalize(_WorldSpaceCameraPos - data.worldVertex));

                fixed3 color = _LightColor0.rgb * _SpecularColor.rgb * pow(
                    max(0, dot(halfDir, normalize(data.normal))), _SpecularPower);

                return fixed4(color, 1);
            }
            ENDCG
        }
    }
}