Shader "TeachShader/Lesson89_PT"
{
    Properties
    {
        _TileCount("TileCount",Float) = 8
        _ColorA("ColorA",Color) = (1,1,1,1)
        _ColorB("ColorB",Color) = (0,0,0,1)
    }
    SubShader
    {
        Tags
        {
            "RenderType"="Opaque"
        }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            float _TileCount;
            fixed4 _ColorA;
            fixed4 _ColorB;

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert(appdata_base v)
            {
                v2f data;
                data.vertex = UnityObjectToClipPos(v.vertex);
                data.uv = v.texcoord;
                return data;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float2 uv = i.uv * _TileCount;

                float2 pos = floor(uv);

                if ((pos.x + pos.y) % 2 == 0)
                    return _ColorA;
                return _ColorB;
            }
            ENDCG
        }
    }
}