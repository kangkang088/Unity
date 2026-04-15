Shader "TeachShader/Lesson93_ScrollingBackground"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _USpeed ("USpeed",Float) = 0.5
        _VSpeed ("VSpeed",Float) = 0.5
    }
    SubShader
    {
        Tags
        {
            "RenderType"="Transparent"
            "Queue"="Transparent"
            "IgnoreProjector"="True"
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
            float _USpeed;
            float _VSpeed;

            v2f vert(appdata_base v)
            {
                v2f data;
                data.vertex = UnityObjectToClipPos(v.vertex);
                data.uv = v.texcoord;
                return data;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float2 scrollUV = frac(i.uv + float2(_Time.y * _USpeed, _Time.y * _VSpeed));
                return tex2D(_MainTex, scrollUV);
            }
            ENDCG
        }
    }
}