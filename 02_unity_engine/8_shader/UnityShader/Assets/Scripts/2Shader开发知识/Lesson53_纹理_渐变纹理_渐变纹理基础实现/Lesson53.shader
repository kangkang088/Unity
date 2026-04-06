Shader "TeachShader/Lesson53"
{
    Properties
    {
        _MainColor("MainColor",Color) = (1,1,1,1)
        _RampTex("RampTex",2D) = "" {}
        _SpecularColor("SpecularColor",Color) = (1,1,1,1)
        _SpecularPower("SpecularPower",Range(1,100)) = 15
    }
    SubShader
    {
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

            fixed4 _MainColor;
            sampler2D _RampTex;
            float4 _RampTex_ST;
            fixed4 _SpecularColor;
            float _SpecularPower;

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float3 worldNormal : NORMAL;
                float3 worldVertex : TEXCOORD1;
            };


            v2f vert(appdata_base v)
            {
                v2f data;
                data.vertex = UnityObjectToClipPos(v.vertex);
                data.worldNormal = UnityObjectToWorldNormal(v.normal);
                data.worldVertex = mul(UNITY_MATRIX_M, v.vertex);
                return data;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float3 lightDir = normalize(_WorldSpaceLightPos0);
                fixed halfLambertNum = dot(normalize(i.worldNormal), lightDir) * 0.5 + 0.5;
                fixed3 diffuseColor = _LightColor0.rgb * _MainColor.rgb * tex2D(
                    _RampTex,fixed2(halfLambertNum, halfLambertNum)).rgb;

                float3 viewDir = normalize(UnityWorldSpaceViewDir(i.worldVertex));
                float3 halfDir = normalize(viewDir + lightDir);
                fixed3 specularColor = _LightColor0.rgb * _SpecularColor.rgb * pow(
                    max(0, dot(i.worldNormal, halfDir)), _SpecularPower);

                fixed3 color = UNITY_LIGHTMODEL_AMBIENT.rgb + diffuseColor + specularColor;

                return fixed4(color, 1);
            }
            ENDCG
        }
    }
}