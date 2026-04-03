Shader "TeachShader/Lesson22"
{
    Properties {}
    SubShader
    {
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            struct a2v
            {
                float4 v : POSITION;
                float3 n : NORMAL;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float3 n : NORMAL;
                float2 uv : TEXCOORD0;
            };

            v2f vert(a2v data)
            {
                v2f v2fData;
                v2fData.pos = UnityObjectToClipPos(data.v);
                v2fData.n = data.n;
                v2fData.uv = data.uv;

                return v2fData;
            }

            fixed4 frag(v2f data) : SV_Target
            {
                return fixed4(0, 1, 1, 1);
            }
            ENDCG
        }
    }
}