Shader "TeachShader/Lesson32_DiffuseHalfLambertVertex"
{
    Properties
    {
        _MainColor ("MyColor", Color) = (1,1,1,1)
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

            struct v2f
            {
                float4 vertex : SV_POSITION;
                fixed4 color : COLOR;
            };

            v2f vert(appdata_base v)
            {
                v2f data;
                data.vertex = UnityObjectToClipPos(v.vertex);
                fixed3 color = _LightColor0.rgb * _MainColor.rgb * (0.5 * dot(UnityObjectToWorldNormal(v.normal),
                                                                              normalize(_WorldSpaceLightPos0)) + 0.5);
                color += UNITY_LIGHTMODEL_AMBIENT.rgb;

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