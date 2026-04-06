Shader "TeachShader/Lesson33_DiffuseHalfLambertFragment"
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
                fixed3 normal : NORMAL;
            };

            v2f vert(appdata_base v)
            {
                v2f data;
                data.vertex = UnityObjectToClipPos(v.vertex);
                data.normal = UnityObjectToWorldNormal(v.normal);
                return data;
            }

            fixed4 frag(v2f data) : SV_Target
            {
                fixed3 color = _LightColor0.rgb * _MainColor.rgb * (dot(
                    normalize(data.normal), normalize(_WorldSpaceLightPos0)) * 0.5 + 0.5);
                color += UNITY_LIGHTMODEL_AMBIENT;

                return fixed4(color, 1);
            }
            ENDCG
        }
    }
}