Shader "Unlit/UnlitSuperponer"
{
    Properties
    {
        _PlayerPosition ("Proyectil position", vector) = (0.0, 0.0, 0.0, 0.0)
        _Distance ("Distance", float) = 5.0
        _MainTex ("Main texture", 2D) = "white" {}
        _MainTexB ("Texture B", 2D) = "white" {}
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

            struct v2f
            {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
                float4 worldPos : TEXCOORD1;
            };

            v2f vert (appdata_base v)
            {
                v2f o;

                o.worldPos = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.texcoord;

                return o;
            }

            float4 _ProyectilPosition;
            sampler2D _MainTex;
            sampler2D _MainTexB;
            float _Distance;

            fixed4 frag (v2f i) : SV_Target
            {
                if (distance(_ProyectilPosition.xyz, i.worldPos.xyz) > _Distance)
                    return tex2D(_MainTex, i.uv);
                else
                    return tex2D(_MainTex, i.uv) * tex2D(_MainTexB, i.uv);
            }
            ENDCG
        }
    }
}
