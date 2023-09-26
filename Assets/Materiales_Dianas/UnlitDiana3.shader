Shader "Unlit/UnlitDiana3"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _MainTex2("Texture", 2D) = "black"{}
        Contador("Contador", float) = 0.0
    }
    SubShader
    {
        Tags { "RenderType" = "Opaque" }
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
                float4 origVertex : TEXTCOORD1;
            };

            sampler2D _MainTex;
            sampler2D _MainTex2;
            float Contador;
            float4 _MainTex_ST;

            v2f vert(appdata v)
            {
                v2f o;
                o.origVertex = v.vertex;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float null = 5;
                if (_Time.y < 60) {
                    null = _Time.y;
                }
                fixed4 col1 = tex2D(_MainTex, i.uv * null);
                fixed4 col2 = tex2D(_MainTex2, i.uv);
                fixed4 col = (col1 * (abs(_SinTime.a + 1) / 2) + (col2 * (1 - (abs(_SinTime.a + 1) / 2))));
                return col;
            }
            ENDCG
        }
    }
}