Shader "TeachShader/Lesson29_DiffuseLambertVertex"
{
    Properties
    {
        _MainColor("MainColor",Color) = (0,0,0,1)
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
                float4 pos : SV_POSITION;
                fixed3 color : COLOR;
            };

            v2f vert(appdata_base v)
            {
                float3 normal = UnityObjectToWorldNormal(v.normal);
                float3 ligth_pos = normalize(_WorldSpaceLightPos0.xyz);

                v2f data;
                data.pos = UnityObjectToClipPos(v.vertex);

                fixed3 color = _LightColor0.rgb * _MainColor.rgb * max(0, dot(normal, ligth_pos));
                data.color = color + UNITY_LIGHTMODEL_AMBIENT.rgb;

                return data;
            }

            fixed4 frag(v2f data) : SV_Target
            {
                fixed4 color = fixed4(data.color, 1);

                return color;
            }
            ENDCG
        }
    }
}