Shader "TeachShader/Lesson35_SpecularPhongVertex"
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
                fixed4 color : COLOR;
            };

            v2f vert(appdata_base v)
            {
                v2f data;

                data.vertex = UnityObjectToClipPos(v.vertex);

                float3 viewDir = normalize(_WorldSpaceCameraPos - mul(UNITY_MATRIX_M, v.vertex));
                float3 reflectDir = reflect(-normalize(_WorldSpaceLightPos0), UnityObjectToWorldNormal(v.normal));

                fixed3 color = _LightColor0.rgb * _SpecularColor.rgb * pow(
                    max(0, dot(viewDir, reflectDir)), _SpecularPower);

                data.color = fixed4(color, 1);

                return data;
            }

            fixed4 frag(v2f data) : SV_Target
            {
                return data.color;
            }
            ENDCG
        }
    }
}