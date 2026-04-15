Shader "TeachShader/Lesson94_2DWater"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Color",Color) = (1,1,1,1)
        _WaveAmplitude ("WaveAmplitude",Float) = 1
        _WaveFrequency ("WaveFrequency",Float) = 1
        _InverseWaveLength ("InverseWaveLength",Float) = 1
        _Speed ("Speed",Float) = 1
    }
    SubShader
    {
        Tags
        {
            "RenderType"="Transparent"
            "Queue"="Transparent"
            "IgnoreProjector"="True"
            "DisableBatching"="True"
        }

        Pass
        {
            ZWrite Off
            Blend SrcAlpha OneMinusSrcAlpha

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed4 _Color;
            float _WaveAmplitude;
            float _WaveFrequency;
            float _InverseWaveLength;
            float _Speed;

            v2f vert(appdata_base v)
            {
                v2f o;
                float4 offset;

                offset.x = sin(_Time.y * _WaveFrequency + v.vertex.z * _InverseWaveLength) * _WaveAmplitude;
                offset.yzw = float3(0, 0, 0);

                o.vertex = UnityObjectToClipPos(v.vertex + offset);
                o.uv = v.texcoord * _MainTex_ST.xy + _MainTex_ST.zw;
                o.uv += float2(0, _Time.y * _Speed);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                return tex2D(_MainTex, i.uv) * _Color;
            }
            ENDCG
        }
    }
}