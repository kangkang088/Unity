Shader "TeachShader/Lesson66"
{
    Properties
    {
        _MainColor("MainColor",Color) = (1,1,1,1)
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
            #pragma multi_compile_fwdbase

            #include "UnityCG.cginc"
            #include "Lighting.cginc"

            fixed4 _MainColor;
            fixed4 _SpecularColor;
            float _SpecularPower;

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float3 normal : NORMAL;
                float3 worldVertex : TEXCOORD0;
            };

            fixed3 getLambertDiffuseColor(in float3 normal)
            {
                fixed3 color = _LightColor0.rgb * _MainColor.rgb * max(
                    0, dot(UnityObjectToWorldNormal(normal), normalize(_WorldSpaceLightPos0)));
                return color;
            }

            fixed3 getBlinnPhongSpecularColor(in float3 vertex, in float3 normal)
            {
                float3 halfDir = normalize(
                    normalize(_WorldSpaceLightPos0) + normalize(_WorldSpaceCameraPos - vertex));

                fixed3 color = _LightColor0.rgb * _SpecularColor.rgb * pow(
                    max(0, dot(halfDir, UnityObjectToWorldNormal(normal))), _SpecularPower);
                return color;
            }

            v2f vert(appdata_base v)
            {
                v2f data;
                data.vertex = UnityObjectToClipPos(v.vertex);
                data.normal = UnityObjectToWorldNormal(v.normal);
                data.worldVertex = mul(UNITY_MATRIX_M, v.vertex).xyz;

                return data;
            }

            fixed4 frag(v2f data) : SV_Target
            {
                fixed3 lambertDiffuseColor = getLambertDiffuseColor(data.normal);
                fixed3 phongSpecularColor = getBlinnPhongSpecularColor(data.worldVertex, data.normal);

                fixed attenuation = 1;

                fixed3 color = UNITY_LIGHTMODEL_AMBIENT + (lambertDiffuseColor + phongSpecularColor) * attenuation;
                return fixed4(color, 1);
            }
            ENDCG
        }

        Pass
        {
            Tags
            {
                "LightMode"="ForwardAdd"
            }

            Blend One One

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_fwdadd

            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "AutoLight.cginc"

            fixed4 _MainColor;
            fixed4 _SpecularColor;
            float _SpecularPower;

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float3 normal : NORMAL;
                float3 worldVertex : TEXCOORD0;
            };

            v2f vert(appdata_base v)
            {
                v2f data;
                data.vertex = UnityObjectToClipPos(v.vertex);
                data.normal = UnityObjectToWorldNormal(v.normal);
                data.worldVertex = mul(UNITY_MATRIX_M, v.vertex).xyz;

                return data;
            }

            fixed4 frag(v2f data) : SV_Target
            {
                fixed3 wNormal = normalize(data.normal);

                #ifdef  USING_DIRECTIONAL_LIGHT
                fixed3 lightDir = normalize(_WorldSpaceLightPos0.xyz);
                #else
                fixed3 lightDir = normalize(_WorldSpaceLightPos0.xyz - data.worldVertex);
                #endif

                fixed3 diffuse = _LightColor0.rgb * _MainColor.rgb * max(0, dot(wNormal, lightDir));

                fixed3 viewDir = normalize(UnityWorldSpaceViewDir(data.worldVertex));
                fixed3 halfDir = normalize(viewDir + lightDir);

                fixed3 specular = _LightColor0.rgb * _MainColor.rgb *
                    pow(max(0, dot(wNormal, halfDir)), _SpecularPower);

                //attenuation value
                #ifdef  USING_DIRECTIONAL_LIGHT
                fixed attenuation = 1;
                #else

                #if defined(POINT)
                fixed attenuation;
                float3 lightCoord = mul(unity_WorldToLight,
                                        float4(data.worldVertex, 1)).xyz;
                attenuation = tex2D(_LightTexture0, dot(lightCoord, lightCoord).xx).UNITY_ATTEN_CHANNEL;
                #elif defined(SPOT)
                fixed attenuation;
                float4 lightCoord = mul(unity_WorldToLight,
                                        float4(data.worldVertex, 1));
                attenuation = (lightCoord.z > 0) *
                    tex2D(_LightTexture0, lightCoord.xy / lightCoord.w + 0.5).w *
                    tex2D(_LightTextureB0, dot(lightCoord, lightCoord).rr).UNITY_ATTEN_CHANNEL;
                #else
                fixed attenuation = 1;
                #endif
                #endif


                fixed3 color = (diffuse + specular) * attenuation;

                return fixed4(color, 1);
            }
            ENDCG
        }

        Pass
        {
            Tags
            {
                "LightMode"="ShadowCaster"
            }

            CGPROGRAM
            #pragma multi_compile_shadowcaster
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct v2f
            {
                V2F_SHADOW_CASTER;
            };

            v2f vert(appdata_base v)
            {
                v2f data;
                TRANSFER_SHADOW_CASTER_NORMALOFFSET(data);
                return data;
            }

            float4 frag(v2f data) : SV_Target
            {
                SHADOW_CASTER_FRAGMENT(data);
            }
            ENDCG
        }
    }

    //    Fallback "Legacy Shaders/Specular"
}