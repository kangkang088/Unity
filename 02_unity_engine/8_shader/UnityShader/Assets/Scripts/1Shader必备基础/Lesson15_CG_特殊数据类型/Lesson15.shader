Shader "TeachShader/Lesson15"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags
        {
            "RenderType"="Opaque"
        }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o, o.vertex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);

                fixed2 f2 = fixed2(2.5, 6.5);
                float3 f3 = float3(5.0f, 6.5f, 7.8f);
                int4 i4 = int4(-1, -2, -3, -4);
                uint4 ui4 = uint4(1, 6, 5, 7);

                fixed2x2 f22 =
                {
                    2.5, 3.7,
                    5.8, 9.1
                };

                float3x3 f33 =
                {
                    1.5f, 3.6, 7.8,
                    5.55f, 6.7f, 8.1f,
                    5.9f, 77.6f, 55.9f
                };

                int4x4 i44 =
                {
                    1, 2, 3, 4,
                    5, 6, 7, 8,
                    9, 10, 11, 12,
                    13, 14, 15, 16
                };

                float3 a = float3(1.5f, 6.6f, 7.9f);
                float3 b = float3(6.6f, 2.7f, 3.9f);
                bool3 c = a < b; //bool3(true,false,false)

                return col;
            }
            ENDCG
        }
    }
}