Shader "Custom/2DSun"
{
    Properties
    {
        _Color ("Sun Color", Color) = (1,0.8,0.2,1)
        _GlowColor ("Glow Color", Color) = (1,0.5,0,1)
        _Radius ("Radius", Range(0,1)) = 0.3
        _Glow ("Glow Size", Range(0,1)) = 0.5
    }

    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }

        Blend SrcAlpha One
        Cull Off
        ZWrite Off

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            fixed4 _Color;
            fixed4 _GlowColor;
            float _Radius;
            float _Glow;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float2 center = float2(0.5, 0.5);

                float dist = distance(i.uv, center);

                float core = smoothstep(_Radius, _Radius - 0.05, dist);

                float glow = smoothstep(_Glow, _Radius, dist);

                fixed4 col = _Color * core;

                col += _GlowColor * glow * 0.5;

                col.a = max(core, glow);

                return col;
            }

            ENDCG
        }
    }
}