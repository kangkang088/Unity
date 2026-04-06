Shader "TeachShader/Lesson51"
{
    Properties
    {
        _MainColor("MainColor",Color) = (1,1,1,1)
        _MainTex("MainTex",2D) = "" {}
        _BumpMap("BumpMap",2D) = "" {}
        _BumpScale("BumpScale",Range(0,1)) = 1
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
            sampler2D _MainTex;
            float4 _MainTex_ST;
            sampler2D _BumpMap;
            float4 _BumpMap_ST;
            float _BumpScale;
            fixed4 _SpecularColor;
            fixed _SpecularPower;

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float4 uvTexAndNormal : TEXCOORD0;
                float3 tangentLightDir : TEXCOORD1;
                float3 tangentViewDir : TEXCOORD2;
            };

            v2f vert(appdata_full v)
            {
                v2f data;
                data.vertex = UnityObjectToClipPos(v.vertex);
                data.uvTexAndNormal.xy = v.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw;
                data.uvTexAndNormal.zw = v.texcoord.xy * _BumpMap_ST.xy + _BumpMap_ST.zw;

                //model to tangent matrix
                float3 binormal = cross(normalize(v.tangent), normalize(v.normal)) * v.tangent.w;
                float3x3 m2t = float3x3(v.tangent.xyz,
                                        binormal,
                                        v.normal);

                data.tangentLightDir = normalize(mul(m2t, ObjSpaceLightDir(v.vertex)));
                data.tangentViewDir = normalize(mul(m2t, ObjSpaceViewDir(v.vertex)));
                return data;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float4 packedNormal = tex2D(_BumpMap, i.uvTexAndNormal.zw);
                float3 tangentNormal = UnpackNormal(packedNormal);
                tangentNormal.xy *= _BumpScale;
                tangentNormal.z = sqrt(1.0 - saturate(dot(tangentNormal.xy, tangentNormal.xy)));

                fixed3 albedo = tex2D(_MainTex, i.uvTexAndNormal.xy) * _MainColor.rgb;
                fixed3 diffuse = _LightColor0.rgb * albedo * max(0, dot(tangentNormal, i.tangentLightDir));

                float3 haflDir = normalize(i.tangentViewDir + i.tangentLightDir);
                fixed3 specular = _LightColor0.rgb * _SpecularColor.rgb * pow(
                    max(0, dot(haflDir, tangentNormal)), _SpecularPower);

                fixed3 color = UNITY_LIGHTMODEL_AMBIENT.rgb * albedo + diffuse + specular;
                return fixed4(color, 1);
            }
            ENDCG
        }
    }
}