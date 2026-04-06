Shader "TeachShader/Lesson16"
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

                fixed4 f4 = fixed4(1.5, 5.6, 79.8, 15.4);
                fixed f = f4.x; //r
                f = f4.y; //g
                f = f4.z; //b
                f = f4.w; //a

                f4 = f4.xzwy; //rbag
                f4 = f4.rbga; //xzyw

                fixed3 f3 = f4.xyz; //rgb
                fixed2 f2 = f4.xw; //ra
                fixed4 f4_2 = fixed4(f2, f3.xy);

                fixed4x4 f44 =
                {
                    f4,
                    f4,
                    fixed4(f2, f2),
                    fixed4(f2, f2)
                };

                f = f44[0][0];

                f4_2 = f44[3];

                fixed3 f3_2 = f4; //自动省去多余的，按顺序

                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}