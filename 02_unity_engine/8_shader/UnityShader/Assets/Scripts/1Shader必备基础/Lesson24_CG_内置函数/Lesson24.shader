Shader "TeachShader/Lesson24"
{
    Properties
    {
        _MyInt("MyInt",Int) = 5
        _MyFloat("MyFloat",Float) = 6
        _MyRange("MyRange",Range(0,10)) = 5

        _MyColor("MyColor",Color) = (0,0,0,1)
        _MyVector("MyVector",Vector) = (0,0,0,1)

        _My2D("My2D",2D) = "" {}
        _My2DArray("My2DArray",2DArray) = "" {}
        _MyCube("MyCube",Cube) = "" {}
        _My3D("My3D",3D) = "" {}

    }
    SubShader
    {
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            float _MyInt;
            float _MyFloat;
            fixed _MyRange;

            fixed4 _MyColor;
            float4 _MyVector;

            sampler2D _My2D;
            samplerCUBE _MyCube;

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
                return _MyColor;
            }
            ENDCG
        }
    }
}