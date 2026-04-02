// Upgrade NOTE: replaced 'samplerRECT' with 'sampler2D'

Shader "TeachShader/Lesson14"
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

            struct Test
            {
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o, o.vertex);

                uint ui = 12; //32位
                int i = -10; //32位
                float f = 10.5f; //32位
                half hf = 5.5h; //16位
                fixed ff = 3.5; //12位
                bool b = true;
                string str = "123";

                sampler sam; //通用纹理
                sampler1D sam1d; //一维纹理
                sampler2D sam2d; //二维纹理
                sampler3D sam3d; //三维纹理
                samplerCUBE samCube; //立方体纹理
                sampler2D samRect; //矩形纹理

                int a[4] = {1, 2, 3, 4};
                int aLength = 4; // CG中无法通过a.length得到，必须自己声明
                int array2D[3][3] = {{1, 2, 3}, {4, 5, 6}, {7, 8, 9}};

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