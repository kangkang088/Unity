Shader "TeachShader/Lesson56_AlphaTest"
{
    Properties
    {
        _MainTex("MainTex",2D) = "" {}
        _MainColor("MainColor",Color) = (1,1,1,1)
        _SpecularColor("SpecularColor",Color) = (1,1,1,1)
        _SpecularPower("SpecularPower",Range(1,20)) = 15
        _Cutoff("Cutoff",Range(0,1)) = 0
    }
    SubShader
    {
        Tags
        {
            "Queue"="AlphaTest"
            "IgnoreProjector"="True"
            "RenderType"="TransparentCutout"
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

            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed4 _MainColor;
            fixed4 _SpecularColor;
            float _SpecularPower;
            fixed _Cutoff;

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
                fixed4 mainColor = tex2D(_MainTex, i.uv);
                // if (mainColor.a < _Cutoff)
                //     discard;
                clip(mainColor.a - _Cutoff);

                fixed3 albedo = mainColor.rgb * _MainColor.rgb;
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