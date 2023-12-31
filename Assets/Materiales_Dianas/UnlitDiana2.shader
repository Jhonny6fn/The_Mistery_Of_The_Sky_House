Shader "Unlit/UnlitDiana2"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        Tiempo("Tiempo", float) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

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
                float4 origVertex : TEXCOORD1;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float Tiempo;

            v2f vert (appdata v)
            {
                v2f o;

                o.origVertex = v.vertex;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);

                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                if (i.origVertex.x < Tiempo)
                    discard;
                return col;
            }
            ENDCG
        }
    }
}