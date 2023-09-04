Shader "Custom/MinecraftStyle"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata_t v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.vertex, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float height = tex2D(_MainTex, i.uv).r;
                fixed4 col = fixed4(height, height, height, 1);
                return col;
            }
            ENDCG
        }
    }
}
