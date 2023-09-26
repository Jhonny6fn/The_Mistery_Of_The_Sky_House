Shader "Unlit/UnlitDiana1"
{
    Properties
    {
        _MainTex("Texture",2D) = "White"{}
    }
    SubShader
    {
        Tags {"RenderType" = "Opaque"}
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
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
            };
        
            sampler2D _MainTex;
            
            v2f vert(appdata textu)
            {
                v2f o;
                textu.vertex.xz *= (sin(3.0 * _Time.y) / 2) + 1;
                textu.vertex.xz *= 3.0;
                o.uv = textu.uv;
                o.vertex = UnityObjectToClipPos(textu.vertex);
                return o;
            }
        
            fixed4 frag(v2f i) : SV_Target
            {
                return tex2D(_MainTex,i.uv);
            }
            ENDCG
        }
    }
}