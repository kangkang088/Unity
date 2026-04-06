Shader "TeachShader/Lesson50"
{
    Properties
    {
        _MainTex("MainTex",2D) = "" {}
        _MainColor("MainColor",Color) = (1,1,1,1)
        _SpecularColor("SpecularColor",Color) = (1,1,1,1)
        _SpecularPower("SpecularPower",Range(1,20)) = 15
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

            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed4 _MainColor;
            fixed4 _SpecularColor;
            float _SpecularPower;

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
                float3 normal : NORMAL;
                float3 worldVertex : TEXCOORD1;
            };

            v2f vert(appdata_base v)
            {
                v2f data;
                data.vertex = UnityObjectToClipPos(v.vertex);
                data.uv = v.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw;
                data.normal = UnityObjectToWorldNormal(v.normal);
                data.worldVertex = mul(UNITY_MATRIX_M, v.vertex);
                return data;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                fixed3 albedo = tex2D(_MainTex, i.uv).rgb * _MainColor.rgb;
                fixed3 diffuseColor = _LightColor0.rgb * albedo *
                    max(0, dot(i.normal, normalize(_WorldSpaceLightPos0)));
                float3 viewDir = normalize(UnityWorldSpaceViewDir(i.worldVertex));
                float3 halfDir = normalize(viewDir + normalize(_WorldSpaceLightPos0));
                fixed3 specularColor = _LightColor0.rgb * _SpecularColor.rgb * pow(
                    max(0, dot(i.normal, halfDir)), _SpecularPower);
                fixed3 color = UNITY_LIGHTMODEL_AMBIENT.rgb * albedo.rgb + diffuseColor + specularColor;
                return fixed4(color, 1);
            }
            ENDCG
        }
    }
}