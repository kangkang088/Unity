Shader "TeachShader/Lesson88"
{
    Properties
    {
        _MainTex("MainTex",2D) = "white" {}
    }
    SubShader
    {
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f_img vert(appdata_base v)
            {
                v2f_img data;
                data.pos = UnityObjectToClipPos(v.vertex);

                data.uv = v.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw;
                // TRANSFORM_TEX(v.texcoord.xy, _MainTex);

                return data;
            }

            fixed4 frag(v2f_img data) : SV_Target
            {
                fixed4 color = tex2D(_MainTex, data.uv);

                return color;
            }
            ENDCG
        }
    }
}