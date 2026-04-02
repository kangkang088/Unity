Shader "TeachShader/Lesson6"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _MyInt ("MyInt",Int) = 5
        _MyFloat ("MyFloat",Float) = 0.5
        _MyRangeFloat ("MyRangeFloat",Range(0,10)) = 5
        _MyColor ("MyColor",Color) = (0,0,0,1)
        _MyVector ("MyVector",Vector) = (0,0,0,0)
        _My2D ("My2D",2D) = "" {}
        _My2DArray ("My2DArray",2DArray) = "" {}
        _MyCube ("MyCube",Cube) = "" {}
        _My3D ("My3D",3D) = "" {}
    }
    SubShader
    {
        Tags
        {
            //Opaque不透明 Transparent透明 TransparentCutout透明切割 Background背景 Overlay覆盖
            //不常用：TreeOpaque TreeTransparentCutout TreeBillboard Grass GrassBillboard
            "RenderType"="Opaque"
            //1000-Background 背景 2000-Geometry 不透明物体 2450-AlphaTest 透明测试 3000-Transparent 半透明、透明混合等 4000-Overlay 覆盖
            "Queue"="Background"

            //            "DisableBatching"="True"
            //            "DisableBatching"="LODFading"

            //            "ForceNoShadowCasting"="True"

            //            "IgnoreProjector"="True" //半透明Shader一般启用

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
                return col;
            }
            ENDCG
        }
    }
}