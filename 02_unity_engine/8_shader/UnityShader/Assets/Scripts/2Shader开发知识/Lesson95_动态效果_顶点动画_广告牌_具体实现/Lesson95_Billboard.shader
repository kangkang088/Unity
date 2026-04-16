Shader "TeachShader/Lesson95_Billboard"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Color", Color) = (1, 1, 1, 1)
        _VerticalBillboard ("VerticalBillboard", Range(0, 1)) = 1
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
            cull Off

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
            float _VerticalBillboard;

            v2f vert(appdata_base v)
            {
                v2f data;

                float3 center = float3(0, 0, 0);
                float3 cameraInObjectPos = mul(UNITY_MATRIX_M, float4(_WorldSpaceCameraPos, 1));
                float3 normal = cameraInObjectPos - center;
                normal.y *= _VerticalBillboard;
                normal = normalize(normal);

                float3 up = normal.y > 0.999 ? float3(0, 0, 1) : float3(0, 1, 0);
                float3 right = normalize(cross(up, normal));
                up = normalize(cross(normal, right));
                float3 offset = v.vertex.xyz - center;
                float3 vertex = center + offset.x * right + offset.y * up + offset.z * normal;
                data.vertex = UnityObjectToClipPos(float4(vertex, 1));
                data.uv = v.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw;
                return data;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                return tex2D(_MainTex, i.uv) * _Color;
            }
            ENDCG
        }
    }
}