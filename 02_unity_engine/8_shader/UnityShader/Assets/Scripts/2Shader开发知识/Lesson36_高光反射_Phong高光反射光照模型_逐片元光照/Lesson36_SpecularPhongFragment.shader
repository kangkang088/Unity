Shader "TeachShader/Lesson36_SpecularPhongFragment"
{
    Properties
    {
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

            fixed4 _SpecularColor;
            float _SpecularPower;

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float3 normal : NORMAL;
                float3 worldVertexPos : TEXCOORD0;
            };


            v2f vert(appdata_base v)
            {
                v2f data;

                data.vertex = UnityObjectToClipPos(v.vertex);
                data.normal = UnityObjectToWorldNormal(v.normal);
                data.worldVertexPos = mul(UNITY_MATRIX_M, v.vertex).xyz;

                return data;
            }

            fixed4 frag(v2f data) : SV_Target
            {
                float3 viewDir = normalize(_WorldSpaceCameraPos - data.worldVertexPos).xyz;
                float3 reflectDir = reflect(-normalize(_WorldSpaceLightPos0), normalize(data.normal));

                fixed3 color = _LightColor0.rgb * _SpecularColor.rgb * pow(
                    max(0, dot(viewDir, reflectDir)), _SpecularPower);

                return fixed4(color, 1);
            }
            ENDCG
        }
    }
}