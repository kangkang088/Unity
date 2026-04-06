Shader "TeachShader/Lesson30_DiffuseLambertFragment"
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
                float4 vertext : SV_POSITION;
                float3 normal : NORMAL;
            };

            v2f vert(appdata_base v)
            {
                v2f data;
                data.vertext = UnityObjectToClipPos(v.vertex);
                data.normal = v.normal;
                return data;
            }

            fixed4 frag(v2f data) : SV_Target
            {
                fixed3 color = _LightColor0.rgb * _MainColor.rgb * max(
                    0, dot(normalize(data.normal), normalize(_WorldSpaceLightPos0)));
                color += UNITY_LIGHTMODEL_AMBIENT.rgb;
                return fixed4(color, 1);
            }
            ENDCG
        }
    }
}