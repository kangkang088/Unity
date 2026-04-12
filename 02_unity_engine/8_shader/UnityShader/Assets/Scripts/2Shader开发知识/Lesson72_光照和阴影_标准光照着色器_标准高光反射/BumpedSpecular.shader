Shader "TeachShader/BumpedSpecular"
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
        Tags
        {
            "RenderType"="Opaque"
            "Queue"="Geometry"
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
            #pragma multi_compile_fwdbase

            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "AutoLight.cginc"

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
                float4 pos : SV_POSITION;
                float4 uvTexAndNormal : TEXCOORD0;
                float4 t2w0 : TEXCOORD1;
                float4 t2w1 : TEXCOORD2;
                float4 t2w2 : TEXCOORD3;
                // float3 worldVertex : TEXCOORD1;
                // float3x3 t2w : TEXCOORD2;
                SHADOW_COORDS(4)
            };

            v2f vert(appdata_full v)
            {
                v2f data;
                data.pos = UnityObjectToClipPos(v.vertex);
                data.uvTexAndNormal.xy = v.texcoord.xy + _MainTex_ST.xy + _MainTex_ST.zw;
                data.uvTexAndNormal.zw = v.texcoord.xy + _BumpMap_ST.xy + _BumpMap_ST.zw;
                float3 worldVertex = mul(UNITY_MATRIX_M, v.vertex);
                data.t2w0.w = worldVertex.x;
                data.t2w1.w = worldVertex.y;
                data.t2w2.w = worldVertex.z;

                // model to world space
                float3 worldNormal = UnityObjectToWorldNormal(v.normal);
                float3 worldTangent = UnityObjectToWorldDir(v.tangent);
                float3 worldBinormal = cross(worldNormal, worldTangent) * v.tangent.w;

                // data.t2w = float3x3(worldTangent.x, worldBinormal.x, worldNormal.x,
                //                     worldTangent.y, worldBinormal.y, worldNormal.y,
                //                     worldTangent.z, worldBinormal.z, worldNormal.z
                // );
                data.t2w0.xyz = float3(worldTangent.x, worldBinormal.x, worldNormal.x);
                data.t2w1.xyz = float3(worldTangent.y, worldBinormal.y, worldNormal.y);
                data.t2w2.xyz = float3(worldTangent.z, worldBinormal.z, worldNormal.z);

                TRANSFER_SHADOW(data);

                return data;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                fixed3 lightDir = normalize(_WorldSpaceLightPos0.xyz);
                fixed3 viewDir = normalize(UnityWorldSpaceViewDir(float3(i.t2w0.w, i.t2w1.w, i.t2w2.w)));
                float4 packedNormal = tex2D(_BumpMap, i.uvTexAndNormal.zw);
                float3 tangentNormal = UnpackNormal(packedNormal);
                tangentNormal.xy *= _BumpScale;
                tangentNormal.z = sqrt(1.0 - saturate(dot(tangentNormal.xy, tangentNormal.xy)));

                float3 worldNormal = float3(dot(i.t2w0.xyz, tangentNormal), dot(i.t2w1.xyz, tangentNormal),
                                            dot(i.t2w2.xyz, tangentNormal));

                fixed3 albedo = tex2D(_MainTex, i.uvTexAndNormal.xy) * _MainColor.rgb;
                fixed3 diffuse = _LightColor0.rgb * albedo * max(0, dot(worldNormal, lightDir));

                float3 haflDir = normalize(viewDir + lightDir);
                fixed3 specular = _LightColor0.rgb * _SpecularColor.rgb * pow(
                    max(0, dot(haflDir, worldNormal)), _SpecularPower);

                UNITY_LIGHT_ATTENUATION(atten, i, float3(i.t2w0.w, i.t2w1.w, i.t2w2.w));

                fixed3 color = UNITY_LIGHTMODEL_AMBIENT.rgb * albedo + (diffuse + specular) * atten;
                return fixed4(color, 1);
            }
            ENDCG
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
            #pragma multi_compile_fwdbase

            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "AutoLight.cginc"

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
                float4 pos : SV_POSITION;
                float4 uvTexAndNormal : TEXCOORD0;
                float4 t2w0 : TEXCOORD1;
                float4 t2w1 : TEXCOORD2;
                float4 t2w2 : TEXCOORD3;
                // float3 worldVertex : TEXCOORD1;
                // float3x3 t2w : TEXCOORD2;
                SHADOW_COORDS(4)
            };

            v2f vert(appdata_full v)
            {
                v2f data;
                data.pos = UnityObjectToClipPos(v.vertex);
                data.uvTexAndNormal.xy = v.texcoord.xy + _MainTex_ST.xy + _MainTex_ST.zw;
                data.uvTexAndNormal.zw = v.texcoord.xy + _BumpMap_ST.xy + _BumpMap_ST.zw;
                float3 worldVertex = mul(UNITY_MATRIX_M, v.vertex);
                data.t2w0.w = worldVertex.x;
                data.t2w1.w = worldVertex.y;
                data.t2w2.w = worldVertex.z;

                // model to world space
                float3 worldNormal = UnityObjectToWorldNormal(v.normal);
                float3 worldTangent = UnityObjectToWorldDir(v.tangent);
                float3 worldBinormal = cross(worldNormal, worldTangent) * v.tangent.w;

                // data.t2w = float3x3(worldTangent.x, worldBinormal.x, worldNormal.x,
                //                     worldTangent.y, worldBinormal.y, worldNormal.y,
                //                     worldTangent.z, worldBinormal.z, worldNormal.z
                // );
                data.t2w0.xyz = float3(worldTangent.x, worldBinormal.x, worldNormal.x);
                data.t2w1.xyz = float3(worldTangent.y, worldBinormal.y, worldNormal.y);
                data.t2w2.xyz = float3(worldTangent.z, worldBinormal.z, worldNormal.z);

                TRANSFER_SHADOW(data);

                return data;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                fixed3 lightDir = normalize(_WorldSpaceLightPos0.xyz);
                fixed3 viewDir = normalize(UnityWorldSpaceViewDir(float3(i.t2w0.w, i.t2w1.w, i.t2w2.w)));
                float4 packedNormal = tex2D(_BumpMap, i.uvTexAndNormal.zw);
                float3 tangentNormal = UnpackNormal(packedNormal);
                tangentNormal.xy *= _BumpScale;
                tangentNormal.z = sqrt(1.0 - saturate(dot(tangentNormal.xy, tangentNormal.xy)));

                float3 worldNormal = float3(dot(i.t2w0.xyz, tangentNormal), dot(i.t2w1.xyz, tangentNormal),
                                            dot(i.t2w2.xyz, tangentNormal));

                fixed3 albedo = tex2D(_MainTex, i.uvTexAndNormal.xy) * _MainColor.rgb;
                fixed3 diffuse = _LightColor0.rgb * albedo * max(0, dot(worldNormal, lightDir));

                float3 haflDir = normalize(viewDir + lightDir);
                fixed3 specular = _LightColor0.rgb * _SpecularColor.rgb * pow(
                    max(0, dot(haflDir, worldNormal)), _SpecularPower);

                UNITY_LIGHT_ATTENUATION(atten, i, float3(i.t2w0.w, i.t2w1.w, i.t2w2.w));

                fixed3 color = UNITY_LIGHTMODEL_AMBIENT.rgb * albedo + (diffuse + specular) * atten;
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
            #pragma multi_compile_fwdadd_fullshadows

            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "AutoLight.cginc"

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
                float4 t2w0 : TEXCOORD1;
                float4 t2w1 : TEXCOORD2;
                float4 t2w2 : TEXCOORD3;
                // float3 worldVertex : TEXCOORD1;
                // float3x3 t2w : TEXCOORD2;
                SHADOW_COORDS(4)
            };

            v2f vert(appdata_full v)
            {
                v2f data;
                data.vertex = UnityObjectToClipPos(v.vertex);
                data.uvTexAndNormal.xy = v.texcoord.xy + _MainTex_ST.xy + _MainTex_ST.zw;
                data.uvTexAndNormal.zw = v.texcoord.xy + _BumpMap_ST.xy + _BumpMap_ST.zw;
                float3 worldVertex = mul(UNITY_MATRIX_M, v.vertex);
                data.t2w0.w = worldVertex.x;
                data.t2w1.w = worldVertex.y;
                data.t2w2.w = worldVertex.z;

                // model to world space
                float3 worldNormal = UnityObjectToWorldNormal(v.normal);
                float3 worldTangent = UnityObjectToWorldDir(v.tangent);
                float3 worldBinormal = cross(worldNormal, worldTangent) * v.tangent.w;

                // data.t2w = float3x3(worldTangent.x, worldBinormal.x, worldNormal.x,
                //                     worldTangent.y, worldBinormal.y, worldNormal.y,
                //                     worldTangent.z, worldBinormal.z, worldNormal.z
                // );
                data.t2w0.xyz = float3(worldTangent.x, worldBinormal.x, worldNormal.x);
                data.t2w1.xyz = float3(worldTangent.y, worldBinormal.y, worldNormal.y);
                data.t2w2.xyz = float3(worldTangent.z, worldBinormal.z, worldNormal.z);

                TRANSFER_SHADOW(data);

                return data;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                fixed3 lightDir = normalize(_WorldSpaceLightPos0.xyz);
                fixed3 viewDir = normalize(UnityWorldSpaceViewDir(float3(i.t2w0.w, i.t2w1.w, i.t2w2.w)));
                float4 packedNormal = tex2D(_BumpMap, i.uvTexAndNormal.zw);
                float3 tangentNormal = UnpackNormal(packedNormal);
                tangentNormal.xy *= _BumpScale;
                tangentNormal.z = sqrt(1.0 - saturate(dot(tangentNormal.xy, tangentNormal.xy)));

                float3 worldNormal = float3(dot(i.t2w0.xyz, tangentNormal), dot(i.t2w1.xyz, tangentNormal),
                                            dot(i.t2w2.xyz, tangentNormal));

                fixed3 albedo = tex2D(_MainTex, i.uvTexAndNormal.xy) * _MainColor.rgb;
                fixed3 diffuse = _LightColor0.rgb * albedo * max(0, dot(worldNormal, lightDir));

                float3 haflDir = normalize(viewDir + lightDir);
                fixed3 specular = _LightColor0.rgb * _SpecularColor.rgb * pow(
                    max(0, dot(haflDir, worldNormal)), _SpecularPower);

                UNITY_LIGHT_ATTENUATION(atten, i, float3(i.t2w0.w, i.t2w1.w, i.t2w2.w));

                fixed3 color = UNITY_LIGHTMODEL_AMBIENT.rgb * albedo + (diffuse + specular) * atten;
                return fixed4(color, 1);
            }
            ENDCG
        }
    }
    Fallback "Legacy Shaders/Specular"
}